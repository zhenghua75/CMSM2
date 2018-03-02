using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using CMSM.Entity;
using CMSM.Common;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmBillOfOutStorageAdd.
	/// </summary>
	public class frmBillOfOutStorageAdd : CMSM.CMSMApp.frmBase
	{
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
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
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
		private System.Windows.Forms.TextBox txtProvideStroage;
		private System.Windows.Forms.TextBox txtMoveNo;
		private System.Windows.Forms.TextBox txtBillOfMaterialsNo;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtTransportCompany;
		private System.Windows.Forms.TextBox txtTransportLiscenseTags;
		private System.Windows.Forms.DateTimePicker dtpOutStorageDate;
		private System.Windows.Forms.TextBox txtReceivableCount;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox txtStorageIncharge;
		private System.Windows.Forms.TextBox txtDeliveryMan;
		private System.Windows.Forms.TextBox txtLister;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cmbDeliveryCompany;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmBillOfOutStorageAdd()
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
			this.txtProvideStroage = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMoveNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpOutStorageDate = new System.Windows.Forms.DateTimePicker();
			this.txtTransportCompany = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTransportLiscenseTags = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtReceivableCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtStorageIncharge = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtDeliveryMan = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtLister = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label17 = new System.Windows.Forms.Label();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtBillOfMaterialsNo = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.cmbDeliveryCompany = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "出库单号";
			// 
			// txtBillNo
			// 
			this.txtBillNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillNo.Location = new System.Drawing.Point(112, 56);
			this.txtBillNo.MaxLength = 20;
			this.txtBillNo.Name = "txtBillNo";
			this.txtBillNo.Size = new System.Drawing.Size(176, 22);
			this.txtBillNo.TabIndex = 2;
			this.txtBillNo.Text = "";
			// 
			// txtProvideStroage
			// 
			this.txtProvideStroage.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtProvideStroage.Location = new System.Drawing.Point(112, 96);
			this.txtProvideStroage.MaxLength = 20;
			this.txtProvideStroage.Name = "txtProvideStroage";
			this.txtProvideStroage.Size = new System.Drawing.Size(176, 22);
			this.txtProvideStroage.TabIndex = 5;
			this.txtProvideStroage.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "发料仓库";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(304, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "提货单位";
			// 
			// txtMoveNo
			// 
			this.txtMoveNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtMoveNo.Location = new System.Drawing.Point(368, 56);
			this.txtMoveNo.MaxLength = 20;
			this.txtMoveNo.Name = "txtMoveNo";
			this.txtMoveNo.Size = new System.Drawing.Size(144, 22);
			this.txtMoveNo.TabIndex = 3;
			this.txtMoveNo.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(304, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "调拨单号";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(544, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "出库日期";
			// 
			// dtpOutStorageDate
			// 
			this.dtpOutStorageDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpOutStorageDate.Location = new System.Drawing.Point(608, 136);
			this.dtpOutStorageDate.Name = "dtpOutStorageDate";
			this.dtpOutStorageDate.Size = new System.Drawing.Size(144, 22);
			this.dtpOutStorageDate.TabIndex = 9;
			// 
			// txtTransportCompany
			// 
			this.txtTransportCompany.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTransportCompany.Location = new System.Drawing.Point(112, 136);
			this.txtTransportCompany.MaxLength = 50;
			this.txtTransportCompany.Name = "txtTransportCompany";
			this.txtTransportCompany.Size = new System.Drawing.Size(176, 22);
			this.txtTransportCompany.TabIndex = 7;
			this.txtTransportCompany.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "承运单位";
			// 
			// txtTransportLiscenseTags
			// 
			this.txtTransportLiscenseTags.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTransportLiscenseTags.Location = new System.Drawing.Point(368, 136);
			this.txtTransportLiscenseTags.MaxLength = 20;
			this.txtTransportLiscenseTags.Name = "txtTransportLiscenseTags";
			this.txtTransportLiscenseTags.Size = new System.Drawing.Size(144, 22);
			this.txtTransportLiscenseTags.TabIndex = 8;
			this.txtTransportLiscenseTags.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(304, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "承运车号";
			// 
			// txtReceivableCount
			// 
			this.txtReceivableCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReceivableCount.Location = new System.Drawing.Point(112, 176);
			this.txtReceivableCount.Name = "txtReceivableCount";
			this.txtReceivableCount.Size = new System.Drawing.Size(176, 22);
			this.txtReceivableCount.TabIndex = 10;
			this.txtReceivableCount.Text = "";
			this.txtReceivableCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceivableCount_KeyPress);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(48, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "应发数";
			// 
			// txtCount
			// 
			this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCount.Location = new System.Drawing.Point(368, 176);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(144, 22);
			this.txtCount.TabIndex = 11;
			this.txtCount.Text = "";
			this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(304, 184);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "实发数";
			// 
			// txtStorageIncharge
			// 
			this.txtStorageIncharge.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtStorageIncharge.Location = new System.Drawing.Point(112, 216);
			this.txtStorageIncharge.MaxLength = 10;
			this.txtStorageIncharge.Name = "txtStorageIncharge";
			this.txtStorageIncharge.Size = new System.Drawing.Size(176, 22);
			this.txtStorageIncharge.TabIndex = 12;
			this.txtStorageIncharge.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(48, 224);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 20;
			this.label11.Text = "仓库主管";
			// 
			// txtDeliveryMan
			// 
			this.txtDeliveryMan.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtDeliveryMan.Location = new System.Drawing.Point(368, 216);
			this.txtDeliveryMan.MaxLength = 10;
			this.txtDeliveryMan.Name = "txtDeliveryMan";
			this.txtDeliveryMan.Size = new System.Drawing.Size(144, 22);
			this.txtDeliveryMan.TabIndex = 13;
			this.txtDeliveryMan.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(304, 224);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 22;
			this.label12.Text = "提货人";
			// 
			// txtLister
			// 
			this.txtLister.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLister.Location = new System.Drawing.Point(608, 216);
			this.txtLister.MaxLength = 10;
			this.txtLister.Name = "txtLister";
			this.txtLister.Size = new System.Drawing.Size(144, 22);
			this.txtLister.TabIndex = 14;
			this.txtLister.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(568, 224);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 16);
			this.label14.TabIndex = 26;
			this.label14.Text = "制单";
			// 
			// txtComments
			// 
			this.txtComments.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtComments.Location = new System.Drawing.Point(112, 256);
			this.txtComments.MaxLength = 100;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtComments.Size = new System.Drawing.Size(640, 72);
			this.txtComments.TabIndex = 15;
			this.txtComments.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(64, 256);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 16);
			this.label15.TabIndex = 28;
			this.label15.Text = "备注";
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(216, 344);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(72, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 16;
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
			this.sbtnClose.TabIndex = 17;
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
			this.cmbGoodsName.Size = new System.Drawing.Size(176, 21);
			this.cmbGoodsName.TabIndex = 0;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.Location = new System.Drawing.Point(368, 16);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(144, 20);
			this.cmbGoodsType.TabIndex = 1;
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(304, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 36;
			this.label18.Text = "物料型号";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBillOfMaterialsNo
			// 
			this.txtBillOfMaterialsNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillOfMaterialsNo.Location = new System.Drawing.Point(608, 56);
			this.txtBillOfMaterialsNo.MaxLength = 20;
			this.txtBillOfMaterialsNo.Name = "txtBillOfMaterialsNo";
			this.txtBillOfMaterialsNo.Size = new System.Drawing.Size(144, 22);
			this.txtBillOfMaterialsNo.TabIndex = 4;
			this.txtBillOfMaterialsNo.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(544, 64);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(64, 16);
			this.label20.TabIndex = 39;
			this.label20.Text = "领料单号";
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(544, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 16);
			this.label19.TabIndex = 41;
			this.label19.Text = "单位：KG";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbDeliveryCompany
			// 
			this.cmbDeliveryCompany.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbDeliveryCompany.Location = new System.Drawing.Point(368, 96);
			this.cmbDeliveryCompany.MaxLength = 25;
			this.cmbDeliveryCompany.Name = "cmbDeliveryCompany";
			this.cmbDeliveryCompany.Size = new System.Drawing.Size(248, 21);
			this.cmbDeliveryCompany.TabIndex = 6;
			// 
			// frmBillOfOutStorageAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(776, 382);
			this.ControlBox = false;
			this.Controls.Add(this.cmbDeliveryCompany);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.txtBillOfMaterialsNo);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtLister);
			this.Controls.Add(this.txtDeliveryMan);
			this.Controls.Add(this.txtStorageIncharge);
			this.Controls.Add(this.txtCount);
			this.Controls.Add(this.txtReceivableCount);
			this.Controls.Add(this.txtTransportLiscenseTags);
			this.Controls.Add(this.txtTransportCompany);
			this.Controls.Add(this.txtMoveNo);
			this.Controls.Add(this.txtProvideStroage);
			this.Controls.Add(this.txtBillNo);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtpOutStorageDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmBillOfOutStorageAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "调拨出库单录入";
			this.Load += new System.EventHandler(this.frmBillOfOutStorageAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private OperFlag _flag;
		public OperFlag Flag
		{
			get{return _flag;}
			set{_flag=value;}
		}
		private BillOfOutStorage _bos;
		public BillOfOutStorage BOS
		{
			get{return _bos;}
			set{_bos=value;}
		}
		private bool _isHis = false;
		public bool IsHis
		{
			get{return _isHis;}
			set{_isHis=value;}
		}

		private void ShowComponent()
		{
			label19.ForeColor=Color.Red;
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			
			txtProvideStroage.ReadOnly=true;
			this.FillGoodsComboBox(cmbDeliveryCompany,"DeptTmp","cnvcCommName");

			switch(_flag)
			{
				case OperFlag.ADD:					
					this.Text = "出库单录入";
					this.dtpOutStorageDate.Value=System.DateTime.Now;
					txtProvideStroage.Text=SysInitial.LocalDeptName;
					break;
				case OperFlag.MOD:
					if(null == _bos)
					{
						MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
						this.Close();
					}					
					this.Text = "出库单修改";
					this.txtBillNo.ReadOnly = true;
					SetBOS();
					break;
				default:
					MessageBox.Show("参数错误！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);		
					this.Close();
					break;
			}
		}
		private void SetBOS()
		{
			txtBillNo.Text = _bos.cnvcBillNo;
			txtProvideStroage.Text = _bos.cnvcProvideStroage;
			cmbDeliveryCompany.Text = _bos.cnvcDeliveryCompany;
			txtMoveNo.Text = _bos.cnvcMoveNo;
			txtBillOfMaterialsNo.Text = _bos.cnvcBillOfMaterialsNo;
			txtTransportCompany.Text = _bos.cnvcTransportCompany;
			txtTransportLiscenseTags.Text = _bos.cnvcTransportLiscenseTags;
			dtpOutStorageDate.Value = _bos.cndOutStorageDate;
			cmbGoodsName.Text = _bos.cnvcGoodsName;
			cmbGoodsType.Text = _bos.cnvcGoodsType;
			txtReceivableCount.Text = _bos.cnnReceivableCount.ToString();
			txtCount.Text = _bos.cnnCount.ToString();
			txtComments.Text = _bos.cnvcComments;
			txtStorageIncharge.Text = _bos.cnvcStorageIncharge;
			txtDeliveryMan.Text = _bos.cnvcDeliveryMan;
			txtLister.Text = _bos.cnvcLister;
		}
		private bool GetBOS()
		{
			string strDeliveryDeptID=GetDDeptID();
			if(strDeliveryDeptID == "") return false;
			_bos.cnvcBillNo=txtBillNo.Text.Trim();
			_bos.cnvcProvideStroage=txtProvideStroage.Text.Trim();
			_bos.cnvcDeliveryCompany=cmbDeliveryCompany.Text.Trim();
			_bos.cnvcMoveNo=txtMoveNo.Text.Trim();
			_bos.cnvcBillOfMaterialsNo=txtBillOfMaterialsNo.Text.Trim();
			_bos.cnvcTransportCompany=txtTransportCompany.Text.Trim();
			_bos.cnvcTransportLiscenseTags=txtTransportLiscenseTags.Text.Trim();
			_bos.cndOutStorageDate=dtpOutStorageDate.Value;
			_bos.cnvcGoodsName=cmbGoodsName.Text.Trim();
			_bos.cnvcGoodsType=cmbGoodsType.Text.Trim();
			_bos.cnvcUnit="KG";
			_bos.cnnReceivableCount=Convert.ToDecimal(txtReceivableCount.Text.Trim());
			_bos.cnnCount=Convert.ToDecimal(txtCount.Text.Trim());
			_bos.cnvcComments=txtComments.Text.Trim();
			_bos.cnvcStorageIncharge=txtStorageIncharge.Text.Trim();
			_bos.cnvcDeliveryMan=txtDeliveryMan.Text.Trim();
			_bos.cnvcLister=txtLister.Text.Trim();
			_bos.cnvcOperName=SysInitial.CurOps.strOperName;
			_bos.cnvcDeptID=SysInitial.LocalDeptID;
			_bos.cnvcDeliveryDeptID=strDeliveryDeptID;
			return true;
		}
		private bool BOSValidate()
		{
			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
			{
				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			if(txtBillNo.Text.Trim()=="")
			{
				MessageBox.Show("出库单号不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			else
			{
				if(this._flag == OperFlag.ADD)
				{
					err=null;
					if(cs.IsDupBillOfOutStorage(txtBillNo.Text.Trim(),out err))
					{
						MessageBox.Show("出库单号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return false;
					}
				}
			}
			if(txtMoveNo.Text.Trim()=="")
			{
				MessageBox.Show("调拨单号不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtBillOfMaterialsNo.Text.Trim()=="")
			{
				MessageBox.Show("领料单号不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtReceivableCount.Text.Trim()=="")
			{
				MessageBox.Show("应发数不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(txtCount.Text.Trim()=="")
			{
				MessageBox.Show("实发数不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if(cmbDeliveryCompany.Text.Trim()=="")
			{
				MessageBox.Show("提货单位不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private string GetDDeptID()
		{
			string strDeliveryDeptID=this.GetColEn(cmbDeliveryCompany.Text.Trim(),"DeptTmp");
			if(strDeliveryDeptID==null||strDeliveryDeptID=="")
			{
				MessageBox.Show("获取提货单位ID出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
			return strDeliveryDeptID;
		}
		private void BOSADD()
		{
			if(!BOSValidate()) return;
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			

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
			
			string strDeliveryDeptID=GetDDeptID();
			if(strDeliveryDeptID == "") return;

			CMSMStruct.BillOfOutStorageStruct billofout=new CMSMData.CMSMStruct.BillOfOutStorageStruct();
			billofout.strBillNo=txtBillNo.Text.Trim();
			billofout.strProvideStroage=txtProvideStroage.Text.Trim();
			billofout.strDeliveryCompany=cmbDeliveryCompany.Text.Trim();
			billofout.strMoveNo=txtMoveNo.Text.Trim();
			billofout.strBillOfMaterialsNo=txtBillOfMaterialsNo.Text.Trim();
			billofout.strTransportCompany=txtTransportCompany.Text.Trim();
			billofout.strTransportLiscenseTags=txtTransportLiscenseTags.Text.Trim();
			billofout.strOutStorageDate=dtpOutStorageDate.Value.ToShortDateString();
			billofout.strGoodsName=strGoodsName;
			billofout.strGoodsType=strGoodsType;
			billofout.strUnit="KG";
			billofout.strReceivableCount=txtReceivableCount.Text.Trim();
			billofout.strCount=txtCount.Text.Trim();
			billofout.strComments=txtComments.Text.Trim();
			billofout.strStorageIncharge=txtStorageIncharge.Text.Trim();
			billofout.strDeliveryMan=txtDeliveryMan.Text.Trim();
			billofout.strLister=txtLister.Text.Trim();
			billofout.strOutType="调拨出库";
			billofout.strOperName=SysInitial.CurOps.strOperName;
			billofout.strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			billofout.strDeptID=SysInitial.LocalDeptID;
			billofout.strDeliveryDeptID=strDeliveryDeptID;

			CMSMStruct.OilStorageLogStruct oilslog=new CMSMData.CMSMStruct.OilStorageLogStruct();
			oilslog.strDeptName=SysInitial.LocalDeptName;
			oilslog.strGoodsName=oils.strGoodsName;
			oilslog.strGoodsType=oils.strGoodsType;
			oilslog.strInOutCount=(-double.Parse(billofout.strCount)).ToString();
			oilslog.strLastCount=oils.dStorageCount.ToString();
			oilslog.strCurCount=(Math.Round(oils.dStorageCount-double.Parse(billofout.strCount),2)).ToString();
			oilslog.strOperType="调拨出库";
			oilslog.strOperName=billofout.strOperName;
			oilslog.strOperDate=billofout.strOperDate;
			oilslog.strDeptID=SysInitial.LocalDeptID;

			DialogResult drMG= MessageBox.Show(this,"是否要对\r 出库单号单号：【"+billofout.strBillNo+"】，物料名称：【"+billofout.strGoodsName+"】，物料型号：【"+billofout.strGoodsType+"】，实发数：【"+billofout.strCount+"】\r是否继续出库？","请仔细核对调拨出库单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
			
			if (drMG == DialogResult.No)
			{
				return;
			}
			err=null;
			if(cs.InsertBillOfOutStorage(billofout,oilslog,out err))
			{
				MessageBox.Show("油料出库单录入成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{
				MessageBox.Show("油料出库单录入失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}
		private void BOSMOD()
		{
			if(!BOSValidate()) return;
			if(!this.GetBOS()) return;
			Entity.BusiLog bl = new BusiLog();			
			bl.cnvcDeptID = CMSMData.CMSMDataAccess.SysInitial.LocalDeptID;
			bl.cnvcDeptName = SysInitial.LocalDeptName;
			bl.cnvcOperName = SysInitial.CurOps.strOperName;
			

			if(MessageBox.Show(this,"是否要对\r 出库单号单号：【"+_bos.cnvcBillNo+"】，物料名称：【"+_bos.cnvcGoodsName+"】，物料型号：【"+_bos.cnvcGoodsType+"】，实发数：【"+_bos.cnnCount+"】\r是否继续出库？","请仔细核对调拨出库单据准确无误后再点“是”否则点“否”！！！",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)
				==DialogResult.No) return;
						
			Business.BOSFacade bf = new CMSM.Business.BOSFacade();
			try
			{
				bf.BOSMOD(_bos,bl,IsHis);
				MessageBox.Show("油料出库单修改成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show("油料出库单修改失败！\r 错误如下：\r"
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
					BOSADD();
					break;
				case OperFlag.MOD:
					BOSMOD();
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


		private void txtReceivableCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void frmBillOfOutStorageAdd_Load(object sender, System.EventArgs e)
		{			
			ShowComponent();
		}
	}
}
