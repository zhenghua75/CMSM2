
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	SpecialOilDept.cs
* 作者:		     郑华
* 创建日期:     2010-4-20
* 功能描述:    专供油合同编号

*                                                           Copyright(C) 2010 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using CMSM.EntityBase;
#endregion

namespace CMSM.Entity
{
	/// <summary>
	/// **功能名称：专供油合同编号实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbSpecialOilDept")]
	public class SpecialOilDept: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcContractNo = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		
		#endregion
		
		#region 构造函数




		public SpecialOilDept():base()
		{
		}
		
		public SpecialOilDept(DataRow row):base(row)
		{
		}
		
		public SpecialOilDept(DataTable table):base(table)
		{
		}
		
		public SpecialOilDept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeliveryCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryCompany
		{
			get {return _cnvcDeliveryCompany;}
			set {_cnvcDeliveryCompany = value;}
		}
		#endregion
	}	
}
