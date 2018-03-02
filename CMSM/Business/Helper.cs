using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
namespace CMSM.Business
{
	/// <summary>
	/// Helper 的摘要说明。
	/// </summary>
	public class Helper
	{
		public Helper()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static DataTable Query(string strSql,bool IsCenter)
		{
			ConnectionPool.IsCenter = IsCenter;
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = SqlHelper.ExecuteDataTable(conn, CommandType.Text, strSql);
			}
			catch(Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw ex;
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}

		public static void UpdateObject(EntityBase.EntityObjectBase oldobj,EntityBase.EntityObjectBase newobj)
		{

		}
		public static DataTable QueryLongTrans(string strSql,bool IsCenter)
		{
			ConnectionPool.IsCenter = IsCenter;
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				//conn.ConnectionTimeout = 300;
				//SqlHelper.
				dtRet = SqlHelper.ExecuteDataTableLongTrans(conn, CommandType.Text, strSql);
			}
			catch(Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw ex;
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public static void DataTableConvert(DataTable dt,string columnName,string newcolumnName,DataTable dtCode,string strIDColumnName,string strCommentsColumnName,string filter)
		{
			string strTemp ;			
			string strCommentColumnName = newcolumnName;//columnName+"Comments";
			//判断新列是否存在，已经存在就不添加，不存在就添加
			if(dt.Columns[strCommentColumnName]==null)
			{			
				dt.Columns.Add(strCommentColumnName,typeof(string));
			}
			foreach (DataRow dr in dt.Rows)
			{
				strTemp = CodeConvert(dtCode,strIDColumnName,dr[columnName].ToString(),strCommentsColumnName,filter);					
				dr[strCommentColumnName] = strTemp;					
			}
		}
		private static string CodeConvert(DataTable dt,string strIDColumnName,string selectId,string strCommentsColumnName,string filter)
		{	
			string strRemark ;		
			DataView dw = new DataView(dt);			
			string strfilter = "";
			if(filter == "")
			{
				strfilter = strIDColumnName+" = '"+selectId+"'"; 
			}
			else
			{
				strfilter = filter +" and "+strIDColumnName+" = '"+selectId+"'"; 
			}
			
			dw.RowFilter = strfilter;			
			if(dw.Count == 1)
			{
				strRemark = dw[0].Row[strCommentsColumnName].ToString();
			}
			else
			{
				strRemark = "";//selectId;
			}
			return strRemark;				
		}

	}
}
