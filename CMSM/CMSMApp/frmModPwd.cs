using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmModPwd.
	/// </summary>
	public class frmModPwd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtOperID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOperName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPwdConf;
		private System.Windows.Forms.TextBox txtPwd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmModPwd()
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
			this.txtOperID = new System.Windows.Forms.TextBox();
			this.txtPwdConf = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOperName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtOperID
			// 
			this.txtOperID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtOperID.Location = new System.Drawing.Point(72, 16);
			this.txtOperID.MaxLength = 10;
			this.txtOperID.Name = "txtOperID";
			this.txtOperID.Size = new System.Drawing.Size(136, 22);
			this.txtOperID.TabIndex = 4;
			this.txtOperID.Text = "";
			// 
			// txtPwdConf
			// 
			this.txtPwdConf.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPwdConf.Location = new System.Drawing.Point(72, 136);
			this.txtPwdConf.MaxLength = 6;
			this.txtPwdConf.Name = "txtPwdConf";
			this.txtPwdConf.PasswordChar = '*';
			this.txtPwdConf.Size = new System.Drawing.Size(136, 22);
			this.txtPwdConf.TabIndex = 1;
			this.txtPwdConf.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 144);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 102;
			this.label1.Text = "����ȷ��";
			// 
			// txtOperName
			// 
			this.txtOperName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtOperName.Location = new System.Drawing.Point(72, 56);
			this.txtOperName.MaxLength = 10;
			this.txtOperName.Name = "txtOperName";
			this.txtOperName.Size = new System.Drawing.Size(136, 22);
			this.txtOperName.TabIndex = 5;
			this.txtOperName.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(32, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 101;
			this.label2.Text = "����";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(32, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 99;
			this.label4.Text = "���";
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(136, 176);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 3;
			this.sbtnCancel.Text = "ȡ��";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(48, 176);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 2;
			this.sbtnOk.Text = "ȷ��";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// txtPwd
			// 
			this.txtPwd.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPwd.Location = new System.Drawing.Point(72, 95);
			this.txtPwd.MaxLength = 6;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(136, 22);
			this.txtPwd.TabIndex = 0;
			this.txtPwd.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(24, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 106;
			this.label3.Text = "������";
			// 
			// frmModPwd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(248, 214);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.txtOperID);
			this.Controls.Add(this.txtPwdConf);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtOperName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmModPwd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�޸ĵ�¼����";
			this.Load += new System.EventHandler(this.frmModPwd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			CMSMStruct.OperStruct opsnew=new CMSMData.CMSMStruct.OperStruct();
			opsnew.strLimit=SysInitial.CurOps.strLimit;
			string strpwdCon="";
			if(txtPwd.Text.Trim()==""||txtPwd.Text.Trim().Length>6)
			{
				MessageBox.Show("����С�ڵ���6λ�ַ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtPwd.Focus();
				return;
			}
			else
			{
				opsnew.strPwd=txtPwd.Text.Trim();
			}
			if(txtPwdConf.Text.Trim()==""||txtPwdConf.Text.Trim().Length>6)
			{
				MessageBox.Show("����С�ڵ���6λ�ַ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtPwdConf.Focus();
				return;
			}
			else
			{
				strpwdCon=txtPwdConf.Text.Trim();
			}
			if(opsnew.strPwd!=strpwdCon)
			{
				MessageBox.Show("������������벻һ�£����������룡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.txtPwd.Text="";
				this.txtPwdConf.Text="";
				this.txtPwd.Focus();
				return;
			}
			CommAccess cs=new CommAccess(SysInitial.ConString);
            Exception err=null;
//			cs.UpdateOper(SysInitial.CurOps,opsnew,out err);
			if(err!=null)
			{
				MessageBox.Show("�޸�����ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				this.Close();
			}
			else
			{
				MessageBox.Show("�޸�����ɹ��������뽫���´ε�¼ʱ��Ч��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.txtPwd.Text="";
				this.txtPwdConf.Text="";
				this.txtPwd.Focus();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmModPwd_Load(object sender, System.EventArgs e)
		{
			this.txtOperID.Text=SysInitial.CurOps.strOperID;
			this.txtOperName.Text=SysInitial.CurOps.strOperName;
			this.txtOperID.ReadOnly=true;
			this.txtOperName.ReadOnly=true;
		}
	}
}
