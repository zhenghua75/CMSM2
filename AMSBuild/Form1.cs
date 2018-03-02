using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;

namespace AMSBuild
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
　　	private SqlCommand cmd1 = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public Form1()
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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(16, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(416, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "创建华能加油卡管理系统初始数据库";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "数据库安装路径";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(112, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 20);
			this.comboBox1.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(448, 85);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "创建数据库";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			SqlConnection con=new SqlConnection(ConfigurationSettings.AppSettings["DBString"] + ";database=master");
			string sql="SELECT count(*) as aa FROM master.dbo.sysdatabases WHERE name = N'OilCardManage'";
			con.Open();
			SqlCommand cmd=new SqlCommand(sql,con);
			SqlDataReader dr=cmd.ExecuteReader();
			dr.Read();
			string strdataexist=dr["aa"].ToString();
			dr.Close();
			
			if(strdataexist!="0")
			{
				MessageBox.Show("本机上已经有华能加油卡管理系统的数据库，不能创建！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{

				//创建数据库，还原形式
				string drivername=this.comboBox1.Text.Trim();
				string strbakpath=Application.StartupPath + @"\OilCardManage.bak";
				string strtomdf=drivername + @"database\OilCardManage\OilCardManage.mdf";
				string strtoldf=drivername + @"database\OilCardManage\OilCardManage_log.ldf";

				if(!File.Exists(strbakpath))
				{
					MessageBox.Show("缺少创建数据库的文件，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}

				if(!Directory.Exists(drivername + @"database\OilCardManage\"))
				{
					Directory.CreateDirectory(drivername + @"database\OilCardManage\");
				}

				string sql1="exec('RESTORE DATABASE OilCardManage FROM DISK = ''" + strbakpath + "'' WITH MOVE ''OilCardManage_Data'' TO ''" + strtomdf + "'',MOVE ''OilCardManage_Log'' TO ''" + strtoldf + "''')";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
				con.Close();

				MessageBox.Show("数据库创建成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);

			}
		}

	
		private void Form1_Load(object sender, System.EventArgs e)
		{
			string[] driverlist=System.IO.Directory.GetLogicalDrives();
			for(int j=0;j<driverlist.Length;j++)
			{
				if(driverlist[j]!=@"A:\")
				{
					this.comboBox1.Items.Add(driverlist[j]);
				}
			}
			this.comboBox1.SelectedIndex=0;

			SqlConnection con=new SqlConnection(ConfigurationSettings.AppSettings["DBString"] + ";database=master");
			string sql="SELECT count(*) as aa FROM master.dbo.sysdatabases WHERE name = N'AMS_OFFICE'";
			con.Open();
			SqlCommand cmd=new SqlCommand(sql,con);
			SqlDataReader dr=cmd.ExecuteReader();
			dr.Read();
			string strdataexist=dr["aa"].ToString();
			dr.Close();
			con.Close();

			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}


		#region 导出到Excel
		protected void ExportToExcel(DataTable dtcheck)
		{
			this.Cursor=Cursors.WaitCursor;
			OleDbConnection con=new OleDbConnection();
			string file="";
			try
			{
				file=Application.StartupPath + @"\门店信息.xls";
				if(System.IO.File.Exists(file))
					System.IO.File.Delete(file);
				con.ConnectionString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file  + ";Extended Properties=Excel 8.0;";
				con.Open();
				OleDbCommand com=new OleDbCommand();
				com.Connection=con;
				string name="";
				if(dtcheck!=null && dtcheck.Rows.Count>0)
				{							
					string table="create table " + "门店信息(门店编码 varchar,门店名称 varchar)";
					com.CommandText=table;
					com.ExecuteNonQuery();//创建表结构
					for(int i=0;i<dtcheck.Rows.Count;i++)
					{
						string row="";
						for(int j=0;j<dtcheck.Columns.Count;j++)
						{
							row+="'" + dtcheck.Rows[i][j].ToString() + "',";
						}
						row=row.Substring(0,row.Length-1);
						row="insert into " + "门店信息" + " values(" + row + ")";
						com.CommandText=row;
						com.ExecuteNonQuery();//插入数据
					}
				}
				else
				{
					MessageBox.Show("表格【" + name + "】没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				}              
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error );
			}
			finally
			{
				con.Close();
				ProcessStartInfo helpFile=new ProcessStartInfo(file);
				Process.Start(helpFile);
			}
			this.Cursor=Cursors.Default;
		}
		#endregion
	}
}
