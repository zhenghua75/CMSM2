using System;

namespace CMSM.Common
{
	/// <summary>
	/// ConstApp 的摘要说明。
	/// </summary>
	public class ConstApp
	{
		public ConstApp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//物理表名,检查数量,类名,下载条件:
		public const string SystemParaTables = "tbCommCode,23,CMSM.Entity.CommCode,:"
			+"tbDept,0,CMSM.Entity.Dept,cnbValidate=1:"
			+"tbFunc,,CMSM.Entity.Func,:"
			+"tbOper,0,CMSM.Entity.Oper,:"
			+"tbOperFunc,,CMSM.Entity.OperFunc,:"
			+"tbRegister,,CMSM.Entity.Register,";
			//+"tbSpecialOilDept,,CMSM.Entity.SpecialOilDept,";		
	}
	/// <summary>
	/// 业务异常
	/// </summary>
	public enum bexType
	{
		/// <summary>
		/// 中心参数不全
		/// </summary>
		centerNoPara,
		/// <summary>
		/// 未连接
		/// </summary>
		noconnect,
		/// <summary>
		/// 下载失败
		/// </summary>
		nodown,
		/// <summary>
		/// 数据库并发
		/// </summary>
		CONCURRENT,
		/// <summary>
		/// 空对象
		/// </summary>
		noobject
	}
	/// <summary>
	/// 操作类型
	/// </summary>
	public enum OperFlag
	{
		/// <summary>
		/// 添加
		/// </summary>
		ADD,
		/// <summary>
		/// 修改
		/// </summary>
		MOD
	}
	/// <summary>
	/// 出入库类型
	/// </summary>
	public sealed class InType
	{	
		/// <summary>
		/// 调拨入库
		/// </summary>
		public const string TransferIn = "调拨入库";
		/// <summary>
		/// 购入
		/// </summary>
		public const string ByIn = "购入";
		/// <summary>
		/// 验收单修改出库
		/// </summary>
		public const string BOVModOut = "验收单修改出库";
		/// <summary>
		/// 验收单修改入库
		/// </summary>
		public const string BOVModIn = "验收单修改入库";
		/// <summary>
		/// 领料单修改出库
		/// </summary>
		public const string BOMModOut = "领料单修改出库";
		/// <summary>
		/// 领料单修改入库
		/// </summary>
		public const string BOMModIn = "领料单修改入库";
	}
	public sealed class OutType
	{
		/// <summary>
		/// 调拨出库
		/// </summary>
		public const string TransferOut = "调拨出库";	
		/// <summary>
		/// 出库单修改出库
		/// </summary>
		public const string BOSOut = "出库单修改出库";
		/// <summary>
		/// 出库单修改入库
		/// </summary>
		public const string BOSIn = "出库单修改入库";
	}
	/// <summary>
	/// 操作类型
	/// </summary>
	public sealed class OperType
	{
		/// <summary>
		/// 验收单录入
		/// </summary>
		public const string OP010 = "OP010";
		/// <summary>
		/// 调拨出库单录入
		/// </summary>
		public const string OP011 = "OP011";
		/// <summary>
		/// 专供油领料单录入
		/// </summary>
		public const string OP012 = "OP012";
		/// <summary>
		/// 验收单修改
		/// </summary>
		public const string OP201 = "OP201";
		/// <summary>
		/// 调拨出库单修改
		/// </summary>
		public const string OP202 = "OP202";
		/// <summary>
		/// 专供油领料单修改
		/// </summary>
		public const string OP203 = "OP203";
		/// <summary>
		/// 专供油合同添加
		/// </summary>
		public const string OP204 = "OP204";
		/// <summary>
		/// 专供油合同修改
		/// </summary>
		public const string OP205 = "OP205";
	}
	/// <summary>
	/// 日志来源
	/// </summary>
	public sealed class InSource
	{
		/// <summary>
		/// 客户端
		/// </summary>
		public const string cs = "客户端";
	}
}
