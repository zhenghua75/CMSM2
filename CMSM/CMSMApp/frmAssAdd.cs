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
	/// frmAssAdd 的摘要说明。
	/// </summary>
	public class frmAssAdd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label label9;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private System.Windows.Forms.TextBox txtLicenseTag;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		private System.Windows.Forms.ComboBox cmbCompName;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.TextBox txtDeptName;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmAssAdd()
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.cmbCompName = new System.Windows.Forms.ComboBox();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.txtDeptName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "会员卡号";
			// 
			// txtCardID
			// 
			this.txtCardID.Location = new System.Drawing.Point(72, 16);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(152, 21);
			this.txtCardID.TabIndex = 0;
			this.txtCardID.Text = "";
			this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "单位名称";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "加油名称";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "指定加油站";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(192, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "型号";
			// 
			// txtComments
			// 
			this.txtComments.Location = new System.Drawing.Point(88, 176);
			this.txtComments.MaxLength = 100;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(384, 72);
			this.txtComments.TabIndex = 6;
			this.txtComments.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "备 注";
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGoodsType.Location = new System.Drawing.Point(232, 96);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(80, 20);
			this.cmbGoodsType.TabIndex = 4;
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Location = new System.Drawing.Point(360, 96);
			this.txtLicenseTag.MaxLength = 10;
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(104, 21);
			this.txtLicenseTag.TabIndex = 2;
			this.txtLicenseTag.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(312, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "车牌号";
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(264, 264);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 8;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(152, 264);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(72, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 7;
			this.sbtnOk.Text = "确定发卡";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// cmbCompName
			// 
			this.cmbCompName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompName.Location = new System.Drawing.Point(72, 56);
			this.cmbCompName.Name = "cmbCompName";
			this.cmbCompName.Size = new System.Drawing.Size(392, 20);
			this.cmbCompName.TabIndex = 1;
			this.cmbCompName.SelectedIndexChanged += new System.EventHandler(this.cmbCompName_SelectedIndexChanged);
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbGoodsName.Location = new System.Drawing.Point(72, 96);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(104, 21);
			this.cmbGoodsName.TabIndex = 3;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// txtDeptName
			// 
			this.txtDeptName.Location = new System.Drawing.Point(88, 136);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.Size = new System.Drawing.Size(152, 21);
			this.txtDeptName.TabIndex = 0;
			this.txtDeptName.Text = "";
			// 
			// frmAssAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(488, 302);
			this.Controls.Add(this.txtDeptName);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.cmbCompName);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
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
			this.Name = "frmAssAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员资料录入";
			this.Load += new System.EventHandler(this.frmAssAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAssAdd_Load(object sender, System.EventArgs e)
		{
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			this.FillComboBox(cmbCompName,"MebComp","cnvcCompanyName");
			this.txtDeptName.ReadOnly=true;
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==8)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			CMSMStruct.MemberStruct meb1=new CMSMStruct.MemberStruct();
			if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length!=5)
			{
				MessageBox.Show("会员卡号不可为空且为5位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			else if(!cs.ChkCardIDDup(txtCardID.Text.Trim(),out err))
			{
				meb1.strCardID=txtCardID.Text.Trim();
			}
			else
			{
				if(err==null)
				{
					MessageBox.Show("该卡已经有其他会员使用，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtCardID.Focus();
					return;	
				}
				else
				{
					MessageBox.Show("检查卡号错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					return;	
				}
			}

			if(cmbCompName.Text.Trim()=="")
			{
				MessageBox.Show("无单位信息，请先录入单位信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				meb1.strCompanyName=cmbCompName.Text.Trim();
			}

			CMSMStruct.CompDeptStruct compdept=this.GetComDeptByCompName(meb1.strCompanyName);
			meb1.strCompanyID=compdept.strCompanyID;
			meb1.strDeptID=compdept.strDeptID;
			meb1.strDeptName=compdept.strDeptName;
			if(meb1.strDeptName==""||meb1.strDeptID=="")
			{
				MessageBox.Show("部门参数不正确！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(txtLicenseTag.Text.Trim()!=""&&txtLicenseTag.Text.Trim().Length>20)
			{
				MessageBox.Show("车牌号不可为空且小于20个字符，请重新填写车牌号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtLicenseTag.Focus();
				return;
			}
			else
			{
				meb1.strLicenseTag=txtLicenseTag.Text.Trim();
			}

			meb1.strGoodsName=cmbGoodsName.Text.Trim();
			meb1.strGoodsType=cmbGoodsType.Text.Trim();
			meb1.strState="0";
			meb1.strComments=txtComments.Text.Trim();
			meb1.strCreateDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			meb1.strOperName=SysInitial.CurOps.strOperName;
			meb1.strOperDate=meb1.strCreateDate;
			
			err=null;
			string strresult=cs.InsertMember(meb1,out err);
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				MessageBox.Show("添加新会员失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null&&strresult!=null)
				{
					clog.WriteLine(err.Message + "\n" + strresult);
				}
				else if(err!=null)
				{
					clog.WriteLine(err);
				}
				else
				{
					clog.WriteLine(strresult);
				}
			}
			else
			{
				MessageBox.Show("添加新会员成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.txtCardID.Text="";
                this.txtLicenseTag.Text="";
				this.txtComments.Text="";
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
		}

		private void cmbCompName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CMSMStruct.CompDeptStruct compdept=this.GetComDeptByCompName(this.cmbCompName.Text.Trim());
			txtDeptName.Text=compdept.strDeptName;
		}
	}
}
