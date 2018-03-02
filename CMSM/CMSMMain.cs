using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSM.CMSMApp;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.Data.SqlClient;
using Sunmast.Hardware;
using cc;
using System.Management;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CMSM
{
	/// <summary>
	/// Summary description for CMSMMain.
	/// </summary>
	public class CMSMMain : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		#region �������
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem7;
		private DevExpress.XtraNavBar.NavBarControl navBarControl1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.Timer timerauto;
		private System.Windows.Forms.MenuItem m01;
		private System.Windows.Forms.MenuItem m0101;
		private System.Windows.Forms.MenuItem m02;
		private System.Windows.Forms.MenuItem m0201;
		private System.Windows.Forms.MenuItem m0202;
		private System.Windows.Forms.MenuItem m0203;
		private System.Windows.Forms.MenuItem m0204;
		private System.Windows.Forms.MenuItem m0205;
		private System.Windows.Forms.MenuItem m03;
		private System.Windows.Forms.MenuItem m0301;
		private System.Windows.Forms.MenuItem m0302;
		private System.Windows.Forms.MenuItem m04;
		private System.Windows.Forms.MenuItem m0401;
		private System.Windows.Forms.MenuItem m0402;
		private System.Windows.Forms.MenuItem m0403;
		private System.Windows.Forms.MenuItem m05;
		private System.Windows.Forms.MenuItem m0501;
		private System.Windows.Forms.MenuItem m0502;
		private System.Windows.Forms.MenuItem m06;
		private System.Windows.Forms.MenuItem m0601;
		private System.Windows.Forms.MenuItem m0602;
		private System.Windows.Forms.MenuItem m0603;
		private System.Windows.Forms.MenuItem m0604;
		private System.Windows.Forms.MenuItem m07;
		private System.Windows.Forms.MenuItem m0701;
		private System.Windows.Forms.MenuItem m0702;
		private DevExpress.XtraNavBar.NavBarGroup nbg01;
		private DevExpress.XtraNavBar.NavBarItem nbi0101;
		private DevExpress.XtraNavBar.NavBarGroup nbg02;
		private DevExpress.XtraNavBar.NavBarItem nbi0201;
		private DevExpress.XtraNavBar.NavBarItem nbi0202;
		private DevExpress.XtraNavBar.NavBarItem nbi0203;
		private DevExpress.XtraNavBar.NavBarItem nbi0204;
		private DevExpress.XtraNavBar.NavBarItem nbi0205;
		private DevExpress.XtraNavBar.NavBarGroup nbg03;
		private DevExpress.XtraNavBar.NavBarItem nbi0301;
		private DevExpress.XtraNavBar.NavBarItem nbi0302;
		private DevExpress.XtraNavBar.NavBarGroup nbg04;
		private DevExpress.XtraNavBar.NavBarItem nbi0401;
		private DevExpress.XtraNavBar.NavBarItem navBarItem16;
		private DevExpress.XtraNavBar.NavBarItem nbi0402;
		private DevExpress.XtraNavBar.NavBarItem nbi0403;
		private DevExpress.XtraNavBar.NavBarGroup nbg05;
		private DevExpress.XtraNavBar.NavBarItem nbi0501;
		private DevExpress.XtraNavBar.NavBarItem nbi0502;
		private DevExpress.XtraNavBar.NavBarGroup nbg07;
		private DevExpress.XtraNavBar.NavBarItem nbi0701;
		private DevExpress.XtraNavBar.NavBarItem nbi0702;
		private DevExpress.XtraNavBar.NavBarItem nbi0503;
		private System.Windows.Forms.MenuItem m0503;
		private System.Windows.Forms.MenuItem m08;
		private System.Windows.Forms.MenuItem m0802;
		private System.Windows.Forms.MenuItem m0801;
		private System.Windows.Forms.MenuItem m0102;
		private DevExpress.XtraNavBar.NavBarItem nbi0102;
		private System.Windows.Forms.MenuItem m0404;
		private DevExpress.XtraNavBar.NavBarItem nbi0404;
		private System.Windows.Forms.MenuItem menuItem1;
		private DevExpress.XtraNavBar.NavBarItem navBarItem1;
		private DevExpress.XtraNavBar.NavBarItem navBarItem2;
		log.CMSMLog clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

		#endregion

		public CMSMMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CMSMMain));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.m01 = new System.Windows.Forms.MenuItem();
			this.m0101 = new System.Windows.Forms.MenuItem();
			this.m0102 = new System.Windows.Forms.MenuItem();
			this.m02 = new System.Windows.Forms.MenuItem();
			this.m0201 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.m0202 = new System.Windows.Forms.MenuItem();
			this.m0203 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.m0204 = new System.Windows.Forms.MenuItem();
			this.m0205 = new System.Windows.Forms.MenuItem();
			this.m03 = new System.Windows.Forms.MenuItem();
			this.m0301 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m0302 = new System.Windows.Forms.MenuItem();
			this.m04 = new System.Windows.Forms.MenuItem();
			this.m0401 = new System.Windows.Forms.MenuItem();
			this.m0402 = new System.Windows.Forms.MenuItem();
			this.m0403 = new System.Windows.Forms.MenuItem();
			this.m0404 = new System.Windows.Forms.MenuItem();
			this.m05 = new System.Windows.Forms.MenuItem();
			this.m0501 = new System.Windows.Forms.MenuItem();
			this.m0502 = new System.Windows.Forms.MenuItem();
			this.m0503 = new System.Windows.Forms.MenuItem();
			this.m08 = new System.Windows.Forms.MenuItem();
			this.m0801 = new System.Windows.Forms.MenuItem();
			this.m0802 = new System.Windows.Forms.MenuItem();
			this.m06 = new System.Windows.Forms.MenuItem();
			this.m0601 = new System.Windows.Forms.MenuItem();
			this.m0602 = new System.Windows.Forms.MenuItem();
			this.m0603 = new System.Windows.Forms.MenuItem();
			this.m0604 = new System.Windows.Forms.MenuItem();
			this.m07 = new System.Windows.Forms.MenuItem();
			this.m0701 = new System.Windows.Forms.MenuItem();
			this.m0702 = new System.Windows.Forms.MenuItem();
			this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
			this.nbg01 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0101 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0102 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbg02 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0201 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0202 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0203 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0204 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0205 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbg03 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0301 = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0302 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbg04 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0401 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0402 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0403 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0404 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbg05 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0501 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0502 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0503 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbg07 = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi0701 = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi0702 = new DevExpress.XtraNavBar.NavBarItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timerauto = new System.Windows.Forms.Timer(this.components);
			this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m01,
																					  this.m02,
																					  this.m03,
																					  this.m04,
																					  this.m05,
																					  this.m08,
																					  this.m06,
																					  this.m07});
			// 
			// m01
			// 
			this.m01.Index = 0;
			this.m01.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0101,
																				this.m0102});
			this.m01.Text = "��Ա��������";
			// 
			// m0101
			// 
			this.m0101.Enabled = false;
			this.m0101.Index = 0;
			this.m0101.Text = "��Ա��������";
			this.m0101.Click += new System.EventHandler(this.m0101_Click);
			// 
			// m0102
			// 
			this.m0102.Enabled = false;
			this.m0102.Index = 1;
			this.m0102.Text = "��Ա��λ����";
			this.m0102.Visible = false;
			this.m0102.Click += new System.EventHandler(this.m0102_Click);
			// 
			// m02
			// 
			this.m02.Index = 1;
			this.m02.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0201,
																				this.menuItem7,
																				this.m0202,
																				this.m0203,
																				this.menuItem22,
																				this.m0204,
																				this.m0205});
			this.m02.Text = "��Ա������";
			// 
			// m0201
			// 
			this.m0201.Enabled = false;
			this.m0201.Index = 0;
			this.m0201.Text = "��Ա����ֵ";
			this.m0201.Visible = false;
			this.m0201.Click += new System.EventHandler(this.m0201_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "-";
			this.menuItem7.Visible = false;
			// 
			// m0202
			// 
			this.m0202.Enabled = false;
			this.m0202.Index = 2;
			this.m0202.Text = "��Ա����ʧ";
			this.m0202.Click += new System.EventHandler(this.m0202_Click);
			// 
			// m0203
			// 
			this.m0203.Enabled = false;
			this.m0203.Index = 3;
			this.m0203.Text = "��ҺͲ���";
			this.m0203.Click += new System.EventHandler(this.m0203_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 4;
			this.menuItem22.Text = "-";
			// 
			// m0204
			// 
			this.m0204.Enabled = false;
			this.m0204.Index = 5;
			this.m0204.Text = "��ʧֱ���˿�";
			this.m0204.Click += new System.EventHandler(this.m0204_Click);
			// 
			// m0205
			// 
			this.m0205.Enabled = false;
			this.m0205.Index = 6;
			this.m0205.Text = "ˢ���˿�";
			this.m0205.Click += new System.EventHandler(this.m0205_Click);
			// 
			// m03
			// 
			this.m03.Index = 2;
			this.m03.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0301,
																				this.menuItem1,
																				this.m0302});
			this.m03.Text = "��Ա����";
			// 
			// m0301
			// 
			this.m0301.Enabled = false;
			this.m0301.Index = 0;
			this.m0301.Text = "��Ա����";
			this.m0301.Click += new System.EventHandler(this.m0301_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Enabled = false;
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "��Ա���ѳ���";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click_2);
			// 
			// m0302
			// 
			this.m0302.Enabled = false;
			this.m0302.Index = 2;
			this.m0302.Text = "���´�ӡСƱ";
			this.m0302.Click += new System.EventHandler(this.m0302_Click);
			// 
			// m04
			// 
			this.m04.Index = 3;
			this.m04.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0401,
																				this.m0402,
																				this.m0403,
																				this.m0404});
			this.m04.Text = "���ϵ�";
			// 
			// m0401
			// 
			this.m0401.Enabled = false;
			this.m0401.Index = 0;
			this.m0401.Text = "���յ�";
			this.m0401.Click += new System.EventHandler(this.m0401_Click);
			// 
			// m0402
			// 
			this.m0402.Enabled = false;
			this.m0402.Index = 1;
			this.m0402.Text = "�������ⵥ";
			this.m0402.Click += new System.EventHandler(this.m0402_Click);
			// 
			// m0403
			// 
			this.m0403.Enabled = false;
			this.m0403.Index = 2;
			this.m0403.Text = "ר�������ϵ�";
			this.m0403.Click += new System.EventHandler(this.m0403_Click);
			// 
			// m0404
			// 
			this.m0404.Enabled = false;
			this.m0404.Index = 3;
			this.m0404.Text = "ר���ͺ�ͬ";
			this.m0404.Click += new System.EventHandler(this.menuItem1_Click_1);
			// 
			// m05
			// 
			this.m05.Index = 4;
			this.m05.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0501,
																				this.m0502,
																				this.m0503});
			this.m05.Text = "���";
			// 
			// m0501
			// 
			this.m0501.Enabled = false;
			this.m0501.Index = 0;
			this.m0501.Text = "��ǰ���";
			this.m0501.Click += new System.EventHandler(this.m0501_Click);
			// 
			// m0502
			// 
			this.m0502.Enabled = false;
			this.m0502.Index = 1;
			this.m0502.Text = "����̵�";
			this.m0502.Click += new System.EventHandler(this.m0502_Click);
			// 
			// m0503
			// 
			this.m0503.Enabled = false;
			this.m0503.Index = 2;
			this.m0503.Text = "�ܶ�����";
			this.m0503.Click += new System.EventHandler(this.m0503_Click);
			// 
			// m08
			// 
			this.m08.Index = 5;
			this.m08.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0801,
																				this.m0802});
			this.m08.Text = "����ͬ��";
			// 
			// m0801
			// 
			this.m0801.Index = 0;
			this.m0801.Text = "��������";
			this.m0801.Click += new System.EventHandler(this.m0801_Click);
			// 
			// m0802
			// 
			this.m0802.Index = 1;
			this.m0802.Text = "�����ϴ�";
			this.m0802.Click += new System.EventHandler(this.m0802_Click);
			// 
			// m06
			// 
			this.m06.Index = 6;
			this.m06.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0601,
																				this.m0602,
																				this.m0603,
																				this.m0604});
			this.m06.Text = "����";
			// 
			// m0601
			// 
			this.m0601.Index = 0;
			this.m0601.Text = "ˢ�¶�����ʱ��";
			this.m0601.Click += new System.EventHandler(this.m0601_Click);
			// 
			// m0602
			// 
			this.m0602.Index = 1;
			this.m0602.Text = "ע��";
			this.m0602.Click += new System.EventHandler(this.m0602_Click);
			// 
			// m0603
			// 
			this.m0603.Index = 2;
			this.m0603.Text = "��������";
			this.m0603.Click += new System.EventHandler(this.m0603_Click);
			// 
			// m0604
			// 
			this.m0604.Index = 3;
			this.m0604.Text = "����";
			this.m0604.Click += new System.EventHandler(this.m0604_Click);
			// 
			// m07
			// 
			this.m07.Index = 7;
			this.m07.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.m0701,
																				this.m0702});
			this.m07.Text = "�˳�ϵͳ";
			// 
			// m0701
			// 
			this.m0701.Index = 0;
			this.m0701.Text = "ע��";
			this.m0701.Click += new System.EventHandler(this.m0701_Click);
			// 
			// m0702
			// 
			this.m0702.Index = 1;
			this.m0702.Text = "�˳�";
			this.m0702.Click += new System.EventHandler(this.m0702_Click);
			// 
			// navBarControl1
			// 
			this.navBarControl1.ActiveGroup = this.nbg01;
			this.navBarControl1.AllowDrop = true;
			this.navBarControl1.BackColor = System.Drawing.Color.Transparent;
			this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
																							this.nbg01,
																							this.nbg02,
																							this.nbg03,
																							this.nbg04,
																							this.nbg05,
																							this.nbg07});
			this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
																						  this.nbi0101,
																						  this.nbi0201,
																						  this.nbi0202,
																						  this.nbi0203,
																						  this.nbi0301,
																						  this.nbi0302,
																						  this.nbi0401,
																						  this.nbi0402,
																						  this.nbi0501,
																						  this.nbi0701,
																						  this.nbi0702,
																						  this.nbi0502,
																						  this.nbi0204,
																						  this.nbi0205,
																						  this.nbi0403,
																						  this.nbi0503,
																						  this.nbi0102,
																						  this.nbi0404,
																						  this.navBarItem2});
			this.navBarControl1.Location = new System.Drawing.Point(0, 65);
			this.navBarControl1.Name = "navBarControl1";
			this.navBarControl1.Size = new System.Drawing.Size(136, 470);
			this.navBarControl1.TabIndex = 7;
			this.navBarControl1.Text = "navBarControl1";
			this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
			this.navBarControl1.Click += new System.EventHandler(this.navBarControl1_Click);
			// 
			// nbg01
			// 
			this.nbg01.Caption = "��Ա��������";
			this.nbg01.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
			this.nbg01.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0101),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0102)});
			this.nbg01.Name = "nbg01";
			// 
			// nbi0101
			// 
			this.nbi0101.Caption = "��Ա��������";
			this.nbi0101.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0101.LargeImage")));
			this.nbi0101.Name = "nbi0101";
			this.nbi0101.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0101_LinkClicked);
			// 
			// nbi0102
			// 
			this.nbi0102.Caption = "��Ա��λ����";
			this.nbi0102.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0102.LargeImage")));
			this.nbi0102.Name = "nbi0102";
			this.nbi0102.Visible = false;
			this.nbi0102.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0102_LinkClicked);
			// 
			// nbg02
			// 
			this.nbg02.Caption = "��Ա������";
			this.nbg02.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0201),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0202),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0203),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0204),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0205)});
			this.nbg02.Name = "nbg02";
			// 
			// nbi0201
			// 
			this.nbi0201.Caption = "��Ա����ֵ";
			this.nbi0201.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0201.LargeImage")));
			this.nbi0201.Name = "nbi0201";
			this.nbi0201.Visible = false;
			this.nbi0201.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0201_LinkClicked);
			// 
			// nbi0202
			// 
			this.nbi0202.Caption = "��Ա����ʧ";
			this.nbi0202.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0202.LargeImage")));
			this.nbi0202.Name = "nbi0202";
			this.nbi0202.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0202_LinkClicked);
			// 
			// nbi0203
			// 
			this.nbi0203.Caption = "��ҺͲ���";
			this.nbi0203.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0203.LargeImage")));
			this.nbi0203.Name = "nbi0203";
			this.nbi0203.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0203_LinkClicked);
			// 
			// nbi0204
			// 
			this.nbi0204.Caption = "��ʧֱ���˿�";
			this.nbi0204.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0204.LargeImage")));
			this.nbi0204.Name = "nbi0204";
			this.nbi0204.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0204_LinkClicked);
			// 
			// nbi0205
			// 
			this.nbi0205.Caption = "ˢ���˿�";
			this.nbi0205.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0205.LargeImage")));
			this.nbi0205.Name = "nbi0205";
			this.nbi0205.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0205_LinkClicked);
			// 
			// nbg03
			// 
			this.nbg03.Caption = "��Ա����";
			this.nbg03.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0301),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0302)});
			this.nbg03.Name = "nbg03";
			// 
			// nbi0301
			// 
			this.nbi0301.Caption = "��Ա����";
			this.nbi0301.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0301.LargeImage")));
			this.nbi0301.Name = "nbi0301";
			this.nbi0301.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0301_LinkClicked);
			// 
			// navBarItem2
			// 
			this.navBarItem2.Caption = "��Ա���ѳ���";
			this.navBarItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.LargeImage")));
			this.navBarItem2.Name = "navBarItem2";
			this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
			// 
			// nbi0302
			// 
			this.nbi0302.Caption = "���´�ӡСƱ";
			this.nbi0302.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0302.LargeImage")));
			this.nbi0302.Name = "nbi0302";
			this.nbi0302.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0302_LinkClicked);
			// 
			// nbg04
			// 
			this.nbg04.Caption = "���ϵ�";
			this.nbg04.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0401),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0402),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0403),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0404)});
			this.nbg04.Name = "nbg04";
			// 
			// nbi0401
			// 
			this.nbi0401.Caption = "���յ�";
			this.nbi0401.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0401.LargeImage")));
			this.nbi0401.Name = "nbi0401";
			this.nbi0401.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0401_LinkClicked);
			// 
			// nbi0402
			// 
			this.nbi0402.Caption = "�������ⵥ";
			this.nbi0402.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0402.LargeImage")));
			this.nbi0402.Name = "nbi0402";
			this.nbi0402.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0402_LinkClicked);
			// 
			// nbi0403
			// 
			this.nbi0403.Caption = "ר�������ϵ�";
			this.nbi0403.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0403.LargeImage")));
			this.nbi0403.Name = "nbi0403";
			this.nbi0403.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0403_LinkClicked);
			// 
			// nbi0404
			// 
			this.nbi0404.Caption = "ר���ͺ�ͬ";
			this.nbi0404.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0404.LargeImage")));
			this.nbi0404.Name = "nbi0404";
			this.nbi0404.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0404_LinkClicked);
			// 
			// nbg05
			// 
			this.nbg05.Caption = "���";
			this.nbg05.Expanded = true;
			this.nbg05.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0501),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0502),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0503)});
			this.nbg05.Name = "nbg05";
			// 
			// nbi0501
			// 
			this.nbi0501.Caption = "��ǰ���";
			this.nbi0501.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0501.LargeImage")));
			this.nbi0501.Name = "nbi0501";
			this.nbi0501.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0501_LinkClicked);
			// 
			// nbi0502
			// 
			this.nbi0502.Caption = "����̵�";
			this.nbi0502.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0502.LargeImage")));
			this.nbi0502.Name = "nbi0502";
			this.nbi0502.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0502_LinkClicked);
			// 
			// nbi0503
			// 
			this.nbi0503.Caption = "�ܶ�����";
			this.nbi0503.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0503.LargeImage")));
			this.nbi0503.Name = "nbi0503";
			this.nbi0503.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0503_LinkClicked);
			// 
			// nbg07
			// 
			this.nbg07.Caption = "�˳�ϵͳ";
			this.nbg07.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0701),
																						 new DevExpress.XtraNavBar.NavBarItemLink(this.nbi0702)});
			this.nbg07.Name = "nbg07";
			// 
			// nbi0701
			// 
			this.nbi0701.Caption = "ע��";
			this.nbi0701.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0701.LargeImage")));
			this.nbi0701.Name = "nbi0701";
			this.nbi0701.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0701_LinkClicked);
			// 
			// nbi0702
			// 
			this.nbi0702.Caption = "�˳�";
			this.nbi0702.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbi0702.LargeImage")));
			this.nbi0702.Name = "nbi0702";
			this.nbi0702.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi0702_LinkClicked);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 535);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel4,
																						  this.statusBarPanel5,
																						  this.statusBarPanel1,
																						  this.statusBarPanel2,
																						  this.statusBarPanel3});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(928, 22);
			this.statusBar1.TabIndex = 9;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel4.Text = "��ӭʹ�õ�Ѷ�Ƽ���Ա����ϵͳ";
			this.statusBarPanel4.Width = 182;
			// 
			// statusBarPanel5
			// 
			this.statusBarPanel5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel5.Text = "�ŵ꣺";
			this.statusBarPanel5.Width = 182;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "����Ա��";
			this.statusBarPanel1.Width = 182;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Text = "��ǰλ�ã�";
			this.statusBarPanel2.Width = 182;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel3.Text = "ʱ�䣺";
			this.statusBarPanel3.Width = 182;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(928, 65);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timerauto
			// 
			this.timerauto.Tick += new System.EventHandler(this.timerauto_Tick);
			// 
			// navBarItem16
			// 
			this.navBarItem16.Name = "navBarItem16";
			// 
			// navBarItem1
			// 
			this.navBarItem1.Caption = "��Ա����";
			this.navBarItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem1.LargeImage")));
			this.navBarItem1.Name = "navBarItem1";
			// 
			// CMSMMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(928, 557);
			this.Controls.Add(this.navBarControl1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "CMSMMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "���ϻ��ܼ��Ϳ�����ϵͳ";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CMSMMain_Closing);
			this.Load += new System.EventHandler(this.CMSMMain_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.CMSMMain_HelpRequested);
			this.Closed += new System.EventHandler(this.CMSMMain_Closed);
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Diagnostics.Process[] proCM=System.Diagnostics.Process.GetProcessesByName("CMSM");
			if(proCM.Length==1)
			{
				Application.Run(new CMSMMain());
			}
		}

		#region encode Column convert to Chinise
		protected string GetColCh(string strCode,string tabName)
		{
			string colch="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "vcCommCode";
			colch = dv[dv.Find(strCode)]["vcCommName"].ToString().Trim();
			return colch;
		}
		#endregion

		#region �������
		private void CMSMMain_Load(object sender, System.EventArgs e)
		{
#if DEBUG
#else
			if(IsUpdate())
			{
				//this.Close();
				Application.Exit();				
				Process.Start("AutoUpdate.exe");
				return;
			}
			this.Visible=false;
//			if(File.Exists(Application.StartupPath+@"\BatchScript.bat")&&File.Exists(Application.StartupPath+@"\Script.sql"))
//			{
//				Process.Start("BatchScript.bat");
//				MessageBox.Show("�Ѹ��±������ݿ�ṹ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//			}
#endif
            SysInitial.desConstring(Application.StartupPath);
#if DEBUG
#else
			UpdateDataBase();
			if(File.Exists(Application.StartupPath+@"\AutoUpdate.exe.delete"))
			{
				File.Delete(Application.StartupPath+@"\AutoUpdate.exe.delete");
			}
			try
			{
				Business.SysInitial si = new CMSM.Business.SysInitial();
				si.SystemStartParaDownLoad();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(ex);
//				Application.Exit();
//				return;
			}
#endif
			//ϵͳ��ʼ��
			Exception err=null;
			
			//err=null;
			SysInitial.CreatDS(out err);
			if(err!=null)
			{
				MessageBox.Show("ϵͳ��ʼ�����󣬻��ǲ��źͲ���Ա��Ϣ��ȫ���������Ա��ϵ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				Application.Exit();
				return;
			}

			if(SysInitial.LocalDeptName==""||SysInitial.LocalDeptID=="")
			{
				Form form1=new frmDeptSet();
				form1.ShowDialog();
			}

			if(SysInitial.dsSys.Tables["Oper"].Rows.Count==0)
			{
				MessageBox.Show("������ȫ����������վ��¼�벿�źͲ�����Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				Application.Exit();
				return;
			}	
#if DEBUG
#else
			//����ǿ�Ƹ���
			Form formdown=new frmAfterStartDown();
			formdown.ShowDialog();
			SysInitial.CreatDS(out err);
			if(err!=null)
			{
				MessageBox.Show("ϵͳ��ʼ�����󣬻��ǲ��źͲ���Ա��Ϣ��ȫ���������Ա��ϵ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				Application.Exit();
				return;
			}

			if(SysInitial.LocalDeptName==""||SysInitial.LocalDeptID=="")
			{
				Form form1=new frmDeptSet();
				form1.ShowDialog();
			}

			if(SysInitial.dsSys.Tables["Oper"].Rows.Count==0)
			{
				MessageBox.Show("������ȫ����������վ��¼�벿�źͲ�����Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				Application.Exit();
				return;
			}	
#endif
			//��¼
			Form form=new frmLogin();
			form.ShowDialog();

			if(SysInitial.CurOps.strOperID==null)
			{
				Application.Exit();
				return;
			}
#if DEBUG
#else
			//���������壬��֤ע����Ϣ
			statusBarPanel1.Text="����Ա��" + SysInitial.CurOps.strOperName;
			statusBarPanel2.Text="��ǰλ�ã�������";
			statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
			statusBarPanel5.Text="���ţ�" + SysInitial.LocalDeptName;

			//��Ӳ�̵����к�
			string str_SerialNumber;
			string str_nb1,str_nb2,str_nb3,str_nb4,str_nb5;
			string str_ss1,str_ss2,str_ss3,str_ss4,str_ss5;
			HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // ��һ��Ӳ��
			str_SerialNumber=hdd.SerialNumber.ToString();
			//str_SerialNumber = "WD-WXCZ07A04859";
			str_nb1=str_SerialNumber.Substring(0,1);
			str_nb2=str_SerialNumber.Substring(1,1);
			str_nb3=str_SerialNumber.Substring(2,1);
			str_nb4=str_SerialNumber.Substring(3,1);
			str_nb5=str_SerialNumber.Substring(4,1);

			//��ע���
			string strsn="";
			bool _exist=false;

			//��ȡע����
			DESEncryptor dese1=new DESEncryptor();
			dese1.InputString=str_SerialNumber;
			dese1.EncryptKey="lhgynkm0";
			dese1.DesEncrypt();
			string miWenSerial=dese1.OutString;
			dese1=null;
			CommAccess access = new CommAccess(SysInitial.ConString);
			strsn = access.GetRegister(miWenSerial,out err);
			if (strsn != "")
			{
				_exist=true;
			}
			if (_exist)
			{
				dese1=new DESEncryptor();
				dese1.InputString=strsn;
				dese1.DecryptKey="lhgynkm0";
				dese1.DesDecrypt();
				string mingWen=dese1.OutString;
				dese1=null;
				if(mingWen==null||mingWen.Length!=29)
				{
					m01.Visible=false;
					m02.Visible=false;
					m03.Visible=false;
					m04.Visible=false;
					m05.Visible=false;
					m0602.Enabled=true;
					foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
					{
						if(nbitmp.Name!="nbg07")
						{
							nbitmp.Visible=false;
						}
					}
					
					MessageBox.Show("ע���벻��ȷ����Щ���ܻ������ƣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					str_ss1=mingWen.Substring(28,1);
					str_ss2=mingWen.Substring(21,1);
					str_ss3=mingWen.Substring(14,1);
					str_ss4=mingWen.Substring(7,1);
					str_ss5=mingWen.Substring(0,1);
					if(str_nb1==str_ss1&&str_nb2==str_ss2&&str_nb3==str_ss3&&str_nb4==str_ss4&&str_nb5==str_ss5)
					{
						err=null;
						CommAccess ca=new CommAccess(SysInitial.ConString);
						DataTable dtoperfunc=ca.GetFuncOper(out err);
						if(err!=null)
						{
							MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err);
							Application.Exit();
							return;
						}
						
						
						foreach(MenuItem mitmp in this.Menu.MenuItems)
						{
							if(mitmp.Text!="����ͬ��"&&mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
							{
								foreach(MenuItem mi2 in mitmp.MenuItems)
								{
									mi2.Enabled=false;
									for(int i=0;i<dtoperfunc.Rows.Count;i++)
									{
										if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
										{
											mi2.Enabled=true;
											break;
										}
									}
								}
							}
						}

						foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
						{
							if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
							{
								nbitmp.Visible=false;
								for(int i=0;i<dtoperfunc.Rows.Count;i++)
								{
									if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
									{
										nbitmp.Visible=true;
										break;
									}
								}
							}
						}
						m0602.Enabled=false;
					}
					else
					{
						m01.Visible=false;
						m02.Visible=false;
						m03.Visible=false;
						m04.Visible=false;
						m05.Visible=false;
						m0602.Enabled=true;
						foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
						{
							if(nbitmp.Name!="nbg07")
							{
								nbitmp.Visible=false;
							}
						}
						MessageBox.Show("ע���벻��ȷ����Щ���ܻ������ƣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				#region �ж�ʱ��				
				DateTime dtnow=DateTime.Now;
				if(dtnow.CompareTo(new DateTime(2009,3,1))>0)
				{
					m01.Visible=false;
					m02.Visible=false;
					m03.Visible=false;
					m04.Visible=false;
					m05.Visible=false;
					m0602.Enabled=true;
					foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
					{
						if(nbitmp.Name!="nbg07")
						{
							nbitmp.Visible=false;
						}
					}
					MessageBox.Show("ϵͳ�������ѹ�����Щ���ܻ������ƣ����볧����ϵ������ע�ᣡ","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					m01.Visible=true;
					m02.Visible=true;
					m03.Visible=true;
					m04.Visible=true;
					m05.Visible=true;
					m0602.Enabled=false;
					err=null;
					CommAccess ca=new CommAccess(SysInitial.ConString);
					DataTable dtoperfunc=ca.GetFuncOper(out err);
					if(err!=null)
					{
						MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err);
						Application.Exit();
						return;
					}
						
					foreach(MenuItem mitmp in this.Menu.MenuItems)
					{
						if(mitmp.Text!="����ͬ��"&&mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
						{
							foreach(MenuItem mi2 in mitmp.MenuItems)
							{
								mi2.Enabled=false;
								for(int i=0;i<dtoperfunc.Rows.Count;i++)
								{
									if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
									{
										mi2.Enabled=true;
										break;
									}
								}
							}
						}
					}

					foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
					{
						if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
						{
							nbitmp.Visible=false;
							for(int i=0;i<dtoperfunc.Rows.Count;i++)
							{
								if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
								{
									nbitmp.Visible=true;
									break;
								}
							}
						}
					}
					m0602.Enabled=true;
				}
				#endregion
			}
#endif
			this.WindowState=System.Windows.Forms.FormWindowState.Maximized;
			this.Visible=true;

			this.timerauto.Interval=SysInitial.RefreshTime*60*1000;
			this.timerauto.Enabled=false;
//			this.timerauto.Start();
		}
		#endregion

		private void formShow(Form form)
		{
			if(form!=null)
			{
				if(this.ActiveMdiChild != form)
				{
					if(this.ActiveMdiChild!=null)
					{
						this.ActiveMdiChild.Close();
					}
					statusBarPanel2.Text="��ǰλ�ã�" + form.Text.Trim();
					form.MdiParent=this;
					form.Show();
				}
			}
		}

		#region �˵��͵������¼�
		private void m0702_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ��ϴ�����","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				//�����ϴ�
				Form form=new frmDataUp();
				formShow(form);
			}
			else
			{
				this.Close();
				Application.Exit();
			}
			
		}

		private void m0101_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssInfo();
			formShow(form);
		}

		private void m0201_Click(object sender, System.EventArgs e)
		{
			Form form=new frmFillFeeByCard();
			formShow(form);
		}

		private void m0202_Click(object sender, System.EventArgs e)
		{
			Form form=new frmCardLose();
			formShow(form);
		}

		private void m2CardAgain_Click(object sender, System.EventArgs e)
		{
			Form form=new frmCardAgain();
			formShow(form);
		}

		private void nbi0201_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmFillFeeByCard();
			formShow(form);
		}

		private void m0301_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssCons();
			formShow(form);
		}

		private void m0302_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRepeatPrint();
			formShow(form);
		}

		private void m2SysBase_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSysSet();
			form.ShowDialog();
		}

		private void m2CardRecycle_Click(object sender, System.EventArgs e)
		{
			CommAccess cs=new CommAccess(SysInitial.ConString);
			string strRes=cs.RecycleCard();
			if((!strRes.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				string colch="";
				DataView dv = new DataView(SysInitial.dsSys.Tables["ERR"]);
				dv.Sort = "vcCommCode";
				colch = dv[dv.Find(strRes)]["vcCommName"].ToString().Trim();
				MessageBox.Show("���ջ�Ա��ʧ�ܣ�\n" + colch,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("���ջ�Ա���ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
		}

		#region ע��
		private void m0701_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close();
			}
			Form form=new frmLogin();
			form.ShowDialog();
			if(SysInitial.ReLoginFlag)
			{
				SysInitial.NewOps.strOperID=SysInitial.CurOps.strOperID;
				SysInitial.NewOps.strOperName=SysInitial.CurOps.strOperName;
				SysInitial.NewOps.strLimit=SysInitial.CurOps.strLimit;
				SysInitial.NewOps.strPwd=SysInitial.CurOps.strPwd;
				SysInitial.NewOps.strDeptID=SysInitial.CurOps.strDeptID;
				statusBarPanel1.Text="����Ա��" + SysInitial.CurOps.strOperName;
				statusBarPanel2.Text="��ǰλ�ã�������";
				statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
				statusBarPanel5.Text="�ŵ꣺" + SysInitial.LocalDeptName;

				//��Ӳ�̵����к�
				string str_SerialNumber;
				string str_nb1,str_nb2,str_nb3,str_nb4,str_nb5;
				string str_ss1,str_ss2,str_ss3,str_ss4,str_ss5;
				HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // ��һ��Ӳ��
				str_SerialNumber=hdd.SerialNumber.ToString();
				str_nb1=str_SerialNumber.Substring(0,1);
				str_nb2=str_SerialNumber.Substring(1,1);
				str_nb3=str_SerialNumber.Substring(2,1);
				str_nb4=str_SerialNumber.Substring(3,1);
				str_nb5=str_SerialNumber.Substring(4,1);

				//��ע���
				string strsn="";
				bool _exist=false;
				//��ȡע����
				DESEncryptor dese1=new DESEncryptor();
				dese1.InputString=str_SerialNumber;
				dese1.EncryptKey="lhgynkm0";
				dese1.DesEncrypt();
				string miWenSerial=dese1.OutString;
				dese1=null;
				Exception err=null;
				CommAccess access = new CommAccess(SysInitial.ConString);
				strsn = access.GetRegister(miWenSerial,out err);
				if (strsn != "")
				{
					_exist=true;
				}
				if (_exist)
				{
					dese1=new DESEncryptor();
					dese1.InputString=strsn;
					dese1.DecryptKey="lhgynkm0";
					dese1.DesDecrypt();
					string mingWen=dese1.OutString;
					dese1=null;
					if(mingWen==null||mingWen.Length!=29)
					{
						m01.Visible=false;
						m02.Visible=false;
						m03.Visible=false;
						m04.Visible=false;
						m05.Visible=false;
						m0602.Enabled=true;
						foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
						{
							if(nbitmp.Name!="nbg07")
							{
								nbitmp.Visible=false;
							}
						}
					
						MessageBox.Show("ע���벻��ȷ����Щ���ܻ������ƣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
					else
					{
						str_ss1=mingWen.Substring(28,1);
						str_ss2=mingWen.Substring(21,1);
						str_ss3=mingWen.Substring(14,1);
						str_ss4=mingWen.Substring(7,1);
						str_ss5=mingWen.Substring(0,1);
						if(str_nb1==str_ss1&&str_nb2==str_ss2&&str_nb3==str_ss3&&str_nb4==str_ss4&&str_nb5==str_ss5)
						{
							err=null;
							CommAccess ca=new CommAccess(SysInitial.ConString);
							DataTable dtoperfunc=ca.GetFuncOper(out err);
							if(err!=null)
							{
								MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
								clog.WriteLine(err);
								Application.Exit();
								return;
							}
						
						
							foreach(MenuItem mitmp in this.Menu.MenuItems)
							{
								if(mitmp.Text!="����ͬ��"&&mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
								{
									foreach(MenuItem mi2 in mitmp.MenuItems)
									{
										mi2.Enabled=false;
										for(int i=0;i<dtoperfunc.Rows.Count;i++)
										{
											if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
											{
												mi2.Enabled=true;
												break;
											}
										}
									}
								}
							}

							foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
							{
								if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
								{
									nbitmp.Visible=false;
									for(int i=0;i<dtoperfunc.Rows.Count;i++)
									{
										if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
										{
											nbitmp.Visible=true;
											break;
										}
									}
								}
							}
							m0602.Enabled=false;
						}
						else
						{
							m01.Visible=false;
							m02.Visible=false;
							m03.Visible=false;
							m04.Visible=false;
							m05.Visible=false;
							m0602.Enabled=true;
							foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
							{
								if(nbitmp.Name!="nbg07")
								{
									nbitmp.Visible=false;
								}
							}
							MessageBox.Show("ע���벻��ȷ����Щ���ܻ������ƣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						}
					}
				}
				else
				{
					#region �ж�ʱ��				
					DateTime dtnow=DateTime.Now;
					if(dtnow.CompareTo(new DateTime(2008,9,1))>0)
					{
						m01.Visible=false;
						m02.Visible=false;
						m03.Visible=false;
						m04.Visible=false;
						m05.Visible=false;
						m0602.Enabled=true;
						foreach(DevExpress.XtraNavBar.NavBarGroup nbitmp in this.navBarControl1.Groups)
						{
							if(nbitmp.Name!="nbg07")
							{
								nbitmp.Visible=false;
							}
						}
						MessageBox.Show("ϵͳ�������ѹ�����Щ���ܻ������ƣ����볧����ϵ������ע�ᣡ","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
					else
					{
						m01.Visible=true;
						m02.Visible=true;
						m03.Visible=true;
						m04.Visible=true;
						m05.Visible=true;
						m0602.Enabled=false;
						err=null;
						CommAccess ca=new CommAccess(SysInitial.ConString);
						DataTable dtoperfunc=ca.GetFuncOper(out err);
						if(err!=null)
						{
							MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err);
							Application.Exit();
							return;
						}
						
						foreach(MenuItem mitmp in this.Menu.MenuItems)
						{
							if(mitmp.Text!="����ͬ��"&&mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
							{
								foreach(MenuItem mi2 in mitmp.MenuItems)
								{
									mi2.Enabled=false;
									for(int i=0;i<dtoperfunc.Rows.Count;i++)
									{
										if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
										{
											mi2.Enabled=true;
											break;
										}
									}
								}
							}
						}

						foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
						{
							if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
							{
								nbitmp.Visible=false;
								for(int i=0;i<dtoperfunc.Rows.Count;i++)
								{
									if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
									{
										nbitmp.Visible=true;
										break;
									}
								}
							}
						}
						m0602.Enabled=true;
					}
					#endregion
				}
//				Exception err=null;
//				CommAccess ca=new CommAccess(SysInitial.ConString);
//				DataTable dtoperfunc=ca.GetFuncOper(out err);
//				if(err!=null)
//				{
//					MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					clog.WriteLine(err);
//					Application.Exit();
//					return;
//				}
//				foreach(MenuItem mitmp in this.Menu.MenuItems)
//				{
//					if(mitmp.Text!="����ͬ��"&&mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
//					{
//						foreach(MenuItem mi2 in mitmp.MenuItems)
//						{
//							mi2.Enabled=false;
//							for(int i=0;i<dtoperfunc.Rows.Count;i++)
//							{
//								if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
//								{
//									mi2.Enabled=true;
//									continue;
//								}
//							}
//						}
//					}
//				}
//
//				foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
//				{
//					if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
//					{
//						nbitmp.Visible=false;
//						for(int i=0;i<dtoperfunc.Rows.Count;i++)
//						{
//							if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
//							{
//								nbitmp.Visible=true;
//								continue;
//							}
//						}
//					}
//				}
			}
		}
		#endregion

		#region ���ݱ���
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			DialogResult strres=MessageBox.Show("�Ƿ�������ݱ��ݣ�","ϵͳȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(strres==DialogResult.No)
			{
				return;
			}
			string ConnectionString = SysInitial.ConString;
			SqlConnection conn = new SqlConnection(ConnectionString);
			SqlCommand cmd = null;
			string strmonth=System.DateTime.Now.Month.ToString();
			string strday=System.DateTime.Now.Day.ToString();
			string strhour=System.DateTime.Now.Hour.ToString();
			string strminute=System.DateTime.Now.Minute.ToString();
			string strsecond=System.DateTime.Now.Second.ToString();
			if(strmonth.Length==1)
			{
				strmonth="0" + strmonth;
			}
			if(strday.Length==1)
			{
				strday="0" + strday;
			}
			if(strhour.Length==1)
			{
				strhour="0" + strhour;
			}
			if(strminute.Length==1)
			{
				strminute="0" + strminute;
			}
			string fileName="AMSCM" + System.DateTime.Now.Year+strmonth+strday+strhour+strminute+strsecond+".bak";
			string filePath=@"E:\\BreadWorksDataBak\\";
			if(!System.IO.Directory.Exists(filePath))
				System.IO.Directory.CreateDirectory(filePath);
			if(System.IO.File.Exists(fileName))
				System.IO.File.Delete(fileName);
			if( conn.State != ConnectionState.Open)
����		conn.Open();
			string sql1="";
			sql1=" declare @AMSCM varchar(100)  ";
			sql1+=" set @AMSCM='AMSCM'";
			sql1+="exec('BACKUP DATABASE '+@AMSCM+' TO DISK =N''" + filePath + fileName + "'' WITH NOINIT,NOUNLOAD,NAME=N''" + fileName + "����'',NOSKIP,STATS=10,NOFORMAT')";
����		cmd = new SqlCommand(sql1,conn);
����		try
����		{
����			cmd.ExecuteNonQuery();
				MessageBox.Show("�������ݿ�ɹ�������E:\\BreadWorksDataBak\\!�ļ���");
����		}
����		catch(SqlException ee)
����		{
����			MessageBox.Show(ee.Message.ToString()+"�������ݿ�ʧ�ܣ�");  
����		}
		}
		#endregion

		private void m0602_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRegister();
			form.ShowDialog();
		}

		private void nbi0101_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmAssInfo();
			formShow(form);
		}

		private void nbi0202_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmCardLose();
			formShow(form);
		}

		private void nbi0203_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmCardAgain();
			formShow(form);
		}

		private void nbi0301_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmAssCons();
			formShow(form);
		}

		private void nbi0302_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmRepeatPrint();
			formShow(form);
		}

		private void nbi0501_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmCurOilStorage();
			form.ShowDialog();
		}

		private void nbi0701_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			if(this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close();
			}
			Form form=new frmLogin();
			form.ShowDialog();
			if(SysInitial.ReLoginFlag)
			{
				if(SysInitial.CurOps.strOperID!=SysInitial.NewOps.strOperID)
				{
					SysInitial.NewOps.strOperID=SysInitial.CurOps.strOperID;
					SysInitial.NewOps.strOperName=SysInitial.CurOps.strOperName;
					SysInitial.NewOps.strLimit=SysInitial.CurOps.strLimit;
					SysInitial.NewOps.strPwd=SysInitial.CurOps.strPwd;
					SysInitial.NewOps.strDeptID=SysInitial.CurOps.strDeptID;
					statusBarPanel1.Text="����Ա��" + SysInitial.CurOps.strOperName;
					statusBarPanel2.Text="��ǰλ�ã�������";
					statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
					statusBarPanel5.Text="�ŵ꣺" + SysInitial.LocalDeptName;
					Exception err=null;
					CommAccess ca=new CommAccess(SysInitial.ConString);
					DataTable dtoperfunc=ca.GetFuncOper(out err);
					if(err!=null)
					{
						MessageBox.Show("��ȡ����Ա�����б�������µ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err);
						Application.Exit();
						return;
					}
					foreach(MenuItem mitmp in this.Menu.MenuItems)
					{
						if(mitmp.Text!="����"&&mitmp.Text!="�˳�ϵͳ")
						{
							foreach(MenuItem mi2 in mitmp.MenuItems)
							{
								mi2.Enabled=false;
								for(int i=0;i<dtoperfunc.Rows.Count;i++)
								{
									if(mi2.Text==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
									{
										mi2.Enabled=true;
										continue;
									}
								}
							}
						}
					}

					foreach(DevExpress.XtraNavBar.NavBarItem nbitmp in this.navBarControl1.Items)
					{
						if(nbitmp.Name!="nbi0701"&&nbitmp.Name!="nbi0702")
						{
							nbitmp.Visible=false;
							for(int i=0;i<dtoperfunc.Rows.Count;i++)
							{
								if(nbitmp.Caption==dtoperfunc.Rows[i]["cnvcFuncName"].ToString())
								{
									nbitmp.Visible=true;
									continue;
								}
							}
						}
					}
				}
			}
		}

		private void nbi0702_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		private void m0604_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAbout();
			form.ShowDialog();
		}

		private void nbi0502_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmOilStorageCheck();
			formShow(form);
		}

		private void m2SysModPwd_Click(object sender, EventArgs e)
		{
			Form form=new frmModPwd();
			formShow(form);
		}

		private void m0203_Click(object sender, EventArgs e)
		{
			Form form=new frmCardAgain();
			formShow(form);
		}

		private void m0204_Click(object sender, EventArgs e)
		{
			Form form=new frmCardLoseToExit();
			formShow(form);
		}

		private void m0205_Click(object sender, EventArgs e)
		{
			Form form=new frmCardExit();
			formShow(form);
		}

		private void m0401_Click(object sender, EventArgs e)
		{
			//�������յ�
			Form form=new frmBillOfValidate();
			formShow(form);
		}

		private void m0402_Click(object sender, EventArgs e)
		{
			Form form=new frmBillOfOutStorage();
			formShow(form);
		}

		private void m0403_Click(object sender, EventArgs e)
		{
			//ר�������ϵ�
			Form form=new frmBillOfMaterials();
			formShow(form);
		}

		private void m0501_Click(object sender, EventArgs e)
		{
			Form form=new frmCurOilStorage();
			formShow(form);
		}

		private void m0502_Click(object sender, EventArgs e)
		{
			Form form=new frmOilStorageCheck();
			formShow(form);
		}

		private void nbi0204_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmCardLoseToExit();
			formShow(form);
		}

		private void nbi0205_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmCardExit();
			formShow(form);
		}

		private void nbi0401_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmBillOfValidate();
			formShow(form);
		}

		private void nbi0402_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmBillOfOutStorage();
			formShow(form);
		}

		private void nbi0403_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmBillOfMaterials();
			formShow(form);
		}

		private void m0503_Click(object sender, System.EventArgs e)
		{
			Form form=new frmDensitySet();
			formShow(form);
		}

		private void nbi0503_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmDensitySet();
			formShow(form);
		}

		private void m0603_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this,"�����ĵ�.chm");
		}

		private void CMSMMain_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			Help.ShowHelp(this,"�����ĵ�.chm");
		}

		private void m0102_Click(object sender, System.EventArgs e)
		{
			Form form=new frmMebCompanyManager();
			formShow(form);
		}

		private void nbi0102_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form=new frmMebCompanyManager();
			formShow(form);
		}

		private void m0801_Click(object sender, System.EventArgs e)
		{
			//��������
//			Form form=new frmDataDown();
//			formShow(form);
			try
			{
				Business.SysInitial si = new CMSM.Business.SysInitial();
				si.SystemStartParaDownLoad();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(ex);
				Application.Exit();
				return;
			}
			//����ǿ�Ƹ���
			Form formdown=new frmAfterStartDown();
			formdown.Text = "�������ظ���";
			formdown.ShowDialog();
		}

		private void m0802_Click(object sender, System.EventArgs e)
		{
			//�����ϴ�
			Form form=new frmDataUp();
			formShow(form);
		}

		#region ˢ�¶�����ʱ��
		private void m0601_Click(object sender, System.EventArgs e)
		{
			//���ö�����ʱ��
			string strtotime=DateTime.Now.Year.ToString().Substring(2,2);
			string strtmp=DateTime.Now.DayOfWeek.ToString();
			switch(strtmp)
			{
				case "Monday":
					strtotime+="01";
					break;
				case "Tuesday":
					strtotime+="02";
					break;
				case "Wednesday":
					strtotime+="03";
					break;
				case "Thursday":
					strtotime+="04";
					break;
				case "Friday":
					strtotime+="05";
					break;
				case "Saturday":
					strtotime+="06";
					break;
				case "Sunday":
					strtotime+="07";
					break;
			}
			strtmp=DateTime.Now.Month.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Day.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Hour.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Minute.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Second.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			CardCommon.CardRef.CardM1 rftmp=new CardCommon.CardRef.CardM1(SysInitial.intCom);
			rftmp.SetRFTime(strtotime);
		}
		#endregion

		#endregion

