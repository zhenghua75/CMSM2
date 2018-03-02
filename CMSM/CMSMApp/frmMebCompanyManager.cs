using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;
using CMSMData;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmMebCompanyManager.
	/// </summary>
	public class frmMebCompanyManager : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnQuery;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private System.ComponentModel.IContainer components = null;

		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbCompName;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton sbtnFill;
		Exception err;

		public frmMebCompanyManager()
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnQuery = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbCompName = new System.Windows.Forms.ComboBox();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.sbtnFill = new DevExpress.XtraEditors.SimpleButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 126);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(960, 408);
			this.dataGrid1.TabIndex = 5;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(744, 24);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 23;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnQuery
			// 
			this.sbtnQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnQuery.Location = new System.Drawing.Point(520, 24);
			this.sbtnQuery.Name = "sbtnQuery";
			this.sbtnQuery.Size = new System.Drawing.Size(56, 23);
			this.sbtnQuery.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnQuery.TabIndex = 22;
			this.sbtnQuery.Text = "查询";
			this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "单位名称";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbCompName);
			this.groupBox1.Controls.Add(this.sbtnAdd);
			this.groupBox1.Controls.Add(this.sbtnClose);
			this.groupBox1.Controls.Add(this.sbtnQuery);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(960, 64);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// cmbCompName
			// 
			this.cmbCompName.Location = new System.Drawing.Point(88, 24);
			this.cmbCompName.Name = "cmbCompName";
			this.cmbCompName.Size = new System.Drawing.Size(384, 20);
			this.cmbCompName.TabIndex = 44;
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAdd.Location = new System.Drawing.Point(632, 24);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.Size = new System.Drawing.Size(56, 23);
			this.sbtnAdd.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAdd.TabIndex = 43;
			this.sbtnAdd.Text = "添加";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.sbtnFill);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(960, 62);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(272, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 16);
			this.label3.TabIndex = 44;
			this.label3.Text = "元";
			// 
			// sbtnFill
			// 
			this.sbtnFill.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnFill.Location = new System.Drawing.Point(336, 24);
			this.sbtnFill.Name = "sbtnFill";
			this.sbtnFill.Size = new System.Drawing.Size(56, 23);
			this.sbtnFill.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnFill.TabIndex = 43;
			this.sbtnFill.Text = "充值";
			this.sbtnFill.Click += new System.EventHandler(this.sbtnFill_Click);
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(88, 24);
			this.textBox1.MaxLength = 5;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(184, 22);
			this.textBox1.TabIndex = 42;
			this.textBox1.Text = "0";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "充值金额";
			// 
			// frmMebCompanyManager
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(960, 534);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmMebCompanyManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员单位资料管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMebCompanyManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}	

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			frmMebCompayAdd frmadd=new frmMebCompayAdd();
			frmadd.ShowDialog();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void DgBind()
		{
			string strCompName=cmbCompName.Text.Trim();
			if(strCompName=="全部")
			{
				strCompName="";
			}
			Exception err=null;
			DataTable dt=new DataTable();

			dt=cs.GetMebCompanyPrepay(strCompName,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("单位编码,单位名称,部门名称,预存款余额,当前会员数量","200,200,200,100,100",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询会员单位信息出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void frmMebCompanyManager_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbCompName,"MebComp","cnvcCompanyName","all");
			this.cmbCompName.DropDownStyle=ComboBoxStyle.DropDown;
		}

		private void sbtnFill_Click(object sender, System.EventArgs e)
		{
			if(this.dataGrid1.CurrentRowIndex>=0)
			{
				double fillfee=0;
				if(this.textBox1.Text.Trim()=="")
				{
					MessageBox.Show("充值金额不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					fillfee=double.Parse(this.textBox1.Text.Trim());
				}
				if(fillfee<=0)
				{
					MessageBox.Show("充值金额不能为0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}

				CMSMStruct.FillFeeStruct fillnew=new CMSMStruct.FillFeeStruct();
				fillnew.strFillFee=Math.Round(fillfee,2).ToString();
				fillnew.strCompanyID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				fillnew.strCompanyName=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
				fillnew.strDeptName=dataGrid1[dataGrid1.CurrentRowIndex,2].ToString();
				fillnew.strOperName=SysInitial.CurOps.strOperName;
				fillnew.strOperDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				string strCount=dataGrid1[dataGrid1.CurrentRowIndex,4].ToString();
				err=null;
				string strDeptID="";
				fillnew.strAcctID=cs.GetMebCompanyAcctDeptID(fillnew.strCompanyID,out strDeptID,out err);
				if(fillnew.strAcctID==""||strDeptID=="")
				{
					MessageBox.Show("检测单位信息出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					fillnew.strDeptID=strDeptID;
				}

				bool isdup=cs.IsDupMebCompanyExist2(fillnew.strCompanyName,out err);
				if(err!=null)
				{
					MessageBox.Show("检测单位信息出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					if(isdup)
					{
						DialogResult dre=MessageBox.Show("名称："+fillnew.strCompanyName+"  的单位有两个\n你确认要为此会员数为"+strCount+"的单位充值吗？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
						if(dre==DialogResult.Yes)
						{
							err=null;
							if(cs.MebCompayFillFee(fillnew,out err))
							{
								MessageBox.Show("充值成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								return;
							}
							else
							{
								MessageBox.Show("充值失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								clog.WriteLine(err);
								return;
							}
						}
					}
					else
					{
						DialogResult dre=MessageBox.Show("你确认要为名称："+fillnew.strCompanyName+" 的单位充值吗？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
						if(dre==DialogResult.Yes)
						{
							err=null;
							if(cs.MebCompayFillFee(fillnew,out err))
							{
								MessageBox.Show("充值成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								return;
							}
							else
							{
								MessageBox.Show("充值失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
								clog.WriteLine(err);
								return;
							}
						}
					}
				}
			}
			else
			{
				MessageBox.Show("没有选中任何需要充值的单位！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
	}
}
