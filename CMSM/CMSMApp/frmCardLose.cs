using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CMSMData.CMSMDataAccess;
using System.Windows.Forms;
using System.Data;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmCardLose.
	/// </summary>
	public class frmCardLose : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton sbtnLose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		private System.Windows.Forms.TextBox txtLicenseTag;
		private System.Windows.Forms.TextBox txtCompName;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmCardLose()
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
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.txtCompName = new System.Windows.Forms.TextBox();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.sbtnLose = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLicenseTag.Location = new System.Drawing.Point(64, 64);
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(144, 22);
			this.txtLicenseTag.TabIndex = 27;
			this.txtLicenseTag.Text = "";
			// 
			// txtCompName
			// 
			this.txtCompName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCompName.Location = new System.Drawing.Point(64, 112);
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(280, 22);
			this.txtCompName.TabIndex = 22;
			this.txtCompName.Text = "";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(64, 16);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(144, 22);
			this.txtCardID.TabIndex = 19;
			this.txtCardID.Text = "";
			this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(0, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 26;
			this.label4.Text = "车牌号";
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(200, 168);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 25;
			this.sbtnClose.Text = "取消";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 21;
			this.label2.Text = "单位名称";
			// 
			// sbtnLose
			// 
			this.sbtnLose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnLose.Location = new System.Drawing.Point(104, 168);
			this.sbtnLose.Name = "sbtnLose";
			this.sbtnLose.Size = new System.Drawing.Size(56, 23);
			this.sbtnLose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnLose.TabIndex = 20;
			this.sbtnLose.Text = "挂失";
			this.sbtnLose.Click += new System.EventHandler(this.sbtnLose_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "会员卡号";
			// 
			// frmCardLose
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(354, 208);
			this.Controls.Add(this.txtLicenseTag);
			this.Controls.Add(this.txtCompName);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sbtnLose);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCardLose";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员卡挂失";
			this.Load += new System.EventHandler(this.frmCardLose_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCardLose_Load(object sender, System.EventArgs e)
		{
			txtCompName.ReadOnly=true;
			txtLicenseTag.ReadOnly=true;
			sbtnLose.Enabled=false;
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
				err=null;
				string strCardID=txtCardID.Text.Trim();
				if(strCardID==""||strCardID.Length!=5)
				{
					MessageBox.Show("会员卡号不可为空且为5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtCardID.Focus();
					return;
				}
				CMSMData.CMSMStruct.MemberStruct mebres=new CMSMData.CMSMStruct.MemberStruct();			
				string strDeptNameTmp= CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp;
				mebres=cs.GetMemberDetail(strCardID,strDeptNameTmp,out err);
				if(mebres!=null)
				{
					string strMebState=mebres.strState;
					if(strMebState!="0")
					{
						MessageBox.Show("该会员已经失效，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.ClearText();
						return;
					}
					txtCompName.Text=mebres.strCompanyName;
					txtLicenseTag.Text=mebres.strLicenseTag;
					txtCardID.ReadOnly=true;
					sbtnLose.Enabled=true;
				}
				else
				{
					MessageBox.Show("你输入的会员卡有误或者不是正常在用会员！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(txtCardID.Text=="")
			{
				this.Close();
			}
			else
			{
				this.ClearText();
				txtCardID.ReadOnly=false;
			}
		}

		private void sbtnLose_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			if(strCardID==""||strCardID.Length!=5)
			{
				MessageBox.Show("会员卡号不可为空且为5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("是否确定挂失该会员卡？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				err=null;
				cs.CardLose(strCardID,out err);
				if(err!=null)
				{
					MessageBox.Show("挂失失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
				}
				else
				{
					MessageBox.Show("挂失成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					this.ClearText();
					txtCardID.ReadOnly=false;
					sbtnLose.Enabled=false;
				}
			}
		}
	}
}
