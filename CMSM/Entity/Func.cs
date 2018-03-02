
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   CMSM
* �ļ���:  	Func.cs
* ����:		     ֣��
* ��������:     2010-4-18
* ��������:    ���ܱ�

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
	/// **�������ƣ����ܱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbFunc")]
	public class Func: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcFuncName = String.Empty;
		private string _cnvcFuncAddress = String.Empty;
		private string _cnvcFuncType = String.Empty;
		
		#endregion
		
		#region ���캯��




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
		
		#region ϵͳ��������




				
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
