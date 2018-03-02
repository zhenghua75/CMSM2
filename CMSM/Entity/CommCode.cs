
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	CommCode.cs
* 作者:		     郑华
* 创建日期:     2010-4-18
* 功能描述:    参数表

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
	/// **功能名称：参数表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbCommCode")]
	public class CommCode: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcCommName = String.Empty;
		private string _cnvcCommCode = String.Empty;
		private string _cnvcCommSign = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region 构造函数




		public CommCode():base()
		{
		}
		
		public CommCode(DataRow row):base(row)
		{
		}
		
		public CommCode(DataTable table):base(table)
		{
		}
		
		public CommCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCommName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCommName
		{
			get {return _cnvcCommName;}
			set {_cnvcCommName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCommCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCommCode
		{
			get {return _cnvcCommCode;}
			set {_cnvcCommCode = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCommSign",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCommSign
		{
			get {return _cnvcCommSign;}
			set {_cnvcCommSign = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}
		#endregion
	}	
}
