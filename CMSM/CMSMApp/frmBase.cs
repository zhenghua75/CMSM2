using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Data.OleDb;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmBase 的摘要说明。
	/// </summary>
	public class frmBase : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CMSM.log.CMSMLog clog;

		public frmBase()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			dgStyle();
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
			// 
			// frmBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "frmBase";
			this.Text = "frmBase";
			this.Load += new System.EventHandler(this.frmBase_Load);
			this.Closing+=new CancelEventHandler(frmBase_Closing);
		}
		#endregion

		#region Set dataGrid's style
		protected void dgStyle()
		{
			foreach(System.Windows.Forms.Control ctl in this.Controls)
			{
				if(ctl is System.Windows.Forms.DataGrid)
				{

					DataGrid dg=ctl as DataGrid;

					dg.ReadOnly=true;//设置只读属性
					dg.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;

					dg.AlternatingBackColor=System.Drawing.Color.WhiteSmoke;
					dg.BackgroundColor = System.Drawing.Color.Gainsboro;
					dg.CaptionBackColor = Color.FromArgb(((System.Byte)(195)), ((System.Byte)(231)), ((System.Byte)(253)));//Color.LightSkyBlue;
					dg.CaptionForeColor=Color.DodgerBlue;
					dg.CaptionForeColor = System.Drawing.Color.Black;
					dg.GridLineColor = System.Drawing.Color.LightSkyBlue;
					dg.HeaderBackColor = Color.Gainsboro;
					dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
					dg.ParentRowsBackColor = System.Drawing.Color.WhiteSmoke;
					dg.SelectionBackColor = System.Drawing.SystemColors.Info;
					dg.SelectionForeColor=Color.Blue;
					dg.PreferredColumnWidth=100;
				}
			}
		}
		#endregion

		private void frmBase_Load(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Control con in this.Controls)
			{
				Font ftnew=new Font("宋体",10);
				con.Font=ftnew;
				if(con is System.Windows.Forms.GroupBox)
				{
					con.ForeColor=Color.RoyalBlue;
					Font ftnew1=new Font("宋体",11);
					con.Font=ftnew1;
					foreach(System.Windows.Forms.Control con1 in con.Controls)
					{
						if(con1 is Label || con1 is TextBox || con1 is ComboBox || con1 is DateTimePicker || con1 is ListBox || con1 is RadioButton)
						{
							con1.Font=ftnew;
							con1.ForeColor=Color.Black;
							con1.Font=ftnew;
						}
						if(con1 is Button)
						{
							Button bt=con1 as Button;
							bt.ForeColor=Color.Black;
							bt.BackColor=Color.SeaShell;
							bt.Font=ftnew;
							bt.FlatStyle=System.Windows.Forms.FlatStyle.Popup;
						}
						if(con1 is DevExpress.XtraEditors.SimpleButton)
						{
							DevExpress.XtraEditors.SimpleButton bts=con1 as DevExpress.XtraEditors.SimpleButton;
							bts.ForeColor=Color.Black;
							bts.ButtonStyle=DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
						}
					}
				}
				if(con is Label || con is TextBox || con is ComboBox || con is DateTimePicker)
				{
					con.Font=ftnew;
				}
				if(con is Button)
				{
					Button bt=con as Button;
					bt.ForeColor=Color.Black;
					bt.BackColor=Color.SeaShell;
					bt.Font=ftnew;
					bt.FlatStyle=System.Windows.Forms.FlatStyle.Popup;
				}
				if(con is DevExpress.XtraEditors.SimpleButton)
				{
					DevExpress.XtraEditors.SimpleButton bts=con as DevExpress.XtraEditors.SimpleButton;
					bts.ForeColor=Color.Black;
					bts.ButtonStyle=DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
				}
			}
		}

		#region English to Chinese
		protected void EnToCh(string strChinese,string strWidth,DataTable dt,System.Windows.Forms.DataGrid dg)
		{
			if(dt!=null)
			{
				int col_count=0;
				string[] str=strChinese.Split(',');
				string[] wid=strWidth.Split(',');
				System.Windows.Forms.DataGridTableStyle t_style=new System.Windows.Forms.DataGridTableStyle();
				t_style.MappingName=dt.TableName;
				System.Windows.Forms.DataGridColumnStyle[] c_style=new System.Windows.Forms.DataGridColumnStyle[str.Length];
				dg.TableStyles.Clear();
				col_count=(str.Length<dt.Columns.Count)?str.Length:dt.Columns.Count;
				for(int i=0;i<col_count;i++)
				{
					c_style[i]=new System.Windows.Forms.DataGridTextBoxColumn();
					c_style[i].MappingName=dt.Columns[i].ColumnName;
					c_style[i].HeaderText=(str[i]!="")?str[i]:dt.Columns[i].ColumnName;
					if(i<wid.Length && wid[i] != "")
						c_style[i].Width=Convert.ToInt32(wid[i]);
					t_style.GridColumnStyles.Add(c_style[i]);
				}
				t_style.AlternatingBackColor=System.Drawing.Color.WhiteSmoke;
				t_style.BackColor=System.Drawing.Color.White;
				t_style.GridLineColor=System.Drawing.Color.LightSkyBlue;
				t_style.HeaderBackColor=Color.Gainsboro;
				t_style.HeaderForeColor=System.Drawing.SystemColors.ControlText;
				t_style.SelectionBackColor=System.Drawing.SystemColors.Info;
				t_style.SelectionForeColor=Color.Blue;

				dg.Capture=true;

				dg.TableStyles.Add(t_style);
				dg.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
				dg.ReadOnly=true;
			}
		}
		#endregion

		#region Fill ComboBox
		protected void FillComboBox(ComboBox cb,string tabName,string colName)
		{
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
				cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}

		protected void FillGoodsComboBox(ComboBox cb,string tabName,string colName)
		{
			string strlastfill="";
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(strlastfill!=SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString())
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
					strlastfill=SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString();
				}
			}
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}

		protected void FillComboBox(ComboBox cb,string tabName,string colName,string flag)
		{
			if(flag=="all")
			{
				cb.Items.Add("全部");
				for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
			if(flag=="allExcRetail")
			{
				cb.Items.Add("全部");
				for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
				{
					if(SysInitial.dsSys.Tables[tabName].Rows[i]["vcCommCode"].ToString()!="AT999")
					{
						cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
					}
				}
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}

		protected void FillComboBox(ComboBox cb,DataTable dttab,string colName,string flag)
		{
			if(flag=="all")
			{
				cb.Items.Add("全部");
				for(int i=0;i<dttab.Rows.Count;i++)
					cb.Items.Add(dttab.Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
			else
			{
				for(int i=0;i<dttab.Rows.Count;i++)
					cb.Items.Add(dttab.Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}

		protected void FillOperComboBox(ComboBox cb,string tabName,string colName)
		{
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(SysInitial.dsSys.Tables[tabName].Rows[i]["vcDeptID"].ToString()==SysInitial.LocalDeptID)
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				}
			}
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}

		protected void FillComboBox(ComboBox cb,string tabName,string colName,string strFilterColName,string strFilterValue)
		{
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(SysInitial.dsSys.Tables[tabName].Rows[i][strFilterColName].ToString()==strFilterValue)
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				}
			}
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}
		#endregion

		#region Fill ComboBox by en spell
		protected void FillComboBoxBySpell(ComboBox cb,string tabName,string colName,string colCode,string strSpell)
		{
			int len=strSpell.Length;
			cb.Items.Clear();
			cb.Refresh();
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(SysInitial.dsSys.Tables[tabName].Rows[i][colCode].ToString().Length>=len&&SysInitial.dsSys.Tables[tabName].Rows[i][colCode].ToString().Substring(0,len)==strSpell)
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				}
			}
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDown;
			if(cb.Items.Count>0)
			{
				cb.SelectedIndex=0;
			}
			else
			{
				cb.DroppedDown=true;
			}
		}
		#endregion

		#region encode Column convert to Chinise
		protected string GetColCh(string strCode,string tabName)
		{
			string colch="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "vcCommCode";
			colch = dv[dv.Find(strCode)]["vcCommName"].ToString().Trim();
			return colch;
		}
		#endregion

		#region Chinise convert to encode
		protected string GetColEn(string strName,string tabName)
		{
			string colen="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "cnvcCommName";
			colen = dv[dv.Find(strName)]["cnvcCommCode"].ToString().Trim();
			return colen;
		}
		#endregion

		#region Find compDept
		protected CMSMStruct.CompDeptStruct GetComDeptByCompName(string strCompName)
		{
			DataView dv = new DataView(SysInitial.dsSys.Tables["MebComp"]);
			dv.Sort = "cnvcCompanyName";
			CMSMStruct.CompDeptStruct comd1=new CMSMStruct.CompDeptStruct();
			comd1.strCompanyID = dv[dv.Find(strCompName)]["cnvcCompanyID"].ToString().Trim();
			comd1.strCompanyName = dv[dv.Find(strCompName)]["cnvcCompanyName"].ToString().Trim();
			comd1.strDeptID = dv[dv.Find(strCompName)]["cnvcDeptID"].ToString().Trim();
			comd1.strDeptName = dv[dv.Find(strCompName)]["cnvcDeptName"].ToString().Trim();
			return comd1;
		}
		#endregion

		#region Code of DataTable convert to chinese
		//have condition
		public void DataTableConvert(DataTable dt,string columnName,string showTable,string tabColumnCode,string tabColumnName,string strFilter)
		{
			/// <summary>
			/// dt：被转换的表名，columnName:被转换的表的字段名,showTable:要转换的表名，tabColumnCode:要转换的表字段代码列名,
			/// tabColumnName:要转换的表字段内容列名,strFilter:要转换的表的过滤条件
			/// </summary>
			string strTemp ;			
			string strCommentColumnName = columnName;
	
			foreach (DataRow dr in dt.Rows)
			{				
				strTemp = this.CodeConvert(showTable,dr[columnName].ToString(),tabColumnCode,tabColumnName,strFilter);	
				dr[strCommentColumnName] = strTemp;
			}			
		}

		//have condition
		public string CodeConvert(string tabName,string columnValue,string tabColumnCode,string tabColumnName,string strFilter)
		{
			/// <summary>
			/// tabName：要转换的表名，columnValue:被转换的表的字段值,tabColumnCode:要转换的表字段代码列名,tabColumnName:要转换的表字段内容列名
			/// </summary>
			
			//			DataTable dt=(DataTable)dat_dsSys.dsSys.Tables[tabName];
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.RowFilter = strFilter;//过滤条件		
			string strRemark = columnValue;

			for(int i = 0;i<dv.Count;i++)
			{
				if(dv[i][""+tabColumnCode+""].ToString().ToUpper().Equals(columnValue.ToUpper()))
				{
					strRemark = dv[i][""+tabColumnName+""].ToString();
					break;
				}
			}
			return strRemark;	
		}

		//no condition
		public void DataTableConvert(DataTable dt,string columnName,string showTable,string tabColumnCode,string tabColumnName)
		{
			/// <summary>
			/// dt：被转换的表名，columnName:被转换的表的字段名,showTable:要转换的表名，tabColumnCode:要转换的表字段代码列名,
			/// tabColumnName:要转换的表字段内容列名,strFilter:要转换的表的过滤条件
			/// </summary>
			string strTemp ;			
			string strCommentColumnName = columnName;
	
			foreach (DataRow dr in dt.Rows)
			{				
				strTemp = this.CodeConvert(showTable,dr[columnName].ToString(),tabColumnCode,tabColumnName);	
				dr[strCommentColumnName] = strTemp;
			}			
		}

		//no condition
		public string CodeConvert(string tabName,string columnValue,string tabColumnCode,string tabColumnName)
		{
			/// <summary>
			/// tabName：要转换的表名，columnValue:被转换的表的字段值,tabColumnCode:要转换的表字段代码列名,tabColumnName:要转换的表字段内容列名
			/// </summary>
			
			//			DataTable dt=(DataTable)dat_dsSys.dsSys.Tables[tabName];
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
					
			string strRemark = columnValue;
		
			for(int i = 0;i<dv.Count;i++)
			{
				if(dv[i][""+tabColumnCode+""].ToString().Equals(columnValue))
				{
					strRemark = dv[i][""+tabColumnName+""].ToString();
					break;
				}
			}
			return strRemark;	
		}
		#endregion

		#region Clear textbox
		protected void ClearText()
		{
			foreach(System.Windows.Forms.Control ctl in this.Controls)
			{
				if(ctl is System.Windows.Forms.TextBox || ctl is System.Windows.Forms.ComboBox)
				{
					ctl.Text="";
				}
				if(ctl is System.Windows.Forms.GroupBox)
				{
					foreach(System.Windows.Forms.Control con1 in ctl.Controls)
					{
						if(con1 is TextBox || con1 is ComboBox)
						{
							con1.Text="";
						}
					}
				}
			}
		}
		#endregion

		#region 导出到Excel
		//去掉DagaGrid的HeadText不符合做为列名称规范的字符
		protected string replace(string str)
		{
			str=str.Replace("(","");
			str=str.Replace(")","");
			str=str.Replace("-","");
			return str;
		}

		private string repText(string str)
		{
			str=str.Replace("'","");
			return str;
		}

		protected void ExportToExcel(string table)
		{
			this.Cursor=Cursors.WaitCursor;
			OleDbConnection con=new OleDbConnection();
			bool sucess=false;
			string file="";
			try
			{
				string strApp = Assembly.GetExecutingAssembly().Location.ToString();
				string strDir = strApp.Substring(0,strApp.LastIndexOf(@"\"));
				file=strDir + "\\XX报表.xls";
				if(System.IO.File.Exists(file))
					System.IO.File.Delete(file);
				con.ConnectionString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file  + ";Extended Properties=Excel 8.0;";
				con.Open();
				OleDbCommand com=new OleDbCommand();
				com.Connection=con;
				int count=0;
				string name="";
				foreach(System.Windows.Forms.Control ctl in this.Controls)
				{
					if(ctl is System.Windows.Forms.DataGrid)
					{
						count++;
						DataGrid dg=ctl as DataGrid;
						if(name==dg.CaptionText)//给表取名称，没有错误对应captionText
							name="Table" + count.ToString();
						else
							name=dg.CaptionText==""?"Table" + count.ToString():dg.CaptionText;
						DataTable dt=new DataTable();
						dt=(DataTable)dg.DataSource;
						if(dt!=null && dt.Rows.Count>0)
						{							
							if(table.Length>0)
								table=table.Substring(0,table.Length-1);
							table="create table " + name + " (" + table + ")";
							com.CommandText=table;
							com.ExecuteNonQuery();//创建表结构
							for(int i=0;i<dt.Rows.Count;i++)
							{
								string row="";
								for(int j=0;j<dt.Columns.Count;j++)
								{
									if(dg.TableStyles[0].GridColumnStyles[j].Width>0)
										row+="'" + this.repText(dt.Rows[i][j].ToString()) + "',";
								}
								row=row.Substring(0,row.Length-1);
								row="insert into " + name + " values(" + row + ")";
								com.CommandText=row;
								com.ExecuteNonQuery();//插入数据
							}
							sucess=true;
						}
						else
						{
							MessageBox.Show("表格【" + name + "】没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
						}
					}
				}                
			}
			catch(Exception err)
			{
				MessageBox.Show("导出出错，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error );
				clog.WriteLine(err);
			}
			finally
			{
				con.Close();
				if(sucess)
				{
					ProcessStartInfo helpFile=new ProcessStartInfo(file);
					Process.Start(helpFile);
				}
			}
			this.Cursor=Cursors.Default;
		}

		protected void BusiIncomeExportToExcel(string tabname,string tabdate,DataTable dtIncome)
		{
			try
			{
				Excel.Application xapp=new Excel.ApplicationClass();
				Excel.Workbook xbook=xapp.Workbooks.Open(Application.StartupPath+@"\BusiIncomeModel.xls",Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				Excel.Worksheet xSheet = (Excel.Worksheet)xbook.Sheets["业务量"];//得到Sheet

				xSheet.get_Range("A1", Missing.Value).Value2 = tabname;
				xSheet.get_Range("A2", Missing.Value).Value2 = tabdate;
				for(int i=1;i<dtIncome.Rows.Count-2;i++)
				{
					for(int j=1;j<8;j++)
					{
						xSheet.Cells[i+3,j+1] = dtIncome.Rows[i][j].ToString();
					}
				}

				for(int i=1;i<8;i++)
				{
					xSheet.Cells[14,i+1] = dtIncome.Rows[11][i].ToString();
				}

				SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
				SaveFileDialog1.Filter = "Excel文件（*.xls）|*.xls";
				SaveFileDialog1.FileName="面包工坊业务量报表" + DateTime.Now.ToShortDateString() + ".xls";
				if(SaveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					xbook.SaveCopyAs(SaveFileDialog1.FileName);//另存
					xbook.Close(false, Application.StartupPath+@"\BusiIncomeModel.xls", Missing.Value);//关闭
					xSheet = null;
					xbook = null;
					xapp.Quit();
					xapp = null;
				}
				else
				{
					xbook.Close(false, Missing.Value, Missing.Value);//关闭
					xSheet = null;
					xbook = null;
					xapp.Quit();
					xapp = null;
				}
			}
			catch(Exception err)
			{
				MessageBox.Show("导出时出错，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error );
				clog.WriteLine(err);
			}
			finally
			{

			}
		}
		#endregion

		private void frmBase_Closing(object sender, CancelEventArgs e)
		{
			if(this.ParentForm!=null)
			{
				foreach(System.Windows.Forms.Control con in this.ParentForm.Controls)
				{
					if(con is System.Windows.Forms.StatusBar)
					{
						StatusBar st=con as StatusBar;
						st.Panels[3].Text="当前位置：主界面";
						return;
					}
				}
			}
		}
	}
}
