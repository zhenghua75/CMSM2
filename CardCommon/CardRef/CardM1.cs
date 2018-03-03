using System;
using System.Text;
using CardCommon.CardDef;

namespace CardCommon.CardRef
{
	/// <summary>
	/// CardM1 ��ժҪ˵����
	/// </summary>
	public class CardM1
	{
		public int icdev ; // ͨѶ�豸��ʶ��
		public Int16 st; //����ֵ
		public int sec; //����
		public Int16 port; //�˿�
		public int baud; //������

		public CardM1(Int16 comport)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
//			port=comport;
			port=0;
			//			port=(Int16)comboPort.SelectedIndex;
			baud=115200;
			sec=1;
			st=0;
		}

		#region ����ʱ��
		public void SetRFTime(string strToTime)
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return;
			}

			//����ʱ��
			byte[] time1=new byte[14];
			byte[] time2=new byte[7];

			string totime=strToTime;
			time1=Encoding.ASCII.GetBytes(totime);
			RFDef.a_hex(time1,time2,14);
			st = RFDef.rf_settime(icdev,time2);
			if(st!=0)
			{
				quit();
				return;
			}

			//������ʾģʽ
			st=RFDef.rf_disp_mode(icdev,0);
			if(st!=0)
			{
				quit();
				return;
			}

			quit();
		}
		#endregion

		#region ����
		public string PutOutCard(string strCardID,double dCurCharge,int iCurIg)
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤
			byte[] akey1=new byte[16];
			byte[] akey2=new byte[6];

			string akey="123456789012";
			akey1=Encoding.ASCII.GetBytes(akey);
			RFDef.a_hex(akey1,akey2,12);
			st = RFDef.rf_load_key(icdev, 0, sec, akey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_A_ERR;
			}
			st = RFDef.rf_authentication(icdev,0,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_A_ERR;
			}

			//д����
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];
			//int lendata=0;

			string data=strCardID;
			data+="000000000000000000000000000";
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*4,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}

			//������
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];
			akey="123456789012";
			string bkey="123456789012";
			akey1=Encoding.ASCII.GetBytes(akey);
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(akey1,akey2,12);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_changeb3(icdev,sec,akey2,3,3,3,3,0,bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFCHANGEB3ERR;
			}

			//����
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region ˢ��
		public string ReadCard(out string strCardID,out double dCurCharge,out int iCurIg)
		{
			strCardID="";
			dCurCharge=0;
			iCurIg=0;
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤B
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];

			string bkey="123456789012";
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_B_ERR;
			}
			st = RFDef.rf_authentication(icdev,4,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_B_ERR;
			}

			//������
			int i=0;
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];

			for(i=0;i<16;i++)
				databuff[i]=0;
			for(i=0;i<32;i++)
				buff[i]=0;
			//����
			st = RFDef.rf_read(icdev,sec*4,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREADERR;
			}
			else
			{
				RFDef.hex_a(databuff,buff,16);
				strCardID=System.Text.Encoding.ASCII.GetString(buff);
				strCardID=strCardID.Substring(0,5);
			}
//
//			//���
//			st = RFDef.rf_read(icdev,sec*5,databuff);
//			if(st!=0)
//			{
//				quit();
//				return ConstMsg.RFREADERR;
//			}
//			else
//			{
//				RFDef.hex_a(databuff,buff,16);
//				string strCharge=System.Text.Encoding.ASCII.GetString(buff);
//				int fcIndex=strCharge.IndexOf("F",0);
//				if(fcIndex==-1)
//				{
//					quit();
//					return ConstMsg.RFREADCHARGEERR;
//				}
//				else
//				{
//					dCurCharge=double.Parse(strCharge.Substring(0,fcIndex)+"."+strCharge.Substring(30,2));
//				}
//			}

			//����
