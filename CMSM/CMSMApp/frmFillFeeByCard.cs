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
	/// frmFillFee 的摘要说明。
	/// </summary>
	public class frmFillFeeByCard : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton sbtnFill;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFillFee;
		private DevExpress.XtraEditors.SimpleButton sbtnRead;
		private System.Windows.Forms.Label lblerr;
		private System.Windows.Forms.TextBox txtLicenseTag;
		private System.Windows.Forms.TextBox txtCompName;

		CommAccess cs=new CommAccess(SysInitial.ConString);
		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
		Exception err;

		public frmFillFeeByCard()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

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
			this.sbtnFill = new DevExpress.XtraEditors.SimpleButton();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFillFee = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.txtCompName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCharge = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sbtnRead = new DevExpress.XtraEditors.SimpleButton();
			this.lblerr = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// sbtnFill
			// 
			this.sbtnFill.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnFill.Location = new System.Drawing.Point(104, 216);
			this.sbtnFill.Name = "sbtnFill";
			this.sbtnFill.Size = new System.Drawing.Size(56, 23);
			this.sbtnFill.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnFill.TabIndex = 7;
			this.sbtnFill.Text = "充值";
			this.sbtnFill.Click += new System.EventHandler(this.sbtnFill_Click);
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(88, 16);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(144, 22);
			this.txtCardID.TabIndex = 6;
			this.txtCardID.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "会员卡号";
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLicenseTag.Location = new System.Drawing.Point(88, 96);
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(144, 22);
			this.txtLicenseTag.TabIndex = 9;
			this.txtLicenseTag.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "车牌号";
			// 
			// txtFillFee
			// 
			this.txtFillFee.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillFee.Location = new System.Drawing.Point(88, 176);
			this.txtFillFee.Name = "txtFillFee";
			this.txtFillFee.Size = new System.Drawing.Size(144, 22);
			this.txtFillFee.TabIndex = 11;
			this.txtFillFee.Text = "";
			this.txtFillFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFillFee_KeyPress);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(24, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "充值金额";
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(192, 216);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 13;
			this.sbtnClose.Text = "取消";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// txtCompName
			// 
			this.txtCompName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCompName.Location = new System.Drawing.Point(88, 56);
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(144, 22);
			this.txtCompName.TabIndex = 15;
			this.txtCompName.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "单位名称";
			// 
			// txtCharge
			// 
			this.txtCharge.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCharge.Location = new System.Drawing.Point(88, 136);
			this.txtCharge.Name = "txtCharge";
			this.txtCharge.Size = new System.Drawing.Size(144, 22);
			this.txtCharge.TabIndex = 17;
			this.txtCharge.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(24, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "当前余额";
			// 
			// sbtnRead
			// 
			this.sbtnRead.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnRead.Location = new System.Drawing.Point(16, 216);
			this.sbtnRead.Name = "sbtnRead";
			this.sbtnRead.Size = new System.Drawing.Size(56, 23);
			this.sbtnRead.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnRead.TabIndex = 21;
			this.sbtnRead.Text = "刷卡";
			this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
			// 
			// lblerr
			// 
			this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.lblerr.Location = new System.Drawing.Point(16, 112);
			this.lblerr.Name = "lblerr";
			this.lblerr.Size = new System.Drawing.Size(232, 48);
			this.lblerr.TabIndex = 22;
			this.lblerr.Visible = false;
			// 
			// frmFillFeeByCard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(262, 256);
			this.Controls.Add(this.lblerr);
			this.Controls.Add(this.sbtnRead);
			this.Controls.Add(this.txtCharge);
			this.Controls.Add(this.txtCompName);
			this.Controls.Add(this.txtFillFee);
			this.Controls.Add(this.txtLicenseTag);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sbtnFill);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFillFeeByCard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员卡充值";
			this.Load += new System.EventHandler(this.frmFillFee_Load);
			this.ResumeLayout(false);

		}
		#endregion

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
				this.sbtnFill.Enabled=false;
				this.txtFillFee.ReadOnly=true;
			}
		}

		private void frmFillFee_Load(object sender, System.EventArgs e)
		{
			txtCardID.ReadOnly=true;
			txtCompName.ReadOnly=true;
			txtLicenseTag.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtFillFee.ReadOnly=true;
			sbtnFill.Enabled=false;
			lblerr.Visible=false;
		}

		private void sbtnFill_Click(object sender, System.EventArgs e)
		{
//			string strCardID=txtCardID.Text.Trim();
//			if(strCardID=="")
//			{
//				MessageBox.Show("会员卡号不正确，请重新刷卡！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				txtCardID.Focus();
//				return;
//			}
//			if(txtFillFee.Text.Trim()=="")
//			{
//				MessageBox.Show("充值金额不可为空，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
//			double dFee=Double.Parse(txtFillFee.Text.Trim());
//			if(dFee<=0)
//			{
//				MessageBox.Show("充值金额应大于0，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
//			else
//			{
//				System.Windows.Forms.DialogResult diaRes=MessageBox.Show("是否确定充值" + dFee.ToString() + "元？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
//				if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
//				{
//					err=null;
//					CMSMStruct.FillFeeStruct ffs=new CMSMData.CMSMStruct.FillFeeStruct();
//					
//					ffs.strCardID=strCardID;
//					ffs.dFillFee=dFee;
//					ffs.dLastFee=double.Parse(txtCharge.Text.Trim());
//					ffs.dCurFee=System.Math.Round((ffs.dFillFee+ffs.dLastFee),2);
//					ffs.strOperName=SysInitial.CurOps.strOperName;
//					ffs.strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
//					ffs.strDeptID=SysInitial.LocalDeptID;
//					ffs.strDeptName=SysInitial.LocalDeptName;
//					double dChargeBak=double.Parse(txtCharge.Text.Trim())+double.Parse(txtFillFee.Text.Trim());
//					if(ffs.dCurFee!=dChargeBak)
//					{
//						MessageBox.Show("充值失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						clog.WriteLine("充值备份值与计算值不等：备份值－" + dChargeBak.ToString() + " 计算值" + ffs.dCurFee.ToString());
//						return;
//					}
//
//					string strresult=cs.FillFee(ffs,dChargeBak,out err);
//					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
//					{
//						MessageBox.Show("充值成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//						clog.WriteLine(strresult);
//					}
//					else
//					{
//						MessageBox.Show("充值失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						lblerr.Text="充值失败，本次充值无效，请检查余额是否正确！";
//						lblerr.Visible=true;
//						if(err!=null)
//						{
//							clog.WriteLine(err);
//						}
//						if(strresult!="")
//						{
//							clog.WriteLine(strresult);
//						}
//					}
//					this.ClearText();
//					txtCardID.ReadOnly=true;
//					this.sbtnFill.Enabled=false;
//					this.sbtnRead.Enabled=true;
//				}
//			}
		}

		private void txtFillFee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==8)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
				return;
			}
		}

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
			string strresult="";
			lblerr.Visible=false;
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
				txtCharge.Text=chs.dCurCharge.ToString();
				txtCardID.ReadOnly=true;
				sbtnFill.Enabled=true;
				sbtnRead.Enabled=false;
				txtFillFee.ReadOnly=false;
				txtFillFee.Focus();
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
	}
}
