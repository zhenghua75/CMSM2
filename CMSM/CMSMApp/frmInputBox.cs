using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using CMSMData;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmInputBox.
	/// </summary>
	public class frmInputBox : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCardID;
		public System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		public System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInputBox()
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
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtCardID
			// 
			this.txtCardID.Location = new System.Drawing.Point(16, 32);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(296, 21);
			this.txtCardID.TabIndex = 2;
			this.txtCardID.Text = "";
			this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "会员卡号";
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(248, 64);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 12;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(168, 64);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 11;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "label2";
			this.label2.Visible = false;
			// 
			// frmInputBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(326, 92);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "输入框";
			this.Load += new System.EventHandler(this.frmInputBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmInputBox_Load(object sender, System.EventArgs e)
		{
		
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			SysInitial.strTmp="CanCel";
			this.Close();
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			switch(label2.Text.Trim())
			{
				case "Again":
					if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length!=5)
					{
						MessageBox.Show("会员卡号不可为空且为5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						txtCardID.Focus();
						return;
					}

					Exception err=null;
					CommAccess cs=new CommAccess(SysInitial.ConString);
					if(!cs.ChkCardIDDup(txtCardID.Text.Trim(),out err))
					{
						SysInitial.strTmp=txtCardID.Text.Trim();
					}
					else
					{
						MessageBox.Show("该卡号已经被其他会员使用过，不能再使用，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						if(err!=null)
						{
							clog.WriteLine(err);
						}
						txtCardID.Focus();
						return;						
					}
					break;
				default:
					break;
			}
			this.Close();
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
				switch(label2.Text.Trim())
				{
					case "Again":
						if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length>10)
						{
							MessageBox.Show("会员卡号不可为空且小于10位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							txtCardID.Focus();
							return;
						}

						Exception err=null;
						CommAccess cs=new CommAccess(SysInitial.ConString);
						if(!cs.ChkCardIDDup(txtCardID.Text.Trim(),out err))
						{
							SysInitial.strTmp=txtCardID.Text.Trim();
						}
						else
						{
							MessageBox.Show("该卡已经有其他会员使用，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							if(err!=null)
							{
								clog.WriteLine(err);
							}
							txtCardID.Focus();
							return;						
						}
						break;
					default:
						break;
				}
				this.Close();
			}
		}
	}
}
