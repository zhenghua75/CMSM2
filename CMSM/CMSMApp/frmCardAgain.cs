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
	/// Summary description for frmCardAgain.
	/// </summary>
	public class frmCardAgain : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.SimpleButton sbtnQuery;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.SimpleButton sbtnAgain;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private DevExpress.XtraEditors.SimpleButton sbtnUnlose;
		private System.Windows.Forms.TextBox txtLicenseTag;
		Exception err;

		public frmCardAgain()
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
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtLicenseTag = new System.Windows.Forms.TextBox();
			this.sbtnUnlose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnAgain = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 82);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(984, 372);
			this.dataGrid1.TabIndex = 4;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnClose.Location = new System.Drawing.Point(848, 40);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(56, 23);
			this.sbtnClose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnClose.TabIndex = 14;
			this.sbtnClose.Text = "�ر�";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnQuery
			// 
			this.sbtnQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnQuery.Location = new System.Drawing.Point(584, 40);
			this.sbtnQuery.Name = "sbtnQuery";
			this.sbtnQuery.Size = new System.Drawing.Size(56, 23);
			this.sbtnQuery.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnQuery.TabIndex = 4;
			this.sbtnQuery.Text = "��ѯ";
			this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(320, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "���ƺ�";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(128, 40);
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(144, 22);
			this.txtCardID.TabIndex = 1;
			this.txtCardID.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(64, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "��Ա����";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtLicenseTag);
			this.groupBox1.Controls.Add(this.sbtnUnlose);
			this.groupBox1.Controls.Add(this.sbtnAgain);
			this.groupBox1.Controls.Add(this.sbtnClose);
			this.groupBox1.Controls.Add(this.sbtnQuery);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtCardID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(984, 82);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// txtLicenseTag
			// 
			this.txtLicenseTag.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtLicenseTag.Location = new System.Drawing.Point(376, 40);
			this.txtLicenseTag.Name = "txtLicenseTag";
			this.txtLicenseTag.Size = new System.Drawing.Size(144, 22);
			this.txtLicenseTag.TabIndex = 18;
			this.txtLicenseTag.Text = "";
			// 
			// sbtnUnlose
			// 
			this.sbtnUnlose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnUnlose.Location = new System.Drawing.Point(672, 40);
			this.sbtnUnlose.Name = "sbtnUnlose";
			this.sbtnUnlose.Size = new System.Drawing.Size(56, 23);
			this.sbtnUnlose.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnUnlose.TabIndex = 17;
			this.sbtnUnlose.Text = "���";
			this.sbtnUnlose.Click += new System.EventHandler(this.sbtnUnlose_Click);
			// 
			// sbtnAgain
			// 
			this.sbtnAgain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnAgain.Location = new System.Drawing.Point(760, 40);
			this.sbtnAgain.Name = "sbtnAgain";
			this.sbtnAgain.Size = new System.Drawing.Size(56, 23);
			this.sbtnAgain.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnAgain.TabIndex = 16;
			this.sbtnAgain.Text = "����";
			this.sbtnAgain.Click += new System.EventHandler(this.sbtnAgain_Click);
			// 
			// frmCardAgain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(984, 454);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmCardAgain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "��Ա����";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void DgBind()
		{
			string strCardID=txtCardID.Text.Trim();
			string strLicenseTag=txtLicenseTag.Text.Trim();
			string strDeptNameTmp= CMSMData.CMSMDataAccess.SysInitial.LocalDeptNameTmp;
			Exception err=null;
			DataTable dt=new DataTable();

			dt=cs.GetMemberLost(strCardID,strLicenseTag,strDeptNameTmp,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"cnvcState","MemState","cnvcCommCode","cnvcCommName");
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("��Ա����,��λ����,���ƺ�,����,�ͺ�,ָ������վ,��Ա״̬,��ע,��������,����Ա,��������","100,200,100,80,80,120,80",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("��ѯ�ѹ�ʧ��Ա���ϳ��������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnAgain_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("û��ѡ���ѹ�ʧ�Ļ�Ա��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			err=null;
			string strCardID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
			CMSMData.CMSMStruct.MemberStruct mebres=new CMSMData.CMSMStruct.MemberStruct();
			mebres=cs.GetMemberLoseDetail(strCardID,out err);
			if(mebres==null||err!=null)
			{
				MessageBox.Show("��ȡ��Ա���ϴ��������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

			frmInputBox frmInput=new frmInputBox();
			frmInput.Text="���������¿���";
			frmInput.label1.Text="�������»�Ա���Ŀ��ţ�";
			frmInput.label2.Text="Again";
			frmInput.ShowDialog();
			if(SysInitial.strTmp=="CanCel")
			{
				return;
			}
			while(SysInitial.strTmp=="")
			{
				MessageBox.Show("����Ļ�Ա���Ų���ȷ�����������룡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				frmInput=new frmInputBox();
				frmInput.ShowDialog();
				if(SysInitial.strTmp=="CanCel")
				{
					return;
				}
			}

			string strNewCardID=SysInitial.strTmp;
			SysInitial.strTmp="";

			err=null;
			string strresult=cs.CardAgain(strNewCardID,mebres,out err);
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(strresult=="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null&&strresult!="")
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
				this.DgBind();
			}
			else
			{
				MessageBox.Show("�������ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.DgBind();
			}
		}

		private void sbtnUnlose_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("û��ѡ���ѹ�ʧ�Ļ�Ա��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ�ȷ����Ҹû�Ա����","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				string strCardID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();

				err=null;
				cs.CardUnlose(strCardID,out err);
				if(err!=null)
				{
					MessageBox.Show("��Ա�����ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					this.DgBind();
				}
				else
				{
					MessageBox.Show("��Ա����ҳɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					this.DgBind();
				}
			}
		}
	}
}