//			st = RFDef.rf_read(icdev,sec*6,databuff);
//			if(st!=0)
//			{
//				quit();
//				return ConstMsg.RFREADERR;
//			}
//			else
//			{
//				RFDef.hex_a(databuff,buff,16);
//				string strIg=System.Text.Encoding.ASCII.GetString(buff);
//				int fiIndex=strIg.IndexOf("F",0);
//				if(fiIndex==-1)
//				{
//					quit();
//					return ConstMsg.RFREADCHARGEERR;
//				}
//				else
//				{
//					iCurIg=int.Parse(strIg.Substring(0,fiIndex));
//				}
//			}

			//����
			st = RFDef.rf_beep(icdev,2);

			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region ������
		public string RecycleCard()
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤B
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];

			string bkey="123456789012";
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_B_ERR;
			}
			st = RFDef.rf_authentication(icdev,4,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_A_ERR;
			}

			//ԭʼ��������Ϣ
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];

			string data="00000000000000000000000000000000";
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*4,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}

			//ԭʼ���������Ϣ
			databuff=new byte[16];
			buff=new byte[32];

			data="00000000000000000000000000000000";
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*5,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}

			//ԭʼ����������Ϣ
			databuff=new byte[16];
			buff=new byte[32];

			data="00000000000000000000000000000000";
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*6,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}

			//������
			byte[]akey1=new byte[16];
			byte[]akey2=new byte[6];
			bkey="123456789012";
			string akey="123456789012";
			akey1=Encoding.ASCII.GetBytes(akey);
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(akey1,akey2,12);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_changeb3(icdev,sec,akey2,0,0,0,1,0,bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFCHANGEB3ERR;
			}

			//����
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region �رն�����
		public void quit()
		{
			st=0;
			RFDef.rf_reset(icdev,80);
			st=RFDef.rf_exit(icdev);
			icdev=-1;
		}
		#endregion

		#region ��ֵд��
		public string FillWriteCard(double dFillFee,double dCurChargeBak1)
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤B
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];

			string bkey="123456789012";
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_B_ERR;
			}
			st = RFDef.rf_authentication(icdev,4,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_A_ERR;
			}

			//����Ϊ��дʱ��������
			int i=0;
			byte[] databuffcharge=new byte[16];

			for(i=0;i<16;i++)
				databuffcharge[i]=0;
			st = RFDef.rf_read(icdev,sec*5,databuffcharge);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREADERR;
			}

			//д���
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];
			int lendata=0;

			string strzero30="FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
			string data=dFillFee.ToString("0.00");
			int dotindex=data.IndexOf(".",0);
			if(dotindex==-1)
			{
				lendata=data.Length;
				data=data+strzero30.Substring(0,30-lendata)+"00";
			}
			else
			{
				string datalar=data.Substring(0,dotindex);
				string datatiny=data.Substring(dotindex+1,2);
				lendata=datalar.Length;
				data=datalar+strzero30.Substring(0,30-lendata)+datatiny;
			}
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*5,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}
			else
			{
				//�������
				for(i=0;i<16;i++)
					databuff[i]=0;
				st = RFDef.rf_read(icdev,sec*5,databuff);
				if(st!=0)
				{
					//��д���
					st = RFDef.rf_write(icdev,sec*5,databuffcharge);
					if(st!=0)
					{
						//����
						st = RFDef.rf_beep(icdev,2);
						quit();
						return "CMT|������д����trans�ύ��correct data: C:" + dFillFee.ToString();
					}
					else
					{
						quit();
						return "ROL|������д�ɹ���trans�ع���";
					}
				}
				else
				{
					double dFillFeeInv=0;
					RFDef.hex_a(databuff,buff,16);
					string strCharge=System.Text.Encoding.ASCII.GetString(buff);
					int fcIndex=strCharge.IndexOf("F",0);
					if(fcIndex==-1)
					{
						dFillFeeInv=-1;
					}
					else
					{
						dFillFeeInv=double.Parse(strCharge.Substring(0,fcIndex)+"."+strCharge.Substring(30,2));
					}
					bool invflag=true;
					if(dFillFeeInv==-1)
					{
						invflag=false;
					}
					else
					{
						if(dFillFee!=dFillFeeInv||dCurChargeBak1!=dFillFee||dCurChargeBak1!=dFillFeeInv)
						{
							invflag=false;
						}
					}
					if(!invflag)
					{
						//��д���
						st = RFDef.rf_write(icdev,sec*5,databuffcharge);
						if(st!=0)
						{
							//����
							st = RFDef.rf_beep(icdev,2);
							quit();
							return "CMT|У����󣬷�д����trans�ύ��correct data: C:" + dFillFee.ToString();
						}
						else
						{
							quit();
							return "ROL|У����󣬷�д�ɹ���trans�ع���";
						}
					}
					else
					{
						//����
						st = RFDef.rf_beep(icdev,2);
						quit();
						return ConstMsg.RFOK;
					}
				}
			}
		}
		#endregion

		#region ��Ա����д��
		public string ConsWriteCard(double dCurCharge,double dCurChargeBak,int iCurIg)
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,0,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤B
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];

			string bkey="123456789012";
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_B_ERR;
			}
			st = RFDef.rf_authentication(icdev,4,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_A_ERR;
			}

			//����Ϊ��дʱ��������
			int i=0;
			byte[] databuffcharge=new byte[16];
			for(i=0;i<16;i++)
				databuffcharge[i]=0;
			st = RFDef.rf_read(icdev,sec*5,databuffcharge);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREADERR;
			}

			//׼�������databuff
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];
			int lendata=0;

			string strzero30="FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
			string data=dCurCharge.ToString("0.00");
			int dotindex=data.IndexOf(".",0);
			if(dotindex==-1)
			{
				lendata=data.Length;
				data=data+strzero30.Substring(0,30-lendata)+"00";
			}
			else
			{
				string datalar=data.Substring(0,dotindex);
				string datatiny=data.Substring(dotindex+1,2);
				lendata=datalar.Length;
				data=datalar+strzero30.Substring(0,30-lendata)+datatiny;
			}
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);

			//д���
			st = RFDef.rf_write(icdev,sec*5,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}
			else
			{
				//�������
				for(i=0;i<16;i++)
					databuff[i]=0;
				st = RFDef.rf_read(icdev,sec*5,databuff);
				if(st!=0)
				{
					//��д���
					st = RFDef.rf_write(icdev,sec*5,databuffcharge);
					if(st!=0)
					{
						//����
						st = RFDef.rf_beep(icdev,2);
						quit();
						return "CMT|������д����trans�ύ��correct data: C:" + dCurCharge.ToString() + "I:" + iCurIg.ToString();
					}
					else
					{
						quit();
						return "ROL|������д�ɹ���trans�ع���";
					}
				}
				else
				{
					double dChargeInv=0;
					RFDef.hex_a(databuff,buff,16);
					string strCharge=System.Text.Encoding.ASCII.GetString(buff);
					int fcIndex=strCharge.IndexOf("F",0);
					if(fcIndex==-1)
					{
						dChargeInv=-1;
					}
					else
					{
						dChargeInv=double.Parse(strCharge.Substring(0,fcIndex)+"."+strCharge.Substring(30,2));
					}
					bool invflag=true;
					if(dChargeInv==-1)
					{
						invflag=false;
					}
					else
					{
						if(dCurCharge!=dChargeInv||dCurCharge!=dCurChargeBak||dCurChargeBak!=dChargeInv)
						{
							invflag=false;
						}
					}
					if(!invflag)
					{
						//��д���
						st = RFDef.rf_write(icdev,sec*5,databuffcharge);
						if(st!=0)
						{
							//����
							st = RFDef.rf_beep(icdev,2);
							quit();
							return "CMT|У����󣬷�д����trans�ύ��correct data: C:" + dCurCharge.ToString() + "I:" + iCurIg.ToString();
						}
						else
						{
							quit();
							return "ROL|У����󣬷�д�ɹ���trans�ع���";
						}
					}
					else
					{
						quit();
						return ConstMsg.RFOK;
					}
				}
			}
		}
		#endregion

		#region ��Ա���ֶһ�д��
		public string IgChangeWriteCard(int iCurIg)
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return ConstMsg.RFINITERR;
			}

			//Ѱ��
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;

			RFDef.rf_reset(icdev, 10);
			st = RFDef.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFREQUESTERR;
			}

			st = RFDef.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFANTICOLLERR;
			}

			st = RFDef.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFSELECTERR;
			}

			//��֤B
			byte[] bkey1=new byte[16];
			byte[] bkey2=new byte[6];

			string bkey="123456789012";
			bkey1=Encoding.ASCII.GetBytes(bkey);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFLOADKEY_B_ERR;
			}
			st = RFDef.rf_authentication(icdev,4,sec);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFAUTHENTICATION_A_ERR;
			}

			//д����
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];

			string strzero32="FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
			string data=iCurIg.ToString();
			int lendata=data.Length;
			data=data+strzero32.Substring(0,32-lendata);
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*6,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}

			//����
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region ����ͨ�Ŵ����������
		public bool TestCommPort()
		{
			//��ʼ��
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return false;
			}
			else
			{
				quit();
				return true;
			}
		}
		#endregion
	}
}
