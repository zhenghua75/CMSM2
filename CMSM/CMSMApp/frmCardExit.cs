using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using CMSMData;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmCardExit.
	/// </summary>
	public class frmCardExit : CMSM.CMSMApp.frmBase
	{
		private DevExpress.XtraEditors.SimpleButton sbtnRead;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.TextBox txtLicenseTag;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton sbtnExit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		CommAccess cs=new CommAccess(SysInitial.ConString);
		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
		Exception err;

		public frmCardExit()
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
			this.sbtnRead = new DevExpress.XtraEditors.SimpleButton();
			this.txtCompName = new System.Windows.Forms.TextBox();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// sbtnRead
			// 
			this.sbtnRead.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnRead.Location = new System.Drawing.Point(80, 160);
			this.sbtnRead.Name = "sbtnRead";
			this.sbtnRead.Size = new System.Drawing.Size(56, 23);
			this.sbtnRead.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnRead.TabIndex = 36;
			this.sbtnRead.Text = "刷卡";
			this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
			// 
			// txtCompName
			// 
			this.txtCompName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCompName.Location = new System.Drawing.Point(88, 112);
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(288, 22);
			this.txtCompName.TabIndex = 32;
			this.txtCompName.Text = "";
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLicenseTag.Location = new System.Drawing.Point(88, 64);
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(144, 22);
			this.txtLicenseTag.TabIndex = 27;
			this.txtLicenseTag.Text = "";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(88, 16);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(144, 22);
			this.txtCardID.TabIndex = 24;
			this.txtCardID.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "会员卡号";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 31;
			this.label4.Text = "单位名称";
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(256, 160);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 30;
			this.sbtnClose.Text = "取消";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "车牌号";
			// 
			// sbtnExit
			// 
			this.sbtnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnExit.Location = new System.Drawing.Point(168, 160);
			this.sbtnExit.Name = "sbtnExit";
			this.sbtnExit.Size = new System.Drawing.Size(56, 23);
			this.sbtnExit.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnExit.TabIndex = 25;
			this.sbtnExit.Text = "退卡";
			this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
			// 
			// frmCardExit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(392, 206);
			this.Controls.Add(this.sbtnRead);
			this.Controls.Add(this.txtCompName);
			this.Controls.Add(this.txtLicenseTag);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sbtnExit);
			this.Name = "frmCardExit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员卡退卡";
			this.Load += new System.EventHandler(this.wfmCardExit_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void wfmCardExit_Load(object sender, System.EventArgs e)
		{
			txtCardID.ReadOnly=true;
			txtCompName.ReadOnly=true;
			txtLicenseTag.ReadOnly=true;
			sbtnExit.Enabled=false;
		}

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
			string strresult="";
			chs=cs.ReadCardInfo(out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(strresult!=null||strresult!="")
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			
			err=null;
			CMSMStruct.MemberStruct mebres=new CMSMStruct.MemberStruct();
			string strDeptNameTmp= CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp;
			mebres=cs.GetMemberDetail(chs.strCardID,strDeptNameTmp,out err);
			if(mebres!=null)
			{
				txtCardID.Text=mebres.strCardID;
				txtCompName.Text=mebres.strCompanyName;
				txtLicenseTag.Text=mebres.strLicenseTag;
				txtCardID.ReadOnly=true;
				sbtnExit.Enabled=true;
				sbtnRead.Enabled=false;
			}
			else
			{
				MessageBox.Show("无此会员或已经失效，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnExit_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			if(strCardID==""||strCardID.Length!=5)
			{
				MessageBox.Show("会员卡号不可为空且为5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("是否确定该会员卡退卡？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				err=null;
				cs.CardExit(strCardID,out err);
				if(err!=null)
				{
					MessageBox.Show("退卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
				}
				else
				{
					MessageBox.Show("退卡成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					this.ClearText();
					txtCardID.ReadOnly=false;
					sbtnExit.Enabled=false;
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
				this.sbtnRead.Enabled=true;
				this.sbtnExit.Enabled=false;
			}
		}
	}
}
