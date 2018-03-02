
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   CMSM
* �ļ���:  	OilStorageLog.cs
* ����:		     ֣��
* ��������:     2010-4-18
* ��������:    �����־

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
	/// **�������ƣ������־ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOilStorageLog")]
	public class OilStorageLog: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private Guid _cnnSerial = Guid.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private decimal _cnnInOutCount;
		private decimal _cnnLastCount;
		private decimal _cnnCurCount;
		private string _cnvcOperType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcDeptID = String.Empty;
		
		#endregion
		
		#region ���캯��




		public OilStorageLog():base()
		{
		}
		
		public OilStorageLog(DataRow row):base(row)
		{
		}
		
		public OilStorageLog(DataTable table):base(table)
		{
		}
		
		public OilStorageLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnSerial",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnnSerial
		{
			get {return _cnnSerial;}
			set {_cnnSerial = value;}
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
		[ColumnMapping("cnvcGoodsName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsName
		{
			get {return _cnvcGoodsName;}
			set {_cnvcGoodsName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcGoodsType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsType
		{
			get {return _cnvcGoodsType;}
			set {_cnvcGoodsType = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnInOutCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnInOutCount
		{
			get {return _cnnInOutCount;}
			set {_cnnInOutCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnLastCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnLastCount
		{
			get {return _cnnLastCount;}
			set {_cnnLastCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnCurCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCurCount
		{
			get {return _cnnCurCount;}
			set {_cnnCurCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcOperType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperType
		{
			get {return _cnvcOperType;}
			set {_cnvcOperType = value;}
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

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}
		#endregion
	}	
}