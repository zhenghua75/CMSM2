using System;

namespace CardCommon.CardDef
{
	/// <summary>
	/// ConstMsg 的摘要说明。
	/// </summary>
	public class ConstMsg
	{
		public const string RFINITERR="初始化读卡器错误";
		public const string RFREQUESTERR="请求寻卡错误";
		public const string RFANTICOLLERR="读卡序列号错误";
		public const string RFSELECTERR="寻卡错误";
		public const string RFLOADKEY_A_ERR="加载A密码错误";
		public const string RFLOADKEY_B_ERR="加载B密码错误";
		public const string RFAUTHENTICATION_A_ERR="验证A错误";
		public const string RFAUTHENTICATION_B_ERR="验证B错误";
		public const string RFREADERR="读卡错误";
		public const string RFWRITEERR="写卡错误";
		public const string RFCHANGEB3ERR="制卡错误";
		public const string RFREADCHARGEERR="读卡余额出错，余额区没有F";
		public const string RFWRITEINVERR="RF012";

		public const string RFOK="OPSUCCESS";
	}
}
