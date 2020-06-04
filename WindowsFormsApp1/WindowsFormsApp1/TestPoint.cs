using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.model
{
    public class TestPoint
    {
        /// <summary>
        /// 角度
        /// </summary>
        public decimal Angle { get; set; }

        /// <summary>
        /// 理想值电压值
        /// </summary>
        public decimal IdealV { get; set; }

        /// <summary>
        /// 实际采集值
        /// </summary>
        public decimal ActualV { get; set; }


        /// <summary>
        /// 上限
        /// </summary>
        public decimal UpperV { get; set; }

        /// <summary>
        /// 下限
        /// </summary>
        public decimal DownV { get; set; }

        /// <summary>
        /// 从1开始
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 线性误差：计算的方法和公示 （）
        /// </summary>
        public decimal LineError { get; set; }


        /// <summary>
        /// 采集的数据是否在合法范围内
        /// </summary>
        /// <returns></returns>
        public bool IsValidateData()
        {
            if (ActualV >= DownV && ActualV <= UpperV)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("Point:{0}--IdealV:{1}---ActualV:{2}---UpperV:{3}:---DownV:{4}", Angle, IdealV, ActualV,
                UpperV, DownV);
        }

        

        /// <summary>
        /// 获取相对的数据
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static List<TestPoint> GetRelativePoints(List<TestPoint> dataList)
        {
            List<TestPoint> newDataList = new List<TestPoint>();
            foreach (var testPoint in dataList)
            {
                testPoint.UpperV = Math.Abs(testPoint.UpperV - 5);
                testPoint.ActualV = Math.Abs(testPoint.ActualV - 5);
                testPoint.DownV = Math.Abs(testPoint.DownV - 5);
                testPoint.IdealV = Math.Abs(testPoint.IdealV - 5);
                newDataList.Add(testPoint);
            }

            return newDataList;
        }

        /// <summary>
        /// 是否误差最大
        /// </summary>
        public bool IsMaxError { get; set; }

        /// <summary>
        /// 查找最大的误差数据
        /// </summary>
        /// <param name="list"></param>
        public static void FindMaxErrorData(List<TestPoint> list)
        {
            decimal interval = 0;
            TestPoint maxErrorData = null;
            foreach (var testPoint in list)
            {
                if (Math.Abs(testPoint.ActualV - testPoint.IdealV) > interval)
                {
                    interval = Math.Abs(testPoint.ActualV - testPoint.IdealV);
                    maxErrorData = testPoint;
                }
            }
            //如果找到了误差最大的数据,就记性标记
            if (null != maxErrorData)
            {
                maxErrorData.IsMaxError = true;
            }
        }

        /// <summary>
        /// 计算线性曲线数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="vMax"></param>
        /// <param name="vMin"></param>
        public static List<TestPoint> ComputeLineErrorValue(List<TestPoint> list, decimal vMax,decimal vMin)
        {
            if (list.Count < 2)
            {
                throw new Exception("测试点数最少为2");
            }
            var newDataList = new List<TestPoint>();
            var dataIndex = 0;
            foreach(var item in list)
            {
                item.Index = dataIndex++;
                item.LineError = GetLineError(vMax, vMin, item, list.Count);
                newDataList.Add(item);
            }
            return newDataList;
        }

        

        public static List<TestPoint> GetTestPointList(List<decimal> vList, decimal downAngle, decimal upperAngle,
            decimal error)
        {
            if (vList.Count <2)
            {
                throw new Exception("测试点数最少为2");
            }
            //采集点之间的角度间隔
            var slopeAngle = (upperAngle - downAngle)/(vList.Count-1);
            //角度一直的电压差
            var slopeV = ((decimal) 10)/(upperAngle - downAngle);
            List<TestPoint> list = new List<TestPoint>();
            var angleBegin = downAngle;
            var dataIndex = 0;
            foreach (decimal item in vList)
            {
                var point = new TestPoint()
                {
                    Angle = Math.Round(angleBegin, 2),
                    //实际采集值
                    ActualV = item,
                    //理论采集值
                    IdealV = Math.Round((angleBegin - downAngle) * slopeV, 2),
                    //采集上限
                    UpperV = Math.Round((angleBegin - downAngle) * slopeV + error, 2),
                    //采集下线
                    DownV = Math.Round((angleBegin - downAngle) * slopeV - error, 2),
                    //序号
                    Index = dataIndex++

                };
               
                list.Add(point);
                angleBegin += slopeAngle;
            }

          
            return list;
        }

        private static decimal GetLineError(decimal vMax, decimal vMin, TestPoint point, int count)
        {
            var idealV = Math.Round(((vMax - vMin) / (count-1))*point.Index+vMin,2);
            if(idealV <= 0.001m)
            {
                idealV = 0.001m;
            }
            return ((point.ActualV / idealV) - 1) * 100;

        }

        public static DataTable ConvertToDataTable(List<TestPoint> dataList)
        {
            DataTable table = new DataTable();
            //
            table.Columns.Add(new DataColumn("角度"));
            table.Columns.Add(new DataColumn("采集值"));
            table.Columns.Add(new DataColumn("理论值"));
            table.Columns.Add(new DataColumn("上限"));
            table.Columns.Add(new DataColumn("下限"));

            foreach (var testPoint in dataList)
            {
                DataRow row = table.NewRow();
                row["角度"] = testPoint.Angle;
                row["采集值"] = testPoint.ActualV;
                row["理论值"] = testPoint.IdealV;
                row["上限"] = testPoint.UpperV;
                row["下限"] = testPoint.DownV;
                table.Rows.Add(row);
            }
            return table;
        }


    }
}
