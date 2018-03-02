
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   CMSM
* �ļ���:  	Dept.cs
* ����:		     ֣��
* ��������:     2010-4-17
* ��������:    ����

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
	/// **�������ƣ�����ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbDept")]
	public class Dept: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcParentDeptID = String.Empty;
		private string _cnvcLocalFlag = String.Empty;
		private bool _cnbValidate;
		
		#endregion
		
		#region ���캯��




		public Dept():base()
		{
		}
		
		public Dept(DataRow row):base(row)
		{
		}
		
		public Dept(DataTable table):base(table)
		{
		}
		
		public Dept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
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
		[ColumnMapping("cnvcParentDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcParentDeptID
		{
			get {return _cnvcParentDeptID;}
			set {_cnvcParentDeptID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcLocalFlag",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLocalFlag
		{
			get {return _cnvcLocalFlag;}
			set {_cnvcLocalFlag = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnbValidate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public bool cnbValidate
		{
			get {return _cnbValidate;}
			set {_cnbValidate = value;}
		}
		#endregion
	}	
}
