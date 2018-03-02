using System;
using System.Data;

namespace CMSMData
{
	/// <summary>
	/// Summary description for CMSMStruct.
	/// </summary>
	public class CMSMStruct
	{
		public CMSMStruct()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public class MemberStruct
		{
			public string strCardID;
			public string strCompanyID;
			public string strCompanyName;
			public string strLicenseTag;
			public string strGoodsName;
			public string strGoodsType;
			public string strDeptID;
			public string strDeptName;
			public string strState;
			public string strComments;
			public string strCreateDate;
			public string strOperName;
			public string strOperDate;
		}

		public class OperStruct
		{
			public string strOperID;
			public string strOperName;
			public string strPwd;
			public string strLimit;
			public string strDeptID;
		}

		public class GoodsStruct
		{
			public string strGoodsName;
			public string strGoodsSort;
			public string strGoodsType;
			public string strUnit;
			public string strComments;
		}

		public class ConsItemStruct
		{
			public string strSerial;
			public string strCardID;
			public string strLicenseTags;
			public string strGoodsName;
			public string strGoodsType;
			public string strUnit;
			public double dDensity;
			public double dKGCount;
			public double dCount;
			public double dPrice;
			public double dFee;
			public string strComments;
			public string strConsType;
			public string strConsDate;
			public string strCompanyID;
			public string strCompanyName;
			public string strAcctID;
			public string strDeptID;
			public string strDeptName;
			public string strOperName;
			public string strOperDate;
			public double dStorageLast;
			public string strCurStorage;
			
		}

		public class ConsDownStruct
		{
			public string strSerial;
			public string strGoodsID;
			public string strAssID;
			public string strCardID;
			public double dPrice;
			public int    iCount;
			public double dTRate;
			public double dFee;
			public string strComments;
			public string strFlag;
			public string strConsDate;
			public string strOperName;
			public string strDeptID;
		}

		public class CommStruct
		{
			public string strCommName;
			public string strCommCode;
			public string strCommSign;
			public string strComments;
		}

		public class FillFeeStruct
		{
			public string strSerial;
			public string strCompanyID;
			public string strCompanyName;
			public string strAcctID;
			public string strFillFee;
			public string strOperName;
			public string strOperDate;
			public string strDeptID;
			public string strDeptName;
		}

		public class CardHardStruct
		{
			public string strCardID;
			public double dCurCharge;
			public int    iCurIg;
		}

		public class AssChangeStruct
		{
			public string strCardID;
			public string strChangeField;
			public string strChangeValue;
			public string strOperDate;
		}

		public class BillStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public double dTRate;
			public double dFee;
			public double dPay;
			public double dBalance;
			public int    iIgValue;
			public string strConsType;
			public string strOperName;
			public string strConsDate;
			public string strDeptID;
		}

