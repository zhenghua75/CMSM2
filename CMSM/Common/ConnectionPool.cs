using System;
using System.Data.SqlClient;


namespace CMSM.Common
{
    /// <summary>
    /// ���ƣ����ݿ����ӳء�
    /// �汾��V1.0
    /// ������Fightop Lin
    /// ���ڣ�2005-12-18
    /// ������ʹ�õ�ʵ��ģʽʵ�����ӳع���
    ///       �������ӵ��ã�ConnectionPool.Instance.BConnection()��
    ///       �黹���ӵ��ã�ConnectionPool.Instance.RConnection(SqlConnection conn)
    ///
    /// Log ��1
    /// �汾��V2.0
    /// �޸ģ�Fightop Lin
    /// ���ڣ�2006-1-11
    /// ��������ҵ����۲��Ƶ����ݷ��ʲ㣬���Ӿ�̬��Ա���� BorrowConnection()
    ///                                                    ReturnConnection(SqlConnection conn)
    ///       ����ԭʵ����Ա������������Ψһʵ�����Ӷ��򻯵��ù��̡�
    ///       �������ӣ�ConnectionPool.BorrowConnection()
    ///       �黹���ӣ�ConnectionPool.ReturnConnection(SqlConnection conn)
    ///       
    /// </summary>
	public sealed class ConnectionPool : ObjectPool
	{
		#region ʹ�þ�̬��������˽��ʵ����˽�г�Ա����
		/// <summary>
		/// �����ӳ��н���һ������
		/// </summary>
		/// <returns>���Ӷ���</returns>
		public static SqlConnection BorrowConnection()
		{
			return Instance.BConnection();
		}

		/// <summary>
		/// �黹һ�����ӵ����ӳ�
		/// </summary>
		/// <param name="conn">���Ӷ���</param>
		public static void ReturnConnection(SqlConnection conn)
		{
			Instance.RConnection(conn);
		}
		#endregion

		#region ˽�г�Ա����
		// Ψһʵ��
		private static readonly ConnectionPool Instance = new ConnectionPool();

		// ���Ӵ�
		private static string _centerConnectionString = "";
		private static string _localConnectionString = "";
		#endregion

		#region ���û�ȡ�����ַ�������
		public  static string CenterConnectionString
		{
			get{ return _centerConnectionString ; }
			//set{ _connectionString = value; }
		}
		public static string LocalConnectionString
		{
			get{return _localConnectionString;}
		}
		#endregion
 
		#region ��̬������ʹ��ConnectionManager��ʼ�������ַ���
		// ���ʾ�̬ʵ��ǰ��ʼ�������ַ���
		private static bool _IsCenter = false;
		public static bool IsCenter
		{
			get{return _IsCenter;}
			set{_IsCenter = value;}
		}
		static ConnectionPool()
		{
			string _connectionStringSet = CMSM.Common.ConfigAdapter.GetConfigNote("DFLAG").Trim();
			_centerConnectionString =  CMSM.Common.ConfigAdapter.GetConfigNote("DBAMSCMCenter").Trim();
			_localConnectionString =  CMSM.Common.ConfigAdapter.GetConfigNote("DBAMSCM").Trim();
			if(_connectionStringSet != "1")
			{
				_centerConnectionString = CMSM.Common.DataSecurity.Encrypt(_centerConnectionString);
				_localConnectionString = CMSM.Common.DataSecurity.Encrypt(_localConnectionString);
				CMSM.Common.ConfigAdapter.SetConfigNote("DBAMSCMCenter",_centerConnectionString);
				CMSM.Common.ConfigAdapter.SetConfigNote("DBAMSCM", _localConnectionString);
				CMSM.Common.ConfigAdapter.SetConfigNote("DFLAG", "1");
			}
			_centerConnectionString = CMSM.Common.DataSecurity.Decrypt(_centerConnectionString);
			_localConnectionString = CMSM.Common.DataSecurity.Decrypt(_localConnectionString);
			
		}
        #endregion

        #region ˽�й�������ֹ���ⲿ���ɶ���ʵ��
        private ConnectionPool() { }
        #endregion

        #region ʵ�ֻ���ĳ��󷽷�����������֤��������ݿ�����
        // ʵ��Create�������µ����Ӷ���
        protected override object Create()
        {
            SqlConnection temp = null;
			if(_IsCenter)
				temp = new SqlConnection(_centerConnectionString);
			else
				temp = new SqlConnection(_localConnectionString);
            temp.Open();

            return(temp);
        }


        // ʵ��Validate����֤���Ӷ����Ƿ���Ч
        protected override bool Validate(object o)
        {
            try
            {
                SqlConnection temp = (SqlConnection)o;

                return(
                    !((temp.State.Equals(System.Data.ConnectionState.Closed)))
                    );
            }
            catch(SqlException)
            {
                return false;
            }
        }

        // ʵ��Expire���رղ�������Ӷ���
        protected override void Expire(object o)
        {
            try
            {
                SqlConnection temp = (SqlConnection)o;
                temp.Close();
                temp.Dispose();
            }
            catch(SqlException){}
        }
        #endregion

        #region ������黹����(���������ʵ�ַ���)
        // ����һ������
        private SqlConnection BConnection()
        {
            try
            {
                return((SqlConnection)base.GetObjectFromPool());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// �黹һ�����ӵ����ӳ�
        /// </summary>
        /// <param name="conn">���Ӷ���</param>
        private void RConnection(SqlConnection conn)
        {
            base.ReturnObjectToPool(conn);
        
        }
        #endregion

    }
}
