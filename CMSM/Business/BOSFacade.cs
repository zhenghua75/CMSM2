using System;
using System.Data;
using System.Data.SqlClient;
using CMSM.Common;
using CMSM.Entity;

namespace CMSM.Business
{
	/// <summary>
	/// BOSFacade ��ժҪ˵����
	/// </summary>
	public class BOSFacade
	{
		public BOSFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public void BOSMOD(Entity.BillOfOutStorage bos,Entity.BusiLog bl,bool isHis)
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
					os.cnvcGoodsName = bos.cnvcGoodsName;
					os.cnvcGoodsType = bos.cnvcGoodsType;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"����ȡ����");

					Guid gd = Guid.NewGuid();

					//�ж��޸Ĳ������� �Ķ�Ϊ��� ����Ϊ����
					Entity.BillOfOutStorage oldbos = new BillOfOutStorage(bos.GetOriginalValue());
					string strOperType = "";
					if(oldbos.cnnCount>bos.cnnCount)
						strOperType = OutType.BOSIn;
					else
						strOperType = OutType.BOSOut;

					//���յ�
					//bos.cnvcInType = strOperType;
					bos.cndOperDate = dtSysTime;
					if(isHis)
					{
						Entity.BillOfOutStorageHis boshis = new BillOfOutStorageHis(bos.GetOriginalValue());
						EntityMapping.Delete(boshis,trans);

						//boshis.SynchronizeModifyValue(bos);
						EntityMapping.Create(bos,trans);
					}
					else
					{
						EntityMapping.Update(bos,trans);
					}
					if(bos.cnnCount != oldbos.cnnCount)
					{
						//�����־
						Entity.OilStorageLog ol = new OilStorageLog(bos.ToTable());
						ol.cnvcDeptName = bl.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = os.cnnStorageCount;
						ol.cnnInOutCount = oldbos.cnnCount-bos.cnnCount;//bos.cnnCount-oldbos.cnnCount;
						ol.cnnCurCount = os.cnnStorageCount + oldbos.cnnCount-bos.cnnCount ;
						EntityMapping.Create(ol,trans);

						//���
						os.cnnStorageCount = ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//��־
					bl.cnnSerial = gd;
					bl.cnvcComments = "���ⵥ�޸ģ����������"+(oldbos.cnnCount-bos.cnnCount);//(bos.cnnCount-oldbos.cnnCount);
					bl.cnvcOperType = OperType.OP202;
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
