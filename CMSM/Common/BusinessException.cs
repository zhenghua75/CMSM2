using System;

namespace CMSM.Common
{
    /// <summary>
    /// ���ƣ�ҵ������쳣�ࡣ
    /// �汾��V1.0
    /// ������Fightop Lin
    /// ���ڣ�2006-1-12
    /// �������������߼�������ҵ�����ʱ�׳����쳣
    ///
    /// Log ��1
    /// �汾��
    /// �޸ģ�
    /// ���ڣ�
    /// ������
    ///       
    /// </summary>
    public class BusinessException : Exception
    {
        private bexType sType;
        private string sMessage = String.Empty;

        public bexType Type
        {
            get
            {
                return sType;
            }
        }

        public override string Message
        {
            get
            {
                return sMessage;
            }
        }


        public BusinessException(bexType sType,string sMessage)
        {
            this.sType    = sType;
            this.sMessage = sMessage;
        }

        public override string ToString()
        {
            return "ҵ������쳣: "  + "[" + sType.ToString() + "]" + sMessage;
        }

    }
}
