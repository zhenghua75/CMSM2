using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using CMSM.Common;
using CMSM.Entity;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmBillOfValidateAdd.
	/// </summary>
	public class frmBillOfValidateAdd : CMSM.CMSMApp.frmBase
	{
		#region 字段
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBillNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOutNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDeliveryComp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpProvideDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTrLicenseTags;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTransportMan;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtOriginalCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtValidateCount;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDistance;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtTransportLose;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtLose;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtQuotaLose;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtProvideAddress;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox cmbInType;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.TextBox txtQuterLose;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cmbGoodsType;		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cmbProvideCompany;
		private System.Windows.Forms.Label label23;
		CommAccess cs=new CommAccess(CMSMData.CMSMDataAccess.SysInitial.ConString);
		#endregion
		public frmBillOfValidateAdd()
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtBillNo = new System.Windows.Forms.TextBox();
			this.txtOutNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDeliveryComp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpProvideDate = new System.Windows.Forms.DateTimePicker();
			this.txtTrLicenseTags = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTransportMan = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtOriginalCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtValidateCount = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDistance = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTransportLose = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtLose = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtQuotaLose = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtQuterLose = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtProvideAddress = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.cmbInType = new System.Windows.Forms.ComboBox();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label17 = new System.Windows.Forms.Label();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.cmbProvideCompany = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "收油核对单号";
			// 
			// txtBillNo
			// 
			this.txtBillNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillNo.Location = new System.Drawing.Point(112, 64);
			this.txtBillNo.MaxLength = 20;
			this.txtBillNo.Name = "txtBillNo";
			this.txtBillNo.Size = new System.Drawing.Size(184, 22);
			this.txtBillNo.TabIndex = 2;
			this.txtBillNo.Text = "";
			// 
			// txtOutNo
			// 
			this.txtOutNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtOutNo.Location = new System.Drawing.Point(408, 64);
			this.txtOutNo.MaxLength = 20;
			this.txtOutNo.Name = "txtOutNo";
			this.txtOutNo.Size = new System.Drawing.Size(192, 22);
			this.txtOutNo.TabIndex = 3;
			this.txtOutNo.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(344, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "出库单号";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "供油单位";
			// 
			// txtDeliveryComp
			// 
			this.txtDeliveryComp.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtDeliveryComp.Location = new System.Drawing.Point(408, 104);
			this.txtDeliveryComp.MaxLength = 25;
			this.txtDeliveryComp.Name = "txtDeliveryComp";
			this.txtDeliveryComp.Size = new System.Drawing.Size(192, 22);
			this.txtDeliveryComp.TabIndex = 6;
			this.txtDeliveryComp.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(344, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "收油单位";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(632, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "发油日期";
			// 
			// dtpProvideDate
			// 
			this.dtpProvideDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpProvideDate.Location = new System.Drawing.Point(696, 104);
			this.dtpProvideDate.Name = "dtpProvideDate";
			this.dtpProvideDate.Size = new System.Drawing.Size(144, 22);
			this.dtpProvideDate.TabIndex = 7;
			// 
			// txtTrLicenseTags
			// 
			this.txtTrLicenseTags.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTrLicenseTags.Location = new System.Drawing.Point(112, 144);
			this.txtTrLicenseTags.MaxLength = 20;
			this.txtTrLicenseTags.Name = "txtTrLicenseTags";
			this.txtTrLicenseTags.Size = new System.Drawing.Size(184, 22);
			this.txtTrLicenseTags.TabIndex = 8;
			this.txtTrLicenseTags.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "运输车号";
			// 
			// txtTransportMan
			// 
			this.txtTransportMan.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTransportMan.Location = new System.Drawing.Point(408, 144);
			this.txtTransportMan.MaxLength = 20;
			this.txtTransportMan.Name = "txtTransportMan";
			this.txtTransportMan.Size = new System.Drawing.Size(192, 22);
			this.txtTransportMan.TabIndex = 9;
			this.txtTransportMan.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(344, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "承运人";
			// 
			// txtOriginalCount
			// 
			this.txtOriginalCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtOriginalCount.Location = new System.Drawing.Point(112, 184);
			this.txtOriginalCount.Name = "txtOriginalCount";
			this.txtOriginalCount.Size = new System.Drawing.Size(184, 22);
			this.txtOriginalCount.TabIndex = 11;
			this.txtOriginalCount.Text = "";
			this.txtOriginalCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalCount_KeyPress);
			this.txtOriginalCount.TextChanged += new System.EventHandler(this.txtOriginalCount_TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(48, 192);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "原发数";
			// 
			// txtValidateCount
			// 
			this.txtValidateCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtValidateCount.Location = new System.Drawing.Point(408, 184);
			this.txtValidateCount.Name = "txtValidateCount";
			this.txtValidateCount.Size = new System.Drawing.Size(192, 22);
			this.txtValidateCount.TabIndex = 12;
			this.txtValidateCount.Text = "";
			this.txtValidateCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidateCount_KeyPress);
			this.txtValidateCount.TextChanged += new System.EventHandler(this.txtValidateCount_TextChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(344, 192);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "验收数";
			// 
			// txtDistance
			// 
			this.txtDistance.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtDistance.Location = new System.Drawing.Point(696, 184);
			this.txtDistance.Name = "txtDistance";
			this.txtDistance.Size = new System.Drawing.Size(112, 22);
			this.txtDistance.TabIndex = 13;
			this.txtDistance.Text = "";
			this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
			this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(616, 192);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 16);
			this.label10.TabIndex = 18;
			this.label10.Text = "运输公里数";
			// 
			// txtTransportLose
			// 
			this.txtTransportLose.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTransportLose.Location = new System.Drawing.Point(112, 224);
			this.txtTransportLose.Name = "txtTransportLose";
			this.txtTransportLose.Size = new System.Drawing.Size(184, 22);
			this.txtTransportLose.TabIndex = 14;
			this.txtTransportLose.Text = "";
			this.txtTransportLose.GotFocus += new System.EventHandler(this.txtTransportLose_GotFocus);
			this.txtTransportLose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransportLose_KeyPress);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 232);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 16);
			this.label11.TabIndex = 20;
			this.label11.Text = "运输损耗定额";
			// 
			// txtLose
			// 
			this.txtLose.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLose.Location = new System.Drawing.Point(408, 224);
			this.txtLose.Name = "txtLose";
			this.txtLose.Size = new System.Drawing.Size(192, 22);
			this.txtLose.TabIndex = 15;
			this.txtLose.Text = "";
			this.txtLose.TextChanged += new System.EventHandler(this.txtLose_TextChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(344, 232);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 22;
			this.label12.Text = "实际损耗";
			// 
			// txtQuotaLose
			// 
			this.txtQuotaLose.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtQuotaLose.Location = new System.Drawing.Point(112, 264);
			this.txtQuotaLose.Name = "txtQuotaLose";
			this.txtQuotaLose.Size = new System.Drawing.Size(184, 22);
			this.txtQuotaLose.TabIndex = 16;
			this.txtQuotaLose.Text = "";
			this.txtQuotaLose.TextChanged += new System.EventHandler(this.txtQuotaLose_TextChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 272);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 16);
			this.label13.TabIndex = 24;
			this.label13.Text = "定额内运输损耗";
			// 
			// txtQuterLose
			// 
			this.txtQuterLose.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtQuterLose.Location = new System.Drawing.Point(408, 264);
			this.txtQuterLose.Name = "txtQuterLose";
			this.txtQuterLose.Size = new System.Drawing.Size(192, 22);
			this.txtQuterLose.TabIndex = 17;
			this.txtQuterLose.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(304, 272);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(104, 16);
			this.label14.TabIndex = 26;
			this.label14.Text = "超定额运输损耗";
			// 
			// txtProvideAddress
			// 
			this.txtProvideAddress.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtProvideAddress.Location = new System.Drawing.Point(112, 304);
			this.txtProvideAddress.MaxLength = 20;
			this.txtProvideAddress.Name = "txtProvideAddress";
			this.txtProvideAddress.Size = new System.Drawing.Size(640, 22);
			this.txtProvideAddress.TabIndex = 18;
			this.txtProvideAddress.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(48, 312);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 28;
			this.label15.Text = "发油地点";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(632, 72);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 30;
			this.label16.Text = "入库方式";
			// 
			// cmbInType
			// 
			this.cmbInType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInType.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbInType.Location = new System.Drawing.Point(696, 64);
			this.cmbInType.Name = "cmbInType";
			this.cmbInType.Size = new System.Drawing.Size(144, 21);
			this.cmbInType.TabIndex = 4;
			this.cmbInType.SelectedIndexChanged += new System.EventHandler(this.cmbInType_SelectedIndexChanged);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(216, 352);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(72, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 19;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(480, 352);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 20;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// label17
			// 
			this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label17.Location = new System.Drawing.Point(48, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 34;
			this.label17.Text = "物料名称";
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbGoodsName.Location = new System.Drawing.Point(112, 16);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(184, 21);
			this.cmbGoodsName.TabIndex = 0;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.Location = new System.Drawing.Point(408, 16);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(192, 20);
			this.cmbGoodsType.TabIndex = 1;
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(344, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 36;
			this.label18.Text = "物料型号";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(632, 24);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 16);
			this.label19.TabIndex = 38;
			this.label19.Text = "单位：KG";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(312, 232);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(24, 16);
			this.label20.TabIndex = 39;
			this.label20.Text = "%";
			// 
			// dtpDeliveryDate
			// 
			this.dtpDeliveryDate.Location = new System.Drawing.Point(696, 144);
			this.dtpDeliveryDate.Name = "dtpDeliveryDate";
			this.dtpDeliveryDate.Size = new System.Drawing.Size(144, 21);
			this.dtpDeliveryDate.TabIndex = 10;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(632, 152);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 16);
			this.label21.TabIndex = 40;
			this.label21.Text = "收油日期";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(816, 192);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 16);
			this.label22.TabIndex = 41;
			this.label22.Text = "公里";
			// 
			// cmbProvideCompany
			// 
			this.cmbProvideCompany.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbProvideCompany.Location = new System.Drawing.Point(112, 104);
			this.cmbProvideCompany.Name = "cmbProvideCompany";
			this.cmbProvideCompany.Size = new System.Drawing.Size(184, 21);
			this.cmbProvideCompany.TabIndex = 5;
			// 
			// label23
			// 
			this.label23.ForeColor = System.Drawing.Color.Red;
			this.label23.Location = new System.Drawing.Point(616, 232);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(240, 64);
			this.label23.TabIndex = 42;
			this.label23.Text = "如果实际损耗小于定额内运输损耗，超定额运输损耗则等于0，请仔细核对单据！（提油计量偏差0.3%）";
			// 
			// frmBillOfValidateAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(864, 390);
			this.ControlBox = false;
			this.Controls.Add(this.label23);
			this.Controls.Add(this.cmbProvideCompany);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.dtpDeliveryDate);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.cmbInType);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.txtProvideAddress);
			this.Controls.Add(this.txtQuterLose);
			this.Controls.Add(this.txtQuotaLose);
			this.Controls.Add(this.txtLose);
			this.Controls.Add(this.txtTransportLose);
			this.Controls.Add(this.txtDistance);
			this.Controls.Add(this.txtValidateCount);
			this.Controls.Add(this.txtOriginalCount);
			this.Controls.Add(this.txtTransportMan);
			this.Controls.Add(this.txtTrLicenseTags);
			this.Controls.Add(this.txtDeliveryComp);
			this.Controls.Add(this.txtOutNo);
			this.Controls.Add(this.txtBillNo);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtpProvideDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmBillOfValidateAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "验收单录入";
			this.Load += new System.EventHandler(this.frmBillOfValidateAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private OperFlag _flag;
		public OperFlag Flag
		{
			get{return _flag;}
			set{_flag=value;}
		}
		private BillOfValidate _bov;
		public BillOfValidate BOV
		{
			get{return _bov;}
			set{_bov=value;}
		}
		private bool _isHis = false;
		public bool IsHis
		{
			get{return _isHis;}
			set{_isHis=value;}
		}
		private void frmBillOfValidateAdd_Load(object sender, System.EventArgs e)
		{
			ShowComponent();
		}
		private void ShowComponent()
		{
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			this.FillGoodsComboBox(cmbProvideCompany,"DeptTmp","cnvcCommName");
			cmbInType.Items.Add("调拨入库");
			cmbInType.Items.Add("购入");
			cmbInType.SelectedIndex=0;
			label19.ForeColor=Color.Red;

			txtLose.ReadOnly=true;
			txtQuotaLose.ReadOnly=true;
			txtQuterLose.ReadOnly=true;
			txtTransportLose.ReadOnly=true;
			txtDeliveryComp.ReadOnly=true;

			switch(_flag)
			{
				case OperFlag.ADD:					
					this.Text = "验收单录入";
					this.dtpProvideDate.Value=System.DateTime.Now;
					this.dtpDeliveryDate.Value=System.DateTime.Now;					
					txtDeliveryComp.Text=SysInitial.LocalDeptName;					
					txtTransportLose.Text="请点击此处...";
					break;
				case OperFlag.MOD:
					if(null == _bov)
					{
						MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
						this.Close();
					}					
					this.Text = "验收单修改";
					this.txtBillNo.ReadOnly = true;
					SetBOV();
					break;
				default:
					MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
					this.Close();
					break;
			}
		}
		private void SetBOV()
		{
			this.cmbGoodsName.Text = _bov.cnvcGoodsName;
			this.cmbGoodsType.Text = _bov.cnvcGoodsType;
			this.txtBillNo.Text = _bov.cnvcBillNo;
			this.txtOutNo.Text = _bov.cnvcOutNo;
			this.cmbInType.Text = _bov.cnvcInType;
			this.cmbProvideCompany.Text = _bov.cnvcProvideCompany;
			this.txtDeliveryComp.Text = _bov.cnvcDeliveryCompany;
			this.dtpProvideDate.Value = _bov.cndProvideDate;
			this.txtTrLicenseTags.Text = _bov.cnvcTransportLicenseTags;
			this.txtTransportMan.Text = _bov.cnvcTransportMan;
			this.dtpDeliveryDate.Value = _bov.cndDeliveryDate;
			this.txtOriginalCount.Text = _bov.cnnOriginalCount.ToString();
			this.txtValidateCount.Text = _bov.cnnValidateCount.ToString();
			this.txtDistance.Text = _bov.cnnDistance.ToString();
			this.txtTransportLose.Text = _bov.cnnTransportLose.ToString();
			this.txtLose.Text = _bov.cnnLose.ToString();
			this.txtQuotaLose.Text = _bov.cnnQuotaLose.ToString();
			this.txtQuterLose.Text = _bov.cnnOuterLose.ToString();
			this.txtProvideAddress.Text = _bov.cnvcProvideAddress;
		}
		private void GetBOV()
		{
			string strDeptProvide=GetPrvDept();
			//if(strDeptProvide == "")return null;
			//Entity.BillOfValidate bov = new BillOfValidate();

			//CMSMStruct.BillOfValidateStruct billofval=new CMSMData.CMSMStruct.BillOfValidateStruct();
			_bov.cnvcBillNo=txtBillNo.Text.Trim();
			_bov.cnvcOutNo=txtOutNo.Text.Trim();
			_bov.cnvcProvideCompany=cmbProvideCompany.Text.Trim();
			_bov.cnvcDeliveryCompany=txtDeliveryComp.Text.Trim();
			_bov.cndProvideDate=dtpProvideDate.Value;//.ToShortDatecnvcing();
			_bov.cndDeliveryDate=dtpDeliveryDate.Value;//.ToShortDatecnvcing();
			_bov.cnvcGoodsName=cmbGoodsName.Text.Trim();;
			_bov.cnvcGoodsType=cmbGoodsType.Text.Trim();;
			_bov.cnvcUnit="KG";
			_bov.cnvcTransportLicenseTags=txtTrLicenseTags.Text.Trim();
			_bov.cnvcTransportMan=txtTransportMan.Text.Trim();
			_bov.cnnOriginalCount=Convert.ToDecimal(txtOriginalCount.Text.Trim());
			_bov.cnnValidateCount=Convert.ToDecimal(txtValidateCount.Text.Trim());
			_bov.cnnDistance=Convert.ToDecimal(txtDistance.Text.Trim());
			_bov.cnnTransportLose=Convert.ToDecimal(txtTransportLose.Text.Trim());
			_bov.cnnLose=Convert.ToDecimal(txtLose.Text.Trim());
			_bov.cnnQuotaLose=Convert.ToDecimal(txtQuotaLose.Text.Trim());
			_bov.cnnOuterLose=Convert.ToDecimal(txtQuterLose.Text.Trim());
			_bov.cnvcProvideAddress=txtProvideAddress.Text.Trim();
			_bov.cnvcInType=cmbInType.Text.Trim();
			_bov.cnvcOperName=CMSMData.CMSMDataAccess.SysInitial.CurOps.strOperName;
			//_bov.cndOperDate=System.DateTime.Now;//.ToShortDatecnvcing() + " " + System.DateTime.Now.ToLongTimecnvcing();
			_bov.cnvcProvideDeptID=strDeptProvide;
			_bov.cnvcDeptID=SysInitial.LocalDeptID;
			//return _bov;
		}
		private bool BOVValidate()
		{			
			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
			{
				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			
			if(cmbProvideCompany.Text.Trim()=="")
			{
				MessageBox.Show("供油单位不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtBillNo.Text.Trim()=="")
			{
				MessageBox.Show("收油核对单号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			else
			{
				if(this._flag == OperFlag.ADD)
				{
					err=null;
					if(cs.IsDupBillOfValidate(txtBillNo.Text.Trim(),out err))
					{
						MessageBox.Show("收油核对单号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return false;
					}
				}
			}

			if(txtOutNo.Text.Trim()==""&&cmbInType.Text.Trim()=="调拨入库")
			{
				MessageBox.Show("出库单号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(txtOriginalCount.Text.Trim()==""||txtOriginalCount.Text.Trim()=="0")
			{
				MessageBox.Show("原发数不能为空或为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtValidateCount.Text.Trim()==""||txtValidateCount.Text.Trim()=="0")
			{
				MessageBox.Show("验收数不能为空或为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtDistance.Text.Trim()=="")
			{
				MessageBox.Show("运输公里数不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtTransportLose.Text.Trim()==""||txtTransportLose.Text.Trim()=="请点击此处...")
			{
				MessageBox.Show("请点击运输损耗定额！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtProvideAddress.Text.Trim()=="")
			{
				MessageBox.Show("发油地点不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(double.Parse(txtQuterLose.Text.Trim())<0)
			{
				MessageBox.Show("超定额运输损耗不能为负！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private CMSMStruct.OilStorageStruct GetOils()
		{
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			err=null;
			CMSMStruct.OilStorageStruct oils=cs.GetOilStorageDetail(strGoodsName,strGoodsType,out err);
			if(err!=null)
			{
				MessageBox.Show("获取当前库存出错，请检查当前库存信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return null;
			}
			if(oils==null)
			{
				MessageBox.Show("还没有原始库存，请先进入库存盘点进行库存操作！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return null;
			}
			return oils;
		}
		private string GetPrvDept()
		{
			string strDeptProvide = "";
			if(cmbInType.Text.Trim()=="购入")
			{
				return "";
			}
			else
			{
				strDeptProvide=this.GetColEn(cmbProvideCompany.Text.Trim(),"DeptTmp");
				if(strDeptProvide==null||strDeptProvide=="")
				{
					MessageBox.Show("获取供油单位ID出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return "获取供油单位ID出错";
				}
			}
			return strDeptProvide;
		}
		private void BOVAdd()
		{
			if(!BOVValidate()) return;
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			err=null;
			CMSMStruct.OilStorageStruct oils= GetOils();//cs.GetOilStorageDetail(strGoodsName,strGoodsType,out err);
			
			if(oils==null)return;

			string strDeptProvide=GetPrvDept();
			if(strDeptProvide == "获取供油单位ID出错")return;

			CMSMStruct.BillOfValidateStruct billofval=new CMSMData.CMSMStruct.BillOfValidateStruct();
			billofval.strBillNo=txtBillNo.Text.Trim();
			billofval.strOutNo=txtOutNo.Text.Trim();
			billofval.strProvideCompany=cmbProvideCompany.Text.Trim();
			billofval.strDeliveryCompany=txtDeliveryComp.Text.Trim();
			billofval.strProvideDate=dtpProvideDate.Value.ToShortDateString();
			billofval.strDeliveryDate=dtpDeliveryDate.Value.ToShortDateString();
			billofval.strGoodsName=strGoodsName;
			billofval.strGoodsType=strGoodsType;
			billofval.strUnit="KG";
			billofval.strTransportLicenseTags=txtTrLicenseTags.Text.Trim();
			billofval.strTransportMan=txtTransportMan.Text.Trim();
			billofval.strOriginalCount=txtOriginalCount.Text.Trim();
			billofval.strValidateCount=txtValidateCount.Text.Trim();
			billofval.strDistance=txtDistance.Text.Trim();
			billofval.strTransportLose=txtTransportLose.Text.Trim();
			billofval.strLose=txtLose.Text.Trim();
			billofval.strQuotaLose=txtQuotaLose.Text.Trim();
			billofval.strQuterLose=txtQuterLose.Text.Trim();
			billofval.strProvideAddress=txtProvideAddress.Text.Trim();
			billofval.strInType=cmbInType.Text.Trim();
			billofval.strOperName=SysInitial.CurOps.strOperName;
			billofval.strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			billofval.strProvideDeptID=strDeptProvide;
			billofval.strDeptID=CMSMData.CMSMDataAccess.SysInitial.LocalDeptID;

			CMSMStruct.OilStorageLogStruct oilslog=new CMSMData.CMSMStruct.OilStorageLogStruct();
			oilslog.strDeptName=SysInitial.LocalDeptName;
			oilslog.strGoodsName=oils.strGoodsName;
			oilslog.strGoodsType=oils.strGoodsType;
			oilslog.strInOutCount=billofval.strValidateCount;
			oilslog.strLastCount=oils.dStorageCount.ToString();
			oilslog.strCurCount=(Math.Round(oils.dStorageCount+double.Parse(billofval.strValidateCount),2)).ToString();
			oilslog.strOperType=billofval.strInType;
			oilslog.strOperName=billofval.strOperName;
			oilslog.strOperDate=billofval.strOperDate;
			oilslog.strDeptID=SysInitial.LocalDeptID;

			DialogResult drMG= MessageBox.Show(this,"是否要对\r单号：【"+billofval.strBillNo+"】，物料名称：【"+billofval.strGoodsName+"】，物料型号：【"+billofval.strGoodsType+"】，验收数：【"+billofval.strValidateCount+"】\r是否继续入库？","请仔细核对收油单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
			
			if (drMG == DialogResult.No)
			{
				return;
			}
	
			err=null;
			if(cs.InsertBillOfValidate(billofval,oilslog,out err))
			{
				MessageBox.Show("油料验收单录入成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{
				MessageBox.Show("油料验收单录入失败，可能是收油核对单号重复！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}
		private void BOVMOD()
		{
			if(!BOVValidate()) return;
			this.GetBOV();
			Entity.BusiLog bl = new BusiLog();			
			bl.cnvcDeptID = CMSMData.CMSMDataAccess.SysInitial.LocalDeptID;
			bl.cnvcDeptName = SysInitial.LocalDeptName;
			bl.cnvcOperName = SysInitial.CurOps.strOperName;
			

			if(MessageBox.Show(this,"是否要对\r单号：【"+_bov.cnvcBillNo+"】，物料名称：【"+_bov.cnvcGoodsName+"】，物料型号：【"+_bov.cnvcGoodsType+"】，验收数：【"+_bov.cnnValidateCount.ToString()+"】\r是否继续入库？","请仔细核对收油单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)
				==DialogResult.No) return;
						
			Business.BOVFacade bf = new CMSM.Business.BOVFacade();
			try
			{
				bf.BOVMOD(_bov,bl,IsHis);
				MessageBox.Show("油料验收单修改成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show("油料验收单修改失败，可能是收油核对单号重复！\r 错误如下：\r"
					+ex.Message
					,"系统提示"
					,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
		}
		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			switch(_flag)
			{
				case OperFlag.ADD:
					BOVAdd();
					break;
				case OperFlag.MOD:
					BOVMOD();
					break;
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
		}

		private void txtOriginalCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtValidateCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtDistance_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtTransportLose_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtOriginalCount_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dval=double.Parse(txtValidateCount.Text.Trim());

				double dlose=dori-dval;
				txtLose.Text=(Math.Round(dlose,2)).ToString();
			}

			if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

				double dql=dori*dtranl;
				txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
			}
		}

		private void txtValidateCount_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dval=double.Parse(txtValidateCount.Text.Trim());

				double dlose=dori-dval;
				txtLose.Text=(Math.Round(dlose,2)).ToString();
			}
		}

		private void txtTransportLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

				double dql=dori*dtranl;
				txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
			}
		}

		private void txtLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
			{
				double dlose=double.Parse(txtLose.Text.Trim());
				double dql=double.Parse(txtQuotaLose.Text.Trim());

				double dql2=dlose-dql;
				if(dql2<0)
				{
					txtQuterLose.Text="0";
				}
				else
				{
					txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
				}
			}
		}

		private void txtQuotaLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
			{
				double dlose=double.Parse(txtLose.Text.Trim());
				double dql=double.Parse(txtQuotaLose.Text.Trim());

				double dql2=dlose-dql;
				if(dql2<0)
				{
					txtQuterLose.Text="0";
				}
				else
				{
					txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
				}
			}
		}

		private void txtTransportLose_GotFocus(object sender, EventArgs e)
		{
			txtDistance.Focus();
			double dTransLose = 0.01;
			double doffset = 0.3;
			if(SysInitial.dsSys.Tables["TRANLOSE"].Rows.Count>0)
				dTransLose = double.Parse(SysInitial.dsSys.Tables["TRANLOSE"].Rows[0]["cnvccommcode"].ToString());
			if(SysInitial.dsSys.Tables["OFFSET"].Rows.Count>0)
				doffset = double.Parse(SysInitial.dsSys.Tables["OFFSET"].Rows[0]["cnvccommcode"].ToString());					
			if(txtDistance.Text.Trim()!=""&&txtDistance.Text.Trim()!="0")
			{
				double ddis=double.Parse(txtDistance.Text.Trim());
				int ratedis=int.Parse(Math.Round((ddis/50),0).ToString());
				double dtranlose=0;
				if(ratedis<=1)
				{
					dtranlose=dTransLose;//0.01;
				}
				else
				{
					dtranlose=ratedis*dTransLose;//0.01;
				}

				if(ratedis*50<ddis)
				{
					dtranlose+=dTransLose;//0.01;
				}
				dtranlose += doffset;//0.3;
				txtTransportLose.Text=dtranlose.ToString("0.00");

				if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
				{
					double dori=double.Parse(txtOriginalCount.Text.Trim());
					double dval=double.Parse(txtValidateCount.Text.Trim());

					double dlose=dori-dval;
					txtLose.Text=(Math.Round(dlose,2)).ToString();
				}

				if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
				{
					double dori=double.Parse(txtOriginalCount.Text.Trim());
					double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

					double dql=dori*dtranl;
					txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
				}

				if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
				{
					double dlose=double.Parse(txtLose.Text.Trim());
					double dql=double.Parse(txtQuotaLose.Text.Trim());

					double dql2=dlose-dql;
					if(dql2<0)
					{
						txtQuterLose.Text="0";
					}
					else
					{
						txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
					}
				}
			}
			else
			{
				MessageBox.Show("请检查运输公里数输入正确！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtTransportLose.Text="请点击此处...";
				return;
			}
		}

		private void txtDistance_TextChanged(object sender, System.EventArgs e)
		{
			if(this.txtTransportLose.Text.Trim()!="请点击此处...")
			{
				this.txtTransportLose.Text="请点击此处...";
			}
		}

		private void cmbInType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbInType.Text.Trim()=="购入")
			{
				txtOutNo.ReadOnly=true;
				cmbProvideCompany.Items.Clear();
				cmbProvideCompany.DropDownStyle=ComboBoxStyle.DropDown;
			}
			else
			{
				txtOutNo.ReadOnly=false;
				cmbProvideCompany.Items.Clear();
				cmbProvideCompany.DropDownStyle=ComboBoxStyle.DropDownList;
				this.FillGoodsComboBox(cmbProvideCompany,"DeptTmp","cnvcCommName");
			}
		}
	}
}
