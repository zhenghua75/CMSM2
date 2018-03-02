using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// ContractFacade 的摘要说明。
	/// </summary>
	public class ContractFacade
	{
		public ContractFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 专供油合同添加
		/// </summary>
		/// <param name="so">合同对象</param>
		/// <param name="bl">日志</param>
		public void SOADD(Entity.SpecialOilDept so,Entity.BusiLog bl)
		{
			ConnectionPool.IsCenter = true;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					Guid gd = Guid.NewGuid();

					EntityMapping.Create(so,trans);
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "专供油合同添加";
					bl.cnvcOperType = OperType.OP204;
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
/// <summary>
/// 专供油合同修改
/// </summary>
/// <param name="so">合同对象</param>
/// <param name="bl">日志</param>
		public void SOMOD(Entity.SpecialOilDept so,Entity.BusiLog bl)
		{
			ConnectionPool.IsCenter = true;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					Guid gd = Guid.NewGuid();

					EntityMapping.Update(so,trans);
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "专供油合同修改";
					bl.cnvcOperType = OperType.OP205;
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



		public void SOSync(string strDeptName)
		{
			ConnectionPool.IsCenter = true;
			DataTable dtCenter = null;
			string strsql = "select * from tbSpecialOilDept where cnvcdeliverycompany like '"+strDeptName+"%'";
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				//SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					dtCenter = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strsql);
				}
				catch(BusinessException bex)
				{
					//trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					//trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					//trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}


			ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					
					DataTable dtLocal = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strsql);
					foreach(DataRow dr in dtCenter.Rows)
					{
						Entity.SpecialOilDept so = new SpecialOilDept(dr);
						DataRow[] drs = dtLocal.Select("cnvcContractNo='"+so.cnvcContractNo+"'");
						if(drs.Length>0)
						{
							Entity.SpecialOilDept oldso = new SpecialOilDept(drs[0]);
							so.SynchronizeModifyValue(oldso);
							EntityMapping.Update(so,trans);
						}
						else
						{
							EntityMapping.Create(so,trans);
						}
					}

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
