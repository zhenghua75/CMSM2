using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DevExpress.XtraReports.UI;

namespace CMSM.Report
{
	/// <summary>
	/// Summary description for xrConsTiny.
	/// </summary>
	public class xrConsTiny : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private CMSM.Report.dtConsItem dtConsItem1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel18;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.XRLabel xrLabel11;
		private DevExpress.XtraReports.UI.XRLabel xrLabel20;
		private DevExpress.XtraReports.UI.XRLabel xrLabel19;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel12;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		private DevExpress.XtraReports.UI.XRLabel xrLabel16;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public xrConsTiny(string strSerial,string strCon)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			/// 
			InitializeComponent();
			this.xrLabel4.Text=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
			this.sqlConnection2.ConnectionString = strCon;
			this.sqlSelectCommand1.CommandText = @"SELECT cnvcCardID,cnvcLicenseTags,cnvcCompanyName,cnvcGoodsName,cnvcGoodsType,cnvcUnit,cnnCount,cnnPrice,cnnFee FROM tbConsItem where cnnSerial='"+strSerial+"'";
			
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

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.dtConsItem1 = new CMSM.Report.dtConsItem();
			this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			((System.ComponentModel.ISupportInitialize)(this.dtConsItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel6,
																						this.xrLabel1,
																						this.xrLabel8,
																						this.xrLabel19,
																						this.xrLabel20,
																						this.xrLabel11,
																						this.xrLabel10,
																						this.xrLabel9,
																						this.xrLabel7,
																						this.xrLabel12,
																						this.xrLabel13,
																						this.xrLabel14,
																						this.xrLabel15});
			this.Detail.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Detail.Height = 91;
			this.Detail.Name = "Detail";
			this.Detail.ParentStyleUsing.UseFont = false;
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel6.Location = new System.Drawing.Point(126, 45);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(38, 16);
			this.xrLabel6.Text = "元/KG";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel1.Location = new System.Drawing.Point(0, 75);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(66, 16);
			this.xrLabel1.Text = "金额：";
			this.xrLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel8.Location = new System.Drawing.Point(0, 30);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(66, 16);
			this.xrLabel8.Text = "单位：";
			this.xrLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel19
			// 
			this.xrLabel19.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnvcGoodsName", ""));
			this.xrLabel19.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel19.Location = new System.Drawing.Point(66, 0);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.ParentStyleUsing.UseFont = false;
			this.xrLabel19.Size = new System.Drawing.Size(116, 16);
			// 
			// dtConsItem1
			// 
			this.dtConsItem1.DataSetName = "dtConsItem";
			this.dtConsItem1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// xrLabel20
			// 
			this.xrLabel20.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel20.Location = new System.Drawing.Point(0, 0);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.ParentStyleUsing.UseFont = false;
			this.xrLabel20.Size = new System.Drawing.Size(66, 16);
			this.xrLabel20.Text = "油料名称：";
			this.xrLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel11
			// 
			this.xrLabel11.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel11.Location = new System.Drawing.Point(0, 15);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.ParentStyleUsing.UseFont = false;
			this.xrLabel11.Size = new System.Drawing.Size(66, 16);
			this.xrLabel11.Text = "型号：";
			this.xrLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel10
			// 
			this.xrLabel10.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel10.Location = new System.Drawing.Point(0, 60);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(66, 16);
			this.xrLabel10.Text = "数量：";
			this.xrLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel9
			// 
			this.xrLabel9.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel9.Location = new System.Drawing.Point(0, 45);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(66, 16);
			this.xrLabel9.Text = "单价：";
			this.xrLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel7
			// 
			this.xrLabel7.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnvcGoodsType", ""));
			this.xrLabel7.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel7.Location = new System.Drawing.Point(66, 15);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(116, 16);
			// 
			// xrLabel12
			// 
			this.xrLabel12.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnvcUnit", ""));
			this.xrLabel12.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel12.Location = new System.Drawing.Point(66, 30);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.ParentStyleUsing.UseFont = false;
			this.xrLabel12.Size = new System.Drawing.Size(116, 16);
			// 
			// xrLabel13
			// 
			this.xrLabel13.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnnPrice", ""));
			this.xrLabel13.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel13.Location = new System.Drawing.Point(66, 45);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.ParentStyleUsing.UseFont = false;
			this.xrLabel13.Size = new System.Drawing.Size(60, 16);
			// 
			// xrLabel14
			// 
			this.xrLabel14.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnnCount", ""));
			this.xrLabel14.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel14.Location = new System.Drawing.Point(66, 60);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.ParentStyleUsing.UseFont = false;
			this.xrLabel14.Size = new System.Drawing.Size(116, 16);
			// 
			// xrLabel15
			// 
			this.xrLabel15.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnnFee", ""));
			this.xrLabel15.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel15.Location = new System.Drawing.Point(66, 75);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.ParentStyleUsing.UseFont = false;
			this.xrLabel15.Size = new System.Drawing.Size(116, 16);
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLine1,
																							this.xrLabel18,
																							this.xrLabel23,
																							this.xrLabel4,
																							this.xrLabel3,
																							this.xrLabel2,
																							this.xrLabel16,
																							this.xrLabel5});
			this.PageHeader.Height = 82;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(1, 78);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(181, 4);
			// 
			// xrLabel18
			// 
			this.xrLabel18.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel18.Location = new System.Drawing.Point(0, 49);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.ParentStyleUsing.UseFont = false;
			this.xrLabel18.Size = new System.Drawing.Size(66, 16);
			this.xrLabel18.Text = "车牌号：";
			this.xrLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel23
			// 
			this.xrLabel23.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel23.Location = new System.Drawing.Point(0, 66);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.ParentStyleUsing.UseFont = false;
			this.xrLabel23.Size = new System.Drawing.Size(66, 16);
			this.xrLabel23.Text = "单位名称：";
			this.xrLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel4.Location = new System.Drawing.Point(41, 33);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(117, 16);
			this.xrLabel4.Text = "2007-04-28";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel3.Location = new System.Drawing.Point(0, 33);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(41, 16);
			this.xrLabel3.Text = "日期：";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel2.Location = new System.Drawing.Point(0, 17);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(175, 16);
			this.xrLabel2.Text = "加油小票";
			this.xrLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel16
			// 
			this.xrLabel16.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnvcLicenseTags", ""));
			this.xrLabel16.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel16.Location = new System.Drawing.Point(65, 49);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.ParentStyleUsing.UseFont = false;
			this.xrLabel16.Size = new System.Drawing.Size(100, 16);
			// 
			// xrLabel5
			// 
			this.xrLabel5.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dtConsItem1, "tbConsItem.cnvcCompanyName", ""));
			this.xrLabel5.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel5.Location = new System.Drawing.Point(65, 66);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(112, 16);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tbConsItem", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("cnvcCardID", "cnvcCardID"),
																																																					new System.Data.Common.DataColumnMapping("cnvcLicenseTags", "cnvcLicenseTags"),
																																																					new System.Data.Common.DataColumnMapping("cnvcCompanyName", "cnvcCompanyName"),
																																																					new System.Data.Common.DataColumnMapping("cnvcGoodsName", "cnvcGoodsName"),
																																																					new System.Data.Common.DataColumnMapping("cnvcGoodsType", "cnvcGoodsType"),
																																																					new System.Data.Common.DataColumnMapping("cnvcUnit", "cnvcUnit"),
																																																					new System.Data.Common.DataColumnMapping("cnnCount", "cnnCount"),
																																																					new System.Data.Common.DataColumnMapping("cnnPrice", "cnnPrice"),
																																																					new System.Data.Common.DataColumnMapping("cnnFee", "cnnFee")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cnvcCardID, cnvcLicenseTags, cnvcCompanyName, cnvcGoodsName, cnvcGoodsType" +
				", cnvcUnit, cnnCount, cnnPrice, cnnFee FROM tbConsItem WHERE (cnnSerial = \'0\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection2;
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = "workstation id=KLONG;packet size=4096;user id=sa;data source=KLONG;persist securi" +
				"ty info=False;initial catalog=OilCardManage";
			// 
			// xrConsTiny
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader});
			this.DataAdapter = this.sqlDataAdapter1;
			this.DataSource = this.dtConsItem1;
			this.Margins = new System.Drawing.Printing.Margins(100, 568, 100, 100);
			((System.ComponentModel.ISupportInitialize)(this.dtConsItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}
