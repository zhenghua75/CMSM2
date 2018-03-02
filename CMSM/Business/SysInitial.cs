using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;
using System.Reflection;
namespace CMSM.Business
{
	/// <summary>
	/// SysInitial 的摘要说明。
	/// </summary>
	public class SysInitial
	{
		public SysInitial()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 启动系统时，下载更新系统参数
		/// <summary>
		/// 仅下载
		/// </summary>
		/// <returns></returns>
		public int SystemStartParaDownLoad()
		{
			int icount = 0;
			try
			{				
				DataSet ds = new DataSet();
				ConnectionPool.IsCenter = true;
				using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
				{
					//conn.Open();	
				
					//SqlTransaction trans = conn.BeginTransaction();
					try
					{

						foreach(string strtable in ConstApp.SystemParaTables.Split(':'))
						{
							string[] strtables = strtable.Split(',');
							string strsql = "select * from "+strtables[0] + " where 1=1";
							if(strtables[3] != "")
								strsql += " and "+strtables[3];
							DataTable dt = //SingleTableQuery.ExcuteQuery(strtables[0],conn);
								SqlHelper.ExecuteDataTable(conn,CommandType.Text,strsql);
							dt.TableName = strtables[0];
							if(strtables.Length>1 && strtables[1] != "")
							{
								if(!(dt.Rows.Count>Convert.ToInt32(strtables[1])))
								{
									throw new BusinessException(bexType.centerNoPara,"中心表："+strtables[0]+"参数不全！");
								}
							}
							ds.Tables.Add(dt);
						}

					}
					catch(BusinessException bex)
					{
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
						foreach(string strtable in ConstApp.SystemParaTables.Split(':'))
						{
							string[] strtables = strtable.Split(',');
							if(strtables[0].ToUpper() == "TBDEPT")
							{
								string strupdatesql = "select * from tbdept where cnvcLocalFlag='LOCAL'";
								DataTable dtLocal = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strupdatesql);
								Entity.Dept deptLocal = new Dept(dtLocal);
								DataTable dtCenter = ds.Tables[strtables[0]];
								DataRow[] drCenters = dtCenter.Select("cnvcdeptid='"+deptLocal.cnvcDeptID+"'");
								if(drCenters.Length>0)
									drCenters[0]["cnvcLocalFlag"] = deptLocal.cnvcLocalFlag;
							}
							//清理表
							int idelcount = SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"truncate table "+strtables[0]);							
							//插入记录
							DataTable dt = ds.Tables[strtables[0]];														
							foreach(DataRow dr in dt.Rows)
							{						
								Type t = Type.GetType(strtables[2]);			
								EntityBase.EntityObjectBase eo = Activator.CreateInstance(t,new object[]{dr}) as EntityBase.EntityObjectBase;
								EntityMapping.Create(eo,trans);
								icount +=1;
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
			catch(BusinessException bex)
			{
				throw bex;
			}
			catch(SqlException sex)
			{
				throw sex;
			}
			catch(Exception ex)
			{
				throw ex;
			}			
			return icount;
		}
		#endregion
	}
}
