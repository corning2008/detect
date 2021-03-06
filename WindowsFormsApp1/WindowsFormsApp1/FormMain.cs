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
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {

        private SerialPort _serialPort = null;
        public delegate void Displaydelegate(byte[] InputBuf);

        public Displaydelegate disp_delegate;

        public ProgressBar GetProgressBar()
        {
            return this.progressBar;
        }

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
                Bitmap bp = new Bitmap(awidth, aheight);
                splitSpan1.DrawToBitmap(bp, new Rectangle(0, 0, awidth, aheight));
                e.Graphics.DrawImage(bp, (pwidht - bp.Width) / 2, 0, new RectangleF(0, currentY, bp.Width, bp.Height), GraphicsUnit.Pixel);
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
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));
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
                if (null != _plcSerialPort)
                {
                    _plcSerialPort.Close();
                    _plcSerialPort = null;
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
            //波特率
            var rateList = GetRateList();
            this.comboBoxRate.DataSource = rateList;
            //获取配置的参数
            var portName = AppConfig.GetValue("com");
            if (!string.IsNullOrEmpty(portName))
            {
                for (var i = 0; i < serialPortList.Count; i++)
                {
                    if (serialPortList[i] == portName)
                    {
                        cmbSerialPort.SelectedIndex = i;
                    }
                }
            }




        }


        public List<int> GetRateList()
        {
            var list = new List<int>();
            list.Add(19200);
            list.Add(9600);
            return list;
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

        //plc的串口
        PLCSerialPort _plcSerialPort = null;

        private void ReadTestData()
        {
            this.progressBar.Value = 0;
            //MessageBox.Show("正在采集数据，请稍后。。。");
            if (false == hasInit)
            {
                MessageBox.Show("请先读取参数");
                return;
            }
            //开始检测之前首先要清空数据
            ClearDrawData();
            var portName = cmbSerialPort.Text;
            var rate = int.Parse(comboBoxRate.Text);
            //首先判断端口是否打开
            if (null != _plcSerialPort)
            {
                _plcSerialPort.Close();
                _plcSerialPort = null;
            }
            //判断串口是否存在
            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("请选择串口");
                return;
            }
            _plcSerialPort = new PLCSerialPort(portName, rate, null);
            //打开串口
            if (!_plcSerialPort.Open())
            {
                throw new Exception("打开串口失败");
            }

            Task.Factory.StartNew(() =>
            {
                try
                {
                    //开启检测的工
                    this.Invoke(new Action(() =>
                    {
                        this.cmbSerialPort.Enabled = false;
                        this.btnConfirm.Enabled = false;
                    }));

                    //在开始测试之前需要发送测试命令
                    SetValue((ushort)RegisterSetting.测试命令, 1, _plcSerialPort);
                    Thread.Sleep(200);
                    //开始读取,读取采集的状态, 如果采集到数据就把数据呈现出来
                    SetSystemStatus("等待测试");

                    try
                    {
                        //开始检测之前首先要清空数据
                        ClearDrawData();

                        this.Invoke(new Action(() => { btnConfirm.Enabled = false; }));
                        this.isReadingStatus = true;
                        //
                        var valueIndex = 0;
                        while (isReadingStatus)
                        {
                            valueIndex++;
                            this.Invoke(new Action(() =>
                            {
                                this.progressBar.Value = valueIndex;
                            }));
                            byte value = _plcSerialPort.GetD10Status();
                            Console.WriteLine($"D10状态：{value}");
                            //呈现测试的结果
                            ShowTestResult(value);
                            //已经检测完毕
                            if (value == 2)
                            {
                                //获取运行的参数，开始计算
                                GetRunParameter();
                                //开始检测
                                BeginWork();
                                break;
                            }
                            if (value == 6)
                            {
                                MessageBox.Show("长时间没有响应");
                                break;
                            }

                            Thread.Sleep(2000);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.btnConfirm.Enabled = true;
                }
            });
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
                //开始读取数据
                ReadTestData();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("读取数据超时，是否重新读取数据?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    btnConfirm_Click(null, null);
                }
            }


        }


        private void ShowTestResult(byte value)
        {
            if (0 == value)
            {
                SetSystemStatus("等待测试");
                return;
            }
            if (1 == value)
            {
                SetSystemStatus("正在测试");
                return;
            }
            if (2 == value)
            {
                SetSystemStatus("测试完成");
                return;
            }
            if (3 == value)
            {
                SetSystemStatus("总阻正超");
                return;
            }
            if (4 == value)
            {
                SetSystemStatus("总阻负超");
                return;
            }
            if (5 == value)
            {
                SetSystemStatus("伺服故障");
                return;
            }
            if (6 == value)
            {
                SetSystemStatus("伺服长时间不到位");
                return;
            }
            SetSystemStatus("未知状态");
        }

        private void SetSystemStatus(string value)
        {
            this.Invoke(new Action(() =>
            {
                systmStatus.Text = value;
            }));
        }

        private void ClearDrawData()
        {
            //清空数据源数据
            this.Invoke(new Action(() =>
            {
                this.dataGridView.DataSource = new List<TestPoint>();
            }));
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
            //对采集的数据进行分析处理
            AnalyzeData(this.myChart, int.Parse(tbNumber.Text), 0, this._allAngle, decimal.Parse(tbOffset.Text));

            this.Invoke(new Action(() =>
            {
                //获取functionid
                var functionId = AppSettingTool.GetFunctionId();
                if (0 == functionId)
                {
                    //加载线性曲线
                    //计算曲线误差
                    var newDataList = TestPoint.ComputeLineErrorValue(_dataSource, _uMax, _uMin);
                    //删除数据
                    ClearDrawData();
                    //加载数据
                    RefreshLineErrorData(newDataList);
                    //打印报表数据
                    ExportData(_dataSource);
                }
                if (1 == functionId)
                {
                    //加载电压曲线
                    ClearDrawData();
                    //刷新数据
                    RefreshVData(_dataSource);
                    //打印报表
                    ExportData(_dataSource);
                }
                MessageBox.Show("采集完成");
            }));
        }

        private bool ValidateParameter()
        {
            var number = int.Parse(this.tbNumber.Text);
            if (number <= 0)
            {
                MessageBox.Show("测试的点数不能为空");
                return false;
            }
            if (number > 3072)
            {
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
            if (decimal.Parse(upValue.Text) < 0 || decimal.Parse(upValue.Text) > 25)
            {
                MessageBox.Show("上行程的有效范围0-25");
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


        /// <summary>
        /// 读取运行参数
        /// </summary>
        private void GetRunParameter()
        {
            this._allAngle = BitConverter.ToUInt16(_plcSerialPort.ReadDataFromPLC((int)RegisterSetting.角度, 2, ReadTimeOut), 0) / 100m;
            this.Invoke(new Action(() =>
            {
                this.tbAllAngle.Text = _allAngle + "";
            }));
            this._upError = BitConverter.ToUInt16(_plcSerialPort.ReadDataFromPLC((int)RegisterSetting.总阻最大正向允许误差, 2, ReadTimeOut), 0) / 100m;
            Console.WriteLine("上限误差：" + _upError);
            this._downError = BitConverter.ToUInt16(_plcSerialPort.ReadDataFromPLC((int)RegisterSetting.总阻最大负向允许误差, 2, ReadTimeOut), 0) / 100m;
            Console.WriteLine("下限误差：" + _downError);


            //获取电压的上下限
            var uMax = BitConverter.ToInt16(_plcSerialPort.ReadDataFromPLC((int)RegisterSetting.电压上限, 2, ReadTimeOut), 0);
            Console.WriteLine($"电压的上限：{uMax}--{uMax / (100m)}");
            this._uMax = (uMax / 100m);
            var uMin = BitConverter.ToInt16(_plcSerialPort.ReadDataFromPLC((int)RegisterSetting.电压下限, 2, ReadTimeOut), 0);
            Console.WriteLine($"电压的上限：{uMin}--{uMin / (100m)}");
            this._uMin = (uMin / 100m);
        }

        private void GetInitValue(PLCSerialPort moduleBus)
        {
            //角度
            InitValue((ushort)RegisterSetting.角度, this.tbAllAngle, _plcSerialPort, 100);

            //点数
            InitValue((ushort)RegisterSetting.测试点数, this.tbNumber, _plcSerialPort);
            //电阻
            InitValue((ushort)RegisterSetting.总阻设定, this.tbResistance, _plcSerialPort, 100);
            //角度1
            InitValue((ushort)RegisterSetting.角度下限, this.tbAngleOne, _plcSerialPort, 10);
            //角度2
            InitValue((ushort)RegisterSetting.角度下限, this.tbAngleTwo, _plcSerialPort, 10);
            //旋转速度
            InitValue((ushort)RegisterSetting.旋转速度, this.tbAngleTransfer, _plcSerialPort, 10);
            //斜率
            InitValue((ushort)RegisterSetting.斜率, this.tbSlope, _plcSerialPort, 100);
            //最大允许误差
            InitValue((ushort)RegisterSetting.线性允许误差, this.tbOffset, _plcSerialPort, 100);
            //极限电压
            //InitValue((ushort)RegisterSetting.极限电压,this.tbV, _plcSerialPort, 100);
            //测试角度差
            InitValue((ushort)RegisterSetting.零位偏差值, this.offsetAngle, _plcSerialPort);
            //正向误差
            InitValue((ushort)RegisterSetting.总阻最大正向允许误差, this.forwardError, _plcSerialPort, 100);

            //负向误差
            InitValue((ushort)RegisterSetting.总阻最大负向允许误差, this.backwardError, _plcSerialPort, 100);


            //零阻误差
            InitValue((ushort)RegisterSetting.零阻最大允许误差, this.zeroError, _plcSerialPort);
            //测量间隔
            InitValue((ushort)RegisterSetting.测量间隔, this.tbIntervalAngle, _plcSerialPort);

            //上行程
            InitValue((ushort)RegisterSetting.上行程, this.upValue, _plcSerialPort, 100);
            this._upValue = 10 * decimal.Parse(upValue.Text);

            //下行程
            InitValue((ushort)RegisterSetting.下行程, this.downValue, _plcSerialPort, 100);
            this._downValue = 10 * (1 - decimal.Parse(downValue.Text));


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

        private readonly int ReadTimeOut = 3000;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        /// <param name="modbus"></param>
        /// <param name="zoomFlag"></param>
        /// <param name="numberByte">读取的字节数据</param>
        private void InitValue(int address, TextBox textBox, PLCSerialPort modbus, int zoomFlag = 1, int numberByte = 2)
        {
            byte[] value = modbus.ReadDataFromPLC(address, numberByte, ReadTimeOut);
            //Int16 dataValue = BitConverter.ToInt16(value, 0);
            //Int16 dataValue = (Int16)value[0];
            GetReadValue(out int dataValue, numberByte, value);
            this.Invoke(new Action(() =>
            {
                textBox.Text = ((decimal)(dataValue / (zoomFlag * 1.0f))) + "";
            }));

            Console.WriteLine($"读取的数据:{dataValue} 转化后的数据：{textBox.Text}");
        }

        private void GetReadValue(out int dataValue, int numberByte, byte[] bytes)
        {
            if (numberByte == 1)
            {
                dataValue = (int)bytes[0];
                return;
            }
            if (numberByte == 2)
            {
                dataValue = BitConverter.ToUInt16(bytes, 0);
                return;
            }
            dataValue = 0;
        }

        /// <summary>
        /// 设置系统的参数
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="modbus"></param>
        private void SetValue(ushort address, byte value, PLCSerialPort modbus)
        {
            //  modbus.WriteMultipleRegisters(ConstPara.SlaveId,address,new ushort[]{value});
            _plcSerialPort.WriteDatasEx(address, new byte[] { value }, 3000);
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
            initTbRange(300, 1, e, this.tbNumber);
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
            initTbRange(5000, 1, e, this.tbResistance);
        }

        private void tbAngleOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(0, -160, e, this.tbAngleOne);
        }

        private void tbAngleTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(160, 1, e, this.tbAngleTwo);
        }

        private void tbAngleTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(1000, 5, e, this.tbAngleTransfer);
        }

        private void tbSlope_KeyPress(object sender, KeyPressEventArgs e)
        {
            initTbRange(25, 10, e, this.tbSlope);
        }





        private void tbResistance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(_plcSerialPort, (ushort)RegisterSetting.总阻设定, (TextBox)sender), 100);
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
                    new SettingResistance(_plcSerialPort, (ushort)RegisterSetting.角度下限, (TextBox)sender), 10);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.角度上限, (TextBox)sender), 10);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.旋转速度, (TextBox)sender), 10);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.测试点数, (TextBox)sender));
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.斜率, (TextBox)sender), 100);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.上行程, (TextBox)sender), 100);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.线性允许误差, (TextBox)sender), 100);
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

            return _plcSerialPort.GetTestVList(length, this);
        }

        /// <summary>
        /// 对采集的数据进行分析处理
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="number"></param>
        /// <param name="angleOne"></param>
        /// <param name="angleTwo"></param>
        /// <param name="offSetLine"></param>
        private void AnalyzeData(Chart chart, int number, decimal angleOne, decimal angleTwo, decimal offSetLine)
        {
            //读取到测试的结果
            var vList = GetTestDataList();
            var list = TestPoint.GetTestPointList(vList, angleOne, 1 * angleTwo, offSetLine, _uMax, _uMin, _upError, _downError);

            this._dataSource = list;
            //查找误差最大的数据
            TestPoint.FindMaxErrorData(list);
           
          

        }


        private void ExportData(List<TestPoint> list)
        {
            this.Invoke(new Action(() =>
            {
                //导出数据
                ExcelTool.TableToExcel(TestPoint.ConvertToDataTable(list), list, GetFileName(), GetBitmap());
            }));
        }


        private List<TestPoint> _dataSource = new List<TestPoint>();
        private decimal _uMax;
        private decimal _uMin;
        //理论上限电压
        private decimal _upValue;
        //理论下线电压
        private decimal _downValue;
        private decimal _upError;
        private decimal _downError;
        //角度的范围
        private decimal _allAngle;

        private void RefreshVData(List<TestPoint> dataList)
        {
            //_dataSource.Clear();
            //_dataSource.AddRange(dataList);
            dataGridView.DataSource = dataList;

            //更新曲线图
            DrawClass.DrawVData(myChart, dataList, "数据1");
        }

        private string GetFileName()
        {
            //判断是否存在文件夹，如果不存在的话就创建一个文件夹 
            var outDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "output";
            if (!Directory.Exists(outDirectory))
            {
                Directory.CreateDirectory(outDirectory);
            }
            return System.AppDomain.CurrentDomain.BaseDirectory + "output/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
        }

        private int GetNumberToRead()
        {
            return int.Parse(this.tbNumber.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var portName = cmbSerialPort.Text;
                var rate = int.Parse(comboBoxRate.Text);
                Console.WriteLine("rate:" + rate);
                //首先判断端口是否打开
                if (null != _plcSerialPort)
                {
                    _plcSerialPort.Close();
                    _plcSerialPort = null;
                }
                //判断串口是否存在
                if (string.IsNullOrEmpty(portName))
                {
                    MessageBox.Show("请选择串口");
                    return;
                }
                Console.WriteLine(rate);
                _plcSerialPort = new PLCSerialPort(portName, rate, null);
                //打开串口
                if (!_plcSerialPort.Open())
                {
                    throw new Exception("打开串口失败");
                }

                //判断是否已经从设备中读取参数
                // if (false == this.hasInit)
                {
                    if (false == InitParameter())
                    {
                        return;
                    }
                    hasInit = true;
                    //保存设置的参数
                    AppConfig.SetValue("com", portName);
                }

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
            if (e.RowIndex < this.dataGridView.Rows.Count)
            {
                DataGridViewRow dgrSingle = this.dataGridView.Rows[e.RowIndex];
                try
                {
                    var testPoint = dataList[e.RowIndex];
                    if (testPoint.LineError > _upError || testPoint.LineError < -1 * _downError)
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }

                    //如果误差最大的话,就标记为蓝色
                    //if (testPoint.IsMaxError == true)
                    //{
                    //    dgrSingle.DefaultCellStyle.ForeColor = Color.Blue;
                    //}
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

                //获取初始化的数据
                GetInitValue(_plcSerialPort);
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

            try
            {

                //获取初始化的数据
                GetInitValue(_plcSerialPort);
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

        private void SetRegisterValue(ushort address, ushort value)
        {

        }


        private void offsetAngle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.零位偏差值, (TextBox)sender));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ForwardError_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.总阻最大正向允许误差, (TextBox)sender), 100);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.总阻最大负向允许误差, (TextBox)sender), 100);
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
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.零阻最大允许误差, (TextBox)sender));
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
                    _dataSource = dataList;
                    if (dataList.Count > 0)
                    {
                        //加载数据
                        ClearDrawData();
                        //RefreshData(dataList);
                        RefreshLineErrorData(dataList);
                        MessageBox.Show("加载数据成功");
                    }
                }
            }
            catch (Exception ex)
            {
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
                ClearDrawData();
                //加载数据
                RefreshVData(dataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbIntervalAngle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.测量间隔, (TextBox)sender), 10);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void systmStatus_Click(object sender, EventArgs e)
        {

        }

        private void 线性度曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //修改FunctionId
                AppSettingTool.SetFunctionId(0);
                //查询数据是否存在
                if (this._dataSource.Count == 0)
                {
                    MessageBox.Show("请获取采集数据,再进行操作");
                    return;
                }
                //计算曲线误差
                // var newDataList = TestPoint.ComputeLineErrorValue(_dataSource,_uMax,_uMin);
                //删除数据
                ClearDrawData();
                //加载数据
                RefreshLineErrorData(_dataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshLineErrorData(List<TestPoint> dataList)
        {
            //_dataSource.Clear();
            //_dataSource.AddRange(dataList);
            this.Invoke(new Action(() =>
            {
                dataGridView.DataSource = dataList;
                dataGridView.Columns[2].Visible = true;

                //更新曲线图
                DrawClass.DrawLineError(myChart, dataList, "线性曲线", _upError, _downError);
            }));

        }

        private void downValue_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.下行程, (TextBox)sender), 100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbAllAngle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormSetting form = new FormSetting();
                form.SetValue(((TextBox)sender).Text,
                    new SettingResistance(this._plcSerialPort, (ushort)RegisterSetting.角度, (TextBox)sender), 100);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 电压值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //修改FunctionId
                AppSettingTool.SetFunctionId(1);
                //查询数据是否存在
                if (this._dataSource.Count == 0)
                {
                    MessageBox.Show("请获取采集数据,再进行操作");
                    return;
                }
                ClearDrawData();
                //刷新数据
                RefreshVData(_dataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}