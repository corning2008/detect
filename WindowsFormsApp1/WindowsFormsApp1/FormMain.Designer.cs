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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdealV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpperV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelChart = new System.Windows.Forms.Panel();
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbIntervalAngle = new System.Windows.Forms.TextBox();
            this.systmStatus = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
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
            this.label17 = new System.Windows.Forms.Label();
            this.tbV = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.其他功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试数据加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据处理相对ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.线性度曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1067, 436);
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
            this.dataGridView.Size = new System.Drawing.Size(434, 436);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
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
            this.ActualV.HeaderText = "采集值";
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
            // panelChart
            // 
            this.panelChart.Controls.Add(this.myChart);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(0, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(629, 436);
            this.panelChart.TabIndex = 5;
            // 
            // myChart
            // 
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.CursorX.Interval = 0.01D;
            chartArea1.Name = "ChartArea1";
            this.myChart.ChartAreas.Add(chartArea1);
            this.myChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.myChart.Legends.Add(legend1);
            this.myChart.Location = new System.Drawing.Point(0, 0);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(629, 436);
            this.myChart.TabIndex = 3;
            this.myChart.Text = "chart1";
            title1.Name = "Title1";
            this.myChart.Titles.Add(title1);
            this.myChart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.myChart_GetToolTipText);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm.Location = new System.Drawing.Point(825, 76);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(73, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "开始检测";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(825, 47);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(147, 20);
            this.cmbSerialPort.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbSerialPort);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.tbIntervalAngle);
            this.panel1.Controls.Add(this.systmStatus);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.label26);
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
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.tbV);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
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
            this.panel1.Size = new System.Drawing.Size(1067, 177);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(449, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "线性仪检测";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(138, 140);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 10);
            this.label25.TabIndex = 45;
            this.label25.Text = "度";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbStatus.Location = new System.Drawing.Point(978, 50);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(31, 15);
            this.lbStatus.TabIndex = 23;
            this.lbStatus.Text = "停止";
            // 
            // tbIntervalAngle
            // 
            this.tbIntervalAngle.Location = new System.Drawing.Point(72, 137);
            this.tbIntervalAngle.Name = "tbIntervalAngle";
            this.tbIntervalAngle.ReadOnly = true;
            this.tbIntervalAngle.Size = new System.Drawing.Size(63, 21);
            this.tbIntervalAngle.TabIndex = 44;
            this.tbIntervalAngle.Text = "0";
            this.tbIntervalAngle.DoubleClick += new System.EventHandler(this.tbIntervalAngle_DoubleClick);
            // 
            // systmStatus
            // 
            this.systmStatus.AutoSize = true;
            this.systmStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.systmStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.systmStatus.Location = new System.Drawing.Point(978, 80);
            this.systmStatus.Name = "systmStatus";
            this.systmStatus.Size = new System.Drawing.Size(55, 15);
            this.systmStatus.TabIndex = 41;
            this.systmStatus.Text = "检测状态";
            this.systmStatus.Click += new System.EventHandler(this.systmStatus_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ForeColor = System.Drawing.Color.Red;
            this.btnExport.Location = new System.Drawing.Point(904, 76);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(68, 23);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "停止检测";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(16, 140);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 10);
            this.label26.TabIndex = 43;
            this.label26.Text = "测量间隔";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(652, 114);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 10);
            this.label23.TabIndex = 40;
            this.label23.Text = "Ω";
            // 
            // zeroError
            // 
            this.zeroError.Location = new System.Drawing.Point(586, 111);
            this.zeroError.Name = "zeroError";
            this.zeroError.ReadOnly = true;
            this.zeroError.Size = new System.Drawing.Size(63, 21);
            this.zeroError.TabIndex = 39;
            this.zeroError.Text = "0";
            this.zeroError.DoubleClick += new System.EventHandler(this.ZeroError_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(527, 114);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 10);
            this.label24.TabIndex = 38;
            this.label24.Text = "零阻误差";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(486, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 10);
            this.label21.TabIndex = 37;
            this.label21.Text = "%";
            // 
            // backwardError
            // 
            this.backwardError.Location = new System.Drawing.Point(420, 112);
            this.backwardError.Name = "backwardError";
            this.backwardError.ReadOnly = true;
            this.backwardError.Size = new System.Drawing.Size(63, 21);
            this.backwardError.TabIndex = 36;
            this.backwardError.Text = "0";
            this.backwardError.DoubleClick += new System.EventHandler(this.BackwardError_DoubleClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(358, 115);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 10);
            this.label22.TabIndex = 35;
            this.label22.Text = "负向误差";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(300, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 10);
            this.label19.TabIndex = 34;
            this.label19.Text = "%";
            // 
            // forwardError
            // 
            this.forwardError.Location = new System.Drawing.Point(234, 111);
            this.forwardError.Name = "forwardError";
            this.forwardError.ReadOnly = true;
            this.forwardError.Size = new System.Drawing.Size(63, 21);
            this.forwardError.TabIndex = 33;
            this.forwardError.Text = "0";
            this.forwardError.DoubleClick += new System.EventHandler(this.ForwardError_DoubleClick);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(173, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 10);
            this.label20.TabIndex = 32;
            this.label20.Text = "正向误差";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(138, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 10);
            this.label2.TabIndex = 31;
            this.label2.Text = "度";
            // 
            // offsetAngle
            // 
            this.offsetAngle.Location = new System.Drawing.Point(71, 107);
            this.offsetAngle.Name = "offsetAngle";
            this.offsetAngle.ReadOnly = true;
            this.offsetAngle.Size = new System.Drawing.Size(63, 21);
            this.offsetAngle.TabIndex = 30;
            this.offsetAngle.Text = "0";
            this.offsetAngle.DoubleClick += new System.EventHandler(this.offsetAngle_DoubleClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(6, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 10);
            this.label18.TabIndex = 29;
            this.label18.Text = "零位偏差值";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(652, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 10);
            this.label17.TabIndex = 27;
            this.label17.Text = "V";
            // 
            // tbV
            // 
            this.tbV.Location = new System.Drawing.Point(586, 79);
            this.tbV.Name = "tbV";
            this.tbV.ReadOnly = true;
            this.tbV.Size = new System.Drawing.Size(63, 21);
            this.tbV.TabIndex = 26;
            this.tbV.Text = "0";
            this.tbV.DoubleClick += new System.EventHandler(this.tbV_DoubleClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(527, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 10);
            this.label16.TabIndex = 25;
            this.label16.Text = "极限电压";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(486, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 10);
            this.label15.TabIndex = 24;
            this.label15.Text = "V";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(138, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 10);
            this.label14.TabIndex = 22;
            this.label14.Text = "个";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(138, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 10);
            this.label13.TabIndex = 21;
            this.label13.Text = "KΩ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(300, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 10);
            this.label12.TabIndex = 18;
            this.label12.Text = "v/度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(300, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 10);
            this.label11.TabIndex = 17;
            this.label11.Text = "度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(486, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 10);
            this.label10.TabIndex = 16;
            this.label10.Text = "度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(652, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 10);
            this.label6.TabIndex = 15;
            this.label6.Text = "转/分";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(420, 80);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.ReadOnly = true;
            this.tbOffset.Size = new System.Drawing.Size(63, 21);
            this.tbOffset.TabIndex = 14;
            this.tbOffset.Text = "0";
            this.tbOffset.DoubleClick += new System.EventHandler(this.tbOffset_DoubleClick);
            // 
            // tbSlope
            // 
            this.tbSlope.Location = new System.Drawing.Point(234, 79);
            this.tbSlope.Name = "tbSlope";
            this.tbSlope.ReadOnly = true;
            this.tbSlope.Size = new System.Drawing.Size(63, 21);
            this.tbSlope.TabIndex = 13;
            this.tbSlope.Text = "0";
            this.tbSlope.DoubleClick += new System.EventHandler(this.tbSlope_DoubleClick);
            this.tbSlope.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSlope_KeyPress);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(71, 77);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.tbNumber.Size = new System.Drawing.Size(63, 21);
            this.tbNumber.TabIndex = 12;
            this.tbNumber.Text = "0";
            this.tbNumber.DoubleClick += new System.EventHandler(this.tbNumber_DoubleClick);
            this.tbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // tbAngleTransfer
            // 
            this.tbAngleTransfer.Location = new System.Drawing.Point(586, 47);
            this.tbAngleTransfer.Name = "tbAngleTransfer";
            this.tbAngleTransfer.ReadOnly = true;
            this.tbAngleTransfer.Size = new System.Drawing.Size(63, 21);
            this.tbAngleTransfer.TabIndex = 11;
            this.tbAngleTransfer.Text = "0";
            this.tbAngleTransfer.DoubleClick += new System.EventHandler(this.tbAngleTransfer_DoubleClick);
            this.tbAngleTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleTransfer_KeyPress);
            // 
            // tbAngleTwo
            // 
            this.tbAngleTwo.Location = new System.Drawing.Point(420, 48);
            this.tbAngleTwo.Name = "tbAngleTwo";
            this.tbAngleTwo.ReadOnly = true;
            this.tbAngleTwo.Size = new System.Drawing.Size(63, 21);
            this.tbAngleTwo.TabIndex = 10;
            this.tbAngleTwo.Text = "0";
            this.tbAngleTwo.DoubleClick += new System.EventHandler(this.tbAngleTwo_DoubleClick);
            this.tbAngleTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleTwo_KeyPress);
            // 
            // tbAngleOne
            // 
            this.tbAngleOne.Location = new System.Drawing.Point(234, 47);
            this.tbAngleOne.Name = "tbAngleOne";
            this.tbAngleOne.ReadOnly = true;
            this.tbAngleOne.Size = new System.Drawing.Size(63, 21);
            this.tbAngleOne.TabIndex = 9;
            this.tbAngleOne.Text = "0";
            this.tbAngleOne.DoubleClick += new System.EventHandler(this.tbAngleOne_DoubleClick);
            this.tbAngleOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAngleOne_KeyPress);
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(71, 47);
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.ReadOnly = true;
            this.tbResistance.Size = new System.Drawing.Size(63, 21);
            this.tbResistance.TabIndex = 8;
            this.tbResistance.Text = "0";
            this.tbResistance.TextChanged += new System.EventHandler(this.tbResistance_TextChanged);
            this.tbResistance.DoubleClick += new System.EventHandler(this.tbResistance_DoubleClick);
            this.tbResistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbResistance_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(338, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 10);
            this.label9.TabIndex = 7;
            this.label9.Text = "线性允许误差";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(193, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 10);
            this.label8.TabIndex = 6;
            this.label8.Text = "斜率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(36, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 10);
            this.label7.TabIndex = 5;
            this.label7.Text = "点数";
            // 
            // 旋转角度
            // 
            this.旋转角度.AutoSize = true;
            this.旋转角度.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.旋转角度.Location = new System.Drawing.Point(527, 50);
            this.旋转角度.Name = "旋转角度";
            this.旋转角度.Size = new System.Drawing.Size(45, 10);
            this.旋转角度.TabIndex = 4;
            this.旋转角度.Text = "旋转速度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(358, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 10);
            this.label5.TabIndex = 3;
            this.label5.Text = "角度上限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(173, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 10);
            this.label4.TabIndex = 2;
            this.label4.Text = "角度下限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 10);
            this.label3.TabIndex = 1;
            this.label3.Text = "总阻";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.其他功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 25);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 其他功能ToolStripMenuItem
            // 
            this.其他功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试数据加载ToolStripMenuItem,
            this.数据处理相对ToolStripMenuItem,
            this.线性度曲线ToolStripMenuItem});
            this.其他功能ToolStripMenuItem.Name = "其他功能ToolStripMenuItem";
            this.其他功能ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.其他功能ToolStripMenuItem.Text = "其他功能";
            // 
            // 测试数据加载ToolStripMenuItem
            // 
            this.测试数据加载ToolStripMenuItem.Name = "测试数据加载ToolStripMenuItem";
            this.测试数据加载ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.测试数据加载ToolStripMenuItem.Text = "测试数据加载";
            this.测试数据加载ToolStripMenuItem.Click += new System.EventHandler(this.检测ToolStripMenuItem_Click);
            // 
            // 数据处理相对ToolStripMenuItem
            // 
            this.数据处理相对ToolStripMenuItem.Name = "数据处理相对ToolStripMenuItem";
            this.数据处理相对ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.数据处理相对ToolStripMenuItem.Text = "数据处理(相对)";
            this.数据处理相对ToolStripMenuItem.Click += new System.EventHandler(this.相对ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 436);
            this.panel2.TabIndex = 4;
            // 
            // 线性度曲线ToolStripMenuItem
            // 
            this.线性度曲线ToolStripMenuItem.Name = "线性度曲线ToolStripMenuItem";
            this.线性度曲线ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.线性度曲线ToolStripMenuItem.Text = "线性度曲线";
            this.线性度曲线ToolStripMenuItem.Click += new System.EventHandler(this.线性度曲线ToolStripMenuItem_Click);
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
            this.Text = "线性仪检测";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdealV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownV;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbIntervalAngle;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripMenuItem 其他功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试数据加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据处理相对ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 线性度曲线ToolStripMenuItem;
    }
}

