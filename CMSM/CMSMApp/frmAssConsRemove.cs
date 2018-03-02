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
	/// Summary description for frmAssCons.
	/// </summary>
	public class frmAssConsRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		public DevExpress.XtraEditors.SimpleButton sbtnRead;
		private System.Windows.Forms.Label label5;
		public DevExpress.XtraEditors.SimpleButton sbtnOk;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtTolCharge;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.TextBox txtCount;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label14;
		DataTable dtConsItem;
		private System.Windows.Forms.Label lblerr;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox txtLicenseTags;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPrice;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnRollback;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbl3;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cmbUnit;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblUnit;
		private System.Windows.Forms.TextBox txtCurStorage;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtDensity;
		private System.Windows.Forms.TextBox txtGoodsType;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtCompID;
		private System.Windows.Forms.Label lblUnit2;
		private System.Windows.Forms.TextBox txtInputCardID;
		private System.Windows.Forms.TextBox txtKGCount;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

		public frmAssConsRemove()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtInputCardID = new System.Windows.Forms.TextBox();
			this.lblUnit2 = new System.Windows.Forms.Label();
			this.txtDensity = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtCurStorage = new System.Windows.Forms.TextBox();
			this.lblUnit = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.cmbUnit = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.label14 = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.sbtnRollback = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sbtnRead = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblerr = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtCharge = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtLicenseTags = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCompName = new System.Windows.Forms.TextBox();
			this.lbl3 = new System.Windows.Forms.Label();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtGoodsType = new System.Windows.Forms.TextBox();
			this.txtCompID = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtTolCharge = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTolCount = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtKGCount = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtKGCount);
			this.groupBox1.Controls.Add(this.txtInputCardID);
			this.groupBox1.Controls.Add(this.lblUnit2);
			this.groupBox1.Controls.Add(this.txtDensity);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.txtCurStorage);
			this.groupBox1.Controls.Add(this.lblUnit);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.cmbUnit);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.txtComments);
			this.groupBox1.Controls.Add(this.cmbGoodsName);
			this.groupBox1.Controls.Add(this.sbtnAdd);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtCount);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtPrice);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.sbtnRollback);
			this.groupBox1.Controls.Add(this.sbtnCancel);
			this.groupBox1.Controls.Add(this.sbtnOk);
			this.groupBox1.Controls.Add(this.cmbGoodsType);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.sbtnRead);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 578);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "消费栏目";
			// 
			// txtInputCardID
			// 
			this.txtInputCardID.Location = new System.Drawing.Point(8, 24);
			this.txtInputCardID.Name = "txtInputCardID";
			this.txtInputCardID.Size = new System.Drawing.Size(112, 21);
			this.txtInputCardID.TabIndex = 40;
			this.txtInputCardID.Text = "";
			// 
			// lblUnit2
			// 
			this.lblUnit2.Location = new System.Drawing.Point(184, 272);
			this.lblUnit2.Name = "lblUnit2";
			this.lblUnit2.Size = new System.Drawing.Size(24, 16);
			this.lblUnit2.TabIndex = 39;
			this.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDensity
			// 
			this.txtDensity.Location = new System.Drawing.Point(80, 192);
			this.txtDensity.MaxLength = 10;
			this.txtDensity.Name = "txtDensity";
			this.txtDensity.Size = new System.Drawing.Size(112, 21);
			this.txtDensity.TabIndex = 38;
			this.txtDensity.Text = "0";
			this.txtDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(16, 200);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 37;
			this.label18.Text = "当前密度";
			// 
			// txtCurStorage
			// 
			this.txtCurStorage.Location = new System.Drawing.Point(80, 160);
			this.txtCurStorage.MaxLength = 10;
			this.txtCurStorage.Name = "txtCurStorage";
			this.txtCurStorage.Size = new System.Drawing.Size(112, 21);
			this.txtCurStorage.TabIndex = 36;
			this.txtCurStorage.Text = "0";
			this.txtCurStorage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCurStorage.GotFocus += new System.EventHandler(this.txtCurStorage_GotFocus);
			// 
			// lblUnit
			// 
			this.lblUnit.Location = new System.Drawing.Point(192, 168);
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.Size = new System.Drawing.Size(24, 16);
			this.lblUnit.TabIndex = 35;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(16, 168);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 34;
			this.label16.Text = "当前库存";
			// 
			// cmbUnit
			// 
			this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUnit.Location = new System.Drawing.Point(80, 128);
			this.cmbUnit.Name = "cmbUnit";
			this.cmbUnit.Size = new System.Drawing.Size(136, 20);
			this.cmbUnit.TabIndex = 2;
			this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(32, 136);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 16);
			this.label15.TabIndex = 32;
			this.label15.Text = "单位";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 400);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 29;
			this.label17.Text = "备注";
			// 
			// txtComments
			// 
			this.txtComments.Location = new System.Drawing.Point(8, 424);
			this.txtComments.MaxLength = 100;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtComments.Size = new System.Drawing.Size(216, 136);
			this.txtComments.TabIndex = 28;
			this.txtComments.Text = "";
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Location = new System.Drawing.Point(80, 64);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
			this.cmbGoodsName.TabIndex = 0;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAdd.Location = new System.Drawing.Point(144, 304);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.Size = new System.Drawing.Size(56, 23);
			this.sbtnAdd.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAdd.TabIndex = 26;
			this.sbtnAdd.Text = "确定(F7)";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(184, 240);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 16);
			this.label14.TabIndex = 20;
			this.label14.Text = "元/KG";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtCount
			// 
			this.txtCount.Location = new System.Drawing.Point(80, 264);
			this.txtCount.MaxLength = 10;
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(104, 21);
			this.txtCount.TabIndex = 4;
			this.txtCount.Text = "0";
			this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 272);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 19;
			this.label8.Text = "数量";
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(80, 232);
			this.txtPrice.MaxLength = 10;
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(104, 21);
			this.txtPrice.TabIndex = 3;
			this.txtPrice.Text = "0";
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "单价";
			// 
			// sbtnRollback
			// 
			this.sbtnRollback.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnRollback.Location = new System.Drawing.Point(48, 304);
			this.sbtnRollback.Name = "sbtnRollback";
			this.sbtnRollback.Size = new System.Drawing.Size(56, 23);
			this.sbtnRollback.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnRollback.TabIndex = 5;
			this.sbtnRollback.Text = "<<撤消";
			this.sbtnRollback.Visible = false;
			this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(144, 344);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 7;
			this.sbtnCancel.Text = "关闭";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(48, 344);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 6;
			this.sbtnOk.Text = "撤销(F6)";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.Location = new System.Drawing.Point(80, 96);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(136, 20);
			this.cmbGoodsType.TabIndex = 1;
			this.cmbGoodsType.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsType_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "物料型号";
			// 
			// sbtnRead
			// 
			this.sbtnRead.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnRead.Location = new System.Drawing.Point(128, 24);
			this.sbtnRead.Name = "sbtnRead";
			this.sbtnRead.Size = new System.Drawing.Size(96, 23);
			this.sbtnRead.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnRead.TabIndex = 0;
			this.sbtnRead.Text = "输入卡号(F5)";
			this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "物料名称";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.lblerr);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.txtCharge);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.txtLicenseTags);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.txtCompName);
			this.groupBox2.Controls.Add(this.lbl3);
			this.groupBox2.Controls.Add(this.txtCardID);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.txtGoodsType);
			this.groupBox2.Controls.Add(this.txtCompID);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(232, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(796, 120);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "会员信息";
			// 
			// lblerr
			// 
			this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.lblerr.Location = new System.Drawing.Point(8, 24);
			this.lblerr.Name = "lblerr";
			this.lblerr.Size = new System.Drawing.Size(760, 64);
			this.lblerr.TabIndex = 23;
			this.lblerr.Visible = false;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(424, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 32);
			this.label4.TabIndex = 24;
			this.label4.Text = "注：请仔细核对车牌号和油号是否正确";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(200, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(24, 16);
			this.label13.TabIndex = 19;
			this.label13.Text = "元";
			// 
			// txtCharge
			// 
			this.txtCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCharge.Location = new System.Drawing.Point(96, 64);
			this.txtCharge.MaxLength = 10;
			this.txtCharge.Name = "txtCharge";
			this.txtCharge.Size = new System.Drawing.Size(104, 21);
			this.txtCharge.TabIndex = 18;
			this.txtCharge.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(32, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 17;
			this.label11.Text = "当前余额";
			// 
			// txtLicenseTags
			// 
			this.txtLicenseTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLicenseTags.Location = new System.Drawing.Point(312, 24);
			this.txtLicenseTags.MaxLength = 10;
			this.txtLicenseTags.Name = "txtLicenseTags";
			this.txtLicenseTags.Size = new System.Drawing.Size(104, 21);
			this.txtLicenseTags.TabIndex = 14;
			this.txtLicenseTags.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.DarkRed;
			this.label7.Location = new System.Drawing.Point(248, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "车牌号";
			// 
			// txtCompName
			// 
			this.txtCompName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCompName.Location = new System.Drawing.Point(96, 96);
			this.txtCompName.MaxLength = 30;
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(320, 21);
			this.txtCompName.TabIndex = 3;
			this.txtCompName.Text = "";
			// 
			// lbl3
			// 
			this.lbl3.Location = new System.Drawing.Point(32, 104);
			this.lbl3.Name = "lbl3";
			this.lbl3.Size = new System.Drawing.Size(64, 16);
			this.lbl3.TabIndex = 4;
			this.lbl3.Text = "单位名称";
			// 
			// txtCardID
			// 
			this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCardID.Location = new System.Drawing.Point(96, 24);
			this.txtCardID.MaxLength = 10;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(104, 21);
			this.txtCardID.TabIndex = 2;
			this.txtCardID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "会员卡号";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(248, 72);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 16);
			this.label19.TabIndex = 26;
			this.label19.Text = "油  号";
			// 
			// txtGoodsType
			// 
			this.txtGoodsType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGoodsType.Location = new System.Drawing.Point(312, 64);
			this.txtGoodsType.MaxLength = 30;
			this.txtGoodsType.Name = "txtGoodsType";
			this.txtGoodsType.Size = new System.Drawing.Size(104, 21);
			this.txtGoodsType.TabIndex = 25;
			this.txtGoodsType.Text = "";
			// 
			// txtCompID
			// 
			this.txtCompID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCompID.Location = new System.Drawing.Point(480, 56);
			this.txtCompID.MaxLength = 30;
			this.txtCompID.Name = "txtCompID";
			this.txtCompID.Size = new System.Drawing.Size(104, 21);
			this.txtCompID.TabIndex = 27;
			this.txtCompID.Text = "";
			this.txtCompID.Visible = false;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(232, 120);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(796, 394);
			this.dataGrid1.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.txtTolCharge);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.txtTolCount);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox3.Location = new System.Drawing.Point(232, 514);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(796, 64);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "消费合计：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(224, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "升";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(448, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(24, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "元";
			// 
			// txtTolCharge
			// 
			this.txtTolCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTolCharge.Location = new System.Drawing.Point(352, 24);
			this.txtTolCharge.MaxLength = 10;
			this.txtTolCharge.Name = "txtTolCharge";
			this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
			this.txtTolCharge.TabIndex = 6;
			this.txtTolCharge.Text = "0";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(288, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 5;
			this.label10.Text = "总金额：";
			// 
			// txtTolCount
			// 
			this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTolCount.Location = new System.Drawing.Point(128, 24);
			this.txtTolCount.MaxLength = 10;
			this.txtTolCount.Name = "txtTolCount";
			this.txtTolCount.Size = new System.Drawing.Size(96, 21);
			this.txtTolCount.TabIndex = 4;
			this.txtTolCount.Text = "0";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(64, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 3;
			this.label9.Text = "总数量：";
			// 
			// txtKGCount
			// 
			this.txtKGCount.Location = new System.Drawing.Point(112, 384);
			this.txtKGCount.Name = "txtKGCount";
			this.txtKGCount.TabIndex = 41;
			this.txtKGCount.Text = "";
			this.txtKGCount.Visible = false;
			// 
			// frmAssConsRemove
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1028, 578);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.KeyPreview = true;
			this.Name = "frmAssConsRemove";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员消费撤销";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAssCons_KeyDown);
			this.Load += new System.EventHandler(this.frmAssCons_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAssCons_Load(object sender, System.EventArgs e)
		{
			txtCardID.ReadOnly=true;
			txtCompName.ReadOnly=true;
			txtLicenseTags.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtCount.ReadOnly=true;
			lblerr.Visible=false;
			txtPrice.ReadOnly=true;
			cmbGoodsName.Enabled=false;
			cmbGoodsType.Enabled=false;
			cmbUnit.Enabled=false;
			txtCurStorage.ReadOnly=true;
			txtDensity.ReadOnly=true;
			txtGoodsType.ReadOnly=true;
			txtCompID.Text="";

			groupBox2.BackColor=Color.AliceBlue;
			groupBox3.BackColor=Color.Snow;
			this.label4.ForeColor=Color.Red;
			this.label7.ForeColor=Color.DarkRed;

			sbtnRollback.ToolTip="撤消已选商品，每次撤消数量为1";

			dtConsItem=new DataTable();
			dtConsItem.Columns.Add("GoodsName");
			dtConsItem.Columns.Add("GoodsType");
			dtConsItem.Columns.Add("Unit");
			dtConsItem.Columns.Add("Count");
			dtConsItem.Columns.Add("Price");
			dtConsItem.Columns.Add("Fee");
			dtConsItem.Columns.Add("Density");
			dtConsItem.Columns.Add("KGCount");
			dtConsItem.Columns.Add("Comments");
			dtConsItem.Columns["Comments"].DefaultValue="";
			DgBind();

			this.txtInputCardID.Focus();
		}

		public void sbtnRead_Click(object sender, System.EventArgs e)
		{
			//string strresult="";
			MessageBox.Show("撤销功能只能针对上笔消费记录！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			lblerr.Visible=false;
			chs= new CMSMStruct.CardHardStruct();//cs.ReadCardInfo(out strresult);
			chs.strCardID = this.txtInputCardID.Text;
//			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
//			{
//				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
//				{
//					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
//				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				if(strresult!="")
//				{
//					clog.WriteLine(strresult);
//				}
//				return;
//			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			
			err=null;
			CMSMData.CMSMStruct.MemberStruct mebres=new CMSMData.CMSMStruct.MemberStruct();
			string strDeptNameTmp= CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp;
			mebres=cs.GetMemberDetail(chs.strCardID,strDeptNameTmp,out err);
			if(mebres!=null)
			{
				string strEmpState=mebres.strState;
				if(strEmpState!="0")
				{
					MessageBox.Show("该会员已经失效，卡号：" + chs.strCardID + "，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(mebres.strDeptName!=SysInitial.LocalDeptName)
				{
					MessageBox.Show("指定加油站不符，不能在此加油站加油！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}

				err=null;
				CMSMStruct.CompDeptStruct comp1=cs.GetMebCompDetial(mebres.strCompanyID,out err);
				if(comp1==null)
				{
					MessageBox.Show("获取会员单位信息出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				//				if(double.Parse(comp1.strPrepayBalance)<=0)
				//				{
				//					MessageBox.Show("当前余额不足，不能消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				//					return;
				//				}
				//				else
				//				{
				txtCharge.Text=comp1.strPrepayBalance;
				//}

				DataTable dtConsItem = cs.GetAssConsLast(chs.strCardID,strDeptNameTmp,out err);

				if(err!=null)
				{
					MessageBox.Show(err.Message,"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					return;
				}
				txtCompID.Text=comp1.strCompanyID;
				txtCardID.Text=mebres.strCardID;
				txtCompName.Text=mebres.strCompanyName;
				txtLicenseTags.Text=mebres.strLicenseTag;
				txtGoodsType.Text=mebres.strGoodsType;
				//cmbGoodsName.Enabled=true;
				//cmbGoodsType.Enabled=true;
				//cmbUnit.Enabled=true;
				txtCount.ReadOnly=true;
				//sbtnRead.Enabled=false;
				//txtCount.ReadOnly=false;
				txtGoodsType.ReadOnly=true;

				string strGoodsName=dtConsItem.Rows[0]["cnvcGoodsName"].ToString();
				string strGoodsType=dtConsItem.Rows[0]["cnvcGoodsType"].ToString();

				this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
				this.cmbGoodsName.SelectedIndex=cmbGoodsName.FindString(strGoodsName);
				this.cmbGoodsType.SelectedIndex=cmbGoodsType.FindString(strGoodsType);
				this.cmbUnit.Items.Add("升");
				this.cmbUnit.SelectedIndex=0;
				this.cmbUnit.Enabled=false;
				lblUnit.Text=cmbUnit.Text.Trim();
				lblUnit2.Text=cmbUnit.Text.Trim();
				//				if(cmbGoodsName.Text.Trim()!=""&&cmbGoodsType.Text.Trim()!=""&&cmbUnit.Text.Trim()!="")
				//				{
				//					err=null;
				CMSMStruct.AssConsParaStruct acp=cs.GetCurOilPrice(cmbGoodsName.Text.Trim(),cmbGoodsType.Text.Trim(),"KG",out err);
				txtPrice.Text=dtConsItem.Rows[0]["cnnPrice"].ToString();//acp.strPrice;
				txtDensity.Text=dtConsItem.Rows[0]["cnnDensity"].ToString();
//				if(double.Parse(acp.strDensity)==0)
//				{
//					MessageBox.Show("密度参数不全！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;						
//				}
				if(cmbUnit.Text.Trim()=="升")
				{
					txtCurStorage.Text=(Math.Round((double.Parse(acp.strCurStorageCount)/double.Parse(dtConsItem.Rows[0]["cnnDensity"].ToString())),2)).ToString();
				}
				//					else if(cmbUnit.Text.Trim()=="KG")
				//					{
				//						txtCurStorage.Text=acp.strCurStorageCount;
				//					}
				//					else if(cmbUnit.Text.Trim()=="吨")
				//					{
				//						txtCurStorage.Text=(Math.Round((double.Parse(acp.strCurStorageCount)/1000),2)).ToString();
				//					}
				lblUnit.Text=cmbUnit.Text.Trim();
				lblUnit2.Text=cmbUnit.Text.Trim();
				this.txtCount.Text = dtConsItem.Rows[0]["cnnCount"].ToString();
				this.txtKGCount.Text = dtConsItem.Rows[0]["cnnKGCount"].ToString();
				//}
				//cmbGoodsName.Focus();
			}
			else
			{
				MessageBox.Show("无会员资料或会员卡已经失效，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}
		}

		private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8||e.KeyChar==46)
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)
				{
					e.Handled=true;
					return;
				}
			}
		}

		public void sbtnOk_Click(object sender, System.EventArgs e)
		{
			lblerr.Visible=false;

			double dConscount=double.Parse(txtTolCount.Text.Trim());
			err=null;
			CMSMStruct.OilStorageStruct oils=cs.GetOilStorageDetail(dtConsItem.Rows[0]["GoodsName"].ToString(),dtConsItem.Rows[0]["GoodsType"].ToString(),out err);
			double dCurShengCount=Math.Round(oils.dStorageCount/double.Parse(txtDensity.Text.Trim()),2);
			if(err!=null||oils==null)
			{
				MessageBox.Show("获取当前库存出错，请检查当前库存信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
//			else if(dCurShengCount<dConscount)
//			{
//				MessageBox.Show("当前库存不足，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}

//			chs=cs.ReadCardInfo(out strresult);
//			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
//			{
//				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
//				{
//					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
//				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				if(strresult!="")
//				{
//					clog.WriteLine(strresult);
//				}
//				return;
//			}
//			if(chs.strCardID=="")
//			{
//				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}

//			if(chs.strCardID!=txtCardID.Text.Trim())
//			{
//				MessageBox.Show("结帐卡与首次刷卡不是同一张卡，结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				this.ClearText();
//				cmbGoodsName.Enabled=false;
//				cmbGoodsType.Enabled=false;
//				txtCount.ReadOnly=true;
//				sbtnRead.Enabled=true;
//				txtTolCount.Text="0";
//				txtTolCharge.Text="0";
//				dtConsItem=new DataTable();
//				dtConsItem.Columns.Add("GoodsName");
//				dtConsItem.Columns.Add("GoodsType");
//				dtConsItem.Columns.Add("Unit");
//				dtConsItem.Columns.Add("Count");
//				dtConsItem.Columns.Add("Price");
//				dtConsItem.Columns.Add("Fee");
//				dtConsItem.Columns.Add("Density");
//				dtConsItem.Columns.Add("KGCount");
//				dtConsItem.Columns.Add("Comments");
//				dtConsItem.Columns["Comments"].DefaultValue="";
//				this.DgBind();
//				
//				return;
//			}
//			else
//			{
//
//			}

			#region 开始结帐
			if(dtConsItem.Rows.Count<=0)
			{
				MessageBox.Show("没有进行任何撤销！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			err=null;
			CMSMStruct.CompDeptStruct comp1=cs.GetMebCompDetial(txtCompID.Text.Trim(),out err);
			if(comp1==null)
			{
				MessageBox.Show("获取会员单位信息出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
//			if(double.Parse(comp1.strPrepayBalance)<=0)
//			{
//				MessageBox.Show("当前余额不足，不能消费，请重新进入消费功能界面！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				this.Close();
//				return;
//			}

			double dTolCharge=double.Parse(txtTolCharge.Text.Trim());
//			if(double.Parse(comp1.strPrepayBalance)<dTolCharge)
//			{
//				MessageBox.Show("当前余额不足，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strCardID=txtCardID.Text.Trim();
			cis.strLicenseTags=txtLicenseTags.Text.Trim();
			cis.strComments=txtComments.Text.Trim();
			cis.strConsType="消费撤销";
			cis.strConsDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.strDeptName=SysInitial.LocalDeptName;
			cis.strDeptID=SysInitial.LocalDeptID;
			cis.strCompanyID=comp1.strCompanyID;
			cis.strAcctID=comp1.strAcctID;
			cis.strOperDate=cis.strConsDate;
			cis.strCompanyName=txtCompName.Text.Trim();
			cis.strGoodsName=dtConsItem.Rows[0]["GoodsName"].ToString();
			cis.strGoodsType=dtConsItem.Rows[0]["GoodsType"].ToString();
			cis.strUnit=dtConsItem.Rows[0]["Unit"].ToString();
			cis.dCount=double.Parse(txtTolCount.Text.Trim());
			cis.dFee=dTolCharge;
			cis.dPrice=double.Parse(dtConsItem.Rows[0]["Price"].ToString());
			cis.dStorageLast=oils.dStorageCount;
			cis.dDensity=double.Parse(dtConsItem.Rows[0]["Density"].ToString());
			cis.dKGCount=double.Parse(dtConsItem.Rows[0]["KGCount"].ToString());
			cis.strCurStorage=(Math.Round((cis.dStorageLast+cis.dKGCount),2)).ToString();

			err=null;
			string strSerialok="";
			if(cs.AssConsRemove(cis,out err,out strSerialok))
			{
				MessageBox.Show("撤销成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//				if(strSerialok=="")
//				{
//					MessageBox.Show("打印小票错误！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
//				else
//				{
//					this.PrintBill(strSerialok);
//				}
			}
			else
			{
				MessageBox.Show("撤销失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				lblerr.Text="撤销失败，本次撤销无效，请检查余额是否正确！";
				lblerr.Visible=true;
				clog.WriteLine(err);
			}
			this.ClearText();
			cmbGoodsName.Enabled=false;
			txtCount.ReadOnly=true;
			sbtnRead.Enabled=true;
			txtTolCount.Text="0";
			txtTolCharge.Text="0";
			dtConsItem=new DataTable();
			dtConsItem.Columns.Add("GoodsName");
			dtConsItem.Columns.Add("GoodsType");
			dtConsItem.Columns.Add("Unit");
			dtConsItem.Columns.Add("Count");
			dtConsItem.Columns.Add("Price");
			dtConsItem.Columns.Add("Fee");
			dtConsItem.Columns.Add("Density");
			dtConsItem.Columns.Add("KGCount");
			dtConsItem.Columns.Add("Comments");
			dtConsItem.Columns["Comments"].DefaultValue="";
			this.DgBind();
			#endregion
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsName=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsName==dtConsItem.Rows[i]["GoodsName"].ToString())
					{
						dtConsItem.Rows.Remove(dtConsItem.Rows[i]);
					}
				}
				cmbGoodsName.Enabled=true;
				cmbGoodsType.Enabled=true;
				cmbUnit.Enabled=true;
				this.DgBind();
			}
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;
				double dTolFee=0;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
					dTolFee+=double.Parse(dtConsItem.Rows[i]["Fee"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolCharge.Text=dTolFee.ToString();
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("物料名称,型号,单位,升数量,单价,应收金额,密度,公斤数量,备注","100,170,100,100,60,100",dtConsItem,this.dataGrid1);
			}
		}

		private void PrintBill(string strSerial)
		{
			try
			{
				string strcon=SysInitial.ConString;
				DevExpress.XtraPrinting.PrintingSystem ps=new DevExpress.XtraPrinting.PrintingSystem();
				DevExpress.XtraReports.UI.XtraReport report1=new CMSM.Report.xrConsTiny(strSerial,strcon);
				report1.PrintingSystem=ps;
				report1.CreateDocument();
				ps.PageSettings.TopMargin=0;
				ps.PageSettings.LeftMargin=-5;
				ps.PageSettings.RightMargin=600;
				ps.PageSettings.BottomMargin=0;
				for(int i=0;i<2;i++)
				{
					//				report1.ShowPreview();
					report1.Print();
				}
			}
			catch(Exception e)
			{
				MessageBox.Show("打印机设置有误，无法打印！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				lblerr.Text="消费已成功，但打印机有误，无法打印小票！";
				lblerr.Visible=true;
				clog.WriteLine(e.ToString());
			}
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
			this.txtCurStorage.Text="请点击此处...";
			this.txtDensity.Text="";
			this.lblUnit.Text="";
			this.lblUnit2.Text="";
			this.txtPrice.Text="0";
		}

		private void frmAssCons_KeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
				case Keys.F5:   
					sbtnRead.PerformClick(); 
					break;
				case Keys.F6:   
					sbtnOk.PerformClick();   
					break;
				case Keys.F7:
					sbtnAdd.PerformClick();
					break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			string strGoodsName="";
			string strGoodsType="";
			if(dtConsItem.Rows.Count>0)
			{
				MessageBox.Show("每张卡只能操作一次加油，如果要再次加油，请完结账再次刷卡加油！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
			{
				MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtPrice.Text="0";
				txtCount.Text="0";
				return;
			}
			else
			{
				strGoodsName=cmbGoodsName.Text.Trim();
				strGoodsType=cmbGoodsType.Text.Trim();
			}

			double dCount=0;
			if(txtCount.Text.Trim()=="")
			{
				MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dCount=double.Parse(txtCount.Text.Trim());
			}
			if(dCount==0)
			{
				MessageBox.Show("数量不能为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			double dDensity=0;
			if(txtDensity.Text.Trim()==""||txtDensity.Text.Trim()=="请点击此处...")
			{
				MessageBox.Show("密度不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dDensity=double.Parse(txtDensity.Text.Trim());
			}
			if(dDensity==0)
			{
				MessageBox.Show("密度不能为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			double dPrice=0;
			if(txtPrice.Text.Trim()==""||txtPrice.Text.Trim()=="请点击此处...")
			{
				MessageBox.Show("单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dPrice=double.Parse(txtPrice.Text.Trim());
			}
			if(dPrice==0)
			{
				MessageBox.Show("单价不能为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

//			if((double.Parse(txtTolCharge.Text.Trim())+dPrice*dDensity*dCount)>double.Parse(txtCharge.Text.Trim()))
//			{
//				MessageBox.Show("所剩余额不能再购买此商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}

//			if(double.Parse(txtCurStorage.Text.Trim())==0||double.Parse(txtCurStorage.Text.Trim())<(dCount+double.Parse(txtTolCount.Text.Trim())))
//			{
//				MessageBox.Show("当前库存不足！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
			err=null;
			double dKgCount=double.Parse(this.txtKGCount.Text);//Math.Round(dCount*double.Parse(txtDensity.Text.Trim()),2);
//			double dFee=Math.Round(dKgCount*dPrice,2);

			if(dtConsItem.Rows.Count==0)
			{
				DataRow drnew=dtConsItem.NewRow();
				drnew["GoodsName"]=cmbGoodsName.Text.Trim();
				drnew["GoodsType"]=cmbGoodsType.Text.Trim();
				drnew["Unit"]=cmbUnit.Text.Trim();
				drnew["Price"]=txtPrice.Text.Trim();
				drnew["Count"]=txtCount.Text.Trim();
				drnew["Fee"]=(Math.Round(dKgCount*dPrice,2)).ToString();
				drnew["Density"]=txtDensity.Text.Trim();
				drnew["KGCount"]=(Math.Round(dKgCount,2)).ToString();
				drnew["Comments"]=txtComments.Text.Trim();
				dtConsItem.Rows.Add(drnew);
			}
			else
			{
				bool sumflag=false;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsName==dtConsItem.Rows[i]["GoodsName"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
						dtConsItem.Rows[i]["Fee"]=(Math.Round(((double.Parse(dtConsItem.Rows[i]["KGCount"].ToString()) + dKgCount)* dPrice),2)).ToString();
//						dtConsItem.Rows[i]["KGCount"]=Math.Round(double.Parse(dtConsItem.Rows[i]["Count"].ToString())*double.Parse(dtConsItem.Rows[i]["Density"].ToString()),2).ToString();
						string aa=dtConsItem.Rows[i]["KGCount"].ToString();
						dtConsItem.Rows[i]["KGCount"]=(Math.Round((double.Parse(dtConsItem.Rows[i]["KGCount"].ToString())+dKgCount),2)).ToString();
						sumflag=true;
						break;
					}
				}
				if(!sumflag)
				{
					MessageBox.Show("每次刷卡只能消费一个型号的油！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
			cmbGoodsName.Enabled=false;
			cmbGoodsType.Enabled=false;
			cmbUnit.Enabled=false;
			this.DgBind();
		}

		private void cmbGoodsType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtCurStorage.Text="请点击此处...";
			this.txtDensity.Text="";
			this.lblUnit.Text="";
			this.txtPrice.Text="0";
		}

		private void cmbUnit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtCurStorage.Text="请点击此处...";
			this.txtDensity.Text="";
			this.lblUnit.Text="";
			this.txtPrice.Text="0";
		}

		private void txtCurStorage_GotFocus(object sender, EventArgs e)
		{
			
		}
	}
}
