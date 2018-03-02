
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	Register.cs
* 作者:		     郑华
* 创建日期:     2010-4-18
* 功能描述:    注册信息表

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
	/// **功能名称：注册信息表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbRegister")]
	public class Register: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcHddSerialNo = String.Empty;
		private string _cnvcRegister = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		
		#endregion
		
		#region 构造函数




		public Register():base()
		{
		}
		
		public Register(DataRow row):base(row)
		{
		}
		
		public Register(DataTable table):base(table)
		{
		}
		
		public Register(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcHddSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHddSerialNo
		{
			get {return _cnvcHddSerialNo;}
			set {_cnvcHddSerialNo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcRegister",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRegister
		{
			get {return _cnvcRegister;}
			set {_cnvcRegister = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}
		#endregion
	}	
}
