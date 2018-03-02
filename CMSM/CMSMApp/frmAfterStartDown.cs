using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.IO;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmAfterStartDown.
	/// </summary>
	public class frmAfterStartDown : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListBox listBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public frmAfterStartDown()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAfterStartDown));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(80, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(456, 57);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.listBox1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 96);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(600, 256);
			this.listBox1.TabIndex = 1;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(280, 368);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 22;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmAfterStartDown
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(634, 408);
			this.ControlBox = false;
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmAfterStartDown";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "启动强制更新";
			this.Load += new System.EventHandler(this.frmAfterStartDown_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.timer1.Stop();
			this.timer1.Enabled=false;
			
			#region 启动系统后，强制下载更新
			DataSet dstmp=new DataSet();
			int i=0;
			SqlDataAdapter daTmp;
			SqlConnection conCenter=new SqlConnection();
			SqlConnection con=new SqlConnection();
			SqlCommand cmd;
			SqlDataReader drr;
			conCenter.ConnectionString=SysInitial.CenterConString;
			con.ConnectionString=SysInitial.ConString;
			try
			{
				conCenter.Open();
			}
			catch(Exception conerr)
			{
				clog.WriteLine(conerr);
				this.listBox1.Items.Add("--------------------------------");
				this.listBox1.Items.Add("连接中心数据库失败，请检查网络！");
				this.sbtnClose.Enabled=true;
				return;
			}
			con.Open();
			using(SqlTransaction transCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				using(SqlTransaction transLocal=con.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					try
					{
						e=null;
						string sql,sql2,sql3;

						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.Items.Add("开始加载中心数据库资料...");
						this.Refresh();
						sql = "select * from tbOilStorageLogHis WITH(UPDLOCK) where cnvcDeptID='"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptID+"'";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp = new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenOilStorageLogHis");
						
						DateTime dt1MonthBefore=DateTime.Today.AddMonths(-1);
						sql="select * from tbOilPrice where cndPriceDate>='"+dt1MonthBefore.ToShortDateString()+"'";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenOilPrice");

						sql="select * from tbMember";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenMember");

						sql="select * from tbMebCompanyPrepay";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenMebCompanyPrepay");

						sql="select * from tbConsItem";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalConsItem");

						sql="select * from tbSpecialOilDept";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenSpecOilDept");

						this.listBox1.Items.Add("加载中心数据库资料成功！");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();
						
						#region 更新本地库存信息
						this.listBox1.Items.Add("更新本地数据：库存信息...");
						this.Refresh();

						sql2="";
						for(i=0;i<dstmp.Tables["CenOilStorageLogHis"].Rows.Count;i++)
						{
							string strSerial = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnnSerial"].ToString();
							string strGoodsName = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcGoodsName"].ToString();
							string strGoodsType = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcGoodsType"].ToString();
							string strDeptID = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcDeptID"].ToString();
							string strDeptName = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcDeptName"].ToString();
							string strLastCount = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnnLastCount"].ToString();
							string strCurCount = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnnCurCount"].ToString();
							string strInOutCount = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnnInOutCount"].ToString();
							string strOperType = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcOperType"].ToString();
							string strOperName = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cnvcOperName"].ToString();
							string strOperDate = dstmp.Tables["CenOilStorageLogHis"].Rows[i]["cndOperDate"].ToString();
							sql2+="update tbOilStorage set cnnStorageCount=cnnStorageCount+"+strInOutCount+" where cnvcDeptID='"+strDeptID+"' and cnvcGoodsName='"+strGoodsName+"' and cnvcGoodsType='"+strGoodsType+"';";
							sql2+="insert into tbOilStorageLogHis values('"+strSerial+"','"+strDeptName+"','"+strGoodsName+"','"+strGoodsType+"',"+strInOutCount+","+strLastCount+","+strCurCount+",'"+strOperType+"','"+strOperName+"','"+strOperDate+"','"+strDeptID+"');";
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion

						this.listBox1.Items.Add("更新本地数据：油价信息...");
						this.Refresh();
						#region 更新本地tbOilPrice
						sql2="";
						for(i=0;i<dstmp.Tables["CenOilPrice"].Rows.Count;i++)
						{
							sql="select count(*) from tbOilPrice where cnnSerialNo='"+dstmp.Tables["CenOilPrice"].Rows[i]["cnnSerialNo"].ToString()+"'";
							cmd=new SqlCommand(sql,con,transLocal);
							drr=cmd.ExecuteReader();
							drr.Read();
							int PriceCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(PriceCount==0)
							{
								sql2+="insert into tbOilPrice values('"+dstmp.Tables["CenOilPrice"].Rows[i]["cnnSerialNo"].ToString()+"','"+dstmp.Tables["CenOilPrice"].Rows[i]["cndPriceDate"].ToString()+"','"+dstmp.Tables["CenOilPrice"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["CenOilPrice"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["CenOilPrice"].Rows[i]["cnvcUnit"].ToString()+"',"+dstmp.Tables["CenOilPrice"].Rows[i]["cnnOilPrice"].ToString()+",'"+dstmp.Tables["CenOilPrice"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenOilPrice"].Rows[i]["cnvcDeptID"].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						this.listBox1.Items.Add("更新本地数据：库存信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();
						#endregion
						this.listBox1.Items.Add("更新本地数据：油价信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：会员信息...");
						this.Refresh();
						#region 更新本地tbMember
						sql2="";
						int MebCount=0;
						for(i=0;i<dstmp.Tables["CenMember"].Rows.Count;i++)
						{
							MebCount=0;
							sql="select count(*) from tbMember where cnvcCardID='"+dstmp.Tables["CenMember"].Rows[i]["cnvcCardID"].ToString()+"'";
							cmd=new SqlCommand(sql,con,transLocal);
							drr=cmd.ExecuteReader();
							drr.Read();
							MebCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(MebCount==0)
							{
								sql2+="insert into tbMember values('"+dstmp.Tables["CenMember"].Rows[i]["cnvcCardID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcLicenseTag"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcState"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcComments"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cndCreateDate"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cndOperDate"].ToString()+"');";
							}
							else
							{
								MebCount=0;
								sql="select count(*) from tbMember where cnvcCardID='"+dstmp.Tables["CenMember"].Rows[i]["cnvcCardID"].ToString()+"' and cndOperDate<'"+dstmp.Tables["CenMember"].Rows[i]["cndOperDate"].ToString()+"'";
								cmd=new SqlCommand(sql,con,transLocal);
								drr=cmd.ExecuteReader();
								drr.Read();
								MebCount=int.Parse(drr[0].ToString());
								drr.Close();

								if(MebCount>0)
								{
									sql2+="delete from tbMember where cnvcCardID='"+dstmp.Tables["CenMember"].Rows[i]["cnvcCardID"].ToString()+"';";
									sql2+="insert into tbMember values('"+dstmp.Tables["CenMember"].Rows[i]["cnvcCardID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcLicenseTag"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcState"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcComments"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cndCreateDate"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenMember"].Rows[i]["cndOperDate"].ToString()+"');";
								}
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：会员信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：专供油单位及合同信息...");
						this.Refresh();
						#region 更新本地tbSpecialOilDept

						sql3="delete  from tbSpecialOilDept";
						cmd=new SqlCommand(sql3,con,transLocal);
						cmd.ExecuteNonQuery();

						sql2="";
						for(i=0;i<dstmp.Tables["CenSpecOilDept"].Rows.Count;i++)
						{
							sql="select count(*) from tbSpecialOilDept where cnvcContractNo='"+dstmp.Tables["CenSpecOilDept"].Rows[i]["cnvcContractNo"].ToString()+"'";
							cmd=new SqlCommand(sql,con,transLocal);
							drr=cmd.ExecuteReader();
							drr.Read();
							int SpecDeptCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(SpecDeptCount==0)
							{
								sql2+="insert into tbSpecialOilDept values('"+dstmp.Tables["CenSpecOilDept"].Rows[i]["cnvcContractNo"].ToString()+"','"+dstmp.Tables["CenSpecOilDept"].Rows[i]["cnvcDeliveryCompany"].ToString()+"')";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：专供油单位及合同信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();

						this.listBox1.Items.Add("更新中心和本地数据：会员单位及余额信息...");
						this.Refresh();
						#region 更新本地tbMebCompanyPrepay
						sql2="";
						for(i=0;i<dstmp.Tables["CenMebCompanyPrepay"].Rows.Count;i++)
						{
							bool bvalidate = Convert.ToBoolean(dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnbValidate"].ToString());
							string strvalidate = bvalidate?"1":"0";
							sql="select count(*) from tbMebCompanyPrepay where cnvcCompanyID='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"'";
							cmd=new SqlCommand(sql,con,transLocal);
							drr=cmd.ExecuteReader();
							drr.Read();
							int MebCompCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(MebCompCount==0)
							{
								sql2+="insert into tbMebCompanyPrepay values('"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcAcctID"].ToString()+"',"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnnPrepayFee"].ToString()+",'"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptID"].ToString()+"',1);";
							}
							else
							{
								sql2+= "update tbMebCompanyPrepay set cnbvalidate="+strvalidate+",cnvcCompanyName='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyName"].ToString()+"' where cnvcCompanyID='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"';";
							}


//							sql="select count(*) from tbMebCompanyPrepay where cnbValidate=0 and cnvcCompanyID='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"'";
//							cmd=new SqlCommand(sql,con,transLocal);
//							drr=cmd.ExecuteReader();
//							drr.Read();
//							MebCompCount=int.Parse(drr[0].ToString());
//							drr.Close();
//
//							if(MebCompCount==0)
//							{
//								sql2+="insert into tbMebCompanyPrepay values('"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcAcctID"].ToString()+"',"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnnPrepayFee"].ToString()+",'"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptID"].ToString()+"',0);";
//							}
//							else
//							{
//								sql2+= "update tbMebCompanyPrepay set cnbvalidate=0 where cnvcCompanyID='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"';";
//							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion

						#region 上传tbConsItem，并进行余额计算，更新中心和本地
						//上传tbConsItem
						sql2="";
						for(i=0;i<dstmp.Tables["LocalConsItem"].Rows.Count;i++)
						{
							sql="select count(*) from tbConsItem where cnnSerial='"+dstmp.Tables["LocalConsItem"].Rows[i]["cnnSerial"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							int ConsCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(ConsCount==0)
							{
								sql2+="insert into tbConsItem values('"+dstmp.Tables["LocalConsItem"].Rows[i]["cnnSerial"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcCardID"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcLicenseTags"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcUnit"].ToString()+"',"+dstmp.Tables["LocalConsItem"].Rows[i]["cnnDensity"].ToString()+","+dstmp.Tables["LocalConsItem"].Rows[i]["cnnKGCount"].ToString()+","+dstmp.Tables["LocalConsItem"].Rows[i]["cnnCount"].ToString()+","+dstmp.Tables["LocalConsItem"].Rows[i]["cnnPrice"].ToString()+","+dstmp.Tables["LocalConsItem"].Rows[i]["cnnFee"].ToString()+",'"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcComments"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcConsType"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cndConsDate"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcAcctID"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["LocalConsItem"].Rows[i]["cndOperDate"].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbConsItemHis select * from tbConsItem";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbConsItem";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						if(SysInitial.LocalDeptID=="")
						{
							this.listBox1.Items.Add("更新中心和本地数据：会员单位及余额信息更新失败，由于本地加油站还未指定！");
							this.listBox1.Items.Add("--------------------------------");
							this.Refresh();
						}
						else
						{
							//计算中心本地部门的单位余额
							sql="select cnvcCompanyID,isnull(sum(cnnFillFee),0) as TolFill from tbFillFee where cnvcDeptID='"+SysInitial.LocalDeptID+"' group by cnvcCompanyID order by cnvcCompanyID";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							daTmp=new SqlDataAdapter(cmd);
							daTmp.Fill(dstmp,"CenCompFill");

							sql="select cnvcCompanyID,isnull(sum(cnnFee),0) as TolCons from tbConsItem where cnvcDeptID='"+SysInitial.LocalDeptID+"' group by cnvcCompanyID union select cnvcCompanyID,0 as TolCons from tbMebCompanyPrepay where cnvcCompanyID not in(select distinct cnvcCompanyID from tbConsItem where cnvcDeptID='"+SysInitial.LocalDeptID+"') order by cnvcCompanyID";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							daTmp=new SqlDataAdapter(cmd);
							daTmp.Fill(dstmp,"CenCompCons");

							double TolFill=0;
							double TolCons=0;
							double TolCompPrepay=0;
							for(i=0;i<dstmp.Tables["CenCompFill"].Rows.Count;i++)
							{
								for(int j=0;j<dstmp.Tables["CenCompCons"].Rows.Count;j++)
								{
									if(dstmp.Tables["CenCompFill"].Rows[i]["cnvcCompanyID"].ToString()==dstmp.Tables["CenCompCons"].Rows[j]["cnvcCompanyID"].ToString())
									{
										TolFill=double.Parse(dstmp.Tables["CenCompFill"].Rows[i]["TolFill"].ToString());
										TolCons=double.Parse(dstmp.Tables["CenCompCons"].Rows[j]["TolCons"].ToString());
										TolCompPrepay=TolFill-TolCons;
										//修正余额为负更新余额
//										if(TolCompPrepay>=0)
//										{
											//更新中心单位余额
											sql="update tbMebCompanyPrepay set cnnPrepayFee="+TolCompPrepay.ToString()+" where cnvcCompanyID='"+dstmp.Tables["CenCompFill"].Rows[i]["cnvcCompanyID"].ToString()+"'";
											cmd=new SqlCommand(sql,conCenter,transCenter);
											cmd.ExecuteNonQuery();
											//更新本地单位余额
											cmd=new SqlCommand(sql,con,transLocal);
											cmd.ExecuteNonQuery();
//										}
									}
								}
							}

							this.listBox1.Items.Add("更新中心和本地数据：会员单位及余额信息更新成功...");
							this.listBox1.Items.Add("--------------------------------");
							this.Refresh();
						}
						#endregion

						this.listBox1.Items.Add("删除中心库存修改历史记录...");
						this.Refresh();
						sql="delete from tbOilStorageLogHis where cnvcDeptID='"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptID+"'";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						cmd.ExecuteNonQuery();

						this.listBox1.Items.Add("删除中心库存修改历史记录成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.Refresh();

						transLocal.Commit();
						transCenter.Commit();

						if(File.Exists(Application.StartupPath+@"\BatchScript.bat"))
						{
							File.Delete(Application.StartupPath+@"\BatchScript.bat");
						}
						if(File.Exists(Application.StartupPath+@"\Script.sql"))
						{
							File.Delete(Application.StartupPath+@"\Script.sql");
						}

						this.listBox1.Items.Add("所有数据更新完成！");
						this.Refresh();
						this.pictureBox1.Visible=false;
					}
					catch(Exception err)
					{
						transLocal.Rollback();
						transCenter.Rollback();
						if(con.State==ConnectionState.Open)
						{
							con.Close();
						}
						if(conCenter.State==ConnectionState.Open)
						{
							conCenter.Close();
						}
						clog.WriteLine(err);
						this.listBox1.Items.Add("----------------------------------------------------------------------");
						this.listBox1.Items.Add("更新过程中发生意外错误，更新未完全！");
						this.listBox1.Items.Add("----------------------------------------------------------------------");
						MessageBox.Show("更新过程中发生意外错误，更新未完全，请重新选择手工更新或重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.sbtnClose.Enabled=true;
						return;
					}
				}
			}

			if(con.State==ConnectionState.Open)
			{
				con.Close();
			}
			if(conCenter.State==ConnectionState.Open)
			{
				conCenter.Close();
			}
			this.sbtnClose.Enabled=true;
		#endregion

		}

		private void frmAfterStartDown_Load(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=true;
			this.timer1.Interval=5000;
			this.timer1.Enabled=true;
			this.timer1.Start();
			this.sbtnClose.Enabled=false;

		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
