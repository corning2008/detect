using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1
{
    public class DrawClass
    {
        #region 绘制曲线函数
        /// <summary>
        　　　　/// 绘制曲线函数
        /// </summary>
        /// <param name="listX">X值集合</param>
        /// <param name="listY">Y值集合</param>
        /// <param name="chart">Chart控件</param>
        public static void DrawSpline(List<decimal> listX, List<decimal> listY, Chart chart,int index)
        {
            try
            {
              
                //X、Y值成员
                chart.Series[index].Points.DataBindXY(listX,listY);
                //chart.Series[index].MarkerColor = Color.Green;
                //chart.Series[index].MarkerSize = 5;
                //chart.Series[index].IsValueShownAsLabel = false;
                 
                //设置游标
                //chart.ChartAreas[index].CursorX.IsUserEnabled = true;
                //chart.ChartAreas[index].CursorX.AutoScroll = true;
                //chart.ChartAreas[index].CursorX.IsUserSelectionEnabled = true;
                ////设置X轴是否可以缩放
                //chart.ChartAreas[index].AxisX.ScaleView.Zoomable = true;
                ////将滚动条放到图表外
                //chart.ChartAreas[index].AxisX.ScrollBar.IsPositionedInside = false;
                //// 设置滚动条的大小
                //chart.ChartAreas[index].AxisX.ScrollBar.Size = 15;
                //// 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
                //chart.ChartAreas[index].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                //chart.ChartAreas[index].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
                //// 设置自动放大与缩小的最小量
                //chart.ChartAreas[index].AxisX.ScaleView.SmallScrollSize = double.NaN;
                //chart.ChartAreas[index].AxisX.ScaleView.SmallScrollMinSize = 1;
                ////设置刻度间隔
                ////chart.ChartAreas[0].AxisX.Interval = 10;
                ////将X轴上格网取消
                //chart.ChartAreas[index].AxisX.MajorGrid.Enabled = false;
            
                chart.DataBind();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        #endregion


        #region 绘制曲线函数
        /// <summary>
        　　　　/// 绘制曲线函数
        /// </summary>
        /// <param name="listX">X值集合</param>
        /// <param name="listY">Y值集合</param>
        /// <param name="chart">Chart控件</param>
        private static void DrawSplineEx(List<decimal> listX, List<decimal> listY, Chart chart, String chartName,Color color, SeriesChartType chartType)
        {
            try
            {
                var serial = new Series(chartName)
                {
                    ChartType = chartType,
                    Color = color
                };
     
                serial.Points.DataBindXY(listX,listY);
                chart.Series.Add(serial);
                chart.DataBind();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        #endregion



        public static void DrawData(Chart chart, List<TestPoint> list, string areaName)
        {
            //画出理论值
            DrawSplineEx(list.Select(item => item.Angle).ToList(), list.Select(item => item.UpperV).ToList(), chart, areaName+"-理论值", Color.Green, SeriesChartType.Spline);
            //画出上限
            DrawSplineEx(list.Select(item => item.Angle).ToList(), list.Select(item => item.UpperV).ToList(), chart, areaName+"-上限", Color.Red, SeriesChartType.Spline);
            //画出下限
            DrawSplineEx(list.Select(item => item.Angle).ToList(), list.Select(item => item.DownV).ToList(), chart, areaName+"-下限", Color.Red, SeriesChartType.Spline);
            //采集数据
            DrawSplineEx(list.Select(item => item.Angle).ToList(), list.Select(item => item.ActualV).ToList(), chart, areaName+"-采集点", Color.DeepSkyBlue, SeriesChartType.Point);
        }
      
    }
}
