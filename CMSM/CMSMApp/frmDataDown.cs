using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CMSMData;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmDataDown.
	/// </summary>
	public class frmDataDown : CMSM.CMSMApp.frmBase
	{
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.ComponentModel.IContainer components=null;

		public frmDataDown()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataDown));
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(400, 360);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 25;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.listBox1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 88);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(600, 256);
			this.listBox1.TabIndex = 24;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(56, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(512, 56);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 23;
			this.pictureBox1.TabStop = false;
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.simpleButton1.Location = new System.Drawing.Point(152, 360);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(80, 23);
			this.simpleButton1.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.simpleButton1.TabIndex = 26;
			this.simpleButton1.Text = "开始下载";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// frmDataDown
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 398);
			this.ControlBox = false;
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.sbtnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDataDown";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据下载更新";
			this.Load += new System.EventHandler(this.frmDataDown_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDataDown_Load(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=false;

		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=true;
			this.sbtnClose.Enabled=false;
			#region 手动下载更新
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
						string sql,sql2;

						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.Items.Add("开始加载中心数据库资料...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						sql="select * from tbCommCode";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenCommCode");

						sql="select * from tbDept";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenDept");

						sql="select * from tbFunc";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenFunc");

						sql="select * from tbOper";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenOper");

						sql="select * from tbOperFunc";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenOperFunc");

						sql="select * from tbRegister";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenRegister");

						DateTime dt1MonthBefore=DateTime.Today.AddMonths(-1);
						sql="select * from tbOilPrice where cndPriceDate>='"+dt1MonthBefore.ToShortDateString()+"'";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenOilPrice");

						sql="select * from tbMember";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenMember");

						sql="select * from tbSpecialOilDept";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenSpecOilDept");

						sql="select * from tbConsItem";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalConsItem");

						sql="select * from tbMebCompanyPrepay";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenMebCompanyPrepay");
						
						this.listBox1.Items.Add("加载中心数据库资料成功！");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						
						this.listBox1.Items.Add("更新本地数据：系统基本参数信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbCommCode
						sql="truncate table tbCommCode";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="";
						for(i=0;i<dstmp.Tables["CenCommCode"].Rows.Count;i++)
						{
							sql+="insert into tbCommCode values('"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommName"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommCode"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcCommSign"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["cnvcComments"].ToString()+"');";
						}
						if(sql!="")
						{
							cmd=new SqlCommand(sql,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：系统基本参数信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：部门信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbDept
						sql="";
						sql="delete from tbDept where cnvcLocalFlag<>'LOCAL' or cnvcLocalFlag is null";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						CMSMStruct.DeptStruct depts=new CMSMData.CMSMStruct.DeptStruct();
						sql="select * from tbDept where cnvcLocalFlag='LOCAL'";
						cmd=new SqlCommand(sql,con,transLocal);
						drr=cmd.ExecuteReader();
						if(drr.HasRows)
						{
							drr.Read();
							depts.strDeptID=drr[0].ToString();
							depts.strDeptName=drr[1].ToString();
							depts.strParentDeptID=drr[2].ToString();
							depts.strLocalFlag=drr[3].ToString();
							drr.Close();

							sql="";
							for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
							{
								if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()!=depts.strDeptID)
								{
									sql+="insert into tbDept values('"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcParentDeptID"].ToString()+"',null);";
								}
							}
							if(sql!="")
							{
								cmd=new SqlCommand(sql,con,transLocal);
								cmd.ExecuteNonQuery();
							}

							sql="";
							if(depts.strDeptID!="NULL")
							{
								for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
								{
									if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()==depts.strDeptID)
									{
										if(dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()!=depts.strDeptName)
										{
											sql+="update tbDept set cnvcDeptName='"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"' where cnvcLocalFlag='LOCAL' and cnvcDeptID='"+depts.strDeptID+"';";
											sql+="update tbRegister set cnvcDeptName='"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"' where cnvcDeptName='"+depts.strDeptName+"';";
											cmd=new SqlCommand(sql,con,transLocal);
											cmd.ExecuteNonQuery();
											sql="";
											break;
										}
									}
								}
							}
						}
						else
						{
							drr.Close();
							sql="";
							for(i=0;i<dstmp.Tables["CenDept"].Rows.Count;i++)
							{
								sql+="insert into tbDept values('"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenDept"].Rows[i]["cnvcParentDeptID"].ToString()+"',null);";
							}
							if(sql!="")
							{
								cmd=new SqlCommand(sql,con,transLocal);
								cmd.ExecuteNonQuery();
							}
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：部门信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：功能列表信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbFunc
						sql="";
						sql="truncate table tbFunc";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="";
						for(i=0;i<dstmp.Tables["CenFunc"].Rows.Count;i++)
						{
							sql+="insert into tbFunc values('"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncType"].ToString()+"');";
						}
						if(sql!="")
						{
							cmd=new SqlCommand(sql,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：功能列表信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：操作员信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbOper
						sql="";
						sql="truncate table tbOper";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="";
						for(i=0;i<dstmp.Tables["CenOper"].Rows.Count;i++)
						{
							sql+="insert into tbOper values("+dstmp.Tables["CenOper"].Rows[i]["cnnOperID"].ToString()+",'"+dstmp.Tables["CenOper"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenOper"].Rows[i]["cnvcPwd"].ToString()+"','"+dstmp.Tables["CenOper"].Rows[i]["cnvcDeptID"].ToString()+"');";
						}
						if(sql!="")
						{
							cmd=new SqlCommand(sql,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：操作员信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：操作员权限信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbOperFunc
						sql="";
						sql="truncate table tbOperFunc";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="";
						for(i=0;i<dstmp.Tables["CenOperFunc"].Rows.Count;i++)
						{
							sql+="insert into tbOperFunc values("+dstmp.Tables["CenOperFunc"].Rows[i]["cnnOperID"].ToString()+",'"+dstmp.Tables["CenOperFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CenOperFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"');";
						}
						if(sql!="")
						{
							cmd=new SqlCommand(sql,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新本地数据：操作员权限信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						#region 更新tbRegister
						sql="";
						sql="truncate table tbRegister";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="";
						for(i=0;i<dstmp.Tables["CenRegister"].Rows.Count;i++)
						{
							sql+="insert into tbRegister values('"+dstmp.Tables["CenRegister"].Rows[i]["cnvcHddSerialNo"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcRegister"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["CenRegister"].Rows[i]["cndOperDate"].ToString()+"');";
						}
						if(sql!="")
						{
							cmd=new SqlCommand(sql,con,transLocal);
							cmd.ExecuteNonQuery();
						}
						#endregion

						this.listBox1.Items.Add("更新本地数据：油价信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
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
						#endregion
						this.listBox1.Items.Add("更新本地数据：油价信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：会员信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
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
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新本地数据：专供油单位及合同信息...");
						this.Refresh();
						#region 更新本地tbSpecialOilDept
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
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新本地tbMebCompanyPrepay
						sql2="";
						for(i=0;i<dstmp.Tables["CenMebCompanyPrepay"].Rows.Count;i++)
						{
							sql="select count(*) from tbMebCompanyPrepay where cnvcCompanyID='"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"'";
							cmd=new SqlCommand(sql,con,transLocal);
							drr=cmd.ExecuteReader();
							drr.Read();
							int MebCompCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(MebCompCount==0)
							{
								sql2+="insert into tbMebCompanyPrepay values('"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcAcctID"].ToString()+"',"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnnPrepayFee"].ToString()+",'"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["CenMebCompanyPrepay"].Rows[i]["cnvcDeptID"].ToString()+"');";
							}
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
//									if(TolCompPrepay>=0)
//									{
										//更新中心单位余额
										sql="update tbMebCompanyPrepay set cnnPrepayFee="+TolCompPrepay.ToString()+" where cnvcCompanyID='"+dstmp.Tables["CenCompFill"].Rows[i]["cnvcCompanyID"].ToString()+"'";
										cmd=new SqlCommand(sql,conCenter,transCenter);
										cmd.ExecuteNonQuery();
										//更新本地单位余额
										cmd=new SqlCommand(sql,con,transLocal);
										cmd.ExecuteNonQuery();
//									}
								}
							}
						}
						#endregion
						this.listBox1.Items.Add("更新中心和本地数据：会员单位及余额信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						transLocal.Commit();
						transCenter.Commit();

						this.listBox1.Items.Add("");
						this.listBox1.Items.Add("所有数据更新完成！");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						this.pictureBox1.Visible=false;
						this.sbtnClose.Enabled=true;

						Exception err=null;
						SysInitial.CreatDS(out err);
						if(err!=null)
						{
							MessageBox.Show("系统参数刷新失败，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err);
							Application.Exit();
						}
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
		#endregion
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
