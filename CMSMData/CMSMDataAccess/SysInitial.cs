using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using cc;
using System.Xml;
using System.Collections;
namespace CMSMData.CMSMDataAccess
{
	/// <summary>
	/// SysInitial 的摘要说明。
	/// </summary>
	public class SysInitial
	{
		static public SqlConnection con=new SqlConnection();
		static public SqlConnection conCenter=new SqlConnection();
		static public string strDesFlag=System.Configuration.ConfigurationSettings.AppSettings["DFLAG"].ToString();
		static public string ConString=System.Configuration.ConfigurationSettings.AppSettings["DBAMSCM"].ToString();
		static public string CenterConString=System.Configuration.ConfigurationSettings.AppSettings["DBAMSCMCenter"].ToString();
		static public int RefreshTime=int.Parse(System.Configuration.ConfigurationSettings.AppSettings["RefreshTime"].ToString());
		static public DataSet dsSys=new DataSet();
		static public Hashtable htSpecOilDept;
		static public CMSMData.CMSMStruct.OperStruct NewOps=new CMSMData.CMSMStruct.OperStruct();
		static public CMSMData.CMSMStruct.OperStruct CurOps=new CMSMData.CMSMStruct.OperStruct();
		static public string LocalDeptID="";
		static public string LocalDeptName="";
		static public string LocalDeptIDTmp="";
		static public string LocalDeptNameTmp="";
		static public bool ReLoginFlag=false;
		static public string strTmp="";
		static public Int16 intCom=0;
		static public SqlDataAdapter daTmp;
		static public SqlDataAdapter daTmp1;

		public SysInitial()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 连接串加密解密
		static public void desConstring(string strpath)
		{
			string strdes="";
			if(strDesFlag=="0")
			{		
				XmlDocument doc=new XmlDocument();
				doc.Load(strpath+@"\CMSM.exe.config");
				XmlNode keyNode=null;

				DESEncryptor dese=new DESEncryptor();
				dese.InputString=ConString;
				dese.EncryptKey="cmsmyykx";
				dese.DesEncrypt();
				strdes=dese.OutString;
				dese=null;

				keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='DBAMSCM']");
				keyNode.Attributes["value"].Value=strdes;

				dese=new DESEncryptor();
				dese.InputString=CenterConString;
				dese.EncryptKey="cmsmyykx";
				dese.DesEncrypt();
				strdes=dese.OutString;
				dese=null;

				keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='DBAMSCMCenter']");
				keyNode.Attributes["value"].Value=strdes;

				keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='DFLAG']");
				keyNode.Attributes["value"].Value="1";
				doc.Save(strpath+@"\CMSM.exe.config");
			}
			else
			{
				DESEncryptor dese=new DESEncryptor();
				dese.InputString=ConString;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;

				ConString=strdes;

				dese=new DESEncryptor();
				dese.InputString=CenterConString;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;

				CenterConString=strdes;
			}
		}
		#endregion

		#region 加载系统参数
		static public void CreatDS(out Exception e)
		{
			try
			{
				e=null;
				string FileName="comset.bet";
				string filePath=Environment.CurrentDirectory;
				if(!System.IO.File.Exists(filePath+@"\"+FileName))
				{
					intCom=0;
				}
				else
				{
					StreamReader fReader = new StreamReader(filePath+@"\"+FileName);
					string strline="";
					if((strline=fReader.ReadLine())==null)
					{
						intCom=0;
					}
					else
					{
						intCom=Int16.Parse(strline.Substring(8,strline.Length-8));
					}
				}
				CommAccess ca=new CommAccess(ConString);
				Exception er=null;
				LocalDeptName=ca.GetLocalDept(out LocalDeptName,out er);
				if(er!=null)
				{
					e=er;
					return;
				}
				CommAccess ca1=new CommAccess(ConString);
				LocalDeptID=ca1.GetLocalDept1(out LocalDeptID,out er);
				if(er!=null)
				{
					e=er;
					return;
				}
				if (LocalDeptID=="")
				{
					LocalDeptIDTmp="";
					LocalDeptNameTmp="";
				}
				else
				{
					LocalDeptIDTmp=LocalDeptID.Substring(0,4);
					LocalDeptNameTmp=LocalDeptName.Substring(0,2);
				}

				con.ConnectionString=ConString;
				dsSys.Tables.Clear();
				string sql;

				int recount=0;
				sql="select cnvcDeptID as cnvcCommCode,cnvcDeptName as cnvcCommName from tbDept where (cnvcLocalFlag is null or cnvcLocalFlag<>'LOCAL') and cnvcDeptID like '"+ LocalDeptIDTmp +"%'";
				daTmp=new SqlDataAdapter(sql,con);
				recount=daTmp.Fill(dsSys,"Dept");

				recount=0;
				sql="select cnvcDeptID as cnvcCommCode,cnvcDeptName as cnvcCommName from tbDept where cnvcLocalFlag is null or cnvcLocalFlag<>'LOCAL' ";
				daTmp1=new SqlDataAdapter(sql,con);
				recount=daTmp1.Fill(dsSys,"DeptTmp");

				recount=0;
				sql="select cnvcDeptID as cnvcCommCode,cnvcDeptName as cnvcCommName from tbDept where cnvcDeptID like '"+ LocalDeptID +"%'";
				daTmp=new SqlDataAdapter(sql,con);
				recount=daTmp.Fill(dsSys,"AllDept");
				if(recount==0)
				{
					e=new Exception("参数不全");
					return;
				}

				recount=0;
				sql="select * from tbOper where cnbValidate=1 and cnvcDeptID=(select top 1 cnvcDeptID from tbDept where cnvcLocalFlag='LOCAL')";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"Oper");

				sql="select * from tbCommCode where cnvcCommSign='MemState'";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"MemState");

				sql="select * from tbCommCode where cnvcCommSign='OPType'";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"OPType");

                sql="select distinct a.cnvcCommName as cnvcGoodsName,b.cnvcCommName as cnvcGoodsType from tbCommCode a,tbCommCode b where a.cnvcCommSign='GoodsName' and b.cnvcCommSign like 'GoodsType%' and b.cnvcCommSign='GoodsType'+a.cnvcCommCode";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"Goods");

				sql="select cnvcCompanyID,cnvcCompanyName,cnvcDeptID,cnvcDeptName from tbMebCompanyPrepay where cnbValidate=1 and cnvcDeptname like '"+ LocalDeptNameTmp +"%' ";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"MebComp");

				sql="select cnvcDeliveryCompany from tbSpecialOilDept  where cnvcDeliveryComPany like '"+ LocalDeptNameTmp + "%' order by cnvcDeliveryCompany";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"SpecDelivery");
				
				sql="select * from tbCommCode where cnvcCommSign='TRANLOSE'";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"TRANLOSE");

				sql="select * from tbCommCode where cnvcCommSign='OFFSET'";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dsSys,"OFFSET");

				htSpecOilDept=null;
				htSpecOilDept=new Hashtable();
				DataTable dttmp=new DataTable();
				sql="select cnvcContractNo,cnvcDeliveryCompany from tbSpecialOilDept where cnvcDeliveryComPany like '"+ LocalDeptNameTmp + "%' order by cnvcDeliveryCompany";
				daTmp=new SqlDataAdapter(sql,con);
				daTmp.Fill(dttmp);
				if(dttmp.Rows.Count>0)
				{
					string strDeliName="";
					ArrayList alContractList=null;
					for(int i=0;i<dttmp.Rows.Count;i++)
					{
						if(strDeliName==dttmp.Rows[i]["cnvcDeliveryCompany"].ToString())
						{
							alContractList.Add(dttmp.Rows[i]["cnvcContractNo"].ToString());
							if(i==dttmp.Rows.Count-1)
							{
								htSpecOilDept.Add(strDeliName,alContractList);
							}
						}
						else
						{
							if(strDeliName!=""&&alContractList.Count>0)
							{
								htSpecOilDept.Add(strDeliName,alContractList);
							}

							alContractList=new ArrayList();
							alContractList.Add(dttmp.Rows[i]["cnvcContractNo"].ToString());
							strDeliName=dttmp.Rows[i]["cnvcDeliveryCompany"].ToString();
							if(i==dttmp.Rows.Count-1)
							{
								htSpecOilDept.Add(strDeliName,alContractList);
							}
						}
					}
				}

				
			}
			catch(Exception err)
			{
				e=err;
			}
		}
		#endregion

		#region 启动系统时，下载更新系统参数
		static public Hashtable SystemStartParaDownLoad(out Exception e)
		{
			Hashtable htout=new Hashtable();
			bool noconnectflag=true;//未连接
			bool centerNoPara=true;//中心参数不全
			bool nodownFlag=true;//下载失败
			DataSet dstmp=new DataSet();			

			try
			{
				e=null;

				conCenter.ConnectionString=CenterConString;
				string sql;

				conCenter.Open();
				sql="select * from tbCommCode";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenCommCode");

				sql="select * from tbDept";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenDept");

				sql="select * from tbFunc";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenFunc");

				sql="select * from tbOper";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenOper");

				sql="select * from tbOperFunc";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenOperFunc");

				sql="select * from tbRegister";
				daTmp=new SqlDataAdapter(sql,conCenter);
				daTmp.Fill(dstmp,"CenRegister");

				conCenter.Close();
				noconnectflag=false;

				if(noconnectflag==false)
				{
					if(dstmp.Tables["CenCommCode"].Rows.Count>=24&&dstmp.Tables["CenDept"].Rows.Count>=1&&dstmp.Tables["CenOper"].Rows.Count>0)
					{
						centerNoPara=false;
					}
					else
					{
						centerNoPara=true;
						htout.Add("IsNoConnect",noconnectflag);
						htout.Add("IsNoPara",centerNoPara);
						htout.Add("IsNoDown",nodownFlag);
						return htout;
					}
				}
			}
			catch(Exception err)
			{
				if(conCenter.State==ConnectionState.Open)
				{
					conCenter.Close();
				}
				e=err;
				htout.Clear();
				htout.Add("IsNoConnect",noconnectflag);
				htout.Add("IsNoPara",centerNoPara);
				htout.Add("IsNoDown",nodownFlag);
				return htout;
			}

			con.ConnectionString=ConString;
			SqlDataReader drr;
			SqlCommand cmd;
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					string strsql="";
					int i=0;

					#region 更新tbCommCode
					strsql="truncate table tbCommCode";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenCommCode"].Rows.Count;i++)
					{
						strsql+="insert into tbCommCode values('"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommName"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommCode"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommSign"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcComments"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,con,trans);
						cmd.ExecuteNonQuery();
					}
					#endregion

					#region 更新tbDept
					strsql="";
					strsql="delete from tbDept where cnvcLocalFlag<>'LOCAL' or cnvcLocalFlag is null";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					CMSMStruct.DeptStruct depts=new CMSMData.CMSMStruct.DeptStruct();
					strsql="select * from tbDept where cnvcLocalFlag='LOCAL'";
					cmd=new SqlCommand(strsql,con,trans);
					drr=cmd.ExecuteReader();
					if(drr.HasRows)
					{
						drr.Read();
						depts.strDeptID=drr[0].ToString();
						depts.strDeptName=drr[1].ToString();
						depts.strParentDeptID=drr[2].ToString();
						depts.strLocalFlag=drr[3].ToString();
						LocalDeptID=depts.strDeptID;
						LocalDeptName=depts.strDeptName;
						drr.Close();

						strsql="";
						for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
						{
							if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()!=depts.strDeptID)
							{
								strsql+="insert into tbDept values('"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcParentDeptID"].ToString()+"',null);";
							}
						}
						if(strsql!="")
						{
							cmd=new SqlCommand(strsql,con,trans);
							cmd.ExecuteNonQuery();
						}

						strsql="";
						if(depts.strDeptID!="NULL")
						{
							for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
							{
								if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()==depts.strDeptID)
								{
									if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()!=depts.strDeptName)
									{
										strsql+="update tbDept set cnvcDeptName='"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"' where cnvcLocalFlag='LOCAL' and cnvcDeptID='"+depts.strDeptID+"';";
										strsql+="update tbRegister set cnvcDeptName='"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"' where cnvcDeptName='"+depts.strDeptName+"';";
										cmd=new SqlCommand(strsql,con,trans);
										cmd.ExecuteNonQuery();
										strsql="";
										break;
									}
								}
							}
						}
					}
					else
					{
						drr.Close();
						strsql="";
						for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
						{
							strsql+="insert into tbDept values('"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcParentDeptID"].ToString()+"',null);";
						}
						if(strsql!="")
						{
							cmd=new SqlCommand(strsql,con,trans);
							cmd.ExecuteNonQuery();
						}
					}
					#endregion

					#region 更新tbFunc
					strsql="";
					strsql="truncate table tbFunc";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenFunc"].Rows.Count;i++)
					{
						strsql+="insert into tbFunc values('"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncType"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,con,trans);
						cmd.ExecuteNonQuery();
					}
					#endregion

					#region 更新tbOper
					strsql="";
					strsql="truncate table tbOper";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenOper"].Rows.Count;i++)
					{
						strsql+="insert into tbOper values("+dstmp.Tables["CenOper"].Rows[i]["cnnOperID"].ToString()+",'"+dstmp.Tables["CenOper"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenOper"].Rows[i]["cnvcPwd"].ToString()+"','"+dstmp.Tables["CenOper"].Rows[i]["cnvcDeptID"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,con,trans);
						cmd.ExecuteNonQuery();
					}
					#endregion

					#region 更新tbOperFunc
					strsql="";
					strsql="truncate table tbOperFunc";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenOperFunc"].Rows.Count;i++)
					{
						strsql+="insert into tbOperFunc values("+dstmp.Tables["CenOperFunc"].Rows[i]["cnnOperID"].ToString()+",'"+dstmp.Tables["CenOperFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CenOperFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,con,trans);
						cmd.ExecuteNonQuery();
					}
					#endregion

					#region 更新tbRegister
					strsql="";
					strsql="truncate table tbRegister";
					cmd=new SqlCommand(strsql,con,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenRegister"].Rows.Count;i++)
					{
						strsql+="insert into tbRegister values('"+dstmp.Tables["CenRegister"].Rows[i]["cnvcHddSerialNo"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcRegister"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cndOperDate"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,con,trans);
						cmd.ExecuteNonQuery();
					}
					#endregion

					trans.Commit();
					nodownFlag=false;
					htout.Clear();
					htout.Add("IsNoConnect",noconnectflag);
					htout.Add("IsNoPara",centerNoPara);
					htout.Add("IsNoDown",nodownFlag);
					return htout;
				}
				catch(Exception err)
				{
					trans.Rollback();
					e=err;
					htout.Clear();
					htout.Add("IsNoConnect",noconnectflag);
					htout.Add("IsNoPara",centerNoPara);
					htout.Add("IsNoDown",nodownFlag);
					return htout;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

	}
}
