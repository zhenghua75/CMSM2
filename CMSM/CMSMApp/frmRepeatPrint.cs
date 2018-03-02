using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Data;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmRepeatPrint.
	/// </summary>
	public class frmRepeatPrint : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnQuery;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private DevExpress.XtraEditors.SimpleButton sbtnPrint;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTolFee;
		private System.Windows.Forms.ComboBox cmbCompName;
		Exception err;

		public frmRepeatPrint()
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
			this.cmbCompName = new System.Windows.Forms.ComboBox();
			this.sbtnPrint = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpBegin = new System.Windows.Forms.DateTimePicker();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnQuery = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTolFee = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 96);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(944, 350);
			this.dataGrid1.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbCompName);
			this.groupBox1.Controls.Add(this.sbtnPrint);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dtpEnd);
			this.groupBox1.Controls.Add(this.dtpBegin);
			this.groupBox1.Controls.Add(this.txtCardID);
			this.groupBox1.Controls.Add(this.sbtnClose);
			this.groupBox1.Controls.Add(this.sbtnQuery);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(944, 96);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// cmbCompName
			// 
			this.cmbCompName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbCompName.Location = new System.Drawing.Point(80, 24);
			this.cmbCompName.Name = "cmbCompName";
			this.cmbCompName.Size = new System.Drawing.Size(288, 21);
			this.cmbCompName.TabIndex = 22;
			// 
			// sbtnPrint
			// 
			this.sbtnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnPrint.Location = new System.Drawing.Point(712, 56);
			this.sbtnPrint.Name = "sbtnPrint";
			this.sbtnPrint.Size = new System.Drawing.Size(56, 23);
			this.sbtnPrint.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnPrint.TabIndex = 21;
			this.sbtnPrint.Text = "打印";
			this.sbtnPrint.Click += new System.EventHandler(this.sbtnPrint_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(376, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "结束日期";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(376, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 19;
			this.label3.Text = "开始日期";
			// 
			// dtpEnd
			// 
			this.dtpEnd.Location = new System.Drawing.Point(448, 64);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(136, 21);
			this.dtpEnd.TabIndex = 18;
			// 
			// dtpBegin
			// 
			this.dtpBegin.Location = new System.Drawing.Point(448, 24);
			this.dtpBegin.Name = "dtpBegin";
			this.dtpBegin.Size = new System.Drawing.Size(136, 21);
			this.dtpBegin.TabIndex = 16;
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(80, 64);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(144, 22);
			this.txtCardID.TabIndex = 15;
			this.txtCardID.Text = "*";
			this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(784, 56);
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
			this.sbtnQuery.Location = new System.Drawing.Point(640, 56);
			this.sbtnQuery.Name = "sbtnQuery";
			this.sbtnQuery.Size = new System.Drawing.Size(56, 23);
			this.sbtnQuery.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnQuery.TabIndex = 4;
			this.sbtnQuery.Text = "查询";
			this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "会员卡号";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "单位名称";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtTolFee);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.txtCount);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(0, 446);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(944, 56);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "汇总数据";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(496, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 16);
			this.label9.TabIndex = 39;
			this.label9.Text = "元";
			// 
			// txtTolFee
			// 
			this.txtTolFee.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTolFee.Location = new System.Drawing.Point(384, 24);
			this.txtTolFee.Name = "txtTolFee";
			this.txtTolFee.Size = new System.Drawing.Size(104, 22);
			this.txtTolFee.TabIndex = 38;
			this.txtTolFee.Text = "";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(320, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 37;
			this.label10.Text = "消费金额";
			// 
			// txtCount
			// 
			this.txtCount.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCount.Location = new System.Drawing.Point(160, 24);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(96, 22);
			this.txtCount.TabIndex = 33;
			this.txtCount.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(80, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 16);
			this.label6.TabIndex = 32;
			this.label6.Text = "总消费次数";
			// 
			// frmRepeatPrint
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(944, 502);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "frmRepeatPrint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "重新打印小票";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmRepeatPrint_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRepeatPrint_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbCompName,"MebComp","cnvcCompanyName","all");
			this.txtCount.Text="0";
			this.txtTolFee.Text="0";
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();			
		}

		private void DgBind()
		{
			string strCardID=txtCardID.Text.Trim();
			string strCompName=cmbCompName.Text.Trim();
			string strBegin=dtpBegin.Value.ToShortDateString() + " 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString() + " 23:59:59";
			string strCompID="";
			if(strCompName=="全部")
			{
				strCompID="";
			}
			else
			{
				CMSMStruct.CompDeptStruct comp1=this.GetComDeptByCompName(strCompName);
                strCompID=comp1.strCompanyID;				
			}
			DataTable dt=new DataTable();
			err=null;
			dt=cs.GetConsRepeat(strCardID,strCompID,strBegin,strEnd,out err);
			if(dt!=null)
			{
				int consCount=dt.Rows.Count;
				double consfee=0;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					consfee+=double.Parse(dt.Rows[i]["cnnFee"].ToString());
				}
				this.txtCount.Text=consCount.ToString();
				this.txtTolFee.Text=consfee.ToString();
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("流水号,会员卡号,车牌号,油料名称,油料型号,计量单位,密度,数量,单价,金额,备注,单位名称,消费日期","120,80,100,50,50,60,50,80,80,100,80",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询小票出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnPrint_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strcon=SysInitial.ConString;
				DevExpress.XtraPrinting.PrintingSystem ps=new DevExpress.XtraPrinting.PrintingSystem();
				DevExpress.XtraReports.UI.XtraReport report1=new CMSM.Report.xrConsTiny(dataGrid1[dataGrid1.CurrentRowIndex,0].ToString(),strcon);
				report1.PrintingSystem=ps;
				report1.CreateDocument();
				ps.PageSettings.TopMargin=0;
				ps.PageSettings.LeftMargin=-5;
				ps.PageSettings.RightMargin=600;
				ps.PageSettings.BottomMargin=0;
//				report1.ShowPreview();
				report1.Print();
			}
			else
			{
				MessageBox.Show("请选择要重打的小票！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void txtCardID_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8||e.KeyChar==42)
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)
				{
					e.Handled=true;
					return;
				}
			}
			else
			{
				this.DgBind();
			}
		}
	}
}
