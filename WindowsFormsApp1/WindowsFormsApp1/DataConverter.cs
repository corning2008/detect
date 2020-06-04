using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DataConverter
    {
        public static List<decimal> ConvertData(List<decimal> dataList,byte d99,byte d98,byte d614)
        {
            var dataListV = new List<decimal>();
            //查询D99,D98,D614的数据
            //var d99 = serialPort.ReadDataFromPLCD(99, 1, 500)[0];
            //var d98 = serialPort.ReadDataFromPLCD(98, 1, 500)[0];
            //var d614 = serialPort.ReadDataFromPLCD(614, 1,500)[0];
            var value = (d99 - d98) / (d614 * 1.0m);
            for (var i = 1; i <= dataList.Count; i++)
            {
                var divider = value * i + d98;
                var newValue = (decimal)(((dataList[i - 1] / divider) - 1) * 100);
                dataListV.Add(newValue);
            }

            return dataListV;
        }


        public void Test()
        {
            Console.WriteLine(Math.Round(1/3m,2));
        }
    }
}
