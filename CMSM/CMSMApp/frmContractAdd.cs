using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSM.Business;
using CMSM.Common;
using CMSM.Entity;
using System.Data;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmContractAdd 的摘要说明。
	/// </summary>
	public class frmContractAdd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmContractAdd()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sbtnCancel);
			this.groupBox1.Controls.Add(this.sbtnOK);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(40, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 184);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnCancel.Location = new System.Drawing.Point(208, 136);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(72, 23);
			this.sbtnCancel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnCancel.TabIndex = 22;
			this.sbtnCancel.Text = "取消";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOK.Location = new System.Drawing.Point(96, 136);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.Size = new System.Drawing.Size(72, 23);
			this.sbtnOK.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOK.TabIndex = 21;
			this.sbtnOK.Text = "确定";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(72, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(320, 21);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "单位名称：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(72, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "合同编号：";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 15.75F);
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(40, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(424, 48);
			this.label3.TabIndex = 25;
			this.label3.Text = "请仔细核对合同编号为半角、单位名称最多可输入25个汉字，确认无误后再点确定！";
			// 
			// frmContractAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(480, 278);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmContractAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "专供油合同";
			this.Load += new System.EventHandler(this.frmContractAdd_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private OperFlag _flag;
		public OperFlag Flag
		{
			get{return _flag;}
			set{_flag=value;}
		}
		private Entity.SpecialOilDept _so;
		public Entity.SpecialOilDept SO
		{
			get{return _so;}
			set{_so=value;}
		}

		private void frmContractAdd_Load(object sender, System.EventArgs e)
		{
			switch(_flag)
			{
				case OperFlag.ADD:
					this.Text = "添加专供油合同";
					break;
				case OperFlag.MOD:
					this.Text = "修改专供油合同";
					this.textBox1.Text = _so.cnvcContractNo;
					this.textBox2.Text = _so.cnvcDeliveryCompany;
					this.textBox1.ReadOnly = true;
					break;
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private bool SOValidate()
		{
			if(this.textBox1.Text.Trim() == "") 
			{
				MessageBox.Show(this,"请输入合同编号");
				return false;
			}
			if(this.textBox2.Text.Trim() == "")
			{
				MessageBox.Show(this,"请输入单位名称");
				return false;
			}
			if(!this.textBox2.Text.StartsWith(CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp))
			{
				MessageBox.Show(this,"单位名称非法，请以"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp+"开头");
				return false;
			}
			if(_flag == OperFlag.ADD)
			{
				DataTable dt = Helper.Query("select * from tbSpecialOilDept where cnvccontractno='"+this.textBox1.Text.Trim()+"'",true);
				if(dt.Rows.Count >0 )
				{
					MessageBox.Show(this,"合同编号重复！");
					return false;
				}
			}
			return true;
		}
		private void LoadPara()
		{
			//系统初始化
			Exception err=null;
			CMSMData.CMSMDataAccess.SysInitial.desConstring(Application.StartupPath);
			//err=null;
			CMSMData.CMSMDataAccess.SysInitial.CreatDS(out err);
			if(err!=null)
			{
//				MessageBox.Show("系统初始化错误，或是部门和操作员信息不全，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				clog.WriteLine(err);
//				Application.Exit();
//				return;
				throw new Exception("系统初始化错误，或是部门和操作员信息不全，请与管理员联系！");
			}

//			if(SysInitial.LocalDeptName==""||SysInitial.LocalDeptID=="")
//			{
//				Form form1=new frmDeptSet();
//				form1.ShowDialog();
//			}
//
//			if(SysInitial.dsSys.Tables["Oper"].Rows.Count==0)
//			{
//				MessageBox.Show("参数不全，请先在网站上录入部门和操作信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				Application.Exit();
//				return;
//			}	
		}
		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			//保存
			if(!SOValidate()) return;
			Entity.BusiLog bl = new CMSM.Entity.BusiLog();
			bl.cnvcDeptID = CMSMData.CMSMDataAccess.SysInitial.LocalDeptID;
			bl.cnvcDeptName = CMSMData.CMSMDataAccess.SysInitial.LocalDeptName;
			bl.cnvcOperName = CMSMData.CMSMDataAccess.SysInitial.CurOps.strOperName;
			ContractFacade cf = new ContractFacade();
			try
			{
				switch(_flag)
				{
					case OperFlag.ADD:
						Entity.SpecialOilDept so = new SpecialOilDept();
						so.cnvcContractNo = this.textBox1.Text;
						so.cnvcDeliveryCompany = this.textBox2.Text;
					
						cf.SOADD(so,bl);
						cf.SOSync(CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp);
						MessageBox.Show(this,"专供油合同添加成功");
						break;
					case OperFlag.MOD:
						//Entity.SpecialOilDept so = new SpecialOilDept();
						_so.cnvcContractNo = this.textBox1.Text;
						_so.cnvcDeliveryCompany = this.textBox2.Text;
						cf.SOMOD(_so,bl);
						cf.SOSync(CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp);
						MessageBox.Show(this,"专供油合同修改成功");
						break;
				}		
				LoadPara();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
