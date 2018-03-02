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
	/// Summary description for frmMebCompayAdd.
	/// </summary>
	public class frmMebCompayAdd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ComboBox cmbDeptName;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmMebCompayAdd()
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
			this.cmbDeptName = new System.Windows.Forms.ComboBox();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.txtCompName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbDeptName
			// 
			this.cmbDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDeptName.Location = new System.Drawing.Point(88, 64);
			this.cmbDeptName.Name = "cmbDeptName";
			this.cmbDeptName.Size = new System.Drawing.Size(208, 20);
			this.cmbDeptName.TabIndex = 38;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(296, 104);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(56, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 37;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(184, 104);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 36;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// txtCompName
			// 
			this.txtCompName.Location = new System.Drawing.Point(88, 24);
			this.txtCompName.MaxLength = 30;
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(392, 21);
			this.txtCompName.TabIndex = 26;
			this.txtCompName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 31;
			this.label4.Text = "指定加油站";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "单位名称";
			// 
			// frmMebCompayAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 142);
			this.Controls.Add(this.cmbDeptName);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.txtCompName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Name = "frmMebCompayAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员单位添加";
			this.Load += new System.EventHandler(this.frmMebCompayAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMebCompayAdd_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbDeptName,"AllDept","cnvcCommName");
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			string strCompName=txtCompName.Text.Trim();
			string strDeptName=cmbDeptName.Text.Trim();
			string strDeptID=this.GetColEn(strDeptName,"AllDept");

			if(strCompName=="")
			{
				MessageBox.Show("单位名称不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.txtCompName.Focus();
				return;
			}
			else
			{
				err=null;
				if(cs.IsDupMebCompany(strCompName,out err))
				{
					MessageBox.Show("单位名称已经存在，不能添加！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					this.txtCompName.Focus();
					return;
				}
			}
			
			err=null;
			if(!cs.InsertMebCompay(strCompName,strDeptName,strDeptID,out err))
			{
				MessageBox.Show("添加新的会员单位失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
			else
			{
				MessageBox.Show("添加新的会员单位成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.ClearText();
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					Application.Exit();
				}
			}
		}
	}
}
