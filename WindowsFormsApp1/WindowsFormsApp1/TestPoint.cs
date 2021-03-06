﻿using System;
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
                var data = new TestPoint();
                data.UpperV = Math.Abs(testPoint.UpperV - 5);
                data.ActualV = Math.Abs(testPoint.ActualV - 5);
                data.DownV = Math.Abs(testPoint.DownV - 5);
                data.IdealV = Math.Abs(testPoint.IdealV - 5);
                newDataList.Add(data);
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
                maxErrorData.IsMaxError = false;
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
                item.LineError = Math.Round(GetLineError(vMax, vMin, item, list.Count),2);
                newDataList.Add(item);
            }
            return newDataList;
        }

        

        public static List<TestPoint> GetTestPointList(List<decimal> vList, decimal downAngle, decimal upperAngle,
            decimal error,decimal vMax,decimal vMin,decimal upError,decimal downError)
        {
            if (vList.Count <2)
            {
                throw new Exception("测试点数最少为2");
            }
            //采集点之间的角度间隔
            var slopeAngle = (upperAngle - downAngle)/(vList.Count-1);
            //采集点之间的电压差
            var slopeV1 = (vMax - vMin) / (vList.Count - 1);
            //角度一直的电压差
            var slopeV = ((decimal) (vMax-vMin))/(upperAngle - downAngle);
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
                    IdealV =   vMin,
                    //采集上限
                    //序号
                    Index = dataIndex++
                };
                //理想电压
                point.IdealV = Math.Round(vMin + slopeV1 * point.Index, 2);
                //上限电压
                point.UpperV = GetValue(vMin, slopeV1, upError / 100m, point.Index);
                //下线电压
                point.DownV = GetValue(vMin, slopeV1, -1*(downError / 100m), point.Index);
               
                list.Add(point);
                angleBegin += slopeAngle;
            }

          
            return list;
        }


        public static decimal GetValue( decimal min,decimal interV,decimal pValue,int index)
        {
            return Math.Round((1 + pValue) * (min + interV * index),2);
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
            table.Columns.Add(new DataColumn("线性度误差"));

            foreach (var testPoint in dataList)
            {
                DataRow row = table.NewRow();
                row["角度"] = testPoint.Angle;
                row["采集值"] = testPoint.ActualV;
                row["理论值"] = testPoint.IdealV;
                row["上限"] = testPoint.UpperV;
                row["下限"] = testPoint.DownV;
                row["线性度误差"] = testPoint.LineError;
                table.Rows.Add(row);
            }
            return table;
        }


    }
}