//		private void CMSMMain_Closed(object sender, EventArgs e)
//		{
//			string ConnectionString = SysInitial.ConString;
//			SqlConnection conn = new SqlConnection(ConnectionString);
//			SqlCommand cmd = null;
//			string strmonth=System.DateTime.Now.Month.ToString();
//			string strday=System.DateTime.Now.Day.ToString();
//			string strhour=System.DateTime.Now.Hour.ToString();
//			string strminute=System.DateTime.Now.Minute.ToString();
//			string strsecond=System.DateTime.Now.Second.ToString();
//			if(strmonth.Length==1)
//			{
//				strmonth="0" + strmonth;
//			}
//			if(strday.Length==1)
//			{
//				strday="0" + strday;
//			}
//			if(strhour.Length==1)
//			{
//				strhour="0" + strhour;
//			}
//			if(strminute.Length==1)
//			{
//				strminute="0" + strminute;
//			}
//			string fileName="AMSCM" + System.DateTime.Now.Year+strmonth+strday+strhour+strminute+strsecond+"_aotm.bak";
//			string filePath=@"E:\\BreadWorksDataBak\\";
//			if(!System.IO.Directory.Exists(filePath))
//				System.IO.Directory.CreateDirectory(filePath);
//			if(System.IO.File.Exists(fileName))
//				System.IO.File.Delete(fileName);
//			if( conn.State != ConnectionState.Open)
//����		conn.Open();
//			string sql1="";
//			sql1=" declare @AMSCM varchar(100)  ";
//			sql1+=" set @AMSCM='AMSCM'";
//			sql1+="exec('BACKUP DATABASE '+@AMSCM+' TO DISK =N''" + filePath + fileName + "'' WITH NOINIT,NOUNLOAD,NAME=N''" + fileName + "����'',NOSKIP,STATS=10,NOFORMAT')";
//����		cmd = new SqlCommand(sql1,conn);
//����		try
//����		{
//����			cmd.ExecuteNonQuery();
//����		}
//����		catch(SqlException ee)
//����		{
//����			MessageBox.Show(ee.Message.ToString()+"�Զ��������ݿ�ʧ�ܣ�");  
//����		}
//		}



		private void timer1_Tick(object sender, EventArgs e)
		{
			statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
		}

		private void timerauto_Tick(object sender, System.EventArgs e)
		{
			#region ��ʼ���FTPϵͳ����
			SqlConnection con1=new SqlConnection(SysInitial.ConString);
			try
			{
				DateTime dtnow=DateTime.Now;
				string filePathdown=@"E:\AMSDataSoft\Soft\down\";
				string filePathupdate=@"E:\AMSDataSoft\Soft\update\";
				string filePathbak=@"E:\AMSDataSoft\bak\";
				string fileSoftPath=Application.StartupPath;
				string strSoftName="";
				if(IsDownSoft(out strSoftName))
				{
					if(strSoftName!="")
					{
						string[] fileall=Directory.GetFiles(filePathupdate);
						if(fileall.Length>0)
						{
							for(int i=0;i<fileall.Length;i++)
							{
								System.IO.File.Delete(fileall[i]);
							}
						}

						System.Diagnostics.Process[] proFTPall=System.Diagnostics.Process.GetProcessesByName("FtpClient");
						if(proFTPall.Length>=1)
						{
							foreach(Process proFTP in Process.GetProcessesByName("FtpClient"))
							{
								proFTP.Kill();
							}
						}
						else
						{
							ZIPPER.Utility.Unzip(filePathupdate,filePathdown+strSoftName,"AMSBread");
							string[] fileallupdate=Directory.GetFiles(filePathupdate);
							if(fileallupdate.Length==0)
							{
								clog.WriteLine("ͬ�������������󣬲��ܽ�������!");
								return;
							}
							else
							{
								for(int i=0;i<fileallupdate.Length;i++)
								{
									string strfilenameupdate=fileallupdate[i].Split('\\')[fileallupdate[i].Split('\\').Length - 1];
									System.IO.File.Copy(fileallupdate[i],fileSoftPath+@"\"+strfilenameupdate,true);
								}
							}

							string[] fileall1=Directory.GetFiles(filePathupdate);
							if(fileall1.Length>0)
							{
								for(int i=0;i<fileall1.Length;i++)
								{
									System.IO.File.Delete(fileall1[i]);
								}
							}
					
							FileInfo file_size = new FileInfo(filePathdown+strSoftName);
							long fsize=file_size.Length;

							if(System.IO.File.Exists(filePathdown+strSoftName))
							{
								System.IO.File.Copy(filePathdown+strSoftName,filePathbak+strSoftName,true);
								System.IO.File.Delete(filePathdown+strSoftName);
							}

							DateTime dtFinDate=DateTime.Now;
							#region д������־
							con1.Open();
							string strsql1="insert into tbDataSoftUpdateLog values('" + strSoftName + "'," + fsize.ToString() + ",1,'" + dtnow.ToShortDateString() + " " + dtnow.ToLongTimeString() + "','"+dtFinDate.ToShortDateString()+" "+dtFinDate.ToLongTimeString()+"','FTPS')";
							SqlCommand cmd=new SqlCommand(strsql1,con1);
							cmd.ExecuteNonQuery();
							con1.Close();
							#endregion
						}
					}
				}
				else
				{
					System.Diagnostics.Process[] proFTPall=System.Diagnostics.Process.GetProcessesByName("FtpClient");
					if(proFTPall.Length<=0)
					{
						Process newFtp=new Process();
						newFtp.StartInfo.FileName=fileSoftPath+@"\FtpClient.exe";
						newFtp.StartInfo.UseShellExecute=true;
						newFtp.Start();
						newFtp.WaitForInputIdle(10000);
					}
				}
			}
			catch(Exception er)
			{
				if(con1.State==ConnectionState.Open)
				{
					con1.Close();
				}
				clog.WriteLine(er);
				return;
			}
		#endregion
		}

		#region �Ƿ����Ѿ����ص����³���
		private bool IsDownSoft(out string onefilename)
		{
			onefilename="";
			string filePath=@"E:\AMSDataSoft\Soft\down\";

			string[] fileall=Directory.GetFiles(filePath);
			if(fileall.Length<=0)
			{
				return false;
			}
			
			bool fileflag=false;
			string strZZ="FtpS" + ".*zip";
			Regex regExpr = new Regex(strZZ.ToLower());
			foreach(string _strFileName in fileall)	
			{
				FileInfo fileInfo = new FileInfo(_strFileName);
				if(regExpr.IsMatch(fileInfo.Name.ToLower(),0))
				{
					fileflag=true;
					onefilename=fileInfo.Name;
					break;
				}
			}
			if(fileflag)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion


		#region ���������жϺ���
		public bool IsUpdate()
		{
			string updateUrl = string.Empty;
			string tempUpdatePath = string.Empty;
			XmlFiles updaterXmlFiles = null;
			int availableUpdate = 0;
			//			if (!CheckInetConnection())
			//			{
			//				MessageBox.Show("����������!", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//				//this.Close();
			//				return false;
			//			}
			
			//panel2.Visible = false;
			//btnFinish.Visible = false;

			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			string serverXmlFile = string.Empty;

			
			try
			{
				//�ӱ��ض�ȡ���������ļ���Ϣ
				updaterXmlFiles = new XmlFiles(localXmlFile );
			}
			catch
			{
				MessageBox.Show("�Զ����������ļ�����!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				//this.Close();
				return false;
			}
			//��ȡ��������ַ
			updateUrl = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater appUpdater = new AppUpdater();
			appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

			//�����������,���ظ��������ļ�
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
				appUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch
			{
				MessageBox.Show("�����������ʧ��,������ʱ!","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				//this.Close();
				return false;

			}

			//��ȡ�����ļ��б�
			Hashtable htUpdateFile = new Hashtable();

			serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
				return false;
			}

			availableUpdate = appUpdater.CheckForUpdate(serverXmlFile,localXmlFile,out htUpdateFile);
			if (availableUpdate > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		private void menuItem1_Click_1(object sender, System.EventArgs e)
		{
			//��ͬ
			Form form=new frmContract();
			formShow(form);
		}

		private void navBarControl1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void nbi0404_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			//
			Form form=new frmContract();
			formShow(form);
		}

		private void menuItem1_Click_2(object sender, System.EventArgs e)
		{
			//
			Form form = new frmAssConsRemove();
			formShow(form);
		}

		private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form form = new frmAssConsRemove();
			formShow(form);
		}
		private void UpdateDataBase()
		{
			if(File.Exists(Application.StartupPath+@"\Script.sql"))
			{
				//string errs = "";
				using (StreamReader sr = File.OpenText(Application.StartupPath+@"\Script.sql")) 
				{ 
					using(SqlConnection conn = new SqlConnection(CMSMData.CMSMDataAccess.SysInitial.ConString))
					{
						try
						{
							conn.Open();
							string s = ""; 
							
							while ((s = sr.ReadLine()) != null) 
							{ 
								//Console.WriteLine(s); 
								try
								{							

									SqlCommand cmd = new SqlCommand(s,conn);
									cmd.ExecuteNonQuery();
								}
								catch(Exception ex)
								{
									clog.WriteLine(ex);
									//MessageBox.Show(this,"�ű�ִ�д���","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
									//errs += s+@"\n";
								}
							}
						}
						catch(Exception ex2)
						{
							clog.WriteLine(ex2);
							MessageBox.Show(this,"�������Ӵ���","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
						}
						finally
						{
							conn.Close();
						}
					}
				} 				
			}
			File.Delete(Application.StartupPath+@"\Script.sql");
		}

		private void CMSMMain_Closed(object sender, EventArgs e)
		{
			
		}

		private void CMSMMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ��ϴ�����","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				e.Cancel=true;
				//�����ϴ�
				Form form=new frmDataUp();
				formShow(form);				
			}
			else
			{
				e.Cancel=false;
			}

		}

	}
}
