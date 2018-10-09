﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.model;
using Modbus.Device;
using NPOI.Util;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
       
        private SerialPort _serialPort = null;
        public delegate void Displaydelegate(byte[] InputBuf);
     
        public Displaydelegate disp_delegate;
        private IModbusMaster moduleBus = null;
        /// <summary>
        /// 是否已经读取配置的参数
        /// </summary>
        private bool hasInit = false;
        private DataGridViewColumnCollection columns;
        public Main()
        {
            InitializeComponent();

            InitChart(myChart);

          

        }

        private void InitChart(Chart chart)
        {
            // Zoom into the X axis
            //chart.ChartAreas[0].AxisX.ScaleView.Zoom(1, 1);
            // Enable range selection and zooming end user interface
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //将滚动内嵌到坐标轴中
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            // 设置滚动条的大小
            chart.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            chart.ChartAreas[0].AxisY.ScrollBar.Size = 10;
            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            // 设置自动放大与缩小的最小量
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 10;
            chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
            chart.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 10;
        }

       

        /// <summary>
        /// 是否正在读取状态
        /// </summary>
        private bool isReadingStatus = false;

        private int currentY = 0;
        private SerialPort port;

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var splitSpan1 = splitContainer1.Panel1;
            var awidth = splitSpan1.DisplayRectangle.Width;
            var aheight = splitSpan1.DisplayRectangle.Height;
            PrintDocument pd = sender as PrintDocument;
            int pwidht = pd.DefaultPageSettings.Bounds.Width;
            int pheight = pd.DefaultPageSettings.Bounds.Height;

            if (currentY < aheight)
            {
                Bitmap bp = new Bitmap(awidth,aheight);
                splitSpan1.DrawToBitmap(bp,new Rectangle(0,0,awidth,aheight));
                e.Graphics.DrawImage(bp,(pwidht-bp.Width)/2,0,new RectangleF(0,currentY,bp.Width,bp.Height), GraphicsUnit.Pixel);
                currentY += pheight;
                if (aheight - pheight > 0)
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                e.HasMorePages = false;
            }

           
        }

        /// <summary>
        /// 截屏
        /// </summary>
        /// <returns></returns>
        private Bitmap GetBitmap()
        {
            var panel = this.panelChart;
            Bitmap bitmap = new Bitmap(panel.Width,panel.Height);
            panel.DrawToBitmap(bitmap,new Rectangle(0,0,panel.Width,panel.Height));
            return bitmap;
        }

       


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = GetOpenFileName();
                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }

                StreamReader sr = new StreamReader(fileName, Encoding.Default);

               

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String GetOpenFileName()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }

            return null;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //释放资源
                if (null != moduleBus)
                {
                    moduleBus.Dispose();
                }
                //关闭串口
                if (null != this.port && this.port.IsOpen)
                {
                    this.port.Close();
                    this.port.Dispose();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
           
          
        }

      

        private void Main_Load(object sender, EventArgs e)
        {
            //获取所有的串口
            var serialPortList = GetSerialPortList();
            this.cmbSerialPort.DataSource = serialPortList;
           
        }

     

        private List<String> GetSerialPortList()
        {
            var list = new List<String>();
            foreach (var name in SerialPort.GetPortNames())
            {
                list.Add(name);
            }

            return list;
        }

        private Boolean HasOpenPort()
        {
            try
            {
                if (null == this.port)
                {
                    this.port = GetPort();
                    if (port.IsOpen)
                    {
                        MessageBox.Show("端口已经被占用");
                        this.port = null;
                        return false;
                    }

                    //如果没有被占用就打开端口
                    port.Open();
                    this.lbStatus.Text = "端口打开成功";
                    this.cmbSerialPort.Enabled = false;
                    return true;
                }
                else
                {
                    //如果已经绑定端口, 查看是否已经工作
                    if (this.port.IsOpen)
                    {
                        return true;
                    }
                    else
                    {
                        //如果端口没有打开, 提示用户重新打开程序
                        MessageBox.Show("请关闭程序后重新打开");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                this.port = null;
                //如果出现异常,就返回false
                MessageBox.Show(ex.Message);
                return false;
            }

        }


      
        /// <summary>
        /// 开始检测程序的工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //首先判断端口是否打开
                if (false == HasOpenPort())
                {
                    return;
                }

                //判断是否已经从设备中读取参数
                if (false == this.hasInit)
                {
                    if (false == InitParameter())
                    {
                        return;
                    }
                }
                //
                //开启检测的工
                this.cmbSerialPort.Enabled = false;
                this.btnConfirm.Enabled = false;
                //在开始测试之前需要发送测试命令
                SetValue((ushort)RegisterSetting.测试命令,1,this.moduleBus);
                //开始读取,读取采集的状态, 如果采集到数据就把数据呈现出来
                SetSystemStatus("等待测试");
                Task.Factory.StartNew(()=>
                {
                    try
                    {
                        //开始检测之前首先要清空数据
                        ClearData();

                        this.Invoke(new Action(() => { btnConfirm.Enabled = false; }));
                        this.isReadingStatus = true;
                        //
                        while (isReadingStatus)
                        {
                            ushort[] value = moduleBus.ReadHoldingRegisters(ConstPara.SlaveId, (ushort) RegisterSetting.测试状态, 1);
                            //呈现测试的结果
                            ShowTestResult(value[0]);
                            //已经检测完毕
                            if (value[0] == 2)
                            {
                                this.Invoke(new Action(() => { BeginWork(); }));
                                break;
                            }
                          
                            Thread.Sleep(500);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() => { MessageBox.Show(ex.Message); }));
                    }
                    finally
                    {
                        isReadingStatus = false;
                        //按钮恢复状态
                        this.Invoke(new Action(() => { this.btnConfirm.Enabled = true; }));
                    }


                });
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.btnConfirm.Enabled = true;
            }
        }


        private void ShowTestResult(ushort value) {
            if (0 == value) {
                SetSystemStatus("等待测试");
                return;
            }
            if (1 == value) {
                SetSystemStatus("正在测试");
                return;
            }
            if (2 == value){
                SetSystemStatus("测试完成");
                return;
            }
            if (3 == value) {
                SetSystemStatus("总阻正超");
                return;
            }
            if (4 == value){
                SetSystemStatus("总阻负超");
                return;
            }
            if (5 == value) {
                SetSystemStatus("伺服故障");
                return;
            }
            if (6 == value) {
                SetSystemStatus("伺服长时间不到位");
                return;
            }
            SetSystemStatus("未知状态");
        }

        private void SetSystemStatus(string value)
        {
            this.Invoke(new Action(() => {
                systmStatus.Text = value;
            }));
        }

        private void ClearData()
        {
            //清空数据源数据
            this.Invoke(new Action(() => {
                this.dataGridView.DataSource = new List<TestPoint>(); }));
            //清空图标数据
            this.Invoke(new Action(() =>
            {
                this.myChart.Series.Clear();
            }));
        }

        private void BeginWork()
        {
            //首先对参数进行基本的校验
            if (!ValidateParameter())
            {
                return;
            }
            //
            DrawChart(this.myChart,int.Parse(tbNumber.Text),int.Parse(tbAngleOne.Text),int.Parse(tbAngleTwo.Text),decimal.Parse(tbOffset.Text));
        }

        private bool ValidateParameter()
        {
            var number = int.Parse(this.tbNumber.Text);
            if (number <= 0)
            {
                MessageBox.Show("测试的点数不能为空");
                return false;
            }
            if (number > 3072) {
                MessageBox.Show("测试的点数不能大于3072");
                return false;
            }
            //判断角度的上限和下限
            if (decimal.Parse(tbAngleOne.Text) < 0)
            {
                MessageBox.Show("数据下限不能小于0");
                return false;
            }
            //判断上限
            if (decimal.Parse(tbAngleTwo.Text) < 0)
            {
                MessageBox.Show("数据上限不能小于0");
                return false;
            }
            //线性误差
            if (decimal.Parse(tbOffset.Text) < 0)
            {
                MessageBox.Show("线性误差不能小于0");
                return false;
            }
            //极限电压
            if (decimal.Parse(tbV.Text) < 0 || decimal.Parse(tbV.Text) >2)
            {
                MessageBox.Show("极限电压不能小于0或者极限电压不能大于200");
                return false;
            }
            //测试点数


            return true;
        }

        public void DispUI(byte[] InputBuf)
        {
            //textBox1.Text = Convert.ToString(InputBuf);  

            ASCIIEncoding encoding = new ASCIIEncoding();
            //richTextBox1.Text += encoding.GetString(InputBuf)+System.Environment.NewLine;
        }


       

      

        private IModbusMaster GetModbusMaster(SerialPort port)
        {
            IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
            master.Transport.ReadTimeout = 1000;//读取数据超时1000ms
            master.Transport.WriteTimeout = 1000;//写入数据超时100ms
            master.Transport.Retries = 3;//重试次数
            master.Transport.WaitToRetryMilliseconds = 100;//重试间隔
            return master;
        }

       
       
      
        private void GetInitValue(IModbusMaster moduleBus)
        {
             //点数
            InitValue((ushort) RegisterSetting.测试点数, this.tbNumber, moduleBus);
            //电阻
            InitValue((ushort) RegisterSetting.总阻设定, this.tbResistance, moduleBus,100);
            //角度1
            InitValue((ushort) RegisterSetting.角度下限, this.tbAngleOne, moduleBus);
            //角度2
            InitValue((ushort) RegisterSetting.角度下限, this.tbAngleTwo, moduleBus);
            //旋转速度
            InitValue((ushort) RegisterSetting.旋转速度, this.tbAngleTransfer, moduleBus,10);
            //斜率
            InitValue((ushort) RegisterSetting.斜率, this.tbSlope, moduleBus,100);
            //最大允许误差
            InitValue((ushort) RegisterSetting.线性允许误差, this.tbOffset, moduleBus,100);
            //极限电压
            InitValue((ushort)RegisterSetting.极限电压,this.tbV,moduleBus,100);
            //测试角度差
            InitValue((ushort)RegisterSetting.零位偏差值,this.offsetAngle,moduleBus);
            //正向误差
            InitValue((ushort)RegisterSetting.总阻最大正向允许误差, this.forwardError, moduleBus,10);
            //负向误差
            InitValue((ushort)RegisterSetting.总阻最大负向允许误差, this.backwardError, moduleBus,10);
            //零阻误差
            InitValue((ushort)RegisterSetting.零阻最大允许误差, this.zeroError, moduleBus);
            //测量间隔
            InitValue((ushort)RegisterSetting.测量间隔,this.tbIntervalAngle,moduleBus,10);
        }

        private void myChart_GetToolTipText(object sender, ToolTipEventArgs e)
        {

            HitTestResult myTestResult = myChart.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            //获取命中测试的结果         
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string XValue = dp.XValue.ToString();//获取数据点的X值    
                string YValue = dp.YValues[0].ToString();//获取数据点的Y值   
                e.Text = "角度:" + XValue + "\r\n电压" + YValue;
            }
        }

        private void InitValue(ushort address, TextBox textBox,IModbusMaster modbus,int zoomFlag=1)
        {
            ushort[] value = modbus.ReadHoldingRegisters(ConstPara.SlaveId, address, 1);
            textBox.Text = ((decimal)(value[0]/(zoomFlag*1.0f))) + "";
        }

        /// <summary>
        /// 设置系统的参数
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="modbus"></param>
        private void SetValue(ushort address, ushort value, IModbusMaster modbus)
        {
            modbus.WriteMultipleRegisters(ConstPara.SlaveId,address,new ushort[]{value});
        }

        


        private SerialPort GetPort()
        {
            
            var port = new SerialPort(this.cmbSerialPort.Text);
            //打开端口开始读取数据
            port.BaudRate = 19200;
            port.DataBits = 8;
            port.Parity = Parity.Even;
            port.StopBits = StopBits.One;
            return port;
        }

        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(300,1,e,this.tbNumber);
        }


        private void initTbRange(int max, int min, KeyPressEventArgs e, TextBox textBox)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.KeyChar))
            {
                int v = int.Parse(textBox.Text + e.KeyChar);
                if (v > max || v < min)
                {
                    e.Handled = true;
                }
            }
        }

       

        private void tbResistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(5000,1,e,this.tbResistance);
        }

        private void tbAngleOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(0,-160,e,this.tbAngleOne);
        }

        private void tbAngleTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(160,1,e,this.tbAngleTwo);
        }

        private void tbAngleTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(1000,5,e,this.tbAngleTransfer);
        }

        private void tbSlope_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(25,10,e,this.tbSlope);
        }

     

       

        private void tbResistance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox) sender).Text,
                    new SettingResistance(this.moduleBus, (ushort) RegisterSetting.总阻设定, (TextBox) sender),100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbResistance_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 角度1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAngleOne_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.角度下限, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbAngleTwo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.角度上限, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbAngleTransfer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.旋转速度, (TextBox)sender),10);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbNumber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.测试点数, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbSlope_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.斜率, (TextBox)sender),100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.极限电压, (TextBox)sender),100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbOffset_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.线性允许误差, (TextBox)sender),100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取测试结果
        /// </summary>
        /// <returns></returns>
        private List<decimal> GetTestDataList()
        {
            var resultList = new List<decimal>();
            var length = int.Parse(this.tbNumber.Text);
            var hasRead = 0;
            ushort address = (ushort)RegisterSetting.返回结果;
            while (hasRead < length) {
                ushort[] list = this.moduleBus.ReadHoldingRegisters(ConstPara.SlaveId, address,length-hasRead >50?(ushort)50:(ushort)(length-hasRead) );
                foreach (var item in list)
                {
                    resultList.Add(Math.Round((decimal)(item / 100.0f),2));
                }
                hasRead += list.Length;
                address += (ushort)list.Length;
            }
            return resultList;
        }

        private void DrawChart(Chart chart, int number,int angleOne,int angleTwo,decimal offSetLine)
        {
            var vList = GetTestDataList();

            var list = TestPoint.GetTestPointList(vList, -1*angleOne, 1*angleTwo,offSetLine);
            //查找误差最大的数据
            TestPoint.FindMaxErrorData(list);
            //刷新数据
            RefreshData(list);
            //导出数据
            ExcelTool.TableToExcel(TestPoint.ConvertToDataTable(list),list,GetFileName(),GetBitmap());
        }


        private List<TestPoint> _dataSource = new List<TestPoint>();

        private void RefreshData(List<TestPoint> dataList)
        {
            _dataSource.Clear();
            _dataSource.AddRange(dataList);
            dataGridView.DataSource = _dataSource;
            //更新曲线图
            DrawClass.DrawData(myChart, _dataSource, "数据1");
        }

        private string GetFileName()
        {
            //判断是否存在文件夹，如果不存在的话就创建一个文件夹 
            var outDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "output";
            if (!Directory.Exists(outDirectory))
            {
                Directory.CreateDirectory(outDirectory);
            }
            return System.AppDomain.CurrentDomain.BaseDirectory+"output/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
        }

        private int GetNumberToRead()
        {
            return int.Parse(this.tbNumber.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                isReadingStatus = false;
                //向设备发送停止测试的命令
                SetValue((ushort)RegisterSetting.测试命令, 2, this.moduleBus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dataList = this.dataGridView.DataSource as List<TestPoint>;
            //
            if (dataList == null)
            {
                return;
            }
            TestPoint.FindMaxErrorData(dataList);
            if (e.RowIndex < this.dataGridView.Rows.Count )
            {
                DataGridViewRow dgrSingle = this.dataGridView.Rows[e.RowIndex];
                try
                {
                    var testPoint = dataList[e.RowIndex];
                    if (testPoint.ActualV > testPoint.UpperV || testPoint.ActualV < testPoint.DownV)
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    //如果误差最大的话,就标记为蓝色
                    if (testPoint.IsMaxError == true)
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private Boolean InitParameter()
        {
            try
            {
                //打开串口进行读取数据
                //this.btnInit.Enabled = false;
                moduleBus = GetModbusMaster(port);
                //获取初始化的数据
                GetInitValue(moduleBus);
                //已经从设备中读取参数
                this.hasInit = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void 参数读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == this.port || !port.IsOpen)
            {
                MessageBox.Show("请先打开端口");
                return;
            }
            try
            {
                //打开串口进行读取数据
                //this.btnInit.Enabled = false;
                moduleBus = GetModbusMaster(port);
                //获取初始化的数据
                GetInitValue(moduleBus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.btnInit.Enabled = true;
            }
        }

        private void SetRegisterValue(ushort address, ushort value) {
            moduleBus.WriteMultipleRegisters(ConstPara.SlaveId, address, new ushort[] { value });
        }


        private void offsetAngle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.零位偏差值, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ForwardError_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.总阻最大正向允许误差, (TextBox)sender),10);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackwardError_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.总阻最大负向允许误差, (TextBox)sender),10);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ZeroError_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.零阻最大允许误差, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "excel|*.xls";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<TestPoint> dataList = ExcelTool.ExcelToDataList(dialog.FileName, null, true);
                    if (dataList.Count > 0)
                    {
                        //加载数据
                        ClearData();
                        RefreshData(dataList);
                        MessageBox.Show("加载数据成功");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }      
        }

        private void 相对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //查询数据是否存在
                if (this._dataSource.Count == 0)
                {
                    MessageBox.Show("请获取采集数据,再进行操作");
                    return;
                }

                List<TestPoint> dataList = TestPoint.GetRelativePoints(_dataSource);
                //删除数据
                ClearData();
                //加载数据
                RefreshData(dataList);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbIntervalAngle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this.moduleBus, (ushort)RegisterSetting.测量间隔, (TextBox)sender), 10);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}