using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Data;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmAssMod.
	/// </summary>
	public class frmAssMod : frmBase
	{
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.TextBox txtLicenseTag;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.TextBox txtDeptName;
		private System.Windows.Forms.ComboBox cmbCompName;
		CMSMStruct.MemberStruct mebOld=new CMSMData.CMSMStruct.MemberStruct();

		public frmAssMod()
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
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.txtDeptName = new System.Windows.Forms.TextBox();
			this.cmbCompName = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(288, 264);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 10;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(152, 264);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 9;
			this.sbtnOk.Text = "更新";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Location = new System.Drawing.Point(368, 96);
			this.txtLicenseTag.MaxLength = 10;
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(104, 21);
			this.txtLicenseTag.TabIndex = 28;
			this.txtLicenseTag.Text = "";
			// 
			// txtComments
			// 
			this.txtComments.Location = new System.Drawing.Point(88, 176);
			this.txtComments.MaxLength = 100;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(384, 72);
			this.txtComments.TabIndex = 32;
			this.txtComments.Text = "";
			// 
			// txtCardID
			// 
			this.txtCardID.Location = new System.Drawing.Point(88, 16);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.ReadOnly = true;
			this.txtCardID.Size = new System.Drawing.Size(152, 21);
			this.txtCardID.TabIndex = 24;
			this.txtCardID.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(320, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 35;
			this.label9.Text = "车牌号";
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGoodsType.Location = new System.Drawing.Point(224, 96);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(80, 20);
			this.cmbGoodsType.TabIndex = 29;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 34;
			this.label8.Text = "备 注";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(184, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 33;
			this.label7.Text = "油号";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 31;
			this.label4.Text = "指定加油站";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 30;
			this.label3.Text = "加油名称";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "单位名称";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 25;
			this.label1.Text = "会员卡号";
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Location = new System.Drawing.Point(88, 96);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(80, 20);
			this.cmbGoodsName.TabIndex = 0;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// txtDeptName
			// 
			this.txtDeptName.Location = new System.Drawing.Point(88, 136);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.Size = new System.Drawing.Size(152, 21);
			this.txtDeptName.TabIndex = 36;
			this.txtDeptName.Text = "";
			// 
			// cmbCompName
			// 
			this.cmbCompName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompName.Location = new System.Drawing.Point(88, 56);
			this.cmbCompName.Name = "cmbCompName";
			this.cmbCompName.Size = new System.Drawing.Size(384, 20);
			this.cmbCompName.TabIndex = 37;
			// 
			// frmAssMod
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(488, 302);
			this.Controls.Add(this.cmbCompName);
			this.Controls.Add(this.txtDeptName);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.txtLicenseTag);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
			this.Name = "frmAssMod";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员资料修改";
			this.Load += new System.EventHandler(this.frmAssMod_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			CMSMStruct.MemberStruct mebNew=new CMSMStruct.MemberStruct();
			if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length>5)
			{
				MessageBox.Show("会员卡号不可为空且等于5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}

			if(cmbCompName.Text.Trim()==""||cmbCompName.Text.Trim().Length>30)
			{
				MessageBox.Show("单位名称不可为空且小于30个汉字，请重新填写单位名称！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				mebNew.strCompanyName=cmbCompName.Text.Trim();
			}

			if(txtLicenseTag.Text.Trim()!=""&&txtLicenseTag.Text.Trim().Length>20)
			{
				MessageBox.Show("车牌号不可为空且小于20个字符，请重新填写车牌号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtLicenseTag.Focus();
				return;
			}
			else
			{
				mebNew.strLicenseTag=txtLicenseTag.Text.Trim();
			}

			mebNew.strCompanyName=cmbCompName.Text.Trim();
			mebNew.strLicenseTag=txtLicenseTag.Text.Trim();
			mebNew.strGoodsName=cmbGoodsName.Text.Trim();
			mebNew.strGoodsType=cmbGoodsType.Text.Trim();
			mebNew.strComments=txtComments.Text.Trim();
			mebNew.strOperName=SysInitial.CurOps.strOperName;
			mebNew.strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			
			err=null;
			cs.UpdateMember(mebNew,mebOld,out err);
			if(err!=null)
			{
				MessageBox.Show("修改会员资料失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{
				MessageBox.Show("修改会员资料成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmAssMod_Load(object sender, System.EventArgs e)
		{
			if(this.Owner!=null)
			{
				this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
				this.FillComboBox(cmbCompName,"MebComp","cnvcCompanyName");
				foreach(System.Windows.Forms.Control ctl in this.Owner.Controls)
				{
					if(ctl is System.Windows.Forms.DataGrid && ctl.Name=="dataGrid1")
					{
						DataGrid dg=ctl as DataGrid;
						if(dg.CurrentRowIndex>=0)
						{
							this.txtCardID.Text=dg[dg.CurrentRowIndex,0].ToString();
							this.cmbCompName.Text =dg[dg.CurrentRowIndex,1].ToString();
							this.txtLicenseTag.Text =dg[dg.CurrentRowIndex,2].ToString();
							this.cmbGoodsName.Text =dg[dg.CurrentRowIndex,3].ToString();
							this.cmbGoodsType.Text =dg[dg.CurrentRowIndex,4].ToString();
							this.txtDeptName.Text =dg[dg.CurrentRowIndex,5].ToString();
							this.txtComments.Text =dg[dg.CurrentRowIndex,7].ToString();

							mebOld.strCardID=dg[dg.CurrentRowIndex,0].ToString();
							mebOld.strCompanyName =dg[dg.CurrentRowIndex,1].ToString();
							mebOld.strLicenseTag =dg[dg.CurrentRowIndex,2].ToString();
							mebOld.strGoodsName =dg[dg.CurrentRowIndex,3].ToString();
							mebOld.strGoodsType =dg[dg.CurrentRowIndex,4].ToString();
							mebOld.strDeptName =dg[dg.CurrentRowIndex,5].ToString();
							mebOld.strState =dg[dg.CurrentRowIndex,6].ToString();
							mebOld.strComments =dg[dg.CurrentRowIndex,7].ToString();
							mebOld.strCreateDate =dg[dg.CurrentRowIndex,8].ToString();
						}
					}
				}
				txtCardID.ReadOnly=true;
				cmbCompName.Enabled=false;
				txtDeptName.ReadOnly=true;
			}
			else
			{
				this.ClearText();
			}
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
		}
	}
}
