using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmAssInfo 的摘要说明。
	/// </summary>
	public class frmAssInfo : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbAssAdd;
		private System.Windows.Forms.ToolBarButton tbbAssMod;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnQuery;
		private DevExpress.XtraEditors.SimpleButton sbtnExcel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLicenseTag;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.ComboBox cmbCompName;

		CommAccess ca=new CommAccess(SysInitial.ConString);
		
		public frmAssInfo()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAssInfo));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbAssAdd = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbAssMod = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbCompName = new System.Windows.Forms.ComboBox();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.cmbDept = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.sbtnExcel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnQuery = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbAssAdd,
																						this.toolBarButton1,
																						this.tbbAssMod});
			this.toolBar1.ButtonSize = new System.Drawing.Size(48, 48);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(936, 54);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAssAdd
			// 
			this.tbbAssAdd.ImageIndex = 0;
			this.tbbAssAdd.Text = "添加";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbAssMod
			// 
			this.tbbAssMod.ImageIndex = 1;
			this.tbbAssMod.Text = "修改";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 136);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(936, 294);
			this.dataGrid1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbCompName);
			this.groupBox1.Controls.Add(this.txtLicenseTag);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cmbType);
			this.groupBox1.Controls.Add(this.cmbDept);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.sbtnExcel);
			this.groupBox1.Controls.Add(this.sbtnClose);
			this.groupBox1.Controls.Add(this.sbtnQuery);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtCardID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 54);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(936, 82);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// cmbCompName
			// 
			this.cmbCompName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompName.ItemHeight = 12;
			this.cmbCompName.Location = new System.Drawing.Point(72, 56);
			this.cmbCompName.Name = "cmbCompName";
			this.cmbCompName.Size = new System.Drawing.Size(360, 20);
			this.cmbCompName.TabIndex = 42;
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLicenseTag.Location = new System.Drawing.Point(536, 56);
			this.txtLicenseTag.MaxLength = 15;
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(128, 22);
			this.txtLicenseTag.TabIndex = 41;
			this.txtLicenseTag.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(488, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 40;
			this.label4.Text = "车牌号";
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Location = new System.Drawing.Point(304, 24);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(128, 20);
			this.cmbType.TabIndex = 39;
			// 
			// cmbDept
			// 
			this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDept.ItemHeight = 12;
			this.cmbDept.Location = new System.Drawing.Point(536, 24);
			this.cmbDept.Name = "cmbDept";
			this.cmbDept.Size = new System.Drawing.Size(128, 20);
			this.cmbDept.TabIndex = 37;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(464, 32);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 24);
			this.label11.TabIndex = 38;
			this.label11.Text = "指定加油站";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(248, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 35;
			this.label3.Text = "会员状态";
			// 
			// sbtnExcel
			// 
			this.sbtnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnExcel.Location = new System.Drawing.Point(792, 40);
			this.sbtnExcel.Name = "sbtnExcel";
			this.sbtnExcel.Size = new System.Drawing.Size(56, 23);
			this.sbtnExcel.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnExcel.TabIndex = 33;
			this.sbtnExcel.Text = "导出";
			this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(864, 40);
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
			this.sbtnQuery.Location = new System.Drawing.Point(720, 40);
			this.sbtnQuery.Name = "sbtnQuery";
			this.sbtnQuery.Size = new System.Drawing.Size(56, 23);
			this.sbtnQuery.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnQuery.TabIndex = 22;
			this.sbtnQuery.Text = "查询";
			this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "单位名称";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(72, 24);
			this.txtCardID.MaxLength = 5;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(136, 22);
			this.txtCardID.TabIndex = 1;
			this.txtCardID.Text = "*";
			this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "会员卡号";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtCount);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 430);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(936, 56);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据汇总";
			// 
			// txtCount
			// 
			this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCount.Location = new System.Drawing.Point(96, 24);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(96, 22);
			this.txtCount.TabIndex = 30;
			this.txtCount.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(32, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 29;
			this.label6.Text = "查询条数";
			// 
			// frmAssInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(936, 486);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.Name = "frmAssInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "会员基本资料管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmAssInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					frmAssAdd frmadd=new frmAssAdd();
					frmadd.ShowDialog();
					break;
				case 2:
					if(this.dataGrid1.CurrentRowIndex<0)
					{
						MessageBox.Show("没有数据可以修改！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					}
					else if(this.dataGrid1[this.dataGrid1.CurrentRowIndex,6].ToString()!="正常在用")
					{
						MessageBox.Show("不能修改非正常在用会员资料！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					}
					else
					{
						frmAssMod frmmod=new frmAssMod();
						this.AddOwnedForm(frmmod);
						frmmod.ShowDialog();
					}
					break;
				default:
					break;
			}
		}

		private void DgBind()
		{
			string strDeptNameTmp= CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp;
			string strCardID=txtCardID.Text.Trim();
			string strCompName=cmbCompName.Text.Trim();
			if(strCompName=="全部")
			{
				strCompName="";
			}
			string strType=cmbType.Text.ToString();
			string strDeptName=cmbDept.Text.Trim();
			string strLicenseTag=txtLicenseTag.Text.Trim();
			if(strDeptName=="全部")
			{
				strDeptName=strDeptNameTmp;
			}
			if (strType=="全部")	
			{
				strType="";
			}
			else
			{
				strType=this.GetColEn(strType,"MemState");
			}
			Hashtable htpara=new Hashtable();
			htpara.Add("strCardID",strCardID);
			htpara.Add("strCompName",strCompName);
			htpara.Add("strType",strType);
			htpara.Add("strDeptName",strDeptName);
			htpara.Add("strLicenseTag",strLicenseTag);
			Exception err=null;
			DataTable dt=new DataTable();
			dt=ca.GetAssociator(htpara, out err);
			if(err!=null)
			{
				MessageBox.Show("查询错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			txtCount.Text=dt.Rows.Count.ToString();
			if(dt!=null)
			{
				this.DataTableConvert(dt,"cnvcState","MemState","cnvcCommCode","cnvcCommName");
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("会员卡号,单位名称,车牌号,加油名称,油号,指定加油站,会员状态,备注,发卡日期,操作员,操作日期","60,200,100,80,80,100,80,90,90",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
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
				this.DgBind();
			}
		}

		private void frmAssInfo_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(this.cmbType,"MemState","cnvcCommName","all");
			this.FillComboBox(this.cmbDept,"AllDept","cnvcCommName","all");
			this.cmbDept.SelectedIndex=0;
			this.FillComboBox(this.cmbCompName,"MebComp","cnvcCompanyName","all");
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnExcel_Click(object sender, System.EventArgs e)
		{
			DataTable dt=new DataTable();
			dt=(DataTable)this.dataGrid1.DataSource;
			string table="";
			if(dt!=null && dt.Rows.Count>0)
			{							
				for(int i=0;i<dt.Columns.Count;i++)
				{
					if(dataGrid1.TableStyles[0].GridColumnStyles[i].Width>0)
					{
						table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
					}		
				}
			}
			else
			{
				MessageBox.Show("没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}

		private void txtCompName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				this.DgBind();
			}
		}
	}
}
