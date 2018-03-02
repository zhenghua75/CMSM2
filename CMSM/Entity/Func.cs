
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	Func.cs
* 作者:		     郑华
* 创建日期:     2010-4-18
* 功能描述:    功能表

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
	/// **功能名称：功能表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbFunc")]
	public class Func: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcFuncName = String.Empty;
		private string _cnvcFuncAddress = String.Empty;
		private string _cnvcFuncType = String.Empty;
		
		#endregion
		
		#region 构造函数




		public Func():base()
		{
		}
		
		public Func(DataRow row):base(row)
		{
		}
		
		public Func(DataTable table):base(table)
		{
		}
		
		public Func(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcFuncName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncName
		{
			get {return _cnvcFuncName;}
			set {_cnvcFuncName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcFuncAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncAddress
		{
			get {return _cnvcFuncAddress;}
			set {_cnvcFuncAddress = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcFuncType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncType
		{
			get {return _cnvcFuncType;}
			set {_cnvcFuncType = value;}
		}
		#endregion
	}	
}
