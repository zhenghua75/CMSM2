using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// ContractFacade ��ժҪ˵����
	/// </summary>
	public class ContractFacade
	{
		public ContractFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}


		/// <summary>
		/// ר���ͺ�ͬ���
		/// </summary>
		/// <param name="so">��ͬ����</param>
		/// <param name="bl">��־</param>
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
					//��־
					bl.cnnSerial = gd;
					bl.cnvcComments = "ר���ͺ�ͬ���";
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
/// ר���ͺ�ͬ�޸�
/// </summary>
/// <param name="so">��ͬ����</param>
/// <param name="bl">��־</param>
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
					//��־
					bl.cnnSerial = gd;
					bl.cnvcComments = "ר���ͺ�ͬ�޸�";
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
