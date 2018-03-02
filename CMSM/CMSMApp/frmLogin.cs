using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmLogin 的摘要说明。
	/// </summary>
	public class frmLogin : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.ComboBox cmbOper;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		int incount=0;

		public frmLogin()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.cmbOper = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(64, 120);
			this.txtPwd.MaxLength = 20;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(152, 21);
			this.txtPwd.TabIndex = 13;
			this.txtPwd.Text = "";
			this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
			// 
			// cmbOper
			// 
			this.cmbOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOper.Location = new System.Drawing.Point(64, 80);
			this.cmbOper.Name = "cmbOper";
			this.cmbOper.Size = new System.Drawing.Size(152, 20);
			this.cmbOper.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 16);
			this.label7.TabIndex = 16;
			this.label7.Text = "用户";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "密码";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(250, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(136, 160);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 25;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(48, 160);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 24;
			this.sbtnOk.Text = "登录";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// frmLogin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(250, 200);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.cmbOper);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员系统登录";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmLogin_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbOper,"Oper","cnvcOperName");
			txtPwd.Text="";
		}

		private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				sbtnOk.PerformClick();
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			incount++;
			string strOperName=cmbOper.Text.Trim();
//			string strPwd=Encrypt(txtPwd.Text.Trim());
			string strPwd=txtPwd.Text.Trim();
			DataTable dt=SysInitial.dsSys.Tables["Oper"];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				if(strOperName==dt.Rows[i]["cnvcOperName"].ToString())
				{
					if(strPwd==Decrypt(dt.Rows[i]["cnvcPwd"].ToString()))
					{
						if(SysInitial.CurOps.strOperName==null)
						{
							SysInitial.NewOps.strOperID=dt.Rows[i]["cnnOperID"].ToString();
							SysInitial.NewOps.strOperName=dt.Rows[i]["cnvcOperName"].ToString();
							SysInitial.NewOps.strPwd=dt.Rows[i]["cnvcPwd"].ToString();
							SysInitial.NewOps.strDeptID=dt.Rows[i]["cnvcDeptID"].ToString();
							SysInitial.CurOps.strOperID=dt.Rows[i]["cnnOperID"].ToString();
							SysInitial.CurOps.strOperName=dt.Rows[i]["cnvcOperName"].ToString();
							SysInitial.CurOps.strPwd=dt.Rows[i]["cnvcPwd"].ToString();
							SysInitial.CurOps.strDeptID=dt.Rows[i]["cnvcDeptID"].ToString();
							this.Close();
						}
						else
						{
							SysInitial.ReLoginFlag=true;
							SysInitial.CurOps.strOperID=dt.Rows[i]["cnnOperID"].ToString();
							SysInitial.CurOps.strOperName=dt.Rows[i]["cnvcOperName"].ToString();
							SysInitial.CurOps.strPwd=dt.Rows[i]["cnvcPwd"].ToString();
							SysInitial.CurOps.strDeptID=dt.Rows[i]["cnvcDeptID"].ToString();
							this.Close();
						}
					}
					else if(incount==3)
					{
						MessageBox.Show("密码错误次数超过3次，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						Application.Exit();
					}
					else
					{
						MessageBox.Show("密码错误！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						txtPwd.Text="";
						return;
					}
				}
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// 默认算法加密密钥
		/// </summary>
		private const string ENCRYPT_KEY = "A^8&o}*z"; //必须是8位

		/// <summary>
		/// Salt长度
		/// </summary>
		private const int    SALT_LENGTH = 10;         //建议接近密码长度不等于密码长度
		#region 文本可逆加密

		/// <summary>
		/// 加密字符串
		/// </summary>
		/// <param name="strText">明文</param>
		/// <returns>密文</returns>
		public static string Encrypt(string strText)
		{
			return Encrypt(strText,ENCRYPT_KEY + ENCRYPT_KEY);
		}


		/// <summary>
		/// 加密字符串
		/// </summary>
		/// <param name="strText">明文</param>
		/// <param name="strKey">加密key必须是16位</param>
		/// <returns>密文</returns>
		public static string Encrypt(string strText,string strKey)
		{
			byte[] byKey=null;   
			byte[] IV= {0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16};

			byKey = System.Text.Encoding.UTF8.GetBytes(strKey.Substring(0,16));
			RijndaelManaged RMCrypto = new RijndaelManaged();
			byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
			MemoryStream ms = new  MemoryStream();
			CryptoStream cs = new  CryptoStream(ms, RMCrypto.CreateEncryptor(byKey, IV), CryptoStreamMode.Write) ;
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			return Convert.ToBase64String(ms.ToArray());
		}


		/// <summary>
		/// 解密字符串
		/// </summary>
		/// <param name="strCrypto">密文</param>
		/// <returns>明文</returns>
		public static string Decrypt(string strCrypto)
		{
			return Decrypt(strCrypto,ENCRYPT_KEY + ENCRYPT_KEY);
		}


		/// <summary>
		/// 解密字符串
		/// </summary>
		/// <param name="strCrypto">密文</param>
		/// <param name="strKey">解密key必须是16位</param>
		/// <returns>明文</returns>
		public static string Decrypt(string strCrypto,string strKey)
		{
			byte[] byKey = null; 
			byte[] IV= {0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16}; 
			byte[] inputByteArray = new Byte[strCrypto.Length];

			byKey = System.Text.Encoding.UTF8.GetBytes(strKey.Substring(0,16));
			RijndaelManaged RMCrypto = new RijndaelManaged();
			inputByteArray = Convert.FromBase64String(strCrypto);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, RMCrypto.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			System.Text.Encoding encoding = new System.Text.UTF8Encoding();
			return encoding.GetString(ms.ToArray());
		}

		#endregion
	}
}
