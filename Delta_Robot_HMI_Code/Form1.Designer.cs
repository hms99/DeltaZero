using System.IO.Ports;

namespace Delta_Robot_HMI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbCOM = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblDebug = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbOneCmd = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLoader = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtVacuum = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtServo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBES = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAccel = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.cbxPathCmd = new System.Windows.Forms.ComboBox();
            this.cbxAngleCmd = new System.Windows.Forms.ComboBox();
            this.cbxControlCmd = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTheta3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTheta2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTheta1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbCoordinate = new System.Windows.Forms.GroupBox();
            this.rdbAbsolute = new System.Windows.Forms.RadioButton();
            this.rdbRelative = new System.Windows.Forms.RadioButton();
            this.grbExecuteAction = new System.Windows.Forms.GroupBox();
            this.rdbToGcode = new System.Windows.Forms.RadioButton();
            this.rdbMove = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxCoorMode = new System.Windows.Forms.ComboBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSegArcSetting = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSegLineSetting = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtOffsetSetting = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtBESSetting = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtAccelSetting = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSpeedSetting = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grbChainOfCommands = new System.Windows.Forms.GroupBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnExecuteChainOfCommands = new System.Windows.Forms.Button();
            this.rtbChainCommands = new System.Windows.Forms.RichTextBox();
            this.btnClearChainCommands = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnZminus = new System.Windows.Forms.Button();
            this.btnZplus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.btnYplus = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.grpBoxConversations = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtTX = new System.Windows.Forms.RichTextBox();
            this.txtRX = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Z = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.lbl30 = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.grbCOM.SuspendLayout();
            this.grbOneCmd.SuspendLayout();
            this.grbCoordinate.SuspendLayout();
            this.grbExecuteAction.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grbChainOfCommands.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.grpBoxConversations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCOM
            // 
            this.grbCOM.Controls.Add(this.btnClose);
            this.grbCOM.Controls.Add(this.btnOpen);
            this.grbCOM.Controls.Add(this.comboBox1);
            this.grbCOM.Controls.Add(this.label1);
            this.grbCOM.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbCOM.Location = new System.Drawing.Point(3, 3);
            this.grbCOM.Margin = new System.Windows.Forms.Padding(4);
            this.grbCOM.Name = "grbCOM";
            this.grbCOM.Padding = new System.Windows.Forms.Padding(4);
            this.grbCOM.Size = new System.Drawing.Size(1106, 80);
            this.grbCOM.TabIndex = 1;
            this.grbCOM.TabStop = false;
            this.grbCOM.Text = "Port Control";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(432, 27);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(289, 28);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 28);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 32);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.receiveData);
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSend.Location = new System.Drawing.Point(358, 334);
            this.txtSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(376, 22);
            this.txtSend.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gcode Command";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(739, 331);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 28);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(355, 368);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(63, 16);
            this.lblDebug.TabIndex = 17;
            this.lblDebug.Text = "Respond";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grbOneCmd
            // 
            this.grbOneCmd.Controls.Add(this.textBox4);
            this.grbOneCmd.Controls.Add(this.label34);
            this.grbOneCmd.Controls.Add(this.label35);
            this.grbOneCmd.Controls.Add(this.textBox5);
            this.grbOneCmd.Controls.Add(this.textBox1);
            this.grbOneCmd.Controls.Add(this.textBox2);
            this.grbOneCmd.Controls.Add(this.comboBox2);
            this.grbOneCmd.Controls.Add(this.label27);
            this.grbOneCmd.Controls.Add(this.label31);
            this.grbOneCmd.Controls.Add(this.label32);
            this.grbOneCmd.Controls.Add(this.textBox3);
            this.grbOneCmd.Controls.Add(this.txtZ);
            this.grbOneCmd.Controls.Add(this.txtY);
            this.grbOneCmd.Controls.Add(this.label18);
            this.grbOneCmd.Controls.Add(this.txtLoader);
            this.grbOneCmd.Controls.Add(this.label19);
            this.grbOneCmd.Controls.Add(this.txtVacuum);
            this.grbOneCmd.Controls.Add(this.label20);
            this.grbOneCmd.Controls.Add(this.txtServo);
            this.grbOneCmd.Controls.Add(this.label15);
            this.grbOneCmd.Controls.Add(this.txtBES);
            this.grbOneCmd.Controls.Add(this.label16);
            this.grbOneCmd.Controls.Add(this.txtAccel);
            this.grbOneCmd.Controls.Add(this.label17);
            this.grbOneCmd.Controls.Add(this.txtSpeed);
            this.grbOneCmd.Controls.Add(this.cbxPathCmd);
            this.grbOneCmd.Controls.Add(this.cbxAngleCmd);
            this.grbOneCmd.Controls.Add(this.cbxControlCmd);
            this.grbOneCmd.Controls.Add(this.label14);
            this.grbOneCmd.Controls.Add(this.txtParameter);
            this.grbOneCmd.Controls.Add(this.label11);
            this.grbOneCmd.Controls.Add(this.label12);
            this.grbOneCmd.Controls.Add(this.label13);
            this.grbOneCmd.Controls.Add(this.txtX);
            this.grbOneCmd.Controls.Add(this.label10);
            this.grbOneCmd.Controls.Add(this.txtTheta3);
            this.grbOneCmd.Controls.Add(this.label9);
            this.grbOneCmd.Controls.Add(this.txtTheta2);
            this.grbOneCmd.Controls.Add(this.label8);
            this.grbOneCmd.Controls.Add(this.txtTheta1);
            this.grbOneCmd.Controls.Add(this.label7);
            this.grbOneCmd.Controls.Add(this.label6);
            this.grbOneCmd.Controls.Add(this.label5);
            this.grbOneCmd.Controls.Add(this.grbCoordinate);
            this.grbOneCmd.Controls.Add(this.grbExecuteAction);
            this.grbOneCmd.Controls.Add(this.label2);
            this.grbOneCmd.Controls.Add(this.lblDebug);
            this.grbOneCmd.Controls.Add(this.txtSend);
            this.grbOneCmd.Controls.Add(this.btnExecute);
            this.grbOneCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbOneCmd.Location = new System.Drawing.Point(3, 3);
            this.grbOneCmd.Name = "grbOneCmd";
            this.grbOneCmd.Size = new System.Drawing.Size(1106, 400);
            this.grbOneCmd.TabIndex = 18;
            this.grbOneCmd.TabStop = false;
            this.grbOneCmd.Text = "Robot Control";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(551, 105);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 72;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(531, 108);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(14, 16);
            this.label34.TabIndex = 71;
            this.label34.Text = "J";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(338, 108);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(10, 16);
            this.label35.TabIndex = 70;
            this.label35.Text = "I";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(363, 105);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 69;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(738, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 68;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(551, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 67;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "G2",
            "G3"});
            this.comboBox2.Location = new System.Drawing.Point(176, 72);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 24);
            this.comboBox2.TabIndex = 66;
            this.comboBox2.Text = "G2";
            this.comboBox2.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(719, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(15, 16);
            this.label27.TabIndex = 65;
            this.label27.Text = "Z";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(531, 76);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(16, 16);
            this.label31.TabIndex = 64;
            this.label31.Text = "Y";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(338, 76);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(15, 16);
            this.label32.TabIndex = 63;
            this.label32.Text = "X";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(363, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 62;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.circleCmd_TextChanged);
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(738, 36);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(100, 22);
            this.txtZ.TabIndex = 61;
            this.txtZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZ.TextChanged += new System.EventHandler(this.pathCmd_TextChanged);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(551, 36);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 22);
            this.txtY.TabIndex = 60;
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtY.TextChanged += new System.EventHandler(this.pathCmd_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(670, 288);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 16);
            this.label18.TabIndex = 59;
            this.label18.Text = "LOADER";
            // 
            // txtLoader
            // 
            this.txtLoader.Location = new System.Drawing.Point(738, 285);
            this.txtLoader.Name = "txtLoader";
            this.txtLoader.Size = new System.Drawing.Size(100, 22);
            this.txtLoader.TabIndex = 58;
            this.txtLoader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLoader.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(480, 288);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 16);
            this.label19.TabIndex = 57;
            this.label19.Text = "VACUUM";
            // 
            // txtVacuum
            // 
            this.txtVacuum.Location = new System.Drawing.Point(551, 285);
            this.txtVacuum.Name = "txtVacuum";
            this.txtVacuum.Size = new System.Drawing.Size(100, 22);
            this.txtVacuum.TabIndex = 56;
            this.txtVacuum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVacuum.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(299, 288);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 16);
            this.label20.TabIndex = 55;
            this.label20.Text = "SERVO";
            // 
            // txtServo
            // 
            this.txtServo.Location = new System.Drawing.Point(363, 285);
            this.txtServo.Name = "txtServo";
            this.txtServo.Size = new System.Drawing.Size(100, 22);
            this.txtServo.TabIndex = 54;
            this.txtServo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServo.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(700, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 16);
            this.label15.TabIndex = 53;
            this.label15.Text = "BES";
            // 
            // txtBES
            // 
            this.txtBES.Location = new System.Drawing.Point(738, 236);
            this.txtBES.Name = "txtBES";
            this.txtBES.Size = new System.Drawing.Size(100, 22);
            this.txtBES.TabIndex = 52;
            this.txtBES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBES.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(463, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 16);
            this.label16.TabIndex = 51;
            this.label16.Text = "Acceleration";
            // 
            // txtAccel
            // 
            this.txtAccel.Location = new System.Drawing.Point(551, 236);
            this.txtAccel.Name = "txtAccel";
            this.txtAccel.Size = new System.Drawing.Size(100, 22);
            this.txtAccel.TabIndex = 50;
            this.txtAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccel.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(304, 239);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "Speed";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(361, 236);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(100, 22);
            this.txtSpeed.TabIndex = 48;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSpeed.TextChanged += new System.EventHandler(this.singleControl_TextChanged);
            // 
            // cbxPathCmd
            // 
            this.cbxPathCmd.FormattingEnabled = true;
            this.cbxPathCmd.Items.AddRange(new object[] {
            "G0",
            "G1"});
            this.cbxPathCmd.Location = new System.Drawing.Point(176, 35);
            this.cbxPathCmd.Name = "cbxPathCmd";
            this.cbxPathCmd.Size = new System.Drawing.Size(100, 24);
            this.cbxPathCmd.TabIndex = 47;
            this.cbxPathCmd.Text = "G0";
            this.cbxPathCmd.SelectedIndexChanged += new System.EventHandler(this.pathCmd_TextChanged);
            // 
            // cbxAngleCmd
            // 
            this.cbxAngleCmd.FormattingEnabled = true;
            this.cbxAngleCmd.Items.AddRange(new object[] {
            "G6"});
            this.cbxAngleCmd.Location = new System.Drawing.Point(176, 139);
            this.cbxAngleCmd.Name = "cbxAngleCmd";
            this.cbxAngleCmd.Size = new System.Drawing.Size(100, 24);
            this.cbxAngleCmd.TabIndex = 46;
            this.cbxAngleCmd.Text = "G6";
            this.cbxAngleCmd.SelectedIndexChanged += new System.EventHandler(this.angleCmd_TextChanged);
            // 
            // cbxControlCmd
            // 
            this.cbxControlCmd.FormattingEnabled = true;
            this.cbxControlCmd.Items.AddRange(new object[] {
            "G28",
            "G4",
            "G90",
            "G91",
            "M370",
            "M203",
            "M204",
            "M206",
            "M207",
            "M361",
            "M362",
            "M84"});
            this.cbxControlCmd.Location = new System.Drawing.Point(551, 187);
            this.cbxControlCmd.Name = "cbxControlCmd";
            this.cbxControlCmd.Size = new System.Drawing.Size(100, 24);
            this.cbxControlCmd.TabIndex = 45;
            this.cbxControlCmd.SelectedIndexChanged += new System.EventHandler(this.controlCmd_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(664, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 16);
            this.label14.TabIndex = 41;
            this.label14.Text = "Parameter";
            // 
            // txtParameter
            // 
            this.txtParameter.Location = new System.Drawing.Point(738, 188);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(100, 22);
            this.txtParameter.TabIndex = 40;
            this.txtParameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtParameter.TextChanged += new System.EventHandler(this.controlCmd_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(719, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Z";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(531, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(338, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "X";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(363, 36);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 22);
            this.txtX.TabIndex = 33;
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtX.TextChanged += new System.EventHandler(this.pathCmd_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(676, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Theta_3";
            // 
            // txtTheta3
            // 
            this.txtTheta3.Location = new System.Drawing.Point(738, 140);
            this.txtTheta3.Name = "txtTheta3";
            this.txtTheta3.Size = new System.Drawing.Size(100, 22);
            this.txtTheta3.TabIndex = 31;
            this.txtTheta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTheta3.TextChanged += new System.EventHandler(this.angleCmd_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(487, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Theta_2";
            // 
            // txtTheta2
            // 
            this.txtTheta2.Location = new System.Drawing.Point(551, 140);
            this.txtTheta2.Name = "txtTheta2";
            this.txtTheta2.Size = new System.Drawing.Size(100, 22);
            this.txtTheta2.TabIndex = 29;
            this.txtTheta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTheta2.TextChanged += new System.EventHandler(this.angleCmd_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Theta_1";
            // 
            // txtTheta1
            // 
            this.txtTheta1.Location = new System.Drawing.Point(363, 140);
            this.txtTheta1.Name = "txtTheta1";
            this.txtTheta1.Size = new System.Drawing.Size(100, 22);
            this.txtTheta1.TabIndex = 27;
            this.txtTheta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTheta1.TextChanged += new System.EventHandler(this.angleCmd_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Control Command";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Angle Command";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Path Command";
            // 
            // grbCoordinate
            // 
            this.grbCoordinate.Controls.Add(this.rdbAbsolute);
            this.grbCoordinate.Controls.Add(this.rdbRelative);
            this.grbCoordinate.Location = new System.Drawing.Point(882, 31);
            this.grbCoordinate.Name = "grbCoordinate";
            this.grbCoordinate.Size = new System.Drawing.Size(197, 75);
            this.grbCoordinate.TabIndex = 21;
            this.grbCoordinate.TabStop = false;
            this.grbCoordinate.Text = "Choose Coodinate Mode";
            // 
            // rdbAbsolute
            // 
            this.rdbAbsolute.AutoSize = true;
            this.rdbAbsolute.Location = new System.Drawing.Point(15, 32);
            this.rdbAbsolute.Name = "rdbAbsolute";
            this.rdbAbsolute.Size = new System.Drawing.Size(81, 20);
            this.rdbAbsolute.TabIndex = 18;
            this.rdbAbsolute.TabStop = true;
            this.rdbAbsolute.Text = "Absolute";
            this.rdbAbsolute.UseVisualStyleBackColor = true;
            this.rdbAbsolute.CheckedChanged += new System.EventHandler(this.rdbAbsolute_CheckedChanged);
            // 
            // rdbRelative
            // 
            this.rdbRelative.AutoSize = true;
            this.rdbRelative.Location = new System.Drawing.Point(107, 32);
            this.rdbRelative.Name = "rdbRelative";
            this.rdbRelative.Size = new System.Drawing.Size(78, 20);
            this.rdbRelative.TabIndex = 19;
            this.rdbRelative.TabStop = true;
            this.rdbRelative.Text = "Relative";
            this.rdbRelative.UseVisualStyleBackColor = true;
            this.rdbRelative.CheckedChanged += new System.EventHandler(this.rdbRelative_CheckedChanged);
            // 
            // grbExecuteAction
            // 
            this.grbExecuteAction.Controls.Add(this.rdbToGcode);
            this.grbExecuteAction.Controls.Add(this.rdbMove);
            this.grbExecuteAction.Location = new System.Drawing.Point(882, 126);
            this.grbExecuteAction.Name = "grbExecuteAction";
            this.grbExecuteAction.Size = new System.Drawing.Size(197, 75);
            this.grbExecuteAction.TabIndex = 20;
            this.grbExecuteAction.TabStop = false;
            this.grbExecuteAction.Text = "Execute Action";
            // 
            // rdbToGcode
            // 
            this.rdbToGcode.AutoSize = true;
            this.rdbToGcode.Location = new System.Drawing.Point(13, 32);
            this.rdbToGcode.Name = "rdbToGcode";
            this.rdbToGcode.Size = new System.Drawing.Size(83, 20);
            this.rdbToGcode.TabIndex = 18;
            this.rdbToGcode.TabStop = true;
            this.rdbToGcode.Text = "to Gcode";
            this.rdbToGcode.UseVisualStyleBackColor = true;
            this.rdbToGcode.CheckedChanged += new System.EventHandler(this.rdbToGcode_CheckedChanged);
            // 
            // rdbMove
            // 
            this.rdbMove.AutoSize = true;
            this.rdbMove.Location = new System.Drawing.Point(106, 32);
            this.rdbMove.Name = "rdbMove";
            this.rdbMove.Size = new System.Drawing.Size(62, 20);
            this.rdbMove.TabIndex = 19;
            this.rdbMove.TabStop = true;
            this.rdbMove.Text = "Move";
            this.rdbMove.UseVisualStyleBackColor = true;
            this.rdbMove.CheckedChanged += new System.EventHandler(this.rdbMove_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1120, 435);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.grbCOM);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1112, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection and Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxCoorMode);
            this.groupBox2.Controls.Add(this.btnConfig);
            this.groupBox2.Controls.Add(this.btnDefault);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtSegArcSetting);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtSegLineSetting);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.txtOffsetSetting);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtBESSetting);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtAccelSetting);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtSpeedSetting);
            this.groupBox2.Location = new System.Drawing.Point(3, 85);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1104, 314);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting";
            // 
            // cbxCoorMode
            // 
            this.cbxCoorMode.FormattingEnabled = true;
            this.cbxCoorMode.Items.AddRange(new object[] {
            "Absolute",
            "Relative"});
            this.cbxCoorMode.Location = new System.Drawing.Point(865, 97);
            this.cbxCoorMode.Name = "cbxCoorMode";
            this.cbxCoorMode.Size = new System.Drawing.Size(100, 24);
            this.cbxCoorMode.TabIndex = 51;
            // 
            // btnConfig
            // 
            this.btnConfig.AutoSize = true;
            this.btnConfig.Location = new System.Drawing.Point(890, 205);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 26);
            this.btnConfig.TabIndex = 50;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.AutoSize = true;
            this.btnDefault.Location = new System.Drawing.Point(751, 205);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(102, 26);
            this.btnDefault.TabIndex = 49;
            this.btnDefault.Text = "Set To Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(780, 160);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 16);
            this.label28.TabIndex = 48;
            this.label28.Text = "mm PerArc";
            // 
            // txtSegArcSetting
            // 
            this.txtSegArcSetting.Location = new System.Drawing.Point(865, 157);
            this.txtSegArcSetting.Name = "txtSegArcSetting";
            this.txtSegArcSetting.Size = new System.Drawing.Size(100, 22);
            this.txtSegArcSetting.TabIndex = 47;
            this.txtSegArcSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(432, 160);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(90, 16);
            this.label29.TabIndex = 46;
            this.label29.Text = "mm PerLinear";
            // 
            // txtSegLineSetting
            // 
            this.txtSegLineSetting.Location = new System.Drawing.Point(533, 157);
            this.txtSegLineSetting.Name = "txtSegLineSetting";
            this.txtSegLineSetting.Size = new System.Drawing.Size(100, 22);
            this.txtSegLineSetting.TabIndex = 45;
            this.txtSegLineSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(742, 101);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(111, 16);
            this.label25.TabIndex = 42;
            this.label25.Text = "Coordinate Mode";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(470, 101);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 16);
            this.label26.TabIndex = 40;
            this.label26.Text = "Z Offset";
            // 
            // txtOffsetSetting
            // 
            this.txtOffsetSetting.Location = new System.Drawing.Point(533, 98);
            this.txtOffsetSetting.Name = "txtOffsetSetting";
            this.txtOffsetSetting.Size = new System.Drawing.Size(100, 22);
            this.txtOffsetSetting.TabIndex = 39;
            this.txtOffsetSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(702, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(151, 16);
            this.label24.TabIndex = 36;
            this.label24.Text = "Begin End Speed (BES)";
            // 
            // txtBESSetting
            // 
            this.txtBESSetting.Location = new System.Drawing.Point(865, 39);
            this.txtBESSetting.Name = "txtBESSetting";
            this.txtBESSetting.Size = new System.Drawing.Size(100, 22);
            this.txtBESSetting.TabIndex = 35;
            this.txtBESSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(440, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 16);
            this.label23.TabIndex = 34;
            this.label23.Text = "Acceleration";
            // 
            // txtAccelSetting
            // 
            this.txtAccelSetting.Location = new System.Drawing.Point(533, 39);
            this.txtAccelSetting.Name = "txtAccelSetting";
            this.txtAccelSetting.Size = new System.Drawing.Size(100, 22);
            this.txtAccelSetting.TabIndex = 33;
            this.txtAccelSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(137, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 16);
            this.label22.TabIndex = 32;
            this.label22.Text = "Speed";
            // 
            // txtSpeedSetting
            // 
            this.txtSpeedSetting.Location = new System.Drawing.Point(201, 39);
            this.txtSpeedSetting.Name = "txtSpeedSetting";
            this.txtSpeedSetting.Size = new System.Drawing.Size(100, 22);
            this.txtSpeedSetting.TabIndex = 31;
            this.txtSpeedSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbOneCmd);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gcode Supporter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grbChainOfCommands);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1112, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Programs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grbChainOfCommands
            // 
            this.grbChainOfCommands.Controls.Add(this.btnPaste);
            this.grbChainOfCommands.Controls.Add(this.btnExecuteChainOfCommands);
            this.grbChainOfCommands.Controls.Add(this.rtbChainCommands);
            this.grbChainOfCommands.Controls.Add(this.btnClearChainCommands);
            this.grbChainOfCommands.Controls.Add(this.btnOpenFile);
            this.grbChainOfCommands.Controls.Add(this.btnSaveFile);
            this.grbChainOfCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbChainOfCommands.Location = new System.Drawing.Point(0, 0);
            this.grbChainOfCommands.Name = "grbChainOfCommands";
            this.grbChainOfCommands.Size = new System.Drawing.Size(1112, 406);
            this.grbChainOfCommands.TabIndex = 16;
            this.grbChainOfCommands.TabStop = false;
            this.grbChainOfCommands.Text = "Chain Of Commands";
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(980, 173);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(100, 28);
            this.btnPaste.TabIndex = 19;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnExecuteChainOfCommands
            // 
            this.btnExecuteChainOfCommands.Location = new System.Drawing.Point(826, 316);
            this.btnExecuteChainOfCommands.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecuteChainOfCommands.Name = "btnExecuteChainOfCommands";
            this.btnExecuteChainOfCommands.Size = new System.Drawing.Size(100, 28);
            this.btnExecuteChainOfCommands.TabIndex = 18;
            this.btnExecuteChainOfCommands.Text = "Execute";
            this.btnExecuteChainOfCommands.UseVisualStyleBackColor = true;
            this.btnExecuteChainOfCommands.Click += new System.EventHandler(this.btnExecuteChainOfCommands_Click);
            // 
            // rtbChainCommands
            // 
            this.rtbChainCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChainCommands.Location = new System.Drawing.Point(20, 21);
            this.rtbChainCommands.Name = "rtbChainCommands";
            this.rtbChainCommands.Size = new System.Drawing.Size(906, 285);
            this.rtbChainCommands.TabIndex = 11;
            this.rtbChainCommands.Text = "";
            // 
            // btnClearChainCommands
            // 
            this.btnClearChainCommands.Location = new System.Drawing.Point(980, 234);
            this.btnClearChainCommands.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearChainCommands.Name = "btnClearChainCommands";
            this.btnClearChainCommands.Size = new System.Drawing.Size(100, 28);
            this.btnClearChainCommands.TabIndex = 14;
            this.btnClearChainCommands.Text = "Clear";
            this.btnClearChainCommands.UseVisualStyleBackColor = true;
            this.btnClearChainCommands.Click += new System.EventHandler(this.btnClearChainCommands_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(980, 51);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(100, 28);
            this.btnOpenFile.TabIndex = 12;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(980, 112);
            this.btnSaveFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(100, 28);
            this.btnSaveFile.TabIndex = 13;
            this.btnSaveFile.Text = "Save";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnZminus);
            this.tabPage4.Controls.Add(this.btnZplus);
            this.tabPage4.Controls.Add(this.btnXplus);
            this.tabPage4.Controls.Add(this.btnYminus);
            this.tabPage4.Controls.Add(this.btnXminus);
            this.tabPage4.Controls.Add(this.btnYplus);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1112, 406);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Manual Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnZminus
            // 
            this.btnZminus.Location = new System.Drawing.Point(657, 199);
            this.btnZminus.Name = "btnZminus";
            this.btnZminus.Size = new System.Drawing.Size(104, 45);
            this.btnZminus.TabIndex = 6;
            this.btnZminus.Text = "Z -";
            this.btnZminus.UseVisualStyleBackColor = true;
            this.btnZminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnZminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // btnZplus
            // 
            this.btnZplus.Location = new System.Drawing.Point(657, 82);
            this.btnZplus.Name = "btnZplus";
            this.btnZplus.Size = new System.Drawing.Size(104, 45);
            this.btnZplus.TabIndex = 5;
            this.btnZplus.Text = "Z+";
            this.btnZplus.UseVisualStyleBackColor = true;
            this.btnZplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnZplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // btnXplus
            // 
            this.btnXplus.Location = new System.Drawing.Point(295, 141);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(104, 45);
            this.btnXplus.TabIndex = 4;
            this.btnXplus.Text = "X +";
            this.btnXplus.UseVisualStyleBackColor = true;
            this.btnXplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnXplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // btnYminus
            // 
            this.btnYminus.Location = new System.Drawing.Point(400, 199);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(104, 45);
            this.btnYminus.TabIndex = 3;
            this.btnYminus.Text = "Y -";
            this.btnYminus.UseVisualStyleBackColor = true;
            this.btnYminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnYminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // btnXminus
            // 
            this.btnXminus.Location = new System.Drawing.Point(503, 141);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(104, 45);
            this.btnXminus.TabIndex = 2;
            this.btnXminus.Text = "X -";
            this.btnXminus.UseVisualStyleBackColor = true;
            this.btnXminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnXminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // btnYplus
            // 
            this.btnYplus.Location = new System.Drawing.Point(400, 82);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(104, 45);
            this.btnYplus.TabIndex = 0;
            this.btnYplus.Text = "Y +";
            this.btnYplus.UseVisualStyleBackColor = true;
            this.btnYplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.manual_MouseDown);
            this.btnYplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.manual_MouseUp);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.grpBoxConversations);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1112, 406);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Conversations";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // grpBoxConversations
            // 
            this.grpBoxConversations.Controls.Add(this.btnClear);
            this.grpBoxConversations.Controls.Add(this.txtTX);
            this.grpBoxConversations.Controls.Add(this.txtRX);
            this.grpBoxConversations.Controls.Add(this.label4);
            this.grpBoxConversations.Controls.Add(this.label3);
            this.grpBoxConversations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxConversations.Location = new System.Drawing.Point(0, 0);
            this.grpBoxConversations.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxConversations.Name = "grpBoxConversations";
            this.grpBoxConversations.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxConversations.Size = new System.Drawing.Size(1112, 406);
            this.grpBoxConversations.TabIndex = 9;
            this.grpBoxConversations.TabStop = false;
            this.grpBoxConversations.Text = "Conversations";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1003, 314);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtTX
            // 
            this.txtTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTX.Location = new System.Drawing.Point(563, 41);
            this.txtTX.Name = "txtTX";
            this.txtTX.ReadOnly = true;
            this.txtTX.Size = new System.Drawing.Size(540, 260);
            this.txtTX.TabIndex = 10;
            this.txtTX.Text = "";
            // 
            // txtRX
            // 
            this.txtRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRX.Location = new System.Drawing.Point(5, 41);
            this.txtRX.Name = "txtRX";
            this.txtRX.ReadOnly = true;
            this.txtRX.Size = new System.Drawing.Size(540, 260);
            this.txtRX.TabIndex = 10;
            this.txtRX.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(803, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Transmitted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Received";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.Z);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.Y);
            this.groupBox1.Controls.Add(this.lbl30);
            this.groupBox1.Controls.Add(this.X);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(9, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1109, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot Status";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Location = new System.Drawing.Point(777, 47);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(49, 16);
            this.Z.TabIndex = 6;
            this.Z.Text = "z value";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(730, 47);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 5;
            this.label33.Text = "Z : ";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Location = new System.Drawing.Point(588, 47);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(50, 16);
            this.Y.TabIndex = 4;
            this.Y.Text = "y value";
            // 
            // lbl30
            // 
            this.lbl30.AutoSize = true;
            this.lbl30.Location = new System.Drawing.Point(539, 47);
            this.lbl30.Name = "lbl30";
            this.lbl30.Size = new System.Drawing.Size(25, 16);
            this.lbl30.TabIndex = 3;
            this.lbl30.Text = "Y : ";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(396, 45);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(49, 16);
            this.X.TabIndex = 2;
            this.X.Text = "x value";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(349, 45);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 16);
            this.label30.TabIndex = 1;
            this.label30.Text = "X : ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Silver;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(27, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(188, 41);
            this.label21.TabIndex = 0;
            this.label21.Text = "Delta_Zero";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1125, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delta Robot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbCOM.ResumeLayout(false);
            this.grbCOM.PerformLayout();
            this.grbOneCmd.ResumeLayout(false);
            this.grbOneCmd.PerformLayout();
            this.grbCoordinate.ResumeLayout(false);
            this.grbCoordinate.PerformLayout();
            this.grbExecuteAction.ResumeLayout(false);
            this.grbExecuteAction.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grbChainOfCommands.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.grpBoxConversations.ResumeLayout(false);
            this.grpBoxConversations.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCOM;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grbOneCmd;
        private System.Windows.Forms.GroupBox grbCoordinate;
        private System.Windows.Forms.RadioButton rdbAbsolute;
        private System.Windows.Forms.RadioButton rdbRelative;
        private System.Windows.Forms.GroupBox grbExecuteAction;
        private System.Windows.Forms.RadioButton rdbToGcode;
        private System.Windows.Forms.RadioButton rdbMove;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxPathCmd;
        private System.Windows.Forms.ComboBox cbxAngleCmd;
        private System.Windows.Forms.ComboBox cbxControlCmd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTheta3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTheta2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTheta1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBES;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAccel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtLoader;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtVacuum;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtServo;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grbChainOfCommands;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnExecuteChainOfCommands;
        private System.Windows.Forms.RichTextBox rtbChainCommands;
        private System.Windows.Forms.Button btnClearChainCommands;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox grpBoxConversations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox txtTX;
        private System.Windows.Forms.RichTextBox txtRX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSegArcSetting;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtSegLineSetting;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtOffsetSetting;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtBESSetting;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAccelSetting;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSpeedSetting;
        private System.Windows.Forms.Button btnZminus;
        private System.Windows.Forms.Button btnZplus;
        private System.Windows.Forms.Button btnXplus;
        private System.Windows.Forms.Button btnYminus;
        private System.Windows.Forms.Button btnXminus;
        private System.Windows.Forms.Button btnYplus;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label lbl30;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbxCoorMode;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox3;
    }
}

