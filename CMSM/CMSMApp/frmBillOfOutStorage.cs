using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;
using CMSM.Common;
using CMSM.Business;
using CMSM.Entity;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmBillOfOutStorage.
	/// </summary>
	public class frmBillOfOutStorage : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnQuery;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBillNo;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private System.Windows.Forms.DateTimePicker dtpDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		CommAccess ca=new CommAccess(CMSMData.CMSMDataAccess.SysInitial.ConString);
		private System.Windows.Forms.CheckBox checkBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnMod;
		Exception err;

		public frmBillOfOutStorage()
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sbtnMod = new DevExpress.XtraEditors.SimpleButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnQuery = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBillNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 82);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(960, 452);
			this.dataGrid1.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sbtnMod);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.dtpDate);
			this.groupBox1.Controls.Add(this.sbtnAdd);
			this.groupBox1.Controls.Add(this.sbtnClose);
			this.groupBox1.Controls.Add(this.sbtnQuery);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtBillNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(960, 82);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// sbtnMod
			// 
			this.sbtnMod.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnMod.Location = new System.Drawing.Point(864, 32);
			this.sbtnMod.Name = "sbtnMod";
			this.sbtnMod.Size = new System.Drawing.Size(56, 23);
			this.sbtnMod.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnMod.TabIndex = 22;
			this.sbtnMod.Text = "修改";
			this.sbtnMod.Visible = false;
			this.sbtnMod.Click += new System.EventHandler(this.sbtnMod_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(544, 40);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(120, 24);
			this.checkBox1.TabIndex = 21;
			this.checkBox1.Text = "查询历史记录";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// dtpDate
			// 
			this.dtpDate.Location = new System.Drawing.Point(376, 40);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(160, 21);
			this.dtpDate.TabIndex = 18;
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAdd.Location = new System.Drawing.Point(736, 32);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.Size = new System.Drawing.Size(56, 23);
			this.sbtnAdd.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAdd.TabIndex = 17;
			this.sbtnAdd.Text = "添加";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(800, 32);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 14;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnQuery
			// 
			this.sbtnQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnQuery.Location = new System.Drawing.Point(672, 32);
			this.sbtnQuery.Name = "sbtnQuery";
			this.sbtnQuery.Size = new System.Drawing.Size(56, 23);
			this.sbtnQuery.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnQuery.TabIndex = 4;
			this.sbtnQuery.Text = "查询";
			this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "出库日期";
			// 
			// txtBillNo
			// 
			this.txtBillNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillNo.Location = new System.Drawing.Point(128, 40);
			this.txtBillNo.Name = "txtBillNo";
			this.txtBillNo.Size = new System.Drawing.Size(144, 22);
			this.txtBillNo.TabIndex = 1;
			this.txtBillNo.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(64, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "出库单号";
			// 
			// frmBillOfOutStorage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(960, 534);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmBillOfOutStorage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "出库单";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmBillOfOutStorage_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			Form frmadd=new frmBillOfOutStorageAdd();
			frmadd.ShowDialog();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void DgBind()
		{
			string strBillNo=txtBillNo.Text.Trim();
			//string strDate=dtpDate.Value.ToShortDateString();
			string strDate=dtpDate.Value.ToString("yyyy-MM-dd");
			err=null;
			DataTable dt=new DataTable();
			if(this.checkBox1.Checked)
			{
				dt=ca.GetBillOfOutStorageHis(strBillNo,strDate,out err);
			}
			else
			{
				dt=ca.GetBillOfOutStorage(strBillNo,strDate,out err);
			}
			if(err!=null)
			{
				MessageBox.Show("查询错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			if(dt!=null)
			{
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("出库单号,发料仓库,提货单位,调拨单号,领料单号,承运单位,承运车号,出库日期,油料名称,油料型号,单位,应发数,实发数,备注,仓库主管,提货人,制单,出库方式,操作员,操作时间","60,60,60,100,80,100,80,90,90",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void sbtnMod_Click(object sender, System.EventArgs e)
		{
			//修改
			if(this.dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("请选择要修改的出库单","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			string strBillNo = this.dataGrid1[this.dataGrid1.CurrentRowIndex,0].ToString();
			string strsql = "";
			bool IsHis = false;
			if(this.checkBox1.Checked)
			{
				strsql = "select * from tbBillOfOutStorageHis where cnvcbillno='"+strBillNo+"' and cnvcDeptID='"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptID+"'";
				IsHis = true;
			}
			else
			{
				strsql = "select * from tbBillOfOutStorage where cnvcbillno='"+strBillNo+"' and cnvcDeptID='"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptID+"'";
			}						
			DataTable dt = Helper.Query(strsql,false);
			Entity.BillOfOutStorage bos = new CMSM.Entity.BillOfOutStorage(dt);
			frmBillOfOutStorageAdd frm = new frmBillOfOutStorageAdd();
			frm.BOS = bos;
			frm.Flag = OperFlag.MOD;
			frm.IsHis = IsHis;
			frm.ShowDialog();
			this.DgBind();
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dataGrid1.SetDataBinding(null,"");
		}

		private void frmBillOfOutStorage_Load(object sender, System.EventArgs e)
		{
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.CustomFormat = "yyyy-MM-dd";
		}
	}
}
