using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using CMSM.Common;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmBillOfMaterialsAdd.
	/// </summary>
	public class frmBillOfMaterialsAdd : CMSM.CMSMApp.frmBase
	{
		#region 字段
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBillNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.TextBox txtDeliveryMan;
		private System.Windows.Forms.TextBox txtProvideCompany;
		private System.Windows.Forms.TextBox txtReceiveCount;
		private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DateTimePicker dtpProvideBeginDate;
		private System.Windows.Forms.DateTimePicker dtpProvideEndDate;
		private System.Windows.Forms.TextBox txtProvideMan;
		private System.Windows.Forms.TextBox txtSignerCompany;
		private System.Windows.Forms.TextBox txtSigner;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.DateTimePicker dtpTimeOfValidity;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtSpecialUnitPrice;
		private System.Windows.Forms.TextBox txtSpecialFee;
		private System.Windows.Forms.ComboBox cmbDeliveryCompany;
		private System.Windows.Forms.ComboBox cmbContractNo;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		#endregion


		private OperFlag _flag;
		public OperFlag Flag
		{
			get{return _flag;}
			set{_flag=value;}
		}
		private Entity.BillOfMaterials _bom;
		public Entity.BillOfMaterials BOM
		{
			get{return _bom;}
			set{_bom=value;}
		}
		private bool _isHis = false;
		public bool IsHis
		{
			get{return _isHis;}
			set{_isHis=value;}
		}

		public frmBillOfMaterialsAdd()
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
			this.txtProvideCompany = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
			this.txtSignerCompany = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSigner = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtReceiveCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtProvideMan = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtDeliveryMan = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label17 = new System.Windows.Forms.Label();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.dtpProvideBeginDate = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.dtpProvideEndDate = new System.Windows.Forms.DateTimePicker();
			this.label13 = new System.Windows.Forms.Label();
			this.dtpTimeOfValidity = new System.Windows.Forms.DateTimePicker();
			this.label16 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtSpecialFee = new System.Windows.Forms.TextBox();
			this.txtSpecialUnitPrice = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbDeliveryCompany = new System.Windows.Forms.ComboBox();
			this.cmbContractNo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 24;
			this.label1.Text = "领料单字号";
			// 
			// txtBillNo
			// 
			this.txtBillNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillNo.Location = new System.Drawing.Point(112, 56);
			this.txtBillNo.MaxLength = 20;
			this.txtBillNo.Name = "txtBillNo";
			this.txtBillNo.Size = new System.Drawing.Size(184, 22);
			this.txtBillNo.TabIndex = 3;
			this.txtBillNo.Text = "";
			// 
			// txtProvideCompany
			// 
			this.txtProvideCompany.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtProvideCompany.Location = new System.Drawing.Point(112, 96);
			this.txtProvideCompany.MaxLength = 50;
			this.txtProvideCompany.Name = "txtProvideCompany";
			this.txtProvideCompany.Size = new System.Drawing.Size(184, 22);
			this.txtProvideCompany.TabIndex = 5;
			this.txtProvideCompany.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "供货单位";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(304, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 27;
			this.label3.Text = "提货单位";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(304, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 25;
			this.label4.Text = "合同编号";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 224);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "提货时间";
			// 
			// dtpDeliveryDate
			// 
			this.dtpDeliveryDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpDeliveryDate.Location = new System.Drawing.Point(112, 216);
			this.dtpDeliveryDate.Name = "dtpDeliveryDate";
			this.dtpDeliveryDate.Size = new System.Drawing.Size(184, 22);
			this.dtpDeliveryDate.TabIndex = 11;
			// 
			// txtSignerCompany
			// 
			this.txtSignerCompany.Enabled = false;
			this.txtSignerCompany.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtSignerCompany.Location = new System.Drawing.Point(112, 296);
			this.txtSignerCompany.MaxLength = 20;
			this.txtSignerCompany.Name = "txtSignerCompany";
			this.txtSignerCompany.Size = new System.Drawing.Size(232, 22);
			this.txtSignerCompany.TabIndex = 16;
			this.txtSignerCompany.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 304);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 37;
			this.label6.Text = "签发单位";
			// 
			// txtSigner
			// 
			this.txtSigner.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtSigner.Location = new System.Drawing.Point(408, 296);
			this.txtSigner.MaxLength = 10;
			this.txtSigner.Name = "txtSigner";
			this.txtSigner.Size = new System.Drawing.Size(144, 22);
			this.txtSigner.TabIndex = 17;
			this.txtSigner.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(352, 304);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 38;
			this.label7.Text = "签发人";
			// 
			// txtReceiveCount
			// 
			this.txtReceiveCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReceiveCount.Location = new System.Drawing.Point(112, 128);
			this.txtReceiveCount.Name = "txtReceiveCount";
			this.txtReceiveCount.Size = new System.Drawing.Size(184, 22);
			this.txtReceiveCount.TabIndex = 9;
			this.txtReceiveCount.Text = "";
			this.txtReceiveCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiveCount_KeyPress);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(48, 136);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 30;
			this.label8.Text = "领用数量";
			// 
			// txtCount
			// 
			this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCount.Location = new System.Drawing.Point(368, 128);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(264, 22);
			this.txtCount.TabIndex = 10;
			this.txtCount.Text = "";
			this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
			this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(304, 136);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 31;
			this.label9.Text = "实发数量";
			// 
			// txtProvideMan
			// 
			this.txtProvideMan.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtProvideMan.Location = new System.Drawing.Point(408, 256);
			this.txtProvideMan.MaxLength = 10;
			this.txtProvideMan.Name = "txtProvideMan";
			this.txtProvideMan.Size = new System.Drawing.Size(144, 22);
			this.txtProvideMan.TabIndex = 15;
			this.txtProvideMan.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(336, 264);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 36;
			this.label11.Text = "发货业务员";
			// 
			// txtDeliveryMan
			// 
			this.txtDeliveryMan.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtDeliveryMan.Location = new System.Drawing.Point(112, 256);
			this.txtDeliveryMan.MaxLength = 10;
			this.txtDeliveryMan.Name = "txtDeliveryMan";
			this.txtDeliveryMan.Size = new System.Drawing.Size(184, 22);
			this.txtDeliveryMan.TabIndex = 14;
			this.txtDeliveryMan.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(48, 264);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 35;
			this.label12.Text = "提货人";
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(216, 344);
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
			this.sbtnClose.Location = new System.Drawing.Point(480, 344);
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
			this.label17.TabIndex = 21;
			this.label17.Text = "物料名称";
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbGoodsName.Location = new System.Drawing.Point(112, 16);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(184, 21);
			this.cmbGoodsName.TabIndex = 1;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.Location = new System.Drawing.Point(368, 16);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(264, 20);
			this.cmbGoodsType.TabIndex = 2;
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(304, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 22;
			this.label18.Text = "物料型号";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpProvideBeginDate
			// 
			this.dtpProvideBeginDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpProvideBeginDate.Location = new System.Drawing.Point(368, 216);
			this.dtpProvideBeginDate.Name = "dtpProvideBeginDate";
			this.dtpProvideBeginDate.Size = new System.Drawing.Size(144, 22);
			this.dtpProvideBeginDate.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(296, 224);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 16);
			this.label10.TabIndex = 33;
			this.label10.Text = "发货起始时间";
			// 
			// dtpProvideEndDate
			// 
			this.dtpProvideEndDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpProvideEndDate.Location = new System.Drawing.Point(624, 216);
			this.dtpProvideEndDate.Name = "dtpProvideEndDate";
			this.dtpProvideEndDate.Size = new System.Drawing.Size(144, 22);
			this.dtpProvideEndDate.TabIndex = 13;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(536, 224);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 16);
			this.label13.TabIndex = 34;
			this.label13.Text = "发货终止时间";
			// 
			// dtpTimeOfValidity
			// 
			this.dtpTimeOfValidity.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpTimeOfValidity.Location = new System.Drawing.Point(624, 296);
			this.dtpTimeOfValidity.Name = "dtpTimeOfValidity";
			this.dtpTimeOfValidity.Size = new System.Drawing.Size(144, 22);
			this.dtpTimeOfValidity.TabIndex = 18;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(568, 304);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 16);
			this.label16.TabIndex = 39;
			this.label16.Text = "有效期";
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(640, 24);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 16);
			this.label19.TabIndex = 23;
			this.label19.Text = "单位：KG";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSpecialFee
			// 
			this.txtSpecialFee.Enabled = false;
			this.txtSpecialFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtSpecialFee.Location = new System.Drawing.Point(368, 168);
			this.txtSpecialFee.Name = "txtSpecialFee";
			this.txtSpecialFee.Size = new System.Drawing.Size(264, 22);
			this.txtSpecialFee.TabIndex = 8;
			this.txtSpecialFee.Text = "0";
			this.txtSpecialFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecialFee_KeyPress);
			// 
			// txtSpecialUnitPrice
			// 
			this.txtSpecialUnitPrice.Enabled = false;
			this.txtSpecialUnitPrice.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtSpecialUnitPrice.Location = new System.Drawing.Point(112, 168);
			this.txtSpecialUnitPrice.Name = "txtSpecialUnitPrice";
			this.txtSpecialUnitPrice.Size = new System.Drawing.Size(184, 22);
			this.txtSpecialUnitPrice.TabIndex = 7;
			this.txtSpecialUnitPrice.Text = "";
			this.txtSpecialUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecialUnitPrice_KeyPress);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(304, 176);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 16);
			this.label14.TabIndex = 29;
			this.label14.Text = "专供金额";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(48, 176);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 28;
			this.label15.Text = "专供单价";
			// 
			// cmbDeliveryCompany
			// 
			this.cmbDeliveryCompany.Location = new System.Drawing.Point(368, 56);
			this.cmbDeliveryCompany.MaxDropDownItems = 15;
			this.cmbDeliveryCompany.Name = "cmbDeliveryCompany";
			this.cmbDeliveryCompany.Size = new System.Drawing.Size(264, 20);
			this.cmbDeliveryCompany.TabIndex = 40;
			this.cmbDeliveryCompany.Click += new System.EventHandler(this.cmbDeliveryCompany_Click);
			// 
			// cmbContractNo
			// 
			this.cmbContractNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbContractNo.Location = new System.Drawing.Point(368, 96);
			this.cmbContractNo.Name = "cmbContractNo";
			this.cmbContractNo.Size = new System.Drawing.Size(264, 20);
			this.cmbContractNo.TabIndex = 41;
			this.cmbContractNo.Click += new System.EventHandler(this.cmbContractNo_Click);
			// 
			// frmBillOfMaterialsAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(776, 382);
			this.ControlBox = false;
			this.Controls.Add(this.cmbContractNo);
			this.Controls.Add(this.cmbDeliveryCompany);
			this.Controls.Add(this.txtSpecialFee);
			this.Controls.Add(this.txtSpecialUnitPrice);
			this.Controls.Add(this.txtDeliveryMan);
			this.Controls.Add(this.txtProvideMan);
			this.Controls.Add(this.txtCount);
			this.Controls.Add(this.txtReceiveCount);
			this.Controls.Add(this.txtSigner);
			this.Controls.Add(this.txtSignerCompany);
			this.Controls.Add(this.txtProvideCompany);
			this.Controls.Add(this.txtBillNo);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.dtpTimeOfValidity);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.dtpProvideEndDate);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.dtpProvideBeginDate);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtpDeliveryDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmBillOfMaterialsAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "专供油领料单录入";
			this.Load += new System.EventHandler(this.frmBillOfMaterialsAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void ShowComponent()
		{
			label19.ForeColor=Color.Red;
			
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			this.FillGoodsComboBox(cmbDeliveryCompany,"SpecDelivery","cnvcDeliveryCompany");
			this.cmbDeliveryCompany.DropDownStyle=ComboBoxStyle.DropDown;
			this.dtpDeliveryDate.Value=System.DateTime.Now;
			this.dtpProvideBeginDate.Value=System.DateTime.Now;
			this.dtpProvideEndDate.Value=System.DateTime.Now;
			this.dtpTimeOfValidity.Value=System.DateTime.Now;
			txtProvideCompany.ReadOnly=true;
			this.txtSignerCompany.Text="云南华能澜沧江水电物资有限公司";

			switch(_flag)
			{
				case OperFlag.ADD:					
					this.Text = "领料单录入";
					txtProvideCompany.Text=SysInitial.LocalDeptName;			
					err=null;
					CMSMStruct.AssConsParaStruct acp=cs.GetOilPrice(SysInitial.LocalDeptName,out err);
					this.txtSpecialUnitPrice.Text=acp.strPrice;
					if(this.txtSpecialUnitPrice.Text=="")
					{
						MessageBox.Show("0#单价参数不全！请到数据中心设置单价！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.Close();					
					}
					break;
				case OperFlag.MOD:
					if(null == _bom)
					{
						MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
						this.Close();
					}					
					this.Text = "领料单修改";
					this.txtBillNo.ReadOnly = true;
					SetBOM();
					break;
				default:
					MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
					this.Close();
					break;
			}
		}
		private void BindContractNo()
		{
			this.cmbContractNo.Items.Clear();
			string strDelivery=this.cmbDeliveryCompany.Text.Trim();
			if(SysInitial.htSpecOilDept.ContainsKey(strDelivery))
			{
				ArrayList alDeliList=(ArrayList)SysInitial.htSpecOilDept[strDelivery];
				for(int i=0;i<alDeliList.Count;i++)
				{
					this.cmbContractNo.Items.Add(alDeliList[i].ToString());
				}
				this.cmbContractNo.SelectedIndex=0;
			}
			
		}
		private void SetBOM()
		{
			txtSpecialUnitPrice.Text = _bom.cnnSpecialUnitPrice.ToString();

			txtBillNo.Text = _bom.cnvcBillNo;
			cmbDeliveryCompany.Text = _bom.cnvcDeliveryCompany;


			BindContractNo();
			

			cmbContractNo.Text = _bom.cnvcContractNo;			
			txtProvideCompany.Text = _bom.cnvcProvideCompany;
			cmbGoodsName.Text = _bom.cnvcGoodsName;
			cmbGoodsType.Text = _bom.cnvcGoodsType;
			txtReceiveCount.Text = _bom.cnnReceiveCount.ToString();
			txtCount.Text = _bom.cnnCount.ToString();
			txtDeliveryMan.Text = _bom.cnvcDeliveryMan;
			dtpDeliveryDate.Value = _bom.cndDeliveryDate;
			dtpProvideBeginDate.Value = _bom.cndProvideBeginDate;
			dtpProvideEndDate.Value = _bom.cndProvideEndDate;
			txtProvideMan.Text = _bom.cndProvideMan;
			txtSignerCompany.Text = _bom.cnvcSignerCompany;
			txtSigner.Text = _bom.cnvcSigner;
			dtpTimeOfValidity.Value = _bom.cndTimeOfValidity;

			txtSpecialFee.Text = _bom.cnnSpecialFee.ToString();

			
		
		}
		private void GetBOM()
		{			
			_bom.cnvcBillNo=txtBillNo.Text.Trim();
			_bom.cnvcContractNo=cmbContractNo.Text.Trim();
			_bom.cnvcDeliveryCompany=cmbDeliveryCompany.Text.Trim();
			_bom.cnvcProvideCompany=txtProvideCompany.Text.Trim();
			_bom.cnvcGoodsName=cmbGoodsName.Text.Trim();;
			_bom.cnvcGoodsType=cmbGoodsType.Text.Trim();;
			_bom.cnvcUnit="KG";
			_bom.cnnReceiveCount=Convert.ToDecimal(txtReceiveCount.Text.Trim());
			_bom.cnnCount=Convert.ToDecimal(txtCount.Text.Trim());
			_bom.cnvcDeliveryMan=txtDeliveryMan.Text.Trim();
			_bom.cndDeliveryDate=dtpDeliveryDate.Value;
			_bom.cndProvideBeginDate=dtpProvideBeginDate.Value;
			_bom.cndProvideEndDate=dtpProvideEndDate.Value;
			_bom.cndProvideMan=txtProvideMan.Text.Trim();
			_bom.cnvcSignerCompany=txtSignerCompany.Text.Trim();
			_bom.cnvcSigner=txtSigner.Text.Trim();
			_bom.cndTimeOfValidity=dtpProvideEndDate.Value;
			_bom.cnvcOperName=SysInitial.CurOps.strOperName;			
			_bom.cnnSpecialUnitPrice=Convert.ToDecimal(txtSpecialUnitPrice.Text.Trim());
			_bom.cnnSpecialFee=Convert.ToDecimal(txtSpecialFee.Text.Trim());
			_bom.cnvcDeptID=SysInitial.LocalDeptID;
		}
		private bool BOMValidate()
		{
			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
			{
				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(txtBillNo.Text.Trim()=="")
			{
				MessageBox.Show("领料单字号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			else
			{
				if(this._flag == OperFlag.ADD)
				{
					err=null;
					if(cs.IsDupBillOfMaterials(txtBillNo.Text.Trim(),out err))
					{
						MessageBox.Show("领料单字号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return false;
					}
				}
			}

			if(cmbDeliveryCompany.Text.Trim()==""||this.cmbContractNo.Text.Trim()=="")
			{
				MessageBox.Show("提货单位和合同编号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(txtReceiveCount.Text.Trim()==""||txtReceiveCount.Text.Trim()=="0")
			{
				MessageBox.Show("领用数量不能为空或为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(txtCount.Text.Trim()==""||txtCount.Text.Trim()=="0")
			{
				MessageBox.Show("实发数量不能为空或为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private void BOMADD()
		{
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			
			if(!BOMValidate()) return;
			double doutcount=double.Parse(txtCount.Text.Trim());
			err=null;
			CMSMStruct.OilStorageStruct oils=cs.GetOilStorageDetail(strGoodsName,strGoodsType,out err);
			if(err!=null||oils==null)
			{
				MessageBox.Show("获取当前库存出错，请检查当前库存信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			else if(oils.dStorageCount<doutcount)
			{
				MessageBox.Show("当前库存不足，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			CMSMStruct.BillOfMaterialsStruct billofmat=new CMSMData.CMSMStruct.BillOfMaterialsStruct();
			billofmat.strBillNo=txtBillNo.Text.Trim();
			billofmat.strContractNo=cmbContractNo.Text.Trim();
			billofmat.strDeliveryCompany=cmbDeliveryCompany.Text.Trim();
			billofmat.strProvideCompany=txtProvideCompany.Text.Trim();
			billofmat.strGoodsName=strGoodsName;
			billofmat.strGoodsType=strGoodsType;
			billofmat.strUnit="KG";
			billofmat.strReceiveCount=txtReceiveCount.Text.Trim();
			billofmat.strCount=txtCount.Text.Trim();
			billofmat.strDeliveryMan=txtDeliveryMan.Text.Trim();
			billofmat.strDeliveryDate=dtpDeliveryDate.Value.ToShortDateString();
			billofmat.strProvideBeginDate=dtpProvideBeginDate.Value.ToShortDateString();
			billofmat.strProvideEndDate=dtpProvideEndDate.Value.ToShortDateString();
			billofmat.strProvideMan=txtProvideMan.Text.Trim();
			billofmat.strSignerCompany=txtSignerCompany.Text.Trim();
			billofmat.strSigner=txtSigner.Text.Trim();
			billofmat.strTimeOfValidity=dtpProvideEndDate.Value.ToShortDateString();
			billofmat.strOperName=SysInitial.CurOps.strOperName;
			billofmat.strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			billofmat.strSpecialUnitPrice=txtSpecialUnitPrice.Text.Trim();
			billofmat.strSpecialFee=txtSpecialFee.Text.Trim();
			billofmat.strDeptID=SysInitial.LocalDeptID;

			CMSMStruct.OilStorageLogStruct oilslog=new CMSMData.CMSMStruct.OilStorageLogStruct();
			oilslog.strDeptName=SysInitial.LocalDeptName;
			oilslog.strGoodsName=oils.strGoodsName;
			oilslog.strGoodsType=oils.strGoodsType;
			oilslog.strInOutCount=(-double.Parse(billofmat.strCount)).ToString();
			oilslog.strLastCount=oils.dStorageCount.ToString();
			oilslog.strCurCount=(Math.Round(oils.dStorageCount-double.Parse(billofmat.strCount),2)).ToString();
			oilslog.strOperType="专供油出库";
			oilslog.strOperName=billofmat.strOperName;
			oilslog.strOperDate=billofmat.strOperDate;

			DialogResult drMG= MessageBox.Show(this,"是否要对\r专供油领料单号：【"+billofmat.strBillNo+"】，物料名称：【"+billofmat.strGoodsName+"】，物料型号：【"+billofmat.strGoodsType+"】，实发数量：【"+billofmat.strCount+"】\r是否继续入库？","请仔细核对专供油单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
			
			if (drMG == DialogResult.No)
			{
				return;
			}
	
			err=null;
			if(cs.InsertBillOfMaterials(billofmat,oilslog,out err))
			{
				MessageBox.Show("专供油领料单录入成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{
				MessageBox.Show("专供油领料单录入失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}
		private void BOMMOD()
		{
			if(!BOMValidate()) return;
			this.GetBOM();
			Entity.BusiLog bl = new CMSM.Entity.BusiLog();
			bl.cnvcDeptID = CMSMData.CMSMDataAccess.SysInitial.LocalDeptID;
			bl.cnvcDeptName = SysInitial.LocalDeptName;
			bl.cnvcOperName = SysInitial.CurOps.strOperName;
			

			if(MessageBox.Show(this,"是否要对\r专供油领料单号：【"+_bom.cnvcBillNo+"】，物料名称：【"+_bom.cnvcGoodsName+"】，物料型号：【"+_bom.cnvcGoodsType+"】，实发数量：【"+_bom.cnnCount.ToString()+"】\r是否继续入库？","请仔细核对专供油单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)
				==DialogResult.No) return;
						
			Business.BOMFacade bf = new CMSM.Business.BOMFacade();
			try
			{
				bf.BOMMOD(_bom,bl,IsHis);
				MessageBox.Show("专供油领料单修改成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show("专供油领料单修改失败！\r 错误如下：\r"
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
					BOMADD();
					break;
				case OperFlag.MOD:
					BOMMOD();
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

		private void txtSpecialUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtSpecialFee_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtReceiveCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void cmbDeliveryCompany_Click(object sender, EventArgs e)
		{
			this.cmbContractNo.Items.Clear();
			this.cmbDeliveryCompany.DroppedDown=true;
		}

		private void cmbContractNo_Click(object sender, EventArgs e)
		{
//			this.cmbContractNo.Items.Clear();
//			string strDelivery=this.cmbDeliveryCompany.Text.Trim();
//			if(SysInitial.htSpecOilDept.ContainsKey(strDelivery))
//			{
//				ArrayList alDeliList=(ArrayList)SysInitial.htSpecOilDept[strDelivery];
//				for(int i=0;i<alDeliList.Count;i++)
//				{
//					this.cmbContractNo.Items.Add(alDeliList[i].ToString());
//				}
//				this.cmbContractNo.SelectedIndex=0;
//			}
			BindContractNo();
		}
		private void txtCount_TextChanged(object sender, EventArgs e)
		{
			if(this.txtCount.Text.Trim()!="")
			{
				this.txtSpecialFee.Text=((Double.Parse(this.txtCount.Text))*(Double.Parse(this.txtSpecialUnitPrice.Text))).ToString();
				
			}
		}

		private void frmBillOfMaterialsAdd_Load(object sender, System.EventArgs e)
		{
			ShowComponent();
		}

	}
}
