using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.IO;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmSysSet.
	/// </summary>
	public class frmSysSet : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox ltbGoods;
		private System.Windows.Forms.ListBox ltbAD;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnRemove;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.SimpleButton sbtnSet;
		private System.Windows.Forms.TextBox txtIg;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private DevExpress.XtraEditors.SimpleButton sbtnProm;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbt1;
		private System.Windows.Forms.RadioButton rbt3;
		private System.Windows.Forms.RadioButton rbt2;
		private System.Windows.Forms.RadioButton rbt4;
		private System.Windows.Forms.RadioButton rbt5;
		private System.Windows.Forms.RadioButton rbt6;
		private System.Windows.Forms.RadioButton rbt7;
		private System.Windows.Forms.RadioButton rbt8;
		private System.Windows.Forms.RadioButton rbt9;
		private System.Windows.Forms.RadioButton rbt10;
		private DevExpress.XtraEditors.SimpleButton sbtnCom;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtPromRate1;
		private System.Windows.Forms.TextBox txtPromRate2;
		private System.Windows.Forms.TextBox txtPromRate3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSysSet()
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
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnRemove = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ltbAD = new System.Windows.Forms.ListBox();
			this.ltbGoods = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.sbtnProm = new DevExpress.XtraEditors.SimpleButton();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPromRate1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.sbtnSet = new DevExpress.XtraEditors.SimpleButton();
			this.label7 = new System.Windows.Forms.Label();
			this.txtIg = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFee = new System.Windows.Forms.TextBox();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbt10 = new System.Windows.Forms.RadioButton();
			this.rbt9 = new System.Windows.Forms.RadioButton();
			this.rbt8 = new System.Windows.Forms.RadioButton();
			this.rbt7 = new System.Windows.Forms.RadioButton();
			this.rbt6 = new System.Windows.Forms.RadioButton();
			this.rbt5 = new System.Windows.Forms.RadioButton();
			this.rbt4 = new System.Windows.Forms.RadioButton();
			this.rbt2 = new System.Windows.Forms.RadioButton();
			this.rbt3 = new System.Windows.Forms.RadioButton();
			this.rbt1 = new System.Windows.Forms.RadioButton();
			this.sbtnCom = new DevExpress.XtraEditors.SimpleButton();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtPromRate2 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtPromRate3 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sbtnSave);
			this.groupBox1.Controls.Add(this.sbtnRemove);
			this.groupBox1.Controls.Add(this.sbtnAdd);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ltbAD);
			this.groupBox1.Controls.Add(this.ltbGoods);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 464);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "新商品推荐设置";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnSave.Location = new System.Drawing.Point(184, 296);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.Size = new System.Drawing.Size(56, 23);
			this.sbtnSave.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnSave.TabIndex = 12;
			this.sbtnSave.Text = "保存";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnRemove
			// 
			this.sbtnRemove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnRemove.Location = new System.Drawing.Point(184, 200);
			this.sbtnRemove.Name = "sbtnRemove";
			this.sbtnRemove.Size = new System.Drawing.Size(56, 23);
			this.sbtnRemove.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnRemove.TabIndex = 11;
			this.sbtnRemove.Text = "<<移除";
			this.sbtnRemove.Click += new System.EventHandler(this.sbtnRemove_Click);
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAdd.Location = new System.Drawing.Point(184, 160);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.Size = new System.Drawing.Size(56, 23);
			this.sbtnAdd.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAdd.TabIndex = 10;
			this.sbtnAdd.Text = "添加>>";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(304, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "推荐新品";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "现有商品";
			// 
			// ltbAD
			// 
			this.ltbAD.ItemHeight = 12;
			this.ltbAD.Location = new System.Drawing.Point(248, 48);
			this.ltbAD.Name = "ltbAD";
			this.ltbAD.Size = new System.Drawing.Size(168, 400);
			this.ltbAD.TabIndex = 1;
			// 
			// ltbGoods
			// 
			this.ltbGoods.ItemHeight = 12;
			this.ltbGoods.Location = new System.Drawing.Point(16, 48);
			this.ltbGoods.Name = "ltbGoods";
			this.ltbGoods.Size = new System.Drawing.Size(165, 400);
			this.ltbGoods.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.txtPromRate3);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.txtPromRate2);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.sbtnProm);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtPromRate1);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.sbtnSet);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.txtIg);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtFee);
			this.groupBox2.Controls.Add(this.sbtnClose);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(432, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(290, 320);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 280);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(200, 32);
			this.label11.TabIndex = 26;
			this.label11.Text = " 注意：该参数如果不配置，将视为充值赠款为0";
			// 
			// sbtnProm
			// 
			this.sbtnProm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnProm.Location = new System.Drawing.Point(224, 272);
			this.sbtnProm.Name = "sbtnProm";
			this.sbtnProm.Size = new System.Drawing.Size(56, 23);
			this.sbtnProm.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnProm.TabIndex = 25;
			this.sbtnProm.Text = "设置";
			this.sbtnProm.Click += new System.EventHandler(this.sbtnProm_Click);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(208, 184);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(16, 16);
			this.label10.TabIndex = 24;
			this.label10.Text = "%";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(24, 184);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 16);
			this.label9.TabIndex = 23;
			this.label9.Text = "100-500赠款比例";
			// 
			// txtPromRate1
			// 
			this.txtPromRate1.Location = new System.Drawing.Point(152, 176);
			this.txtPromRate1.MaxLength = 10;
			this.txtPromRate1.Name = "txtPromRate1";
			this.txtPromRate1.Size = new System.Drawing.Size(56, 21);
			this.txtPromRate1.TabIndex = 22;
			this.txtPromRate1.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(144, 16);
			this.label8.TabIndex = 21;
			this.label8.Text = "充值赠款金额设置：";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(200, 32);
			this.label6.TabIndex = 20;
			this.label6.Text = " 注意：该参数如果不配置，将视为消费无积分";
			// 
			// sbtnSet
			// 
			this.sbtnSet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnSet.Location = new System.Drawing.Point(224, 96);
			this.sbtnSet.Name = "sbtnSet";
			this.sbtnSet.Size = new System.Drawing.Size(56, 23);
			this.sbtnSet.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnSet.TabIndex = 19;
			this.sbtnSet.Text = "设置";
			this.sbtnSet.Click += new System.EventHandler(this.sbtnSet_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(216, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 16);
			this.label7.TabIndex = 18;
			this.label7.Text = "积分";
			// 
			// txtIg
			// 
			this.txtIg.Location = new System.Drawing.Point(168, 64);
			this.txtIg.MaxLength = 10;
			this.txtIg.Name = "txtIg";
			this.txtIg.Size = new System.Drawing.Size(48, 21);
			this.txtIg.TabIndex = 14;
			this.txtIg.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(32, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "消费";
			// 
			// txtFee
			// 
			this.txtFee.Location = new System.Drawing.Point(64, 64);
			this.txtFee.MaxLength = 10;
			this.txtFee.Name = "txtFee";
			this.txtFee.Size = new System.Drawing.Size(48, 21);
			this.txtFee.TabIndex = 12;
			this.txtFee.Text = "";
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(224, 16);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 11;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "消费积分设置：";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(112, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "元，赠送";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbt10);
			this.groupBox3.Controls.Add(this.rbt9);
			this.groupBox3.Controls.Add(this.rbt8);
			this.groupBox3.Controls.Add(this.rbt7);
			this.groupBox3.Controls.Add(this.rbt6);
			this.groupBox3.Controls.Add(this.rbt5);
			this.groupBox3.Controls.Add(this.rbt4);
			this.groupBox3.Controls.Add(this.rbt2);
			this.groupBox3.Controls.Add(this.rbt3);
			this.groupBox3.Controls.Add(this.rbt1);
			this.groupBox3.Controls.Add(this.sbtnCom);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox3.Location = new System.Drawing.Point(432, 328);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(290, 136);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "通信串口设置：";
			// 
			// rbt10
			// 
			this.rbt10.Location = new System.Drawing.Point(88, 96);
			this.rbt10.Name = "rbt10";
			this.rbt10.Size = new System.Drawing.Size(64, 24);
			this.rbt10.TabIndex = 35;
			this.rbt10.Text = "COM10";
			// 
			// rbt9
			// 
			this.rbt9.Location = new System.Drawing.Point(24, 96);
			this.rbt9.Name = "rbt9";
			this.rbt9.Size = new System.Drawing.Size(56, 24);
			this.rbt9.TabIndex = 34;
			this.rbt9.Text = "COM9";
			// 
			// rbt8
			// 
			this.rbt8.Location = new System.Drawing.Point(216, 64);
			this.rbt8.Name = "rbt8";
			this.rbt8.Size = new System.Drawing.Size(56, 24);
			this.rbt8.TabIndex = 33;
			this.rbt8.Text = "COM8";
			// 
			// rbt7
			// 
			this.rbt7.Location = new System.Drawing.Point(152, 64);
			this.rbt7.Name = "rbt7";
			this.rbt7.Size = new System.Drawing.Size(56, 24);
			this.rbt7.TabIndex = 32;
			this.rbt7.Text = "COM7";
			// 
			// rbt6
			// 
			this.rbt6.Location = new System.Drawing.Point(88, 64);
			this.rbt6.Name = "rbt6";
			this.rbt6.Size = new System.Drawing.Size(56, 24);
			this.rbt6.TabIndex = 31;
			this.rbt6.Text = "COM6";
			// 
			// rbt5
			// 
			this.rbt5.Location = new System.Drawing.Point(24, 64);
			this.rbt5.Name = "rbt5";
			this.rbt5.Size = new System.Drawing.Size(56, 24);
			this.rbt5.TabIndex = 30;
			this.rbt5.Text = "COM5";
			// 
			// rbt4
			// 
			this.rbt4.Location = new System.Drawing.Point(216, 32);
			this.rbt4.Name = "rbt4";
			this.rbt4.Size = new System.Drawing.Size(56, 24);
			this.rbt4.TabIndex = 29;
			this.rbt4.Text = "COM4";
			// 
			// rbt2
			// 
			this.rbt2.Location = new System.Drawing.Point(88, 32);
			this.rbt2.Name = "rbt2";
			this.rbt2.Size = new System.Drawing.Size(56, 24);
			this.rbt2.TabIndex = 28;
			this.rbt2.Text = "COM2";
			// 
			// rbt3
			// 
			this.rbt3.Location = new System.Drawing.Point(152, 32);
			this.rbt3.Name = "rbt3";
			this.rbt3.Size = new System.Drawing.Size(56, 24);
			this.rbt3.TabIndex = 27;
			this.rbt3.Text = "COM3";
			// 
			// rbt1
			// 
			this.rbt1.Location = new System.Drawing.Point(24, 32);
			this.rbt1.Name = "rbt1";
			this.rbt1.Size = new System.Drawing.Size(56, 24);
			this.rbt1.TabIndex = 26;
			this.rbt1.Text = "COM1";
			// 
			// sbtnCom
			// 
			this.sbtnCom.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCom.Location = new System.Drawing.Point(216, 104);
			this.sbtnCom.Name = "sbtnCom";
			this.sbtnCom.Size = new System.Drawing.Size(56, 23);
			this.sbtnCom.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCom.TabIndex = 25;
			this.sbtnCom.Text = "设置";
			this.sbtnCom.Click += new System.EventHandler(this.sbtnCom_Click);
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(208, 216);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(16, 16);
			this.label12.TabIndex = 29;
			this.label12.Text = "%";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(24, 216);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(128, 16);
			this.label13.TabIndex = 28;
			this.label13.Text = "500-1000赠款比例";
			// 
			// txtPromRate2
			// 
			this.txtPromRate2.Location = new System.Drawing.Point(152, 208);
			this.txtPromRate2.MaxLength = 10;
			this.txtPromRate2.Name = "txtPromRate2";
			this.txtPromRate2.Size = new System.Drawing.Size(56, 21);
			this.txtPromRate2.TabIndex = 27;
			this.txtPromRate2.Text = "";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.Location = new System.Drawing.Point(208, 248);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 16);
			this.label14.TabIndex = 32;
			this.label14.Text = "%";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.Location = new System.Drawing.Point(24, 248);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(128, 16);
			this.label15.TabIndex = 31;
			this.label15.Text = "1000以上赠款比例";
			// 
			// txtPromRate3
			// 
			this.txtPromRate3.Location = new System.Drawing.Point(152, 240);
			this.txtPromRate3.MaxLength = 10;
			this.txtPromRate3.Name = "txtPromRate3";
			this.txtPromRate3.Size = new System.Drawing.Size(56, 21);
			this.txtPromRate3.TabIndex = 30;
			this.txtPromRate3.Text = "";
			// 
			// frmSysSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(722, 464);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysSet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "系统参数设置";
			this.Load += new System.EventHandler(this.frmSysSet_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSysSet_Load(object sender, System.EventArgs e)
		{
			DataTable dtgoods=SysInitial.dsSys.Tables["Goods"];
			for(int i=0;i<dtgoods.Rows.Count;i++)
			{
				ltbGoods.Items.Add(dtgoods.Rows[i]["vcGoodsName"].ToString());
				if(dtgoods.Rows[i]["cNewFlag"].ToString()=="1")
				{
					ltbAD.Items.Add(dtgoods.Rows[i]["vcGoodsName"].ToString());
				}	
			}
			dtgoods=new DataTable();
			dtgoods=SysInitial.dsSys.Tables["IG"];
			if(dtgoods.Rows.Count>0)
			{
				txtFee.Text=dtgoods.Rows[0]["vcCommName"].ToString();
				txtIg.Text=dtgoods.Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtFee.Text="";
				txtIg.Text="";
			}

			if(SysInitial.dsSys.Tables["FP1"].Rows.Count>0)
			{
				txtPromRate1.Text=SysInitial.dsSys.Tables["FP1"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate1.Text="0";
			}
			if(SysInitial.dsSys.Tables["FP2"].Rows.Count>0)
			{
				txtPromRate2.Text=SysInitial.dsSys.Tables["FP2"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate2.Text="0";
			}

			if(SysInitial.dsSys.Tables["FP3"].Rows.Count>0)
			{
				txtPromRate3.Text=SysInitial.dsSys.Tables["FP3"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate3.Text="0";
			}
			
			this.label6.ForeColor=Color.Red;

			switch(SysInitial.intCom)
			{
				case 0:
					this.rbt1.Checked=true;
					break;
				case 1:
					this.rbt2.Checked=true;
					break;
				case 2:
					this.rbt3.Checked=true;
					break;
				case 3:
					this.rbt4.Checked=true;
					break;
				case 4:
					this.rbt5.Checked=true;
					break;
				case 5:
					this.rbt6.Checked=true;
					break;
				case 6:
					this.rbt7.Checked=true;
					break;
				case 7:
					this.rbt8.Checked=true;
					break;
				case 8:
					this.rbt9.Checked=true;
					break;
				case 9:
					this.rbt10.Checked=true;
					break;
			}
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			if(ltbGoods.Items.Count==0)
			{
				MessageBox.Show("没有商品信息，请先录入商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			if(ltbAD.Items.Count>=10)
			{
				MessageBox.Show("推荐新品只能设置10个！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			for(int i=0;i<ltbAD.Items.Count;i++)
			{
				if(ltbGoods.SelectedItem.ToString()==ltbAD.Items[i].ToString())
				{
					return;
				}
			}
			if(ltbGoods.SelectedItem==null)
			{
				MessageBox.Show("请确定选中某个商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{
				ltbAD.Items.Add(ltbGoods.SelectedItem);
			}
		}

		private void sbtnRemove_Click(object sender, System.EventArgs e)
		{
			if(ltbAD.Items.Count==0)
			{
				MessageBox.Show("目前还没有要推荐的商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			ltbAD.Items.Remove(ltbAD.SelectedItem);
		}

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
//			ArrayList al=new ArrayList();
//			for(int i=0;i<ltbAD.Items.Count;i++)
//			{
//				al.Add(ltbAD.Items[i].ToString());
//			}
//			CommAccess cs=new CommAccess(SysInitial.ConString);
//			Exception err=null;
//			cs.UpdateGoodsNew(al,out err);
//			if(err==null)
//			{
//				MessageBox.Show("推荐新品设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//				err=null;
//				SysInitial.CreatDS(out err);
//				if(err!=null)
//				{
//					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					Application.Exit();
//				}
//				return;
//			}
//			else
//			{
//				MessageBox.Show("推荐新品设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				clog.WriteLine(err);
//				return;
//			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnSet_Click(object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.CommStruct cos=new CMSMData.CMSMStruct.CommStruct();
			if(txtFee.Text.Trim()=="")
			{
				cos.strCommName="0";
			}
			else if(double.Parse(txtFee.Text.Trim())<0)
			{
				MessageBox.Show("消费金额不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommName=txtFee.Text.Trim();
			}

			if(txtIg.Text.Trim()=="")
			{
				cos.strCommCode="0";
			}
			else if(double.Parse(txtIg.Text.Trim())<0)
			{
				MessageBox.Show("赠送积分分值不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommCode=txtIg.Text.Trim();
			}
			cos.strCommSign="IG";
			cos.strComments="积分赠送";
			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
			cs.UpdateIgComm(cos,out err);
			if(err==null)
			{
				MessageBox.Show("消费积分设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("消费积分设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void sbtnProm_Click(Object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.CommStruct cos=new CMSMData.CMSMStruct.CommStruct();
			Hashtable htpar=new Hashtable();
			if(txtPromRate1.Text.Trim()=="")
			{
				cos.strCommCode="0";
			}
			else if(double.Parse(txtPromRate1.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommCode=txtPromRate1.Text.Trim();
			}
			cos.strCommName="充值赠款100-500";
			cos.strCommSign="FP1";
			cos.strComments="充值赠款";
			htpar.Add("FP1",cos);

			CMSMData.CMSMStruct.CommStruct cos2=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate2.Text.Trim()=="")
			{
				cos2.strCommCode="0";
			}
			else if(double.Parse(txtPromRate2.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos2.strCommCode=txtPromRate2.Text.Trim();
			}
			cos2.strCommName="充值赠款500-1000";
			cos2.strCommSign="FP2";
			cos2.strComments="充值赠款";
			htpar.Add("FP2",cos2);

			CMSMData.CMSMStruct.CommStruct cos3=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate3.Text.Trim()=="")
			{
				cos3.strCommCode="0";
			}
			else if(double.Parse(txtPromRate3.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos3.strCommCode=txtPromRate3.Text.Trim();
			}
			cos3.strCommName="充值赠款1000以上";
			cos3.strCommSign="FP3";
			cos3.strComments="充值赠款";
			htpar.Add("FP3",cos3);

			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
//			cs.UpdateFillPromComm(htpar,out err);
			if(err==null)
			{
				MessageBox.Show("充值赠款比例设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("充值赠款比例设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void sbtnCom_Click(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Control con1 in this.groupBox3.Controls)
			{
				if(con1 is RadioButton)
				{
					RadioButton rbttmp=con1 as RadioButton;
					if(rbttmp.Checked)
					{
						string rbtname=rbttmp.Name.Substring(3,rbttmp.Name.Length-3);
						int icom=int.Parse(rbtname);
						icom=icom-1;
//						CardCommon.CardRef.CardM1 card1=new CardCommon.CardRef.CardM1(Int16.Parse(icom.ToString()));
//						if(!card1.TestCommPort())
//						{
//							MessageBox.Show("无法连接，该端口连接异常，请选择其它端口！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//							break;
//						}
						SysInitial.intCom=Int16.Parse(icom.ToString());
						string FileName="comset.bet";
						string filePath=Environment.CurrentDirectory;
						if(System.IO.File.Exists(filePath+@"\"+FileName))
							System.IO.File.Delete(filePath+@"\"+FileName);
						StreamWriter swFile = new StreamWriter(filePath+@"\"+FileName,true);
						swFile.WriteLine("COMPort=" + SysInitial.intCom.ToString());
						swFile.Close();
						MessageBox.Show("通信串口设置成功，连接正常！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						break;
					}
					else
					{
						continue;
					}
				}
			}
		}
	}
}
