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
	/// Summary description for frmDensitySet.
	/// </summary>
	public class frmDensitySet : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.ComboBox cmbDeptName;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCurDensity;
		private System.Windows.Forms.TextBox txtDensity;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmDensitySet()
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
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.cmbDeptName = new System.Windows.Forms.ComboBox();
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCurDensity = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.txtDensity = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGoodsName.Location = new System.Drawing.Point(80, 56);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(152, 20);
			this.cmbGoodsName.TabIndex = 2;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// cmbDeptName
			// 
			this.cmbDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDeptName.Location = new System.Drawing.Point(80, 16);
			this.cmbDeptName.Name = "cmbDeptName";
			this.cmbDeptName.Size = new System.Drawing.Size(152, 20);
			this.cmbDeptName.TabIndex = 0;
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGoodsType.Location = new System.Drawing.Point(328, 56);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(152, 20);
			this.cmbGoodsType.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(264, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 27;
			this.label7.Text = "物料型号";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 26;
			this.label4.Text = "部门";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 25;
			this.label3.Text = "物料名称";
			// 
			// txtCurDensity
			// 
			this.txtCurDensity.Location = new System.Drawing.Point(80, 96);
			this.txtCurDensity.MaxLength = 10;
			this.txtCurDensity.Name = "txtCurDensity";
			this.txtCurDensity.Size = new System.Drawing.Size(152, 21);
			this.txtCurDensity.TabIndex = 3;
			this.txtCurDensity.Text = "";
			this.txtCurDensity.GotFocus += new System.EventHandler(this.txtCurDensity_GotFocus);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 31;
			this.label9.Text = "当前密度";
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(296, 136);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 33;
			this.sbtnClose.Text = "取消";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(136, 136);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(56, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 32;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// txtDensity
			// 
			this.txtDensity.Location = new System.Drawing.Point(328, 96);
			this.txtDensity.MaxLength = 10;
			this.txtDensity.Name = "txtDensity";
			this.txtDensity.Size = new System.Drawing.Size(152, 21);
			this.txtDensity.TabIndex = 4;
			this.txtDensity.Text = "";
			this.txtDensity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDensity_KeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(264, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 35;
			this.label1.Text = "最新密度";
			// 
			// frmDensitySet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(504, 174);
			this.Controls.Add(this.txtDensity);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.txtCurDensity);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.cmbDeptName);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Name = "frmDensitySet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "密度设置 ";
			this.Load += new System.EventHandler(this.frmDensitySet_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDensitySet_Load(object sender, System.EventArgs e)
		{
			this.cmbDeptName.Items.Add(SysInitial.LocalDeptName);
			this.cmbDeptName.SelectedIndex=0;
			this.cmbDeptName.Enabled=false;
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			txtCurDensity.ReadOnly=true;
			txtCurDensity.Text="请点击此处...";
		}

		private void txtDensity_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8||e.KeyChar==46)
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)
				{
					e.Handled=true;
					return;
				}
			}
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(this.cmbGoodsName.Enabled)
			{
				this.Close();
			}
			else
			{
				this.cmbGoodsName.Enabled=true;
				this.cmbGoodsType.Enabled=true;
				this.txtCurDensity.Text="请点击此处...";
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			string strDeptName=cmbDeptName.Text.Trim();
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			if(strGoodsName==""||strGoodsType==""||strDeptName=="")
			{
				MessageBox.Show("部门及物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(txtCurDensity.Text.Trim()=="请点击此处...")
			{
				MessageBox.Show("请先获取当前密度！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(txtDensity.Text.Trim()==""||txtDensity.Text.Trim()=="0")
			{
				MessageBox.Show("请设置最新密度，不能为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			CMSMData.CMSMStruct.DensityStruct dens=new CMSMData.CMSMStruct.DensityStruct();
			dens.strDeptName=strDeptName;
			dens.strGoodsName=strGoodsName;
			dens.strGoodsType=strGoodsType;
			dens.strDensity=Math.Round(double.Parse(txtDensity.Text.Trim()),4).ToString();
			dens.strDeptID=SysInitial.LocalDeptID;

			err=null;
			if(cs.InsertDensity(dens,out err))
			{
				MessageBox.Show("最新密度设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.cmbGoodsName.Enabled=true;
				this.cmbGoodsType.Enabled=true;
				this.txtCurDensity.Text="请点击此处...";
				this.txtDensity.Text="";
				return;
			}
			else
			{
				MessageBox.Show("最新密度设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void txtCurDensity_GotFocus(object sender, EventArgs e)
		{
			this.cmbGoodsName.Focus();
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			string strDeptName=cmbDeptName.Text.Trim();
			if(strGoodsName==""||strGoodsType==""||strDeptName=="")
			{
				MessageBox.Show("部门及物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			
			err=null;
			CMSMStruct.DensityStruct dens=cs.GetCurDensity(strGoodsName,strGoodsType,strDeptName,out err);
			if(err!=null)
			{
				MessageBox.Show("获取当前密度出错，请检查当前密度信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			if(dens==null)
			{
				this.txtCurDensity.Text="尚未设置";
			}
			else
			{
				this.txtCurDensity.Text=dens.strDensity;
			}
			this.cmbGoodsName.Enabled=false;
			this.cmbGoodsType.Enabled=false;
		}
	}
}
