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
	/// Summary description for frmOilStorageCheck.
	/// </summary>
	public class frmOilStorageCheck : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ComboBox cmbGoodsType;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLoseCount;
		private System.Windows.Forms.TextBox txtStorageCount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbltitle;
		private System.Windows.Forms.TextBox txtCount;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		CommAccess cs=new CommAccess(SysInitial.ConString);
		Exception err;

		public frmOilStorageCheck()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.cmbGoodsType = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.cmbGoodsName = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtStorageCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLoseCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbltitle = new System.Windows.Forms.Label();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// cmbGoodsType
			// 
			this.cmbGoodsType.Location = new System.Drawing.Point(360, 80);
			this.cmbGoodsType.Name = "cmbGoodsType";
			this.cmbGoodsType.Size = new System.Drawing.Size(144, 20);
			this.cmbGoodsType.TabIndex = 1;
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(296, 88);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 42;
			this.label18.Text = "物料型号";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbGoodsName
			// 
			this.cmbGoodsName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbGoodsName.Location = new System.Drawing.Point(104, 80);
			this.cmbGoodsName.Name = "cmbGoodsName";
			this.cmbGoodsName.Size = new System.Drawing.Size(144, 21);
			this.cmbGoodsName.TabIndex = 0;
			this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
			// 
			// label17
			// 
			this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label17.Location = new System.Drawing.Point(40, 88);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 40;
			this.label17.Text = "物料名称";
			// 
			// txtStorageCount
			// 
			this.txtStorageCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtStorageCount.Location = new System.Drawing.Point(104, 120);
			this.txtStorageCount.MaxLength = 20;
			this.txtStorageCount.Name = "txtStorageCount";
			this.txtStorageCount.Size = new System.Drawing.Size(144, 22);
			this.txtStorageCount.TabIndex = 2;
			this.txtStorageCount.Text = "";
			this.txtStorageCount.GotFocus += new System.EventHandler(this.txtStorageCount_GotFocus);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 45;
			this.label1.Text = "当前库存数量";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "请注意：此功能所述库存以“公斤”为单位";
			// 
			// txtLoseCount
			// 
			this.txtLoseCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLoseCount.Location = new System.Drawing.Point(360, 120);
			this.txtLoseCount.MaxLength = 20;
			this.txtLoseCount.Name = "txtLoseCount";
			this.txtLoseCount.Size = new System.Drawing.Size(144, 22);
			this.txtLoseCount.TabIndex = 3;
			this.txtLoseCount.Text = "";
			this.txtLoseCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoseCount_KeyPress);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 49;
			this.label2.Text = "损耗";
			// 
			// txtCount
			// 
			this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCount.Location = new System.Drawing.Point(200, 160);
			this.txtCount.MaxLength = 20;
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(144, 22);
			this.txtCount.TabIndex = 4;
			this.txtCount.Text = "";
			this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(120, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 51;
			this.label4.Text = "库存实际数";
			// 
			// lbltitle
			// 
			this.lbltitle.Location = new System.Drawing.Point(32, 40);
			this.lbltitle.Name = "lbltitle";
			this.lbltitle.Size = new System.Drawing.Size(464, 24);
			this.lbltitle.TabIndex = 53;
			this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(368, 208);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 6;
			this.sbtnClose.Text = "关闭";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(104, 208);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(72, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 5;
			this.sbtnOk.Text = "确定";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// frmOilStorageCheck
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(536, 246);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.lbltitle);
			this.Controls.Add(this.txtCount);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtLoseCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtStorageCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbGoodsType);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.cmbGoodsName);
			this.Controls.Add(this.label17);
			this.Name = "frmOilStorageCheck";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "库存盘点";
			this.Load += new System.EventHandler(this.frmOilStorageCheck_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			if(strGoodsName==""||strGoodsType=="")
			{
				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(txtStorageCount.Text.Trim()=="请点击此处...")
			{
				MessageBox.Show("请先获取当前库存！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			
			err=null;
			CMSMStruct.OilStorageStruct oils=cs.GetOilStorageDetail(strGoodsName,strGoodsType,out err);
			if(err!=null)
			{
				MessageBox.Show("获取当前库存出错，请检查当前库存信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}
			else if(oils==null&&this.txtStorageCount.Text.Trim()=="初始库存")
			{
				oils=new CMSMData.CMSMStruct.OilStorageStruct();
				oils.strGoodsType=strGoodsType;
				oils.strGoodsName=strGoodsName;
				oils.dStorageCount=0;
				oils.strDeptName=SysInitial.LocalDeptName;
				oils.strDeptID=SysInitial.LocalDeptID;
			}
			else
			{
				if(oils.dStorageCount!=double.Parse(txtStorageCount.Text.Trim()))
				{
					MessageBox.Show("当前库存和之前获取的有差异，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					this.Close();
					return;
				}
			}

			if(txtCount.Text.Trim()==""||txtLoseCount.Text.Trim()=="")
			{
				MessageBox.Show("实际库存和损耗不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			CMSMData.CMSMStruct.OilStorageCheckStruct oilcheck=new CMSMData.CMSMStruct.OilStorageCheckStruct();
			oilcheck.strGoodsName=strGoodsName;
			oilcheck.strGoodsType=strGoodsType;
			oilcheck.dStorageCount=oils.dStorageCount;
			oilcheck.dLoseCount=double.Parse(txtLoseCount.Text.Trim());
			oilcheck.dCount=double.Parse(txtCount.Text.Trim());
			oilcheck.strDeptName=oils.strDeptName;
			oilcheck.strOperName=SysInitial.CurOps.strOperName;
			oilcheck.strOperDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
			oilcheck.strDeptID=SysInitial.LocalDeptID;

			if(oilcheck.dCount<=0)
			{
				MessageBox.Show("实际库存应大于0，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(this.txtStorageCount.Text.Trim()!="初始库存"&&(Math.Round(oilcheck.dStorageCount-oilcheck.dLoseCount))!=Math.Round(oilcheck.dCount))
			{
				MessageBox.Show("库存数量减去损耗与实际库存不相符，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			CMSMData.CMSMStruct.OilStorageLogStruct oilslog=new CMSMData.CMSMStruct.OilStorageLogStruct();
			oilslog.strDeptName=SysInitial.LocalDeptName;
			oilslog.strGoodsName=oilcheck.strGoodsName;
			oilslog.strGoodsType=oilcheck.strGoodsType;
			if(this.txtStorageCount.Text.Trim()=="初始库存")
			{
				oilslog.strInOutCount=oilcheck.dCount.ToString();
			}
			else
			{
				oilslog.strInOutCount=(-oilcheck.dLoseCount).ToString();
			}
			oilslog.strLastCount=oils.dStorageCount.ToString();
			oilslog.strCurCount=oilcheck.dCount.ToString();
			oilslog.strOperType="库存盘点";
			oilslog.strOperName=oilcheck.strOperName;
			oilslog.strOperDate=oilcheck.strOperDate;
			oilslog.strDeptID=SysInitial.LocalDeptID;

			err=null;
			if(cs.InsertOilStorageCheck(oilcheck,oilslog,out err))
			{
				MessageBox.Show("库存盘点成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.txtStorageCount.Text="请点击此处...";
				this.txtLoseCount.Text="";
				this.txtCount.Text="";
				this.txtLoseCount.ReadOnly=false;
				return;
			}
			else
			{
				MessageBox.Show("库存盘点失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.txtStorageCount.Text="请点击此处...";
				this.txtLoseCount.Text="";
				this.txtCount.Text="";
				this.txtLoseCount.ReadOnly=false;
				clog.WriteLine(err);
				return;
			}
		}

		private void frmOilStorageCheck_Load(object sender, System.EventArgs e)
		{
			this.FillGoodsComboBox(cmbGoodsName,"Goods","cnvcGoodsName");
			txtStorageCount.ReadOnly=true;
			this.lbltitle.Text=SysInitial.LocalDeptName + "  库存盘点";
			this.label3.ForeColor=Color.Red;
			this.lbltitle.ForeColor=Color.RoyalBlue;
			this.lbltitle.Font=new Font("宋体",14);
			txtStorageCount.Text="请点击此处...";
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cmbGoodsType.Items.Clear();
			this.FillComboBox(cmbGoodsType,"Goods","cnvcGoodsType","cnvcGoodsName",cmbGoodsName.Text.Trim());
			txtStorageCount.Text="请点击此处...";
		}

		private void txtStorageCount_GotFocus(object sender, EventArgs e)
		{
			string strGoodsName=cmbGoodsName.Text.Trim();
			string strGoodsType=cmbGoodsType.Text.Trim();
			if(strGoodsName==""||strGoodsType=="")
			{
				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			
			err=null;
			CMSMStruct.OilStorageStruct oils=cs.GetOilStorageDetail(strGoodsName,strGoodsType,out err);
			if(err!=null)
			{
				MessageBox.Show("获取当前库存出错，请检查当前库存信息，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			if(oils==null)
			{
				this.txtStorageCount.Text="初始库存";
				this.txtLoseCount.Text="0";
				this.txtLoseCount.ReadOnly=true;
			}
			else
			{
				this.txtStorageCount.Text=oils.dStorageCount.ToString();
			}
		}

		private void txtLoseCount_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
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
