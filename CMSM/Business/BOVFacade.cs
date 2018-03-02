using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// BOVFacade 的摘要说明。
	/// </summary>
	public class BOVFacade
	{
		public BOVFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void BOVMOD(Entity.BillOfValidate bov,Entity.BusiLog bl,bool isHis)
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
					os.cnvcGoodsName = bov.cnvcGoodsName;
					os.cnvcGoodsType = bov.cnvcGoodsType;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为入库 改少为出库
					Entity.BillOfValidate oldbov = new BillOfValidate(bov.GetOriginalValue());
					string strOperType = "";
					if(oldbov.cnnValidateCount>bov.cnnValidateCount)
						strOperType = InType.BOVModOut;
					else
						strOperType = InType.BOVModIn;

					//验收单
					//bov.cnvcInType = strOperType;
					bov.cndOperDate = dtSysTime;
					if(isHis)
					{
						Entity.BillOfValidateHis bovhis = new BillOfValidateHis(bov.GetOriginalValue());
						EntityMapping.Delete(bovhis,trans);

						//bovhis.SynchronizeModifyValue(bov);
						EntityMapping.Create(bov,trans);
					}
					else
					{
						EntityMapping.Update(bov,trans);
					}
					if(bov.cnnValidateCount != oldbov.cnnValidateCount)
					{
						//库存日志
						Entity.OilStorageLog ol = new OilStorageLog(bov.ToTable());
						ol.cnvcDeptName = bl.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = os.cnnStorageCount;
						ol.cnnInOutCount = bov.cnnValidateCount-oldbov.cnnValidateCount;
						ol.cnnCurCount = os.cnnStorageCount + bov.cnnValidateCount - oldbov.cnnValidateCount;
						EntityMapping.Create(ol,trans);

						//库存
						os.cnnStorageCount = ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "验收单修改，出入库量："+(bov.cnnValidateCount-oldbov.cnnValidateCount);
					bl.cnvcOperType = OperType.OP201;
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
