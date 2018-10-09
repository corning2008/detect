namespace WindowsFormsApp1
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelChart = new System.Windows.Forms.Panel();
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.systmStatus = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.zeroError = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.backwardError = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.forwardError = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.offsetAngle = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tbV = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.tbSlope = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbAngleTransfer = new System.Windows.Forms.TextBox();
            this.tbAngleTwo = new System.Windows.Forms.TextBox();
            this.tbAngleOne = new System.Windows.Forms.TextBox();
            this.tbResistance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.旋转角度 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相对ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdealV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpperV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelChart);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 442);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Angle,
            this.ActualV,
            this.IdealV,
            this.UpperV,
            this.DownV});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(434, 442);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.myChart);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(0, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(629, 442);
            this.panelChart.TabIndex = 5;
            // 
            // myChart
            // 
            chartArea3.AxisY.Maximum = 10D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.CursorX.Interval = 0.01D;
            chartArea3.Name = "ChartArea1";
            this.myChart.ChartAreas.Add(chartArea3);
            this.myChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.myChart.Legends.Add(legend3);
            this.myChart.Location = new System.Drawing.Point(0, 0);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(629, 442);
            this.myChart.TabIndex = 3;
            this.myChart.Text = "chart1";
            title3.Name = "Title1";
            this.myChart.Titles.Add(title3);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm.Location = new System.Drawing.Point(835, 109);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "开始检测";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(886, 25);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialPort.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(851, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.systmStatus);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.zeroError);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.backwardError);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.forwardError);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.offsetAngle);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.tbV);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbSerialPort);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbOffset);
            this.panel1.Controls.Add(this.tbSlope);
            this.panel1.Controls.Add(this.tbNumber);
            this.panel1.Controls.Add(this.tbAngleTransfer);
            this.panel1.Controls.Add(this.tbAngleTwo);
            this.panel1.Controls.Add(this.tbAngleOne);
            this.panel1.Controls.Add(this.tbResistance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.旋转角度);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 171);
            this.panel1.TabIndex = 3;
            // 
            // systmStatus
            // 
            this.systmStatus.AutoSize = true;
            this.systmStatus.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.systmStatus.Location = new System.Drawing.Point(36, 141);
            this.systmStatus.Name = "systmStatus";
            this.systmStatus.Size = new System.Drawing.Size(53, 12);
            this.systmStatus.TabIndex = 41;
            this.systmStatus.Text = "工作状态";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(738, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 40;
            this.label23.Text = "Ω";
            // 
            // zeroError
            // 
            this.zeroError.Location = new System.Drawing.Point(662, 95);
            this.zeroError.Name = "zeroError";
            this.zeroError.ReadOnly = true;
            this.zeroError.Size = new System.Drawing.Size(75, 21);
            this.zeroError.TabIndex = 39;
            this.zeroError.Text = "0";
            this.zeroError.DoubleClick += new System.EventHandler(this.ZeroError_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(599, 98);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 38;
            this.label24.Text = "零阻误差";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(551, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 37;
            this.label21.Text = "0.1%";
            // 
            // backwardError
            // 
            this.backwardError.Location = new System.Drawing.Point(475, 95);
            this.backwardError.Name = "backwardError";
            this.backwardError.ReadOnly = true;
            this.backwardError.Size = new System.Drawing.Size(75, 21);
            this.backwardError.TabIndex = 36;
            this.backwardError.Text = "0";
            this.backwardError.DoubleClick += new System.EventHandler(this.BackwardError_DoubleClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(416, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 35;
            this.label22.Text = "负向误差";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(320, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 34;
            this.label19.Text = "0.1%";
            // 
            // forwardError
            // 
            this.forwardError.Location = new System.Drawing.Point(244, 95);
            this.forwardError.Name = "forwardError";
            this.forwardError.ReadOnly = true;
            this.forwardError.Size = new System.Drawing.Size(75, 21);
            this.forwardError.TabIndex = 33;
            this.forwardError.Text = "0";
            this.forwardError.DoubleClick += new System.EventHandler(this.ForwardError_DoubleClick);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(181, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 32;
            this.label20.Text = "正向误差";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "度";
            // 
            // offsetAngle
            // 
            this.offsetAngle.Location = new System.Drawing.Point(71, 95);
            this.offsetAngle.Name = "offsetAngle";
            this.offsetAngle.ReadOnly = true;
            this.offsetAngle.Size = new System.Drawing.Size(75, 21);
            this.offsetAngle.TabIndex = 30;
            this.offsetAngle.Text = "0";
            this.offsetAngle.DoubleClick += new System.EventHandler(this.offsetAngle_DoubleClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 29;
            this.label18.Text = "零位偏差值";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ForeColor = System.Drawing.Color.Red;
            this.btnExport.Location = new System.Drawing.Point(931, 109);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "停止检测";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(740, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 27;
            this.label17.Text = "0.01V";
            // 
            // tbV
            // 
            this.tbV.Location = new System.Drawing.Point(659, 64);
            this.tbV.Name = "tbV";
            this.tbV.ReadOnly = true;
            this.tbV.Size = new System.Drawing.Size(75, 21);
            this.tbV.TabIndex = 26;
            this.tbV.Text = "0";
            this.tbV.DoubleClick += new System.EventHandler(this.tbV_DoubleClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(599, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 25;
            this.label16.Text = "极限电压";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(556, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "0.01V";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Green;
            this.lbStatus.Location = new System.Drawing.Point(1023, 28);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(29, 12);
            this.lbStatus.TabIndex = 23;
            this.lbStatus.Text = "停止";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "个";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(152, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "10Ω";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "0.01v/度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(555, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(739, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "0.1转/分";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(475, 64);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.ReadOnly = true;
            this.tbOffset.Size = new System.Drawing.Size(75, 21);
            this.tbOffset.TabIndex = 14;
            this.tbOffset.Text = "0";
            this.tbOffset.DoubleClick += new System.EventHandler(this.tbOffset_DoubleClick);
            // 
            // tbSlope
            // 
            this.tbSlope.Location = new System.Drawing.Point(244, 64);
            this.tbSlope.Name = "tbSlope";
            this.tbSlope.ReadOnly = true;
            this.tbSlope.Size = new System.Drawing.Size(75, 21);
            this.tbSlope.TabIndex = 13;
            this.tbSlope.Text = "0";
            this.tbSlope.DoubleClick += new System.EventHandler(this.tbSlope_DoubleClick);
            this.tbSlope.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSlope_KeyPress);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(71, 64);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.tbNumber.Size = new System.Drawing.Size(75, 21);
            this.tbNumber.TabIndex = 12;
            this.tbNumber.Text = "0";
            this.tbNumber.DoubleClick += new System.EventHandler(this.tbNumber_DoubleClick);
            this.tbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // tbAngleTransfer
            // 
            this.tbAngleTransfer.Location = new System.Drawing.Point(658, 25);
            this.tbAngleTransfer.Name = "tbAngleTransfer";
            this.tbAngleTransfer.ReadOnly = true;
            this.tbAngleTransfer.Size = new System.Drawing.Size(75, 21);
            this.tbAngleTransfer.TabIndex = 11;
            this.tbAngleTransfer.Text = "0";
            this.tbAngleTransfer.DoubleClick += new System.EventHandler(this.tbAngleTransfer_DoubleClick);
            this.tbAngleTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleTransfer_KeyPress);
            // 
            // tbAngleTwo
            // 
            this.tbAngleTwo.Location = new System.Drawing.Point(478, 25);
            this.tbAngleTwo.Name = "tbAngleTwo";
            this.tbAngleTwo.ReadOnly = true;
            this.tbAngleTwo.Size = new System.Drawing.Size(75, 21);
            this.tbAngleTwo.TabIndex = 10;
            this.tbAngleTwo.Text = "0";
            this.tbAngleTwo.DoubleClick += new System.EventHandler(this.tbAngleTwo_DoubleClick);
            this.tbAngleTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleTwo_KeyPress);
            // 
            // tbAngleOne
            // 
            this.tbAngleOne.Location = new System.Drawing.Point(244, 25);
            this.tbAngleOne.Name = "tbAngleOne";
            this.tbAngleOne.ReadOnly = true;
            this.tbAngleOne.Size = new System.Drawing.Size(75, 21);
            this.tbAngleOne.TabIndex = 9;
            this.tbAngleOne.Text = "0";
            this.tbAngleOne.DoubleClick += new System.EventHandler(this.tbAngleOne_DoubleClick);
            this.tbAngleOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleOne_KeyPress);
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(71, 25);
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.ReadOnly = true;
            this.tbResistance.Size = new System.Drawing.Size(75, 21);
            this.tbResistance.TabIndex = 8;
            this.tbResistance.Text = "0";
            this.tbResistance.TextChanged += new System.EventHandler(this.tbResistance_TextChanged);
            this.tbResistance.DoubleClick += new System.EventHandler(this.tbResistance_DoubleClick);
            this.tbResistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbResistance_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(394, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "线性允许误差";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "斜率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "点数";
            // 
            // 旋转角度
            // 
            this.旋转角度.AutoSize = true;
            this.旋转角度.Location = new System.Drawing.Point(599, 28);
            this.旋转角度.Name = "旋转角度";
            this.旋转角度.Size = new System.Drawing.Size(53, 12);
            this.旋转角度.TabIndex = 4;
            this.旋转角度.Text = "旋转速度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "角度上限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "角度下限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "总阻";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 442);
            this.panel2.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检测ToolStripMenuItem,
            this.相对ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 25);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 检测ToolStripMenuItem
            // 
            this.检测ToolStripMenuItem.Name = "检测ToolStripMenuItem";
            this.检测ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.检测ToolStripMenuItem.Text = "检测数据加载";
            this.检测ToolStripMenuItem.Click += new System.EventHandler(this.检测ToolStripMenuItem_Click);
            // 
            // 相对ToolStripMenuItem
            // 
            this.相对ToolStripMenuItem.Name = "相对ToolStripMenuItem";
            this.相对ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.相对ToolStripMenuItem.Text = "相对";
            this.相对ToolStripMenuItem.Click += new System.EventHandler(this.相对ToolStripMenuItem_Click);
            // 
            // Angle
            // 
            this.Angle.DataPropertyName = "Angle";
            this.Angle.HeaderText = "角度";
            this.Angle.Name = "Angle";
            // 
            // ActualV
            // 
            this.ActualV.DataPropertyName = "ActualV";
            this.ActualV.HeaderText = "采集量";
            this.ActualV.Name = "ActualV";
            // 
            // IdealV
            // 
            this.IdealV.DataPropertyName = "IdealV";
            this.IdealV.HeaderText = "理论值";
            this.IdealV.Name = "IdealV";
            // 
            // UpperV
            // 
            this.UpperV.DataPropertyName = "UpperV";
            this.UpperV.HeaderText = "上限";
            this.UpperV.Name = "UpperV";
            // 
            // DownV
            // 
            this.DownV.DataPropertyName = "DownV";
            this.DownV.HeaderText = "下限";
            this.DownV.Name = "DownV";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "测试仪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart myChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.TextBox tbSlope;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbAngleTransfer;
        private System.Windows.Forms.TextBox tbAngleTwo;
        private System.Windows.Forms.TextBox tbAngleOne;
        private System.Windows.Forms.TextBox tbResistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label 旋转角度;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbV;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox offsetAngle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox zeroError;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox backwardError;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox forwardError;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label systmStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相对ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdealV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownV;
    }
}

