using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// BOMFacade 的摘要说明。
	/// </summary>
	public class BOMFacade
	{
		public BOMFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void BOMMOD(Entity.BillOfMaterials bom,Entity.BusiLog bl,bool isHis)
		{
			ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Entity.OilStorage os = new OilStorage(bl.ToTable());
					os.cnvcGoodsName = bom.cnvcGoodsName;
					os.cnvcGoodsType = bom.cnvcGoodsType;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为入库 改少为出库
					//专供油出库
					Entity.BillOfMaterials oldbom = new BillOfMaterials(bom.GetOriginalValue());
					string strOperType = "";
					if(oldbom.cnnCount>bom.cnnCount)
						strOperType = InType.BOMModIn;
					else
						strOperType = InType.BOMModOut;

					//验收单
					//bom.cnvcInType = strOperType;
					bom.cndOperDate = dtSysTime;
					if(isHis)
					{
						Entity.BillOfMaterialsHis bomhis = new BillOfMaterialsHis(bom.GetOriginalValue());
						EntityMapping.Delete(bomhis,trans);

						//bomhis.SynchronizeModifyValue(bom);
						EntityMapping.Create(bom,trans);
					}
					else
					{
						EntityMapping.Update(bom,trans);
					}
					if(bom.cnnCount != oldbom.cnnCount)
					{
						//库存日志
						Entity.OilStorageLog ol = new OilStorageLog(bom.ToTable());
						ol.cnvcDeptName = bl.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = os.cnnStorageCount;
						ol.cnnInOutCount = oldbom.cnnCount-bom.cnnCount;//bom.cnnCount-oldbom.cnnCount;
						ol.cnnCurCount = os.cnnStorageCount + oldbom.cnnCount - bom.cnnCount;
						EntityMapping.Create(ol,trans);

						//库存
						os.cnnStorageCount = ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "领料单修改，出入库量："+(oldbom.cnnCount-bom.cnnCount);
					bl.cnvcOperType = OperType.OP203;
					bl.cndOperDate = dtSysTime;
					bl.cnvcSource = InSource.cs;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
	}
}
