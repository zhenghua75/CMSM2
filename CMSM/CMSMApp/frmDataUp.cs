using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CMSMData;
using CMSMData.CMSMDataAccess;
using CMSM.Common;
using CMSM.Entity;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmDataUp.
	/// </summary>
	public class frmDataUp : CMSM.CMSMApp.frmBase
	{
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDataUp()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataUp));
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.simpleButton1.Location = new System.Drawing.Point(152, 360);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(80, 23);
			this.simpleButton1.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.simpleButton1.TabIndex = 30;
			this.simpleButton1.Text = "开始上传";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
			this.listBox1.TabIndex = 28;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(56, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(512, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 27;
			this.pictureBox1.TabStop = false;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(400, 360);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 29;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// frmDataUp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 398);
			this.ControlBox = false;
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.sbtnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDataUp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据上传";
			this.Load += new System.EventHandler(this.frmDataUp_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDataUp_Load(object sender, System.EventArgs e)
		{
		  this.pictureBox1.Visible=false;
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=true;
			this.sbtnClose.Enabled=false;

			#region 手动上传数据
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
						this.listBox1.Items.Add("开始加载本地数据库资料...");
						this.Refresh();
						sql="select * from tbBillOfMaterials";
						cmd=new SqlCommand(sql,con,transLocal);						
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalBillOfMaterials");

						sql="select * from tbBillOfOutStorage";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalBillOfOutStorage");

						sql="select * from tbBillOfValidate";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalBillOfValidate");

						sql="select * from tbBusiLog";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalBusiLog");

						DateTime dt1MonthBefore=DateTime.Today.AddMonths(-1);
						sql="select * from tbDensity where cndRateDate>='"+dt1MonthBefore.ToShortDateString()+"'";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalDensity");

						sql="select * from tbOilStorage";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalOilStorage");

						sql="select * from tbOilStorageCheck";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalOilStorageCheck");

						sql="select * from tbOilStorageLog";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalOilStorageLog");

						sql="select * from tbMember";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalMember");

						sql="select * from tbConsItem";
						cmd=new SqlCommand(sql,con,transLocal);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"LocalConsItem");

						sql="select * from tbMebCompanyPrepay";
						cmd=new SqlCommand(sql,conCenter,transCenter);
						daTmp=new SqlDataAdapter(cmd);
						daTmp.Fill(dstmp,"CenMebCompanyPrepay");
						
						this.listBox1.Items.Add("加载本地数据库资料成功！");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						
						this.listBox1.Items.Add("更新中心数据：领料单信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						int recCount=0;
						#region 更新tbBillOfMaterials
						sql2="";
						for(i=0;i<dstmp.Tables["LocalBillOfMaterials"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbBillOfMaterials where cnvcBillNo='"+dstmp.Tables["LocalBillOfMaterials"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfMaterials"].Rows[i]["cnvcDeptID"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbBillOfMaterials values('"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][2].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][3].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][4].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][5].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][6].ToString()+"',";
								sql2+=dstmp.Tables["LocalBillOfMaterials"].Rows[i][7].ToString()+","+dstmp.Tables["LocalBillOfMaterials"].Rows[i][8].ToString()+",'"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][9].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][10].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][11].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][12].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][13].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][14].ToString()+"','";
								sql2+=dstmp.Tables["LocalBillOfMaterials"].Rows[i][15].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][16].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][17].ToString()+"','"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][18].ToString()+"',"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][19].ToString()+","+dstmp.Tables["LocalBillOfMaterials"].Rows[i][20].ToString()+",'"+dstmp.Tables["LocalBillOfMaterials"].Rows[i][21].ToString()+"');";
							}				
							else//同步更新数据
							{
								sql="select * from tbBillOfMaterials where cnvcBillNo='"+dstmp.Tables["LocalBillOfMaterials"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfMaterials"].Rows[i]["cnvcDeptID"].ToString()+"'";
								DataTable dt = SqlHelper.ExecuteDataTable(transCenter,CommandType.Text,sql);
								Entity.BillOfMaterials centerbom = new BillOfMaterials(dt);
								Entity.BillOfMaterials localbom = new BillOfMaterials(dstmp.Tables["LocalBillOfMaterials"].Rows[i]);
								centerbom.SynchronizeModifyValue(localbom);
								EntityMapping.Update(centerbom,transCenter);
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbBillOfMaterialsHis select * from tbBillOfMaterials";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbBillOfMaterials";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：领料单信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						
						this.listBox1.Items.Add("更新中心数据：出库单信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbBillOfOutStorage
						sql2="";
						for(i=0;i<dstmp.Tables["LocalBillOfOutStorage"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbBillOfOutStorage where cnvcBillNo='"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i]["cnvcDeptID"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbBillOfOutStorage values('"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][2].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][3].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][4].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][5].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][6].ToString()+"','";
								sql2+=dstmp.Tables["LocalBillOfOutStorage"].Rows[i][7].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][8].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][9].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][10].ToString()+"',"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][11].ToString()+","+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][12].ToString()+",'"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][13].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][14].ToString()+"','";
								sql2+=dstmp.Tables["LocalBillOfOutStorage"].Rows[i][15].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][16].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][17].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][18].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][19].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][20].ToString()+"','"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i][21].ToString()+"');";
							}
							else//同步更新数据
							{
								sql="select * from tbBillOfOutStorage where cnvcBillNo='"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfOutStorage"].Rows[i]["cnvcDeptID"].ToString()+"'";
								DataTable dt = SqlHelper.ExecuteDataTable(transCenter,CommandType.Text,sql);
								Entity.BillOfOutStorage centerbos = new BillOfOutStorage(dt);
								Entity.BillOfOutStorage localbos = new BillOfOutStorage(dstmp.Tables["LocalBillOfOutStorage"].Rows[i]);
								centerbos.SynchronizeModifyValue(localbos);
								EntityMapping.Update(centerbos,transCenter);
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbBillOfOutStorageHis select * from tbBillOfOutStorage";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbBillOfOutStorage";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：出库单信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：验收单信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbBillOfValidate
						sql2="";
						for(i=0;i<dstmp.Tables["LocalBillOfValidate"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbBillOfValidate where cnvcBillNo='"+dstmp.Tables["LocalBillOfValidate"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfValidate"].Rows[i]["cnvcDeptID"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbBillOfValidate values('"+dstmp.Tables["LocalBillOfValidate"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][2].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][3].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][4].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][5].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][6].ToString()+"','";
								sql2+=dstmp.Tables["LocalBillOfValidate"].Rows[i][7].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][8].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][9].ToString()+"',"+dstmp.Tables["LocalBillOfValidate"].Rows[i][10].ToString()+","+dstmp.Tables["LocalBillOfValidate"].Rows[i][11].ToString()+","+dstmp.Tables["LocalBillOfValidate"].Rows[i][12].ToString()+","+dstmp.Tables["LocalBillOfValidate"].Rows[i][13].ToString()+","+dstmp.Tables["LocalBillOfValidate"].Rows[i][14].ToString()+",";
								sql2+=dstmp.Tables["LocalBillOfValidate"].Rows[i][15].ToString()+","+dstmp.Tables["LocalBillOfValidate"].Rows[i][16].ToString()+",'"+dstmp.Tables["LocalBillOfValidate"].Rows[i][17].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][18].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][19].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][20].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][21].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][22].ToString()+"','"+dstmp.Tables["LocalBillOfValidate"].Rows[i][23].ToString()+"');";
							}
							else//同步更新数据
							{
								sql="select * from tbBillOfValidate where cnvcBillNo='"+dstmp.Tables["LocalBillOfValidate"].Rows[i]["cnvcBillNo"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalBillOfValidate"].Rows[i]["cnvcDeptID"].ToString()+"'";
								DataTable dt = SqlHelper.ExecuteDataTable(transCenter,CommandType.Text,sql);
								Entity.BillOfValidate centerbov = new BillOfValidate(dt);
								Entity.BillOfValidate localbov = new BillOfValidate(dstmp.Tables["LocalBillOfValidate"].Rows[i]);
								centerbov.SynchronizeModifyValue(localbov);
								EntityMapping.Update(centerbov,transCenter);
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbBillOfValidateHis select * from tbBillOfValidate";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbBillOfValidate";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：验收单信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：操作日志信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbBusiLog
						sql2="";
						for(i=0;i<dstmp.Tables["LocalBusiLog"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbBusiLog where cnnSerial='"+dstmp.Tables["LocalBusiLog"].Rows[i]["cnnSerial"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbBusiLog values('"+dstmp.Tables["LocalBusiLog"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][2].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][3].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][4].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][5].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][6].ToString()+"','"+dstmp.Tables["LocalBusiLog"].Rows[i][7].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbBusiLogHis select * from tbBusiLog";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbBusiLog";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：操作日志信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：密度信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbDensity
						sql2="";
						for(i=0;i<dstmp.Tables["LocalDensity"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbDensity where cnnSerialNo='"+dstmp.Tables["LocalDensity"].Rows[i]["cnnSerialNo"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbDensity values('"+dstmp.Tables["LocalDensity"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalDensity"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalDensity"].Rows[i][2].ToString()+"',"+dstmp.Tables["LocalDensity"].Rows[i][3].ToString()+",'"+dstmp.Tables["LocalDensity"].Rows[i][4].ToString()+"','"+dstmp.Tables["LocalDensity"].Rows[i][5].ToString()+"','"+dstmp.Tables["LocalDensity"].Rows[i][6].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新中心数据：密度信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：库存信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbOilStorage
						sql2="";
						for(i=0;i<dstmp.Tables["LocalOilStorage"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbOilStorage where cnvcGoodsName='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcGoodsName"].ToString()+"' and cnvcGoodsType='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcGoodsType"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcDeptID"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbOilStorage values('"+dstmp.Tables["LocalOilStorage"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalOilStorage"].Rows[i][1].ToString()+"',"+dstmp.Tables["LocalOilStorage"].Rows[i][2].ToString()+",'"+dstmp.Tables["LocalOilStorage"].Rows[i][3].ToString()+"','"+dstmp.Tables["LocalOilStorage"].Rows[i][4].ToString()+"');";
							}
							else
							{
								sql2+="update tbOilStorage set cnnStorageCount="+dstmp.Tables["LocalOilStorage"].Rows[i]["cnnStorageCount"].ToString()+ " where cnvcGoodsName='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcGoodsName"].ToString()+"' and cnvcGoodsType='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcGoodsType"].ToString()+"' and cnvcDeptID='"+dstmp.Tables["LocalOilStorage"].Rows[i]["cnvcDeptID"].ToString()+"';";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新中心数据：库存信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：库存盘点信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbOilStorageCheck
						sql2="";
						for(i=0;i<dstmp.Tables["LocalOilStorageCheck"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbOilStorageCheck where cnnSerialNo='"+dstmp.Tables["LocalOilStorageCheck"].Rows[i]["cnnSerialNo"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbOilStorageCheck values('"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][2].ToString()+"',"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][3].ToString()+","+dstmp.Tables["LocalOilStorageCheck"].Rows[i][4].ToString()+","+dstmp.Tables["LocalOilStorageCheck"].Rows[i][5].ToString()+",'"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][6].ToString()+"','";
								sql2+=dstmp.Tables["LocalOilStorageCheck"].Rows[i][7].ToString()+"','"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][8].ToString()+"','"+dstmp.Tables["LocalOilStorageCheck"].Rows[i][9].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbOilStorageCheckHis select * from tbOilStorageCheck";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbOilStorageCheck";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：库存盘点信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：库存流水信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新tbOilStorageLog
						sql2="";
						for(i=0;i<dstmp.Tables["LocalOilStorageLog"].Rows.Count;i++)
						{
							recCount=0;
							sql="select count(*) from tbOilStorageLog where cnnSerial='"+dstmp.Tables["LocalOilStorageLog"].Rows[i]["cnnSerial"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							recCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(recCount==0)
							{
								sql2+="insert into tbOilStorageLog values('"+dstmp.Tables["LocalOilStorageLog"].Rows[i][0].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][1].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][2].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][3].ToString()+"',"+dstmp.Tables["LocalOilStorageLog"].Rows[i][4].ToString()+","+dstmp.Tables["LocalOilStorageLog"].Rows[i][5].ToString()+","+dstmp.Tables["LocalOilStorageLog"].Rows[i][6].ToString()+",'";
								sql2+=dstmp.Tables["LocalOilStorageLog"].Rows[i][7].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][8].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][9].ToString()+"','"+dstmp.Tables["LocalOilStorageLog"].Rows[i][10].ToString()+"');";
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}

						sql="insert into tbOilStorageLogHis select * from tbOilStorageLog";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();

						sql="truncate table tbOilStorageLog";
						cmd=new SqlCommand(sql,con,transLocal);
						cmd.ExecuteNonQuery();
						#endregion
						this.listBox1.Items.Add("更新中心数据：库存流水信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();

						this.listBox1.Items.Add("更新中心数据：会员信息...");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						#region 更新本地tbMember
						sql2="";
						int MebCount=0;
						for(i=0;i<dstmp.Tables["LocalMember"].Rows.Count;i++)
						{
							MebCount=0;
							sql="select count(*) from tbMember where cnvcCardID='"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCardID"].ToString()+"'";
							cmd=new SqlCommand(sql,conCenter,transCenter);
							drr=cmd.ExecuteReader();
							drr.Read();
							MebCount=int.Parse(drr[0].ToString());
							drr.Close();

							if(MebCount==0)
							{
								sql2+="insert into tbMember values('"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCardID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcLicenseTag"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcState"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcComments"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cndCreateDate"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cndOperDate"].ToString()+"');";
							}
							else
							{
								MebCount=0;
								sql="select count(*) from tbMember where cnvcCardID='"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCardID"].ToString()+"' and cndOperDate<'"+dstmp.Tables["LocalMember"].Rows[i]["cndOperDate"].ToString()+"'";
								cmd=new SqlCommand(sql,conCenter,transCenter);
								drr=cmd.ExecuteReader();
								drr.Read();
								MebCount=int.Parse(drr[0].ToString());
								drr.Close();

								if(MebCount>0)
								{
									sql2+="delete from tbMember where cnvcCardID='"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCardID"].ToString()+"';";
									sql2+="insert into tbMember values('"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCardID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCompanyID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcCompanyName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcLicenseTag"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcGoodsName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcGoodsType"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcDeptID"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcDeptName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcState"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcComments"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cndCreateDate"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cnvcOperName"].ToString()+"','"+dstmp.Tables["LocalMember"].Rows[i]["cndOperDate"].ToString()+"');";
								}
							}
						}
						if(sql2!="")
						{
							cmd=new SqlCommand(sql2,conCenter,transCenter);
							cmd.ExecuteNonQuery();
						}
						#endregion
						this.listBox1.Items.Add("更新中心数据：会员信息更新成功...");
						this.listBox1.Items.Add("--------------------------------");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
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

						sql="select cnvcCompanyID,isnull(sum(cnnFee),0) as TolCons from tbConsItem where cnvcDeptID='"+SysInitial.LocalDeptID+"' group by cnvcCompanyID order by cnvcCompanyID";
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
									if(TolCompPrepay>=0)
									{
										//更新中心单位余额
										sql="update tbMebCompanyPrepay set cnnPrepayFee="+TolCompPrepay.ToString()+" where cnvcCompanyID='"+dstmp.Tables["CenCompFill"].Rows[i]["cnvcCompanyID"].ToString()+"'";
										cmd=new SqlCommand(sql,conCenter,transCenter);
										cmd.ExecuteNonQuery();
										//更新本地单位余额
										cmd=new SqlCommand(sql,con,transLocal);
										cmd.ExecuteNonQuery();
									}
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
						this.listBox1.Items.Add("所有数据上传成功！");
						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
						this.Refresh();
						this.pictureBox1.Visible=false;
						this.sbtnClose.Enabled=true;
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
