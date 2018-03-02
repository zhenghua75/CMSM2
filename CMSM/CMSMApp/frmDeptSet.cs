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
	/// Summary description for frmDeptSet.
	/// </summary>
	public class frmDeptSet : frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		CommAccess ca=new CommAccess(SysInitial.ConString);

		public frmDeptSet()
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
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "部门";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(320, 24);
			this.label3.TabIndex = 7;
			this.label3.Text = "本设置是确定本部门名称信息，只设置一次";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(48, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 20);
			this.comboBox1.TabIndex = 8;
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(216, 72);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(40, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 21;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// frmDeptSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.PowderBlue;
			this.ClientSize = new System.Drawing.Size(272, 112);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeptSet";
			this.Opacity = 0.8;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设置本门店信息";
			this.Load += new System.EventHandler(this.frmDeptSet_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDeptSet_Load(object sender, System.EventArgs e)
		{
			this.label3.ForeColor=Color.Red;
			this.FillComboBox(comboBox1,"Dept","cnvcCommName");
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			string strDeptName=this.comboBox1.Text;
			string strDeptID=this.GetColEn(strDeptName,"Dept");
			Exception err=null;
			ca.SetLocalDept(strDeptName,strDeptID,out err);
			if(err!=null)
			{
				MessageBox.Show("设置本地门店出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				Application.Exit();
			}
			else
			{
				SysInitial.LocalDeptID=strDeptID;
				SysInitial.LocalDeptName=strDeptName;
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统初始化错误，或是部门和操作员信息不全，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					Application.Exit();
					return;
				}
				this.Close();
			}
		}


	}
}
