using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;

namespace WindowsFormsApp1
{

    public class SettingResistance : ISetting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modbus"></param>
        /// <param name="address"></param>
        /// <param name="sender"></param>
        /// <param name="numberBytes">字节的个数</param>
        public SettingResistance(PLCSerialPort modbus, ushort address, TextBox sender,int numberBytes=2)
        {
            this.modbus = modbus;
            this._address = address;
            this._sender = sender;
            this._numberByte = numberBytes;
        }

        private PLCSerialPort modbus;
        private ushort _address;
        private TextBox _sender;
        private int _numberByte;

        public void DealData(string value,int zoomFlag =1)
        {
            try
            {
                //获取设置的数据
                ushort valueSet = (ushort)(decimal.Parse(value)*zoomFlag);
                //判断modBus是否已经打开
                if (null == modbus)
                {
                    MessageBox.Show("请先打开串口,否则无法设置参数");
                    return;
                }
                //电阻
                if (modbus.WriteDatasEx(this._address, BitConverter.GetBytes(valueSet), 3000))
                {
                    //如果修改成功的话,就重新读取这个数值
                    byte[] dataList = modbus.ReadDataFromPLC(this._address, 2,3000);
                    this._sender.Text = ((decimal)((BitConverter.ToUInt16(dataList,0))/ (zoomFlag * 1.0f))) + "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
