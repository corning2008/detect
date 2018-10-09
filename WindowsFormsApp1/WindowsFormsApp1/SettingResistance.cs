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
        public SettingResistance(IModbusMaster modbus, ushort address, TextBox sender)
        {
            this.modbus = modbus;
            this._address = address;
            this._sender = sender;
        }

        private IModbusMaster modbus;
        private ushort _address;
        private TextBox _sender;

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
                modbus.WriteMultipleRegisters(ConstPara.SlaveId, this._address, new ushort[] { valueSet });
                //如果修改成功的话,就重新读取这个数值
                ushort[] dataList = modbus.ReadHoldingRegisters(ConstPara.SlaveId, this._address, 1);
                this._sender.Text = ((decimal)(dataList[0]/(zoomFlag*1.0f))) + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
