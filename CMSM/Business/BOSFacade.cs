using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// BOSFacade 的摘要说明。
	/// </summary>
	public class BOSFacade
	{
		public BOSFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void BOSMOD(Entity.BillOfOutStorage bos,Entity.BusiLog bl,bool isHis)
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
					os.cnvcGoodsName = bos.cnvcGoodsName;
					os.cnvcGoodsType = bos.cnvcGoodsType;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为入库 改少为出库
					Entity.BillOfOutStorage oldbos = new BillOfOutStorage(bos.GetOriginalValue());
					string strOperType = "";
					if(oldbos.cnnCount>bos.cnnCount)
						strOperType = OutType.BOSIn;
					else
						strOperType = OutType.BOSOut;

					//验收单
					//bos.cnvcInType = strOperType;
					bos.cndOperDate = dtSysTime;
					if(isHis)
					{
						Entity.BillOfOutStorageHis boshis = new BillOfOutStorageHis(bos.GetOriginalValue());
						EntityMapping.Delete(boshis,trans);

						//boshis.SynchronizeModifyValue(bos);
						EntityMapping.Create(bos,trans);
					}
					else
					{
						EntityMapping.Update(bos,trans);
					}
					if(bos.cnnCount != oldbos.cnnCount)
					{
						//库存日志
						Entity.OilStorageLog ol = new OilStorageLog(bos.ToTable());
						ol.cnvcDeptName = bl.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = os.cnnStorageCount;
						ol.cnnInOutCount = oldbos.cnnCount-bos.cnnCount;//bos.cnnCount-oldbos.cnnCount;
						ol.cnnCurCount = os.cnnStorageCount + oldbos.cnnCount-bos.cnnCount ;
						EntityMapping.Create(ol,trans);

						//库存
						os.cnnStorageCount = ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "出库单修改，出入库量："+(oldbos.cnnCount-bos.cnnCount);//(bos.cnnCount-oldbos.cnnCount);
					bl.cnvcOperType = OperType.OP202;
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
