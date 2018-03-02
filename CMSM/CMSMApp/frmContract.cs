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
	/// frmContract ��ժҪ˵����
	/// </summary>
	public class frmContract: CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ListView listView1;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnMod;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmContract()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnMod = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(32, 80);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(512, 280);
			this.listView1.TabIndex = 0;
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAdd.Location = new System.Drawing.Point(552, 128);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.Size = new System.Drawing.Size(72, 23);
			this.sbtnAdd.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAdd.TabIndex = 20;
			this.sbtnAdd.Text = "���";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// sbtnMod
			// 
			this.sbtnMod.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnMod.Location = new System.Drawing.Point(552, 184);
			this.sbtnMod.Name = "sbtnMod";
			this.sbtnMod.Size = new System.Drawing.Size(72, 23);
			this.sbtnMod.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnMod.TabIndex = 21;
			this.sbtnMod.Text = "�޸�";
			this.sbtnMod.Click += new System.EventHandler(this.sbtnMod_Click);
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(552, 240);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(72, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 22;
			this.sbtnClose.Text = "�ر�";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(40, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 24);
			this.label1.TabIndex = 23;
			this.label1.Text = "���������������жϲ��ܽ��в�����";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("����", 15.75F);
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(40, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(544, 23);
			this.label2.TabIndex = 24;
			this.label2.Text = "��ͬ���Ϊ��ǡ���λ������������25������";
			// 
			// frmContract
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 374);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnMod);
			this.Controls.Add(this.sbtnAdd);
			this.Controls.Add(this.listView1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmContract";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ר���ͺ�ͬ";
			this.Load += new System.EventHandler(this.frmContract_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmContract_Load(object sender, System.EventArgs e)
		{
			//
			BindList();
			

		}

		private void BindList()
		{
			DataTable dt = Helper.Query("select * from tbSpecialOilDept where cnvcdeliverycompany like '"+CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp+"%'",true);

			listView1.Items.Clear();
			listView1.Columns.Clear();
			listView1.GridLines = true;//��ʾ������֮��ķָ���   
			listView1.FullRowSelect = true;//Ҫѡ�����һ��   
			listView1.View = View.Details;//�����б���ʾ�ķ�ʽ  
			listView1.Scrollable = true;//��Ҫʱ����ʾ������  
			listView1.MultiSelect = false; // �����Զ���ѡ��   
			listView1.HeaderStyle = ColumnHeaderStyle.Clickable;  
  
			listView1.Columns.Add("��ͬ���", 200, HorizontalAlignment.Left);
			listView1.Columns.Add("��λ����",270,HorizontalAlignment.Left);
			
			listView1.BeginUpdate();
			foreach(DataRow dr in dt.Rows)
			{
				Entity.SpecialOilDept so = new SpecialOilDept(dr);
				ListViewItem lvi = new ListViewItem(new string[]{so.cnvcContractNo,so.cnvcDeliveryCompany});				
				listView1.Items.Add(lvi);
			}
			listView1.EndUpdate();
		}
		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			//���ר���ͺ�ͬ
			frmContractAdd frm = new frmContractAdd();
			frm.Flag = OperFlag.ADD;
			frm.ShowDialog(this);
			BindList();
		}

		private void sbtnMod_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count<1)
			{
				MessageBox.Show(this,"��ѡ��ר���ͺ�ͬ","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			Entity.SpecialOilDept so = new SpecialOilDept();
			so.cnvcContractNo = listView1.SelectedItems[0].SubItems[0].Text;
			so.cnvcDeliveryCompany = listView1.SelectedItems[0].SubItems[1].Text;
			so.SetOriginalValue();
			frmContractAdd frm = new frmContractAdd();
			frm.Flag = OperFlag.MOD;
			frm.SO = so;
			frm.ShowDialog(this);
			BindList();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