		public class IntegralStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public string strIgType;
			public int    iIgLast;
			public int    iIgGet;
			public int    iIgArrival;
			public int    iLinkCons;
			public string strIgDate;
			public string strOperName;
			public string strComments;
			public string strDeptID;
		}

		public class BusiLogStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public string strOperType;
			public string strOperName;
			public string strOperDate;
			public string strComments;
			public string strDeptID;
			public string strDeptName;
		}

		public class DeptToCenterLogStruct
		{
			public string strFileName;
			public int FileSize;
			public string strCreatingDate;
			public string strCreatedDate;
			public string strUpingDate;
			public string strUpedDate;
			public string strUpdatingDate;
			public string strUpdatedDate;
			public string strCreateFinish;
			public string strUpFinish;
			public string strUpdateFinish;
		}

		public class EmployeeStruct
		{
			public string strCardID;
			public string strEmpName;
			public string strSex;
			public string strEmpNbr;
			public string strInDate;
			public string strDegree;
			public string strLinkPhone;
			public string strAddress;
			public string strPwd;
			public string strOfficer;
			public string strDeptID;
			public string strFlag;
			public string strComments;
			public string strOperDate;
		}

		public class EmpSignStruct
		{
			public string strSerial;
			public string strCardID;
			public string strEmpName;
			public string strSignDate;
			public string strClass;
			public string strSignFlag;
			public string strComments;
			public string strDeptID;
		}

		public class NoticeStruct
		{
			public string strID;
			public string strComments;
			public string strCreateDate;
			public string strActiveFlag;
			public string strDeptFlag;
		}

		public class BillOfValidateStruct
		{
			public string strBillNo;
			public string strOutNo;
			public string strProvideCompany;
			public string strDeliveryCompany;
			public string strProvideDate;
			public string strGoodsName;
			public string strGoodsType;
			public string strUnit;
			public string strTransportLicenseTags;
			public string strTransportMan;
			public string strOriginalCount;
			public string strValidateCount;
			public string strDistance;
			public string strTransportLose;
			public string strLose;
			public string strQuotaLose;
			public string strQuterLose;
			public string strProvideAddress;
			public string strInType;
			public string strOperName;
			public string strOperDate;
			public string strDeliveryDate;
			public string strDeptID;
			public string strProvideDeptID;
		}

		public class OilStorageLogStruct
		{
			public string strSerial;
			public string strDeptName;
			public string strGoodsName;
			public string strGoodsType;
			public string strInOutCount;
			public string strLastCount;
			public string strCurCount;
			public string strOperType;
			public string strOperName;
			public string strOperDate;
			public string strDeptID;
		}

		public class OilStorageStruct
		{
			public string strGoodsName;
			public string strGoodsType;
			public double dStorageCount;
			public string strDeptName;
			public string strDeptID;
		}

		public class BillOfOutStorageStruct
		{
			public string strBillNo;
			public string strProvideStroage;
			public string strDeliveryCompany;
			public string strMoveNo;
			public string strBillOfMaterialsNo;
			public string strTransportCompany;
			public string strTransportLiscenseTags;
			public string strOutStorageDate;
			public string strGoodsName;
			public string strGoodsType;
			public string strUnit;
			public string strReceivableCount;
			public string strCount;
			public string strComments;
			public string strStorageIncharge;
			public string strDeliveryMan;
			public string strLister;
			public string strOutType;
			public string strOperName;
			public string strOperDate;
			public string strDeptID;
			public string strDeliveryDeptID;
		}

		public class BillOfMaterialsStruct
		{
			public string strBillNo;
			public string strContractNo;
			public string strDeliveryCompany;
			public string strProvideCompany;
			public string strGoodsName;
			public string strGoodsType;
			public string strUnit;
			public string strReceiveCount;
			public string strCount;
			public string strDeliveryMan;
			public string strDeliveryDate;
			public string strProvideBeginDate;
			public string strProvideEndDate;
			public string strProvideMan;
			public string strSignerCompany;
			public string strSigner;
			public string strTimeOfValidity;
			public string strOperName;
			public string strOperDate;
			public string strSpecialUnitPrice;
			public string strSpecialFee;
			public string strDeptID;
		}

		public class OilStorageCheckStruct
		{
			public string strSerialNo;
			public string strGoodsName;
			public string strGoodsType;
			public double dStorageCount;
			public double dLoseCount;
			public double dCount;
			public string strDeptName;
			public string strOperName;
			public string strOperDate;
			public string strDeptID;
		}

		public class AssConsParaStruct
		{
			public string strPrice;
			public string strDensity;
			public string strCurStorageCount;
		}

		public class DensityStruct
		{
			public string strSerialNo;
			public string strDeptName;
			public string strRateDate;
			public string strDensity;
			public string strGoodsName;
			public string strGoodsType;
			public string strDeptID;
		}

		public class DeptStruct
		{
			public string strDeptID;
			public string strDeptName;
			public string strParentDeptID;
			public string strLocalFlag;
		}

		public class CompDeptStruct
		{
			public string strCompanyID;
			public string strCompanyName;
			public string strAcctID;
			public string strDeptID;
			public string strDeptName;
			public string strPrepayBalance;
		}
	}
}
