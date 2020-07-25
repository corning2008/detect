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

        角度=26,
        /// <summary>
        /// 角度上限PLC地址502
        /// </summary>
        角度上限=502,
        /// <summary>
        /// 角度下限PLC地址501
        /// </summary>
        角度下限=501,
        /// <summary>
        /// 点数,PLC地址614
        /// </summary>
        测试点数=614,
        /// <summary>
        /// PLC地址503
        /// </summary>
        旋转速度=503,
        /// <summary>
        /// 总阻,PLC地址500
        /// </summary>
        总阻设定=500,
        /// <summary>
        /// PLC地址504
        /// </summary>
        斜率=504,

        上行程= 612,
        下行程 = 613,
        /// <summary>
        /// PLC地址610
        /// </summary>
        总阻最大正向允许误差=610,
        /// <summary>
        /// PLC地址611
        /// </summary>
        总阻最大负向允许误差=611,
        /// <summary>
        /// PLC地址506
        /// </summary>
	    零阻最大允许误差=506,
        /// <summary>
        /// PLC地址505
        /// </summary>
        线性允许误差=505,
        电压上限 = 98,
        电压下限 = 99,
        极限电压=214,
        //读取采集状态  0:等待测试 1:正在测试  2:测试完成  3:测试故障-总阻正超  4:测试故障-总阻负超  5:测试故障-伺服故障  6测试故障-伺服长时间不到位
        测试状态=10,
        /// <summary>
        /// PLC地址615
        /// </summary>
        零位偏差值=615,
        /// <summary>
        /// PLC507
        /// </summary>
        测量间隔=507,
        返回结果=8192,
        //0:无操作 1:开始测试  2:结束测试 4:清测试故障回等待
        测试命令=10,
    }
}
