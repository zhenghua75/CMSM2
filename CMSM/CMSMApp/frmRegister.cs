using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32;
using System.Windows.Forms;
using Sunmast.Hardware;
using CMSMData.CMSMDataAccess;
using cc;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmRegister.
	/// </summary>
	public class frmRegister : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnReg;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmRegister()
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
			this.btnReg = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 80);
			this.label1.TabIndex = 0;
			// 
			// btnReg
			// 
			this.btnReg.Location = new System.Drawing.Point(72, 120);
			this.btnReg.Name = "btnReg";
			this.btnReg.Size = new System.Drawing.Size(88, 23);
			this.btnReg.TabIndex = 11;
			this.btnReg.Text = "申请注册";
			this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(200, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(48, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmRegister
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(376, 160);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnReg);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRegister";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员管理系统--注册";
			this.Load += new System.EventHandler(this.frmRegister_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRegister_Load(object sender, System.EventArgs e)
		{
			label1.Text="注册\n" + "本软件为受权软件，未经注册，您将受限使用部份功能。\n" + "通过注册，您将可以使用全部功能。";
		}

		private void btnReg_Click(object sender, System.EventArgs e)
		{
			//读硬盘的序列号
			string str_SerialNumber;
			HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // 第一个硬盘
			str_SerialNumber=hdd.SerialNumber.ToString();

			DESEncryptor dese1=new DESEncryptor();
			dese1.InputString=str_SerialNumber;
			dese1.EncryptKey="lhgynkm0";
			dese1.DesEncrypt();
			string miWen=dese1.OutString;
			dese1=null;

			err=null;
			string strresult=cs.Register(miWen,SysInitial.LocalDeptName,SysInitial.CurOps.strOperName,out err);
			if(strresult=="connection")
			{
				MessageBox.Show("中心数据库连接失败，请检查网再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				MessageBox.Show("注册申请已经发送至中心，请等待注册完成后，再重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
