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

        public void DealData(string value)
        {
            try
            {
                //电阻
                modbus.WriteMultipleRegisters(ConstPara.SlaveId, this._address, new ushort[] { ushort.Parse(value) });
                //如果修改成功的话,就重新读取这个数值
                ushort[] dataList = modbus.ReadHoldingRegisters(ConstPara.SlaveId, this._address, 1);
                this._sender.Text = dataList[0] + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
