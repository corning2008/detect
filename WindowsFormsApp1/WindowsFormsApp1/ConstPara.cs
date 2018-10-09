using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ConstPara
    {
        /// <summary>
        /// 从站编号
        /// </summary>
        public static readonly byte SlaveId = 1;
    }


    public enum RegisterSetting
    {
        角度上限=207,
        角度下限=206,
        测试点数=205,
        旋转速度=208,
        总阻设定=204,
        斜率=209,
        总阻最大正向允许误差=210,
        总阻最大负向允许误差=211,
	    零阻最大允许误差=212,
        线性允许误差=213,
        极限电压=214,
        //读取采集状态  0:等待测试 1:正在测试  2:测试完成  3:测试故障-总阻正超  4:测试故障-总阻负超  5:测试故障-伺服故障  6测试故障-伺服长时间不到位
        测试状态=2248,
        
        零位偏差值=214,
        返回结果=8192,
        //0:无操作 1:开始测试  2:结束测试 4:清测试故障回等待
        测试命令=2249,
    }
}
