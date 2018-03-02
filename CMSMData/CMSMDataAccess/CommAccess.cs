using System;
using System.Data;
using System.Data.SqlClient;
using CardCommon.CardRef;
using CMSMData;
using System.Text;
using System.Collections;
using System.Threading;	
using System.IO;

namespace CMSMData.CMSMDataAccess
{
	/// <summary>
	/// CommAccess 的摘要说明。
	/// </summary>
	public class CommAccess
	{
		public SqlConnection con=new SqlConnection();
		SqlCommand cmd;
		SqlDataReader drr;
		private string sql1,sql2,sql3,sql4,sql5,sql6,sql7,sql8,sql9;//,sql10

		public CommAccess(string strconstring)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			con.ConnectionString=strconstring;
			//
		}

		#region Associator operation
		public DataTable GetAssociator(Hashtable htpara, out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htpara["strCardID"].ToString()!=""&&htpara["strCardID"].ToString()!="*")
				{
					strCondition=" cnvcCardID like '%" + htpara["strCardID"].ToString() + "%'";
				}
				if(htpara["strCompName"].ToString()!=""&&htpara["strCompName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" cnvcCompanyName like '%" + htpara["strCompName"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and cnvcCompanyName like '%" +  htpara["strCompName"].ToString() + "%'";
					}
				}
				if(htpara["strType"].ToString()!=""&&htpara["strType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" cnvcState= '" + htpara["strType"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and cnvcState = '" +  htpara["strType"].ToString() + "'";
					}
				}
				if(htpara["strLicenseTag"].ToString()!=""&&htpara["strLicenseTag"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" cnvcLicenseTag like '%" + htpara["strLicenseTag"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and cnvcLicenseTag like '%" +  htpara["strLicenseTag"].ToString() + "%'";
					}
				}
				if(htpara["strDeptName"].ToString()!=""&&htpara["strDeptName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" cnvcDeptName like '" + htpara["strDeptName"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and cnvcDeptName like '" +  htpara["strDeptName"].ToString() + "%'";
					}
				}

				sql1="select [cnvcCardID], [cnvcCompanyName], [cnvcLicenseTag], [cnvcGoodsName], [cnvcGoodsType], [cnvcDeptName], [cnvcState], [cnvcComments], [cndCreateDate], [cnvcOperName], [cndOperDate] from tbMember ";
				if(strCondition!="")
				{
					sql1+=" where "+strCondition +" ";
				}
				sql1+=" order by cnvcDeptName,cnvcCompanyName,cndCreateDate";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}

		public DataTable GetMemberLost(string strCardID,string strLicenseTag,string strDeptNameTmp,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(strCardID!=""&&strCardID!="*")
				{
					strCondition=" cnvcCardID like '%" + strCardID + "%'";
				}
				if(strLicenseTag!=""&&strLicenseTag!="*")
				{
					if(strCondition=="")
					{
						strCondition=" cnvcLicenseTag like '%" + strLicenseTag + "%'";
					}
					else
					{
						strCondition=strCondition + " and cnvcLicenseTag like '%" + strLicenseTag + "%'";
					}
				}
				sql1="select [cnvcCardID], [cnvcCompanyName], [cnvcLicenseTag], [cnvcGoodsName], [cnvcGoodsType], [cnvcDeptName], [cnvcState],[cnvcComments], [cndCreateDate], [cnvcOperName], [cndOperDate] from tbMember where cnvcState='1' and cnvcDeptName like '"+ strDeptNameTmp +"%'";
				if(strCondition!="")
				{
					sql1=sql1 + " and " + strCondition + " order by cnvcCardID";
				}
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}

		public string InsertMember(CMSMStruct.MemberStruct meb1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);

					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbMember values('" + meb1.strCardID + "','" +meb1.strCompanyID +"','"+ meb1.strCompanyName + "','" + meb1.strLicenseTag + "','" + meb1.strGoodsName + "','" + meb1.strGoodsType + "','"+meb1.strDeptID+"','" + meb1.strDeptName + "','" + meb1.strState + "','";
					sql2+=meb1.strComments + "','" + meb1.strCreateDate + "','" + meb1.strOperName + "','" + meb1.strOperDate + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP001','"+ SysInitial.CurOps.strOperName + "','" + meb1.strOperDate + "','发卡，卡号：" + meb1.strCardID + "','" + SysInitial.LocalDeptName + "','"+SysInitial.LocalDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='"+meb1.strCardID+"' and cnvcState='"+meb1.strState+"'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					
					strresult=cm.PutOutCard(meb1.strCardID,0,0);
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void UpdateMember(CMSMStruct.MemberStruct mebnew,CMSMStruct.MemberStruct mebold,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string sqlset="";
				try
				{
					err=null;
					if(mebnew.strCompanyName!=mebold.strCompanyName)
					{
						sqlset="cnvcCompanyName='" + mebnew.strCompanyName + "',";
					}
					if(mebnew.strLicenseTag!=mebold.strLicenseTag)
					{
						sqlset+="cnvcLicenseTag='" + mebnew.strLicenseTag + "',";
					}
					if(mebnew.strGoodsName!=mebold.strGoodsName)
					{
						sqlset+="cnvcGoodsName='" + mebnew.strGoodsName + "',";

					}
					if(mebnew.strGoodsType!=mebold.strGoodsType)
					{
						sqlset+="cnvcGoodsType='" + mebnew.strGoodsType + "',";
					}
					if(mebnew.strComments!=mebold.strComments)
					{
						sqlset+="cnvcComments='" + mebnew.strComments + "',";
					}
					if(sqlset!="")
					{
						sqlset+="cnvcOperName='"+mebnew.strOperName+"',cndOperDate='" + mebnew.strOperDate + "'";

						string strSerial=System.Guid.NewGuid().ToString();

						sql2="update tbMember set " + sqlset + " where cnvcCardID='" + mebold.strCardID + "'";
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();

						sql3="insert into tbBusiLog values('"+ strSerial + "','OP002','"+ mebnew.strOperName + "','" + mebnew.strOperDate + "','修改会员资料，卡号：" + mebold.strCardID + "','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
						cmd=new SqlCommand(sql3,con,trans);
						cmd.ExecuteNonQuery();

						sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + mebold.strCardID + "'";
						cmd=new SqlCommand(sql4,con,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public CMSMStruct.MemberStruct GetMemberDetail(string strCardID,string strDeptNameTmp,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.MemberStruct asstmp=new CMSMData.CMSMStruct.MemberStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select a.* from tbMember a where a.cnvcCardID='" + strCardID + "' and a.cnvcState='0' and a.cnvcDeptName like '"+ strDeptNameTmp +"%'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strCardID=dtAss.Rows[0]["cnvcCardID"].ToString();
					asstmp.strCompanyID=dtAss.Rows[0]["cnvcCompanyID"].ToString();
					asstmp.strCompanyName=dtAss.Rows[0]["cnvcCompanyName"].ToString();
					asstmp.strLicenseTag=dtAss.Rows[0]["cnvcLicenseTag"].ToString();
					asstmp.strGoodsName=dtAss.Rows[0]["cnvcGoodsName"].ToString();
					asstmp.strGoodsType=dtAss.Rows[0]["cnvcGoodsType"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["cnvcDeptID"].ToString();
					asstmp.strDeptName=dtAss.Rows[0]["cnvcDeptName"].ToString();
					asstmp.strState=dtAss.Rows[0]["cnvcState"].ToString();
					asstmp.strComments=dtAss.Rows[0]["cnvcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["cndCreateDate"].ToString();
					asstmp.strOperName=dtAss.Rows[0]["cnvcOperName"].ToString();
					asstmp.strOperDate=dtAss.Rows[0]["cndOperDate"].ToString();
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return asstmp;
		}

		public CMSMStruct.MemberStruct GetMemberLoseDetail(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.MemberStruct asstmp=new CMSMData.CMSMStruct.MemberStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select a.* from tbMember a where a.cnvcCardID='" + strCardID + "' and cnvcState='1'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strCardID=dtAss.Rows[0]["cnvcCardID"].ToString();
					asstmp.strCompanyID=dtAss.Rows[0]["cnvcCompanyID"].ToString();
					asstmp.strCompanyName=dtAss.Rows[0]["cnvcCompanyName"].ToString();
					asstmp.strLicenseTag=dtAss.Rows[0]["cnvcLicenseTag"].ToString();
					asstmp.strGoodsName=dtAss.Rows[0]["cnvcGoodsName"].ToString();
					asstmp.strGoodsType=dtAss.Rows[0]["cnvcGoodsType"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["cnvcDeptID"].ToString();
					asstmp.strDeptName=dtAss.Rows[0]["cnvcDeptName"].ToString();
					asstmp.strState=dtAss.Rows[0]["cnvcState"].ToString();
					asstmp.strComments=dtAss.Rows[0]["cnvcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["cndCreateDate"].ToString();
					asstmp.strOperName=dtAss.Rows[0]["cnvcOperName"].ToString();
					asstmp.strOperDate=dtAss.Rows[0]["cndOperDate"].ToString();
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return asstmp;
		}

		public bool ChkCardIDDup(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbMember where cnvcCardID='" + strCardID + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				if(int.Parse(dtAss.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public DataTable GetMebCompanyPrepay(string strCompName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				if(strCompName!=""&&strCompName!="*")
				{
					sql1="select cnvcCompanyID,cnvcCompanyName,cnvcDeptName,cnnPrepayFee,0 as MebCount from tbMebCompanyPrepay where cnvcCompanyName like '%"+strCompName+"%' and cnvcCompanyID not in(select distinct cnvcCompanyID from tbMember where cnvcState='0')";
					sql1+=" union all select a.cnvcCompanyID,a.cnvcCompanyName,a.cnvcDeptName,sum(cnnPrepayFee) as cnnPrepayFee,count(b.cnvcCardID) as MebCount from tbMebCompanyPrepay a,tbMember b where b.cnvcState='0' and a.cnvcCompanyName like '%"+strCompName+"%' and a.cnvcCompanyID=b.cnvcCompanyID group by a.cnvcCompanyID,a.cnvcCompanyName,a.cnvcDeptName order by cnvcCompanyName";

				}
				else
				{
					sql1="select cnvcCompanyID,cnvcCompanyName,cnvcDeptName,cnnPrepayFee,0 as MebCount from tbMebCompanyPrepay where cnvcCompanyID not in(select distinct cnvcCompanyID from tbMember where cnvcState='0')";
					sql1+=" union all select a.cnvcCompanyID,a.cnvcCompanyName,a.cnvcDeptName,sum(cnnPrepayFee) as cnnPrepayFee,count(b.cnvcCardID) as MebCount from tbMebCompanyPrepay a,tbMember b where b.cnvcState='0' and a.cnvcCompanyID=b.cnvcCompanyID group by a.cnvcCompanyID,a.cnvcCompanyName,a.cnvcDeptName order by cnvcCompanyName";
				}
				
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}

		public string GetMebCompanyAcctDeptID(string strCompID,out string strDeptID,out Exception err)
		{
			string strAcctID="";
			strDeptID="";
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select cnvcAcctID,cnvcDeptID from tbMebCompanyPrepay where cnvcCompanyID='"+strCompID+"'";				
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				strAcctID=drr[0].ToString();
				strDeptID=drr[1].ToString();
				drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return strAcctID;
			}
			finally
			{
				con.Close();
			}
			return strAcctID;
		}

		public CMSMStruct.CompDeptStruct GetMebCompDetial(string strCompID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			CMSMStruct.CompDeptStruct comptmp=new CMSMData.CMSMStruct.CompDeptStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbMebCompanyPrepay where cnvcCompanyID='"+strCompID+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
				if(dttmp!=null&&dttmp.Rows.Count>0)
				{
					comptmp.strCompanyID=dttmp.Rows[0]["cnvcCompanyID"].ToString();
					comptmp.strCompanyName=dttmp.Rows[0]["cnvcCompanyName"].ToString();
					comptmp.strAcctID=dttmp.Rows[0]["cnvcAcctID"].ToString();
					comptmp.strDeptID=dttmp.Rows[0]["cnvcDeptID"].ToString();
					comptmp.strDeptName=dttmp.Rows[0]["cnvcDeptName"].ToString();
					comptmp.strPrepayBalance=dttmp.Rows[0]["cnnPrepayFee"].ToString();
				}
				else
				{
					comptmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return comptmp;
		}

		public bool IsDupMebCompany(string strCompName,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbMebCompanyPrepay where cnvcCompanyName = '"+strCompName+"'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				string reccount=drr[0].ToString();
				drr.Close();
				if(reccount=="0")
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return true;
			}
			finally
			{
				con.Close();
			}
		}

		public bool IsDupMebCompanyExist2(string strCompName,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbMebCompanyPrepay where cnvcCompanyName = '"+strCompName+"'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				int reccount=int.Parse(drr[0].ToString());
				drr.Close();
				if(reccount<=1)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return true;
			}
			finally
			{
				con.Close();
			}
		}

		public bool InsertMebCompay(string strCompName,string strDeptName,string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();
					string strCompID=System.Guid.NewGuid().ToString();
					string strAcctID=System.Guid.NewGuid().ToString();

					sql2="insert into tbMebCompanyPrepay values('"+strCompID+"','"+strCompName+"','"+strAcctID+"',0,'"+strDeptName+"','"+strDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP015','"+ SysInitial.CurOps.strOperName + "',getdate(),'','" + SysInitial.LocalDeptName + "','"+SysInitial.LocalDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool MebCompayFillFee(CMSMStruct.FillFeeStruct fill1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					sql1="update tbMebCompanyPrepay set cnnPrepayFee=cnnPrepayFee+"+fill1.strFillFee+" where cnvcCompanyID='"+fill1.strCompanyID+"'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbFillFee values('"+strSerial+"','"+fill1.strCompanyID+"','"+fill1.strCompanyName+"','"+fill1.strAcctID+"',"+fill1.strFillFee+",'"+fill1.strOperName+"','"+fill1.strOperDate+"','"+fill1.strDeptID+"','"+fill1.strDeptName+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP016','"+ SysInitial.CurOps.strOperName + "',getdate(),'','" + SysInitial.LocalDeptName + "','"+SysInitial.LocalDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Fill Fee
		public string FillFee(CMSMStruct.FillFeeStruct ffs,double dChargeCurBak,out Exception err)
		{
//			this.MaskSqlToNull();
//			con.Open();
//			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
				string strresult="";
//				try
//				{
//					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
//
//					string strSerial=System.Guid.NewGuid().ToString();
//
//					sql2="insert into tbFillFee values('" +strSerial+"'," + ffs.strMemberID + ",'" + ffs.strCardID + "'," + (Math.Round(ffs.dFillFee,2)).ToString() + "," +(Math.Round(ffs.dLastFee,2)).ToString() + "," + (Math.Round(ffs.dCurFee,2)).ToString() +",'" + ffs.strOperName + "','" + ffs.strOperDate + "','"+ffs.strDeptID+"','"+ffs.strDeptName+"')";
//					cmd=new SqlCommand(sql2,con,trans);
//					cmd.ExecuteNonQuery();
//
//					sql3="insert into tbBusiLog values('"+ strSerial + "','OP003','"+ ffs.strOperName + "','" + ffs.strOperDate + "','会员充值，卡号：" + ffs.strCardID + "','" +SysInitial.LocalDeptName+"','"+ SysInitial.LocalDeptID + "','客户端')";
//					cmd=new SqlCommand(sql3,con,trans);
//					cmd.ExecuteNonQuery();
//
//					sql4="update tbMebCharge set cnnCharge=" + (Math.Round(ffs.dCurFee,2)).ToString() + " where cnvcCardID='" + ffs.strCardID + "' and cnnMemberID=" + ffs.strMemberID;
//					cmd=new SqlCommand(sql4,con,trans);
//					cmd.ExecuteNonQuery();
//
//					sql5="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + ffs.strCardID + "' and cnnMemberID=" + ffs.strMemberID;
//					cmd=new SqlCommand(sql5,con,trans);
//					cmd.ExecuteNonQuery();
//
//					sql6="select count(*) from tbFillFee where cnnSerial='"+strSerial+"' and cnnCurFee=" + (Math.Round(dChargeCurBak,2)).ToString() +" and cnvcDeptID='"+ffs.strDeptID+"'";
//					cmd=new SqlCommand(sql6,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					if(drr[0].ToString()!="1")
//					{
//						strresult="充值写入库的值不对！";
//						drr.Close();
//					}
//					else
//					{
//						drr.Close();
//						strresult=cm.FillWriteCard(ffs.dCurFee,dChargeCurBak);
////						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
//					}
//
//					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
//					{
//						if(strresult.Substring(0,3)!="CMT")
//						{
//							trans.Rollback();
//						}
//						else
//						{
//							trans.Commit();
//						}
//					}
//					else
//					{
//						trans.Commit();
//					}
//					
					return strresult;					
//				}
//				catch(Exception e)
//				{
//					trans.Rollback();
//					err=e;
//					return strresult;
//				}
//				finally
//				{
//					con.Close();
//				}
//			}
		}
		#endregion

		#region Card Lost
		public void CardLose(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
					sql2="update tbMember set cnvcState='1',cndOperDate='" + strOperDate + "',cnvcOperName='" + SysInitial.CurOps.strOperName + "' where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP004','"+ SysInitial.CurOps.strOperName + "','" + strOperDate + "','会员挂失，卡号：" + strCardID + "','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void CardUnlose(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
					sql2="update tbMember set cnvcState='0',cndOperDate='" + strOperDate + "',cnvcOperName='" + SysInitial.CurOps.strOperName + "' where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP005','"+ SysInitial.CurOps.strOperName + "','" + strOperDate + "','会员解挂，卡号：" + strCardID + "','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Card put again
		public string CardAgain(string strNewCardID,CMSMStruct.MemberStruct mebold,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					sql1="insert into tbMember values('" + strNewCardID + "','" +mebold.strCompanyID+"','"+ mebold.strCompanyName + "','" + mebold.strLicenseTag + "','" + mebold.strGoodsName + "','" + mebold.strGoodsType + "','"+mebold.strDeptID+"','" + mebold.strDeptName + "','0','";
					sql1+=mebold.strComments + "','" + mebold.strCreateDate + "','" + mebold.strOperName + "','" + mebold.strOperDate + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="update tbMember set cnvcState='2',cndOperDate='" + strOperDate + "',cnvcOperName='" + SysInitial.CurOps.strOperName + "' where cnvcCardID='" + mebold.strCardID + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP006','"+ SysInitial.CurOps.strOperName + "','" + strOperDate + "','补卡，原卡号：" + mebold.strCardID + "，新卡号："+strNewCardID+"','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql8="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + mebold.strCardID + "'";
					cmd=new SqlCommand(sql8,con,trans);
					cmd.ExecuteNonQuery();

					string strSerialnew=System.Guid.NewGuid().ToString();

					sql9="insert into tbMemberLog select '"+strSerialnew+"',* from tbMember where cnvcCardID='" + strNewCardID + "'";
					cmd=new SqlCommand(sql9,con,trans);
					cmd.ExecuteNonQuery();

					CardM1 cm=new CardM1(SysInitial.intCom);
					strresult=cm.PutOutCard(strNewCardID,0,0);
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Card Exit
		public void CardLoseToExit(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
					sql2="update tbMember set cnvcState='3',cndOperDate='" + strOperDate + "',cnvcOperName='" + SysInitial.CurOps.strOperName + "' where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP007','"+ SysInitial.CurOps.strOperName + "','" + strOperDate + "','会员退卡，卡号：" + strCardID + "','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void CardExit(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strSerial=System.Guid.NewGuid().ToString();

					string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
					sql2="update tbMember set cnvcState='3',cndOperDate='" + strOperDate + "',cnvcOperName='" + SysInitial.CurOps.strOperName + "' where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP008','"+ SysInitial.CurOps.strOperName + "','" + strOperDate + "','会员退卡，卡号：" + strCardID + "','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + strCardID + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					CardM1 m1=new CardM1(SysInitial.intCom);
					m1.RecycleCard();

				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Read Card
		public CMSMStruct.CardHardStruct ReadCardInfo(out string strResult)
		{
			strResult="";
			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
			CardM1 cm=new CardM1(SysInitial.intCom);
#if DEBUG
			strResult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
			chs.strCardID="00810";
			chs.dCurCharge=10000;
			chs.iCurIg=10000;
#else
			strResult=cm.ReadCard(out chs.strCardID,out chs.dCurCharge,out chs.iCurIg);
#endif

			return chs;
		}
		
		#endregion

		#region Consumption
		public bool AssCons(CMSMData.CMSMStruct.ConsItemStruct cis,out Exception err,out string strSerial)
		{
			this.MaskSqlToNull();
			strSerial="";
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					strSerial=System.Guid.NewGuid().ToString();

					sql2+="insert into tbConsItem values('" + strSerial + "','" + cis.strCardID + "','" + cis.strLicenseTags + "','" + cis.strGoodsName + "','" + cis.strGoodsType + "','" + cis.strUnit + "',"+cis.dDensity.ToString()+","+cis.dKGCount.ToString()+","+cis.dCount.ToString() +",";
					sql2+=cis.dPrice.ToString() + "," + cis.dFee.ToString() + ",'"+cis.strComments+"','"+ cis.strConsType +"','" + cis.strConsDate + "','"+cis.strCompanyID+"','"+cis.strCompanyName+"','"+cis.strAcctID+"','"+cis.strDeptID+"','"+cis.strDeptName+"','" + cis.strOperName + "','"+ cis.strOperDate + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP009','"+ cis.strOperName + "','" + cis.strOperDate + "','会员消费，卡号：" + cis.strCardID + "','" + cis.strDeptName + "','"+cis.strDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbMebCompanyPrepay set cnnPrepayFee=cnnPrepayFee-" + (Math.Round(cis.dFee,2)).ToString() + " where cnvcCompanyID='" + cis.strCompanyID+"'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + cis.strCardID + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql7="insert into tbOilStorageLog values('"+strSerial+"','"+cis.strDeptName+"','"+cis.strGoodsName+"','"+cis.strGoodsType+"',"+(-cis.dKGCount).ToString("0.00")+","+cis.dStorageLast.ToString("0.00")+","+cis.strCurStorage+",'零售油','"+cis.strOperName+"','"+cis.strOperDate+"','"+cis.strDeptID+"')";
					cmd=new SqlCommand(sql7,con,trans);
					cmd.ExecuteNonQuery();

					sql8="update tbOilStorage set cnnStorageCount="+cis.strCurStorage+" where cnvcGoodsName='"+cis.strGoodsName+"' and cnvcGoodsType='"+cis.strGoodsType+"' and cnvcDeptID='"+cis.strDeptID+"'";
					cmd=new SqlCommand(sql8,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public DataTable GetConsRepeat(string strCardID,string strCompID,string strBegin,string strEnd,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(strCardID!=""&&strCardID!="*")
				{
					strCondition=" and cnvcCardID='" + strCardID + "'";
				}
				if(strCompID!=""&&strCompID!="*")
				{
					strCondition+=" and cnvcCompanyID='" + strCompID+"'";
				}
				sql1="select cnnSerial,cnvcCardID,cnvcLicenseTags,cnvcGoodsName,cnvcGoodsType,cnvcUnit,cnnDensity,cnnCount,cnnPrice,cnnFee,cnvcComments,cnvcCompanyName,cndConsDate from tbConsItem where cnvcDeptID='"+ SysInitial.LocalDeptID +"' and cndConsDate between '" + strBegin + "' and '" + strEnd + "' ";
				if(strCondition!="")
				{
					sql1+= strCondition;
				}
				sql1+=" order by cndConsDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}

		public CMSMStruct.AssConsParaStruct GetCurOilPrice(string strGoodsName,string strGoodsType,string strUnit,out Exception err)
		{
			this.MaskSqlToNull();
			CMSMStruct.AssConsParaStruct acp=new CMSMData.CMSMStruct.AssConsParaStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select isnull((select top 1 cnnOilPrice from tbOilPrice where cnvcGoodsName='" + strGoodsName + "' and cnvcGoodsType='"+strGoodsType+"' and cnvcUnit='"+strUnit+"' and cnvcDeptName='"+ SysInitial.LocalDeptName+"' order by cndPriceDate desc),0),";
				sql1+="isnull((select top 1 cnnDensity from tbDensity where cnvcDeptName='"+SysInitial.LocalDeptName+"' and cnvcGoodsName='" + strGoodsName + "' and cnvcGoodsType='"+strGoodsType+"' order by cndRateDate desc),0),";
				sql1+="isnull((select cnnStorageCount from tbOilStorage where cnvcDeptName='"+SysInitial.LocalDeptName+"' and cnvcGoodsName='" + strGoodsName + "' and cnvcGoodsType='"+strGoodsType+"'),0)";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				acp.strPrice=drr[0].ToString();
				acp.strDensity=drr[1].ToString();
				acp.strCurStorageCount=drr[2].ToString();
				drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return acp;
			}
			finally
			{
				con.Close();
			}
			return acp;
		}

		public CMSMStruct.AssConsParaStruct GetOilPrice(string strDeptName,out Exception err)
		{
			this.MaskSqlToNull();
			CMSMStruct.AssConsParaStruct acp=new CMSMData.CMSMStruct.AssConsParaStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select top 1 cnnOilPrice from tbOilPrice  where cnvcGoodsType='0#' and cnvcDeptName='"+ strDeptName +"' order by cndPriceDate desc";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				acp.strPrice=drr[0].ToString();
				drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return acp;
			}
			finally
			{
				con.Close();
			}
			return acp;
		}
		#endregion

		#region Recycle card
		public string RecycleCard()
		{
			string strResult="";
			CardM1 cm=new CardM1(SysInitial.intCom);
			strResult=cm.RecycleCard();
			return strResult;
		}
		#endregion

		#region Oper manage
		public DataTable GetFuncOper(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select a.cnvcFuncName from tbOperFunc a,tbFunc b where b.cnvcFuncType='CS' and a.cnvcFuncName=b.cnvcFuncName and cnnOperID="+SysInitial.CurOps.strOperID;
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtOper;
		}
		#endregion

		#region Integral Common Code
		public void UpdateIgComm(CMSMData.CMSMStruct.CommStruct cos,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="select count(*) from tbCommCode where vcCommSign='IG'";
					cmd=new SqlCommand(sql1,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strCount=drr[0].ToString();
					drr.Close();

					if(strCount=="0")
					{
						sql2="insert into tbCommCode values('" + cos.strCommName + "','" + cos.strCommCode + "','" + cos.strCommSign + "','" + cos.strComments + "')";
					}
					else
					{
						sql2="update tbCommCode set vcCommName='" + cos.strCommName + "',vcCommCode='" + cos.strCommCode + "' where vcCommSign='IG'";
					}
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();

				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region DeptManage
		public string GetLocalDept(out string strDeptName,out Exception err)
		{
			this.MaskSqlToNull();
		    strDeptName="";
			string strDeptID="";
			err=null;
			try
			{
				con.Open();
				sql1="select count(*) from tbDept where cnvcLocalFlag='LOCAL'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				strDeptName=drr[0].ToString();
				drr.Close();
				if(strDeptName=="0")
				{
					strDeptName="";
					strDeptID="";
				}
				else
				{
					sql1="select cnvcDeptID,cnvcDeptName from tbDept where cnvcLocalFlag='LOCAL'";
					cmd=new SqlCommand(sql1,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					strDeptID=drr[0].ToString();
					strDeptName=drr[1].ToString();
					drr.Close();
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return strDeptName;
		}
		public string GetLocalDept1(out string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			string strDeptName="";
			strDeptID="";
			err=null;
			try
			{
				con.Open();
				sql1="select count(*) from tbDept where cnvcLocalFlag='LOCAL'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				strDeptName=drr[0].ToString();
				drr.Close();
				if(strDeptName=="0")
				{
					strDeptName="";
					strDeptID="";
				}
				else
				{
					sql1="select cnvcDeptID,cnvcDeptName from tbDept where cnvcLocalFlag='LOCAL'";
					cmd=new SqlCommand(sql1,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					strDeptID=drr[0].ToString();
					strDeptName=drr[1].ToString();
					drr.Close();
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return strDeptID;
		}

		public void SetLocalDept(string strDeptName,string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="update tbDept set cnvcLocalFlag='LOCAL' where cnvcDeptName='"+strDeptName+"' and cnvcDeptID='"+strDeptID+"'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region DataToHis
		public DataTable GetCurrentMonth(out Exception err)
		{
			this.MaskSqlToNull();
			err=null;
			DataTable dtmonth=new DataTable();
			try
			{
				sql1="select distinct convert(char(6),dtOperDate,112) as curmonth from tbBusiLog where convert(char(6),dtOperDate,112)<convert(char(6),dateadd(Month,-1,getdate()),112) order by convert(char(6),dtOperDate,112)";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtmonth);
				return dtmonth;
			}
			catch (Exception e) 
			{
				err=e;
				return dtmonth;
			}
			finally
			{
				con.Close();
			}
		}

		public bool AllDataToHis(string strmonth,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="insert into tbBillHis select * from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBusiLogHis select * from tbBusiLog where convert(char(6),dtOperDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbConsItemHis select * from tbConsItem where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbFillFeeHis select * from tbFillFee where convert(char(6),dtFillDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="insert into tbIntegralLogHis select * from tbIntegralLog where convert(char(6),dtIgDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBusiLog where convert(char(6),dtOperDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbConsItem where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbFillFee where convert(char(6),dtFillDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbIntegralLog where convert(char(6),dtIgDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Bill oper
		public CMSMStruct.OilStorageStruct GetOilStorageDetail(string strGoodsName,string strGoodsType,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			CMSMStruct.OilStorageStruct oils=new CMSMData.CMSMStruct.OilStorageStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbOilStorage where cnvcGoodsName='" + strGoodsName + "' and cnvcGoodsType='"+strGoodsType+"' and cnvcDeptName='"+SysInitial.LocalDeptName+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
				if(dttmp!=null&&dttmp.Rows.Count>0)
				{
					oils.strGoodsName=dttmp.Rows[0]["cnvcGoodsName"].ToString();
					oils.strGoodsType=dttmp.Rows[0]["cnvcGoodsType"].ToString();
					oils.dStorageCount=double.Parse(dttmp.Rows[0]["cnnStorageCount"].ToString());
					oils.strDeptName=dttmp.Rows[0]["cnvcDeptName"].ToString();
					oils.strDeptID=dttmp.Rows[0]["cnvcDeptID"].ToString();
				}
				else
				{
					oils=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return oils;
		}

		public bool IsDupBillOfMaterials(string strBillNo,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select sum(a.billcount) from (select count(*) as billcount from tbBillOfMaterials where cnvcBillNo='"+strBillNo+"' union all select count(*) as billcount from tbBillOfMaterialsHis where cnvcBillNo='"+strBillNo+"') as a";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				int strcount=int.Parse(drr[0].ToString());
				drr.Close();
				if(strcount==0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return true;
			}
			finally
			{
				con.Close();
			}
		}

		public bool IsDupBillOfOutStorage(string strBillNo,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select sum(a.billcount) from (select count(*) as billcount from tbBillOfOutStorage where cnvcBillNo='"+strBillNo+"' union all select count(*) as billcount from tbBillOfOutStorageHis where cnvcBillNo='"+strBillNo+"') as a";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				int strcount=int.Parse(drr[0].ToString());
				drr.Close();
				if(strcount==0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return true;
			}
			finally
			{
				con.Close();
			}
		}

		public bool IsDupBillOfValidate(string strBillNo,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="select sum(a.billcount) from (select count(*) as billcount from tbBillOfValidate where cnvcBillNo='"+strBillNo+"' union all select count(*) as billcount from tbBillOfValidateHis where cnvcBillNo='"+strBillNo+"') as a";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				int strcount=int.Parse(drr[0].ToString());
				drr.Close();
				if(strcount==0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return true;
			}
			finally
			{
				con.Close();
			}
		}

		public bool InsertBillOfValidate(CMSMStruct.BillOfValidateStruct billofval,CMSMStruct.OilStorageLogStruct oils, out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbBillOfValidate values('"+billofval.strBillNo+"','"+billofval.strOutNo+"','"+billofval.strProvideCompany+"','"+billofval.strDeliveryCompany+"','"+billofval.strProvideDate+"','"+billofval.strGoodsName+"','"+billofval.strGoodsType+"','"+billofval.strUnit+"','"+billofval.strTransportLicenseTags+"','"+billofval.strTransportMan+"',";
					sql2+=billofval.strOriginalCount+","+billofval.strValidateCount+","+billofval.strDistance+","+billofval.strTransportLose+","+billofval.strLose+","+billofval.strQuotaLose+","+billofval.strQuterLose+",'"+billofval.strProvideAddress+"','"+billofval.strInType+"','"+billofval.strOperName+"','"+billofval.strOperDate+"','"+billofval.strDeliveryDate+"','"+billofval.strDeptID+"','"+billofval.strProvideDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP010','"+ billofval.strOperName + "','" + billofval.strOperDate + "','','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbOilStorageLog values('"+strSerial+"','"+oils.strDeptName+"','"+oils.strGoodsName+"','"+oils.strGoodsType+"',"+oils.strInOutCount+","+oils.strLastCount+","+oils.strCurCount+",'"+oils.strOperType+"','"+oils.strOperName+"','"+oils.strOperDate+"','"+SysInitial.LocalDeptID+"')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbOilStorage set cnnStorageCount="+oils.strCurCount+" where cnvcGoodsName='"+oils.strGoodsName+"' and cnvcGoodsType='"+oils.strGoodsType+"' and cnvcDeptName='"+SysInitial.LocalDeptName+"'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}


		#region 获取验收单
		public DataTable GetBillOfValidate(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select [cnvcBillNo], [cnvcOutNo], [cnvcProvideCompany], [cnvcDeliveryCompany], [cndProvideDate],[cndDeliveryDate], [cnvcGoodsName], [cnvcGoodsType], [cnvcUnit], [cnvcTransportLicenseTags], [cnvcTransportMan], [cnnOriginalCount], [cnnValidateCount], [cnnDistance], [cnnTransportLose], [cnnLose], [cnnQuotaLose], [cnnOuterLose], [cnvcProvideAddress], [cnvcInType], [cnvcOperName], [cndOperDate] from tbBillOfValidate where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndDeliveryDate,121) = '"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}
		public DataTable GetBillOfValidateHis(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select [cnvcBillNo], [cnvcOutNo], [cnvcProvideCompany], [cnvcDeliveryCompany], [cndProvideDate],[cndDeliveryDate], [cnvcGoodsName], [cnvcGoodsType], [cnvcUnit], [cnvcTransportLicenseTags], [cnvcTransportMan], [cnnOriginalCount], [cnnValidateCount], [cnnDistance], [cnnTransportLose], [cnnLose], [cnnQuotaLose], [cnnOuterLose], [cnvcProvideAddress], [cnvcInType], [cnvcOperName], [cndOperDate] from tbBillOfValidateHis where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndDeliveryDate,121) = '"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}
		#endregion
		public DataTable GetBillOfOutStorage(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbBillOfOutStorage where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndOperDate,121) ='"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}
		public DataTable GetBillOfOutStorageHis(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbBillOfOutStorageHis where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndOperDate,121) ='"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}

		public bool InsertBillOfOutStorage(CMSMStruct.BillOfOutStorageStruct billofout,CMSMStruct.OilStorageLogStruct oils, out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
//					sql1="INSERT INTO tbBusiSerialNo (cnvcFill) VALUES ('0');SELECT scope_identity()";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strSerial=drr[0].ToString();
//					drr.Close();

					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbBillOfOutStorage values('"+billofout.strBillNo+"','"+billofout.strProvideStroage+"','"+billofout.strDeliveryCompany+"','"+billofout.strMoveNo+"','"+billofout.strBillOfMaterialsNo+"','"+billofout.strTransportCompany+"','"+billofout.strTransportLiscenseTags+"','"+billofout.strOutStorageDate+"','"+billofout.strGoodsName+"','";
					sql2+=billofout.strGoodsType+"','"+billofout.strUnit+"',"+billofout.strReceivableCount+","+billofout.strCount+",'"+billofout.strComments+"','"+billofout.strStorageIncharge+"','"+billofout.strDeliveryMan+"','"+billofout.strLister+"','"+billofout.strOutType+"','"+billofout.strOperName+"','"+billofout.strOperDate+"','"+billofout.strDeptID+"','"+billofout.strDeliveryDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP011','"+ billofout.strOperName + "','" + billofout.strOperDate + "','','" +SysInitial.LocalDeptName+"','"+ SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbOilStorageLog values('"+strSerial+"','"+oils.strDeptName+"','"+oils.strGoodsName+"','"+oils.strGoodsType+"',"+oils.strInOutCount+","+oils.strLastCount+","+oils.strCurCount+",'"+oils.strOperType+"','"+oils.strOperName+"','"+oils.strOperDate+"','"+oils.strDeptID+"')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbOilStorage set cnnStorageCount="+oils.strCurCount+" where cnvcGoodsName='"+oils.strGoodsName+"' and cnvcGoodsType='"+oils.strGoodsType+"' and cnvcDeptName='"+SysInitial.LocalDeptName+"'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public DataTable GetBillOfMaterials(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select [cnvcBillNo], [cnvcContractNo], [cnvcDeliveryCompany], [cnvcProvideCompany], [cnvcGoodsName], [cnvcGoodsType], [cnvcUnit], [cnnReceiveCount], [cnnCount], [cnnSpecialUnitPrice], [cnnSpecialFee], [cnvcDeliveryMan], [cndDeliveryDate], [cndProvideBeginDate], [cndProvideEndDate], [cndProvideMan], [cnvcSignerCompany], [cnvcSigner], [cndTimeOfValidity], [cnvcOperName], [cndOperDate] from tbBillOfMaterials where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndDeliveryDate,121) ='"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}
		public DataTable GetBillOfMaterialsHis(string strBillNo,string strDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select [cnvcBillNo], [cnvcContractNo], [cnvcDeliveryCompany], [cnvcProvideCompany], [cnvcGoodsName], [cnvcGoodsType], [cnvcUnit], [cnnReceiveCount], [cnnCount], [cnnSpecialUnitPrice], [cnnSpecialFee], [cnvcDeliveryMan], [cndDeliveryDate], [cndProvideBeginDate], [cndProvideEndDate], [cndProvideMan], [cnvcSignerCompany], [cnvcSigner], [cndTimeOfValidity], [cnvcOperName], [cndOperDate] from tbBillOfMaterialsHis where cnvcBillNo like '%"+strBillNo+"%' and CONVERT(char(10),cndDeliveryDate,121) ='"+strDate+"'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}

		public bool InsertBillOfMaterials(CMSMStruct.BillOfMaterialsStruct billofmat,CMSMStruct.OilStorageLogStruct oils, out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
//					sql1="INSERT INTO tbBusiSerialNo (cnvcFill) VALUES ('0');SELECT scope_identity()";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strSerial=drr[0].ToString();
//					drr.Close();

					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbBillOfMaterials values('"+billofmat.strBillNo+"','"+billofmat.strContractNo+"','"+billofmat.strDeliveryCompany+"','"+billofmat.strProvideCompany+"','"+billofmat.strGoodsName+"','"+billofmat.strGoodsType+"','"+billofmat.strUnit+"',"+billofmat.strReceiveCount+","+billofmat.strCount+",'";
					sql2+=billofmat.strDeliveryMan+"','"+billofmat.strDeliveryDate+"','"+billofmat.strProvideBeginDate+"','"+billofmat.strProvideEndDate+"','"+billofmat.strProvideMan+"','"+billofmat.strSignerCompany+"','"+billofmat.strSigner+"','"+billofmat.strTimeOfValidity+"','"+billofmat.strOperName+"','"+billofmat.strOperDate+"',"+billofmat.strSpecialUnitPrice+","+billofmat.strSpecialFee+",'"+billofmat.strDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP012','"+ billofmat.strOperName + "','" + billofmat.strOperDate + "','','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbOilStorageLog values('"+strSerial+"','"+oils.strDeptName+"','"+oils.strGoodsName+"','"+oils.strGoodsType+"',"+oils.strInOutCount+","+oils.strLastCount+","+oils.strCurCount+",'"+oils.strOperType+"','"+oils.strOperName+"','"+oils.strOperDate+"','"+SysInitial.LocalDeptID+"')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbOilStorage set cnnStorageCount="+oils.strCurCount+" where cnvcGoodsName='"+oils.strGoodsName+"' and cnvcGoodsType='"+oils.strGoodsType+"' and cnvcDeptName='"+SysInitial.LocalDeptName+"'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public DataTable GetCurOilStorage(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbOilStorage";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}

		public bool InsertOilStorageCheck(CMSMStruct.OilStorageCheckStruct oilcheck,CMSMStruct.OilStorageLogStruct oils,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
//					sql1="INSERT INTO tbBusiSerialNo (cnvcFill) VALUES ('0');SELECT scope_identity()";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strSerial=drr[0].ToString();
//					drr.Close();

					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbOilStorageCheck values('"+strSerial+"','"+oilcheck.strGoodsName+"','"+oilcheck.strGoodsType+"',"+oilcheck.dStorageCount.ToString()+","+oilcheck.dLoseCount+","+oilcheck.dCount+",'"+oilcheck.strDeptName+"','"+oilcheck.strOperName+"','"+oilcheck.strOperDate+"','"+oilcheck.strDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP013','"+ oilcheck.strOperName + "','" + oilcheck.strOperDate + "','','"+SysInitial.LocalDeptName+"','" + SysInitial.LocalDeptID + "','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbOilStorageLog values('"+strSerial+"','"+oils.strDeptName+"','"+oils.strGoodsName+"','"+oils.strGoodsType+"',"+oils.strInOutCount+","+oils.strLastCount+","+oils.strCurCount+",'"+oils.strOperType+"','"+oils.strOperName+"','"+oils.strOperDate+"','"+oils.strDeptID+"')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="select count(*) from tbOilStorage where cnvcGoodsName='"+oils.strGoodsName+"' and cnvcGoodsType='"+oils.strGoodsType+"' and cnvcDeptName='"+oilcheck.strDeptName+"'";
					cmd=new SqlCommand(sql5,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					int IsOriStorage=int.Parse(drr[0].ToString());
					drr.Close();

					if(IsOriStorage==0)
					{
						sql6="insert into tbOilStorage values('"+oils.strGoodsName+"','"+oils.strGoodsType+"',"+oilcheck.dCount.ToString()+",'"+oilcheck.strDeptName+"','"+oilcheck.strDeptID+"')";
					}
					else
					{
						sql6="update tbOilStorage set cnnStorageCount="+oilcheck.dCount+" where cnvcGoodsName='"+oils.strGoodsName+"' and cnvcGoodsType='"+oils.strGoodsType+"' and cnvcDeptName='"+oilcheck.strDeptName+"'";
					}
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public CMSMStruct.DensityStruct GetCurDensity(string strGoodsName,string strGoodsType,string strDeptName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			CMSMStruct.DensityStruct dens=new CMSMData.CMSMStruct.DensityStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select top 1 * from tbDensity where cnvcGoodsName='" + strGoodsName + "' and cnvcGoodsType='"+strGoodsType+"' and cnvcDeptName='"+strDeptName+"' order by cndRateDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
				if(dttmp!=null&&dttmp.Rows.Count>0)
				{
					dens.strGoodsName=dttmp.Rows[0]["cnvcGoodsName"].ToString();
					dens.strGoodsType=dttmp.Rows[0]["cnvcGoodsType"].ToString();
					dens.strDeptName=dttmp.Rows[0]["cnvcDeptName"].ToString();
					dens.strRateDate=dttmp.Rows[0]["cndRateDate"].ToString();
					dens.strDensity=dttmp.Rows[0]["cnnDensity"].ToString();
				}
				else
				{
					dens=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dens;
		}

		public bool InsertDensity(CMSMStruct.DensityStruct dens,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
//					sql1="INSERT INTO tbBusiSerialNo (cnvcFill) VALUES ('0');SELECT scope_identity()";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strSerial=drr[0].ToString();
//					drr.Close();

					string strSerial=System.Guid.NewGuid().ToString();

					sql2="insert into tbDensity values('"+strSerial+"','"+dens.strDeptName+"',getdate(),"+dens.strDensity+",'"+dens.strGoodsName+"','"+dens.strGoodsType+"','"+dens.strDeptID+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP014','"+ SysInitial.CurOps.strOperName + "',getdate(),'','" + dens.strDeptName + "','"+dens.strDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();

					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Make strsql to null
		private void MaskSqlToNull()
		{
			sql1="";
			sql2="";
			sql3="";
			sql4="";
			sql5="";
			sql6="";
			sql7="";
			sql7="";
			sql8="";
			sql9="";
			//sql10="";
		}
		#endregion

		public void Tmpupdate(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				err=null;
				con.Open();
				sql1="update tbFillFee set vcComments='' where vcComments ='补充值，由于操作错误' and dtFillDate between '2008-05-01'and '2008-05-06 23:00:00'";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();

				sql1="update tbBusiLog set vcOperType='OP003',vcComments='充值' where vcOpertype='OP008' and dtOperDate between '2008-05-01'and '2008-05-06 23:00:00'";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		#region 注册
		public string Register(string strHddSerialNo,string strDeptName,string strOperName,out Exception err)
		{
			this.MaskSqlToNull();
			SqlConnection concenter=new SqlConnection(SysInitial.CenterConString);
			try
			{
				concenter.Open();
			}
			catch(Exception e1)
			{
				err=e1;
				return "connection";
			}
			using(SqlTransaction trans=concenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{				
				try
				{		
					err=null;
					sql1="insert into tbRegister(cnvcHddSerialNo,cnvcDeptName,cnvcOperName,cndOperDate) values('"+strHddSerialNo+"','"+strDeptName+"','"+strOperName+"',getdate())";
					cmd=new SqlCommand(sql1,concenter,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();	
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					concenter.Close();
				}
			}
			return "";
		}

		public string GetRegister(string strHddSerialNo,out Exception err)
		{
			this.MaskSqlToNull();
			string strRet = "";
			try
			{
				err=null;
				con.Open();
				sql1="select cnvcRegister from tbRegister where cnvcHddSerialNo='"+strHddSerialNo+"'";
				cmd=new SqlCommand(sql1,con);
				strRet = cmd.ExecuteScalar().ToString();		
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			return strRet;
		}
		#endregion


		public DataTable GetAssConsLast(string strCardID,string strDeptNameTmp, out Exception err)
		{
			this.MaskSqlToNull();
			//DataSet dsout=new DataSet();
			DataTable dtConsItem=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strbegindate = "";
				sql1 = "select top 1 cndOperDate from tbBusiLog where cnvcComments='消费撤销，卡号："+strCardID+"' order by cndOperDate desc";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				if(drr.HasRows)
				 strbegindate = drr[0].ToString();				
				drr.Close();

				if(strbegindate=="")
				{
					sql1 = "select top 1 cndOperDate from tbBusiLogHis where cnvcComments='消费撤销，卡号："+strCardID+"' order by cndOperDate desc";
					cmd=new SqlCommand(sql1,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr.HasRows)
					strbegindate = drr[0].ToString();				
					drr.Close();
				}
				if(strbegindate=="") strbegindate="2000-01-01";

				sql1="select top 1 * from tbConsItem where cnvcCardID='"+strCardID+"' and cnvcConsType='会员消费' and cndOperDate>='"+strbegindate+"' and  DATEADD(DAY,2,cndOperDate)>=getdate() order by cndOperDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtConsItem);

				if(dtConsItem.Rows.Count==0)
				{
					sql1="select top 1 * from tbConsItemHis where cnvcCardID='"+strCardID+"' and cnvcConsType='会员消费' and cndOperDate>='"+strbegindate+"' and  DATEADD(DAY,2,cndOperDate)>=getdate() order by cndOperDate desc";
					cmd=new SqlCommand(sql1,con);
					da=new SqlDataAdapter(cmd);
					dtConsItem=new DataTable();
					da.Fill(dtConsItem);
				}
				if(dtConsItem.Rows.Count==0)
				{
					err=new Exception("在最近48小时内没有可以撤销的消费记录！");
					return null;
				}
				//dtConsItem.TableName="ConsItem";
				//dsout.Tables.Add(dtConsItem);				

				
				return dtConsItem;
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
		}

		public bool AssConsRemove(CMSMData.CMSMStruct.ConsItemStruct cis,out Exception err,out string strSerial)
		{
			this.MaskSqlToNull();
			strSerial="";
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					strSerial=System.Guid.NewGuid().ToString();

					sql2+="insert into tbConsItem values('" + strSerial + "','" + cis.strCardID + "','" + cis.strLicenseTags + "','" + cis.strGoodsName + "','" + cis.strGoodsType + "','" + cis.strUnit + "',"+cis.dDensity.ToString()+",-"+cis.dKGCount.ToString()+",-"+cis.dCount.ToString() +",";
					sql2+=cis.dPrice.ToString() + ",-" + cis.dFee.ToString() + ",'"+cis.strComments+"消费撤销','"+ cis.strConsType +"','" + cis.strConsDate + "','"+cis.strCompanyID+"','"+cis.strCompanyName+"','"+cis.strAcctID+"','"+cis.strDeptID+"','"+cis.strDeptName+"','" + cis.strOperName + "','"+ cis.strOperDate + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbBusiLog values('"+ strSerial + "','OP017','"+ cis.strOperName + "','" + cis.strOperDate + "','消费撤销，卡号：" + cis.strCardID + "','" + cis.strDeptName + "','"+cis.strDeptID+"','客户端')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbMebCompanyPrepay set cnnPrepayFee=cnnPrepayFee+" + (Math.Round(cis.dFee,2)).ToString() + " where cnvcCompanyID='" + cis.strCompanyID+"'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="insert into tbMemberLog select '"+strSerial+"',* from tbMember where cnvcCardID='" + cis.strCardID + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql7="insert into tbOilStorageLog values('"+strSerial+"','"+cis.strDeptName+"','"+cis.strGoodsName+"','"+cis.strGoodsType+"',"+(cis.dKGCount).ToString("0.00")+","+cis.dStorageLast.ToString("0.00")+","+cis.strCurStorage+",'零售油撤销','"+cis.strOperName+"','"+cis.strOperDate+"','"+cis.strDeptID+"')";
					cmd=new SqlCommand(sql7,con,trans);
					cmd.ExecuteNonQuery();

					sql8="update tbOilStorage set cnnStorageCount="+cis.strCurStorage+" where cnvcGoodsName='"+cis.strGoodsName+"' and cnvcGoodsType='"+cis.strGoodsType+"' and cnvcDeptID='"+cis.strDeptID+"'";
					cmd=new SqlCommand(sql8,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

	}
}
