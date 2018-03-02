using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// BOMFacade ��ժҪ˵����
	/// </summary>
	public class BOMFacade
	{
		public BOMFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void BOMMOD(Entity.BillOfMaterials bom,Entity.BusiLog bl,bool isHis)
		{
			ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Entity.OilStorage os = new OilStorage(bl.ToTable());
					os.cnvcGoodsName = bom.cnvcGoodsName;
					os.cnvcGoodsType = bom.cnvcGoodsType;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"����ȡ����");

					Guid gd = Guid.NewGuid();

					//�ж��޸Ĳ������� �Ķ�Ϊ��� ����Ϊ����
					//ר���ͳ���
					Entity.BillOfMaterials oldbom = new BillOfMaterials(bom.GetOriginalValue());
					string strOperType = "";
					if(oldbom.cnnCount>bom.cnnCount)
						strOperType = InType.BOMModIn;
					else
						strOperType = InType.BOMModOut;

					//���յ�
					//bom.cnvcInType = strOperType;
					bom.cndOperDate = dtSysTime;
					if(isHis)
					{
						Entity.BillOfMaterialsHis bomhis = new BillOfMaterialsHis(bom.GetOriginalValue());
						EntityMapping.Delete(bomhis,trans);

						//bomhis.SynchronizeModifyValue(bom);
						EntityMapping.Create(bom,trans);
					}
					else
					{
						EntityMapping.Update(bom,trans);
					}
					if(bom.cnnCount != oldbom.cnnCount)
					{
						//�����־
						Entity.OilStorageLog ol = new OilStorageLog(bom.ToTable());
						ol.cnvcDeptName = bl.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = os.cnnStorageCount;
						ol.cnnInOutCount = oldbom.cnnCount-bom.cnnCount;//bom.cnnCount-oldbom.cnnCount;
						ol.cnnCurCount = os.cnnStorageCount + oldbom.cnnCount - bom.cnnCount;
						EntityMapping.Create(ol,trans);

						//���
						os.cnnStorageCount = ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//��־
					bl.cnnSerial = gd;
					bl.cnvcComments = "���ϵ��޸ģ����������"+(oldbom.cnnCount-bom.cnnCount);
					bl.cnvcOperType = OperType.OP203;
					bl.cndOperDate = dtSysTime;
					bl.cnvcSource = InSource.cs;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
	}
}
