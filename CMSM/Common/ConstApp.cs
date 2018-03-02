using System;

namespace CMSM.Common
{
	/// <summary>
	/// ConstApp ��ժҪ˵����
	/// </summary>
	public class ConstApp
	{
		public ConstApp()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		//�������,�������,����,��������:
		public const string SystemParaTables = "tbCommCode,23,CMSM.Entity.CommCode,:"
			+"tbDept,0,CMSM.Entity.Dept,cnbValidate=1:"
			+"tbFunc,,CMSM.Entity.Func,:"
			+"tbOper,0,CMSM.Entity.Oper,:"
			+"tbOperFunc,,CMSM.Entity.OperFunc,:"
			+"tbRegister,,CMSM.Entity.Register,";
			//+"tbSpecialOilDept,,CMSM.Entity.SpecialOilDept,";		
	}
	/// <summary>
	/// ҵ���쳣
	/// </summary>
	public enum bexType
	{
		/// <summary>
		/// ���Ĳ�����ȫ
		/// </summary>
		centerNoPara,
		/// <summary>
		/// δ����
		/// </summary>
		noconnect,
		/// <summary>
		/// ����ʧ��
		/// </summary>
		nodown,
		/// <summary>
		/// ���ݿⲢ��
		/// </summary>
		CONCURRENT,
		/// <summary>
		/// �ն���
		/// </summary>
		noobject
	}
	/// <summary>
	/// ��������
	/// </summary>
	public enum OperFlag
	{
		/// <summary>
		/// ���
		/// </summary>
		ADD,
		/// <summary>
		/// �޸�
		/// </summary>
		MOD
	}
	/// <summary>
	/// ���������
	/// </summary>
	public sealed class InType
	{	
		/// <summary>
		/// �������
		/// </summary>
		public const string TransferIn = "�������";
		/// <summary>
		/// ����
		/// </summary>
		public const string ByIn = "����";
		/// <summary>
		/// ���յ��޸ĳ���
		/// </summary>
		public const string BOVModOut = "���յ��޸ĳ���";
		/// <summary>
		/// ���յ��޸����
		/// </summary>
		public const string BOVModIn = "���յ��޸����";
		/// <summary>
		/// ���ϵ��޸ĳ���
		/// </summary>
		public const string BOMModOut = "���ϵ��޸ĳ���";
		/// <summary>
		/// ���ϵ��޸����
		/// </summary>
		public const string BOMModIn = "���ϵ��޸����";
	}
	public sealed class OutType
	{
		/// <summary>
		/// ��������
		/// </summary>
		public const string TransferOut = "��������";	
		/// <summary>
		/// ���ⵥ�޸ĳ���
		/// </summary>
		public const string BOSOut = "���ⵥ�޸ĳ���";
		/// <summary>
		/// ���ⵥ�޸����
		/// </summary>
		public const string BOSIn = "���ⵥ�޸����";
	}
	/// <summary>
	/// ��������
	/// </summary>
	public sealed class OperType
	{
		/// <summary>
		/// ���յ�¼��
		/// </summary>
		public const string OP010 = "OP010";
		/// <summary>
		/// �������ⵥ¼��
		/// </summary>
		public const string OP011 = "OP011";
		/// <summary>
		/// ר�������ϵ�¼��
		/// </summary>
		public const string OP012 = "OP012";
		/// <summary>
		/// ���յ��޸�
		/// </summary>
		public const string OP201 = "OP201";
		/// <summary>
		/// �������ⵥ�޸�
		/// </summary>
		public const string OP202 = "OP202";
		/// <summary>
		/// ר�������ϵ��޸�
		/// </summary>
		public const string OP203 = "OP203";
		/// <summary>
		/// ר���ͺ�ͬ���
		/// </summary>
		public const string OP204 = "OP204";
		/// <summary>
		/// ר���ͺ�ͬ�޸�
		/// </summary>
		public const string OP205 = "OP205";
	}
	/// <summary>
	/// ��־��Դ
	/// </summary>
	public sealed class InSource
	{
		/// <summary>
		/// �ͻ���
		/// </summary>
		public const string cs = "�ͻ���";
	}
}
