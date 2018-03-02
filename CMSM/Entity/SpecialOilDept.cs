
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   CMSM
* �ļ���:  	SpecialOilDept.cs
* ����:		     ֣��
* ��������:     2010-4-20
* ��������:    ר���ͺ�ͬ���

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
	/// **�������ƣ�ר���ͺ�ͬ���ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbSpecialOilDept")]
	public class SpecialOilDept: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcContractNo = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		
		#endregion
		
		#region ���캯��




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
		
		#region ϵͳ��������




				
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
