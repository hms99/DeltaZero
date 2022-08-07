using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Delta_Robot_HMI
{
    public partial class Form1 : Form
    {
        private string[] gCodesToExecute = new string[1000];
        private int TX_SIZE = 60;
        private int numberOfCommands = 0;
        //khai bao bien tai day
        private float _X = 0;
        private float _Y = 0;
        private float _Z = 0;

        private float c_X = 0;
        private float c_Y = 0;
        private float c_Z = 0;
        private float c_I = 0;
        private float c_J = 0;

        private float last_X = 0;
        private float last_Y = 0;
        private float last_Z = 0;
        bool isMouseHold = false;
        string manual_btn_active = "btnYplus";
        int time_ms = 0;
        int time_lastSend = 0;

        private float parameter = 0;

        private float speed = 50;
        private float accel = 100;
        private float BES = 40;
        private float servo_position = 0;
        private float vacuum = 0;
        private float loader_speed = 0;

        private float mm_per_linear_seg = 8;
        private float mm_per_arc_seg = 8;
        private float Z_Offset = 0;
        private string Coordinate_Mode = "Absolute";

        private const float const_speed = 50;
        private const float const_accel = 100;
        private const float const_BES = 40;
        private const float const_mm_per_linear_seg = 8;
        private const float const_mm_per_arc_seg = 8;
        private const float const_Z_Offset = 0;
        private const string const_Coordinate_Mode = "Absolute";

        private bool toGcode = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;           

            timer1.Enabled = true;

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                comboBox1.Items.Add(port);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            //thiet lap cac gia tri khoi dau textBox tai day
            this.txtX.Text = _X.ToString();
            this.txtY.Text = _Y.ToString();
            this.txtZ.Text = _Z.ToString();

            this.textBox3.Text = c_X.ToString();
            this.textBox2.Text = c_Y.ToString();
            this.textBox1.Text = c_Z.ToString();
            this.textBox5.Text = c_I.ToString();
            this.textBox4.Text = c_J.ToString();

            this.txtTheta1.Text = _X.ToString();
            this.txtTheta2.Text = _Y.ToString();
            this.txtTheta3.Text = _Z.ToString();

            this.txtParameter.Text = parameter.ToString();

            this.txtSpeed.Text = speed.ToString();
            this.txtAccel.Text = accel.ToString();
            this.txtBES.Text = BES.ToString();
            this.txtServo.Text = servo_position.ToString();
            this.txtVacuum.Text = vacuum.ToString();
            this.txtLoader.Text = loader_speed.ToString();

            this.txtSend.Text = "";

            settingDefaultParameters();

            this.rdbAbsolute.Checked = true;
            this.rdbToGcode.Checked = true;

            //this.lblDebug.Text = serialPort1.ReadBufferSize.ToString();

            configHandler();
        }
        private void settingDefaultParameters()
        {
            this.txtSpeedSetting.Text = const_speed.ToString();
            this.txtAccelSetting.Text = const_accel.ToString();
            this.txtBESSetting.Text = const_BES.ToString();

            this.txtSegLineSetting.Text = const_mm_per_linear_seg.ToString();
            this.txtSegArcSetting.Text = const_mm_per_arc_seg.ToString();
            this.txtOffsetSetting.Text = const_Z_Offset.ToString();
            this.cbxCoorMode.Text = const_Coordinate_Mode;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSend.Text != null)
                {
                    Clipboard.SetText(txtSend.Text);
                }
            }
            catch
            {

            }
            if (!toGcode)
            {
                gCodesToExecute[numberOfCommands] = txtSend.Text;
                numberOfCommands++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sendData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRX.Clear();
            txtTX.Clear();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Gcode File (*.txt)|*.txt";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtbChainCommands.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Luu thanh cong!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            rtbChainCommands.Clear();
            openFileDialog1.Filter = "Gcode File (*.txt)|*.txt";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = openFileDialog1.OpenFile();
                    StreamReader sr = new StreamReader(stream);

                    string line = sr.ReadLine();
                    lblDebug.Text = line;
                    while (line != null)
                    {
                        rtbChainCommands.Text += line;
                        rtbChainCommands.Text += '\n';
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClearChainCommands_Click(object sender, EventArgs e)
        {
            rtbChainCommands.Clear();
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            rtbChainCommands.Text += (Clipboard.GetText(TextDataFormat.Text) + '\n');
        }

        private void btnExecuteChainOfCommands_Click(object sender, EventArgs e)
        {
            string[] commands = new string[1000];
            commands = rtbChainCommands.Lines;

            int j = 0;
            foreach (string command in commands)
            {
                if (command.Length > 2)
                {
                    gCodesToExecute[j] = command;
                    j++;
                }
            }
            numberOfCommands = j;
            lblDebug.Text = j.ToString();
        }
        public void sendData()
        {
            if(serialPort1.IsOpen)
            {
                try
                { 
                    string command;
                    if (numberOfCommands > 0)
                    {
                        int _numberBuffer = numberOfCommands;
                        for (int i = 0; i < _numberBuffer; i++)
                        {
                            command = gCodesToExecute[i];
                            txtTX.Text += DateTime.Now.ToLongTimeString() + "  -->  " + command + '\n';
                            command = String.Concat(command, '*');
                            if (command.Length < TX_SIZE)
                            {
                                int numberOfSpaces = TX_SIZE - command.Length;
                                command += new String(' ', numberOfSpaces);
                                numberOfCommands--;
                                serialPort1.Write(command);
                                gCodesToExecute[i] = "";
                            }
                            else
                            {
                                lblDebug.Text = "QUA SO KI TU !";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
            }
        }
        public void receiveData(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //SerialPort sp = (SerialPort)sender;
                try
                {
                    /*string receivedMessages = serialPort1.ReadExisting();
                    string[] messages = receivedMessages.Split(':');
                    dataHandler(messages);
                    foreach (string message in messages)
                    {
                        if ((message != null) || (message != " "))
                        {
                            string _message = DateTime.Now.ToLongTimeString() + "  -->  " + message + '\n';
                            SetText("txtRX", _message);
                        }
                    }*/

                    string receivedMessage = serialPort1.ReadLine();
                    if (receivedMessage != null)
                    {
                        dataHandler(receivedMessage);
                        string message = DateTime.Now.ToLongTimeString() + "  -->  " + receivedMessage + '\n';
                        SetText("txtRX", message);
                    }
                }
                catch (Exception ex)
                {
                   // throw ex;
                }
            }
        }
        private void dataHandler(string data)
        {
            try
            {
                string[] datas = data.Split(' ');
                if (datas[0] == ":Position")
                {
                    _X = float.Parse(datas[1]);
                    _Y = float.Parse(datas[2]);
                    _Z = float.Parse(datas[3]);
                    manualHandler();
                    //string message = "Position: " + _X.ToString() + " " + _Y.ToString() + " " + _Z.ToString();
                    //SetText("lblDebug", message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            updateDataHandler();
        }
        private void updateDataHandler()
        {
            SetText("X", (string)_X.ToString());
            SetText("Y", (string)_Y.ToString());
            SetText("Z", (string)_Z.ToString());
        }
        delegate void SetTextCallback(string target, string text);

        private void SetText(string target, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtRX.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { target, text });
            }
            else
            {
                if (target == "txtRX")
                {
                    this.txtRX.Text += text;
                }
                else if (target == "lblDebug")
                {
                    this.lblDebug.Text = text;
                }
                else if (target == "X")
                {
                    this.X.Text = text;
                }
                else if (target == "Y")
                {
                    this.Y.Text = text;
                }
                else if (target == "Z")
                {
                    this.Z.Text = text;
                }
            }
        }

        private void pathCmd_TextChanged(object sender, EventArgs e)
        {
            float X_value = 0;
            float Y_value = 0;
            float Z_value = 0;
            try
            {
                X_value = float.Parse(txtX.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                Y_value = float.Parse(txtY.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                Z_value = float.Parse(txtZ.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                string pathCmd = cbxPathCmd.Text.ToString()
                    + " X" + X_value.ToString()
                    + " Y" + Y_value.ToString()
                    + " Z" + Z_value.ToString();
                txtSend.Text = pathCmd;
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(ex.Message + '\n' + "Gia tri nhap phai la mot so thuc!");
                }
            }
        }

        private void angleCmd_TextChanged(object sender, EventArgs e)
        {
            float theta_1_value = 0;
            float theta_2_value = 0;
            float theta_3_value = 0;
            try
            {
                theta_1_value = float.Parse(txtTheta1.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                theta_2_value = float.Parse(txtTheta2.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                theta_3_value = float.Parse(txtTheta3.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                string angleCmd = cbxAngleCmd.Text.ToString()
                    + " X" + theta_1_value.ToString()
                    + " Y" + theta_2_value.ToString()
                    + " Z" + theta_3_value.ToString();
                txtSend.Text = angleCmd;
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(ex.Message + '\n' + "Gia tri nhap phai la mot so thuc!");
                }
            }
        }

        private void controlCmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            float parameter_value = 0;
            try
            {
                parameter_value = float.Parse(txtParameter.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                string controlCmd = cbxControlCmd.Text.ToString();

                if ((controlCmd == "G90") || (controlCmd == "G91") || (controlCmd == "G28") || (controlCmd == "M84"))
                {
                    
                }
                else
                {
                    if (controlCmd == "M203")
                    {
                        controlCmd += " S";
                    }
                    else if (controlCmd == "M204")
                    {
                        controlCmd += " A";
                    }
                    else if (controlCmd == "M206")
                    {
                        controlCmd += " Z";
                    }
                    else if (controlCmd == "M207")
                    {
                        controlCmd += " P";
                    }
                    else if (controlCmd == "M361")
                    {
                        controlCmd += " P";
                    }
                    else if (controlCmd == "M362")
                    {
                        controlCmd += " P";
                    }
                    else if (controlCmd == "M370")
                    {
                        controlCmd += " K";
                    }
                    else if (controlCmd == "G4")
                    {
                        controlCmd += " P";
                    }
                    controlCmd += parameter_value.ToString();
                }
                txtSend.Text = controlCmd;
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(ex.Message + '\n' + "Gia tri nhap phai la mot so thuc!");
                }
            }
        }

        private void singleControl_TextChanged(object sender, EventArgs e)
        {
            float parameter_value = 0;

            TextBox txtCmd = (TextBox) sender;
            try
            {
                parameter_value = float.Parse(txtCmd.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                if (txtCmd.Name == "txtSpeed")
                {
                    txtSend.Text = "M203 S" + parameter_value.ToString();
                }
                else if (txtCmd.Name == "txtAccel")
                {
                    txtSend.Text = "M204 A" + parameter_value.ToString();
                }
                else if (txtCmd.Name == "txtBES")
                {
                    txtSend.Text = "M207 P" + parameter_value.ToString();
                }
                else if (txtCmd.Name == "txtServo")
                {
                    txtSend.Text = "G0 W" + parameter_value.ToString();
                }
                else if (txtCmd.Name == "txtVacuum")
                {
                    txtSend.Text = "G0 V" + parameter_value.ToString();
                }
                else if (txtCmd.Name == "txtLoader")
                {
                    txtSend.Text = "M370 K" + parameter_value.ToString();
                }
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(ex.Message + '\n' + "Gia tri nhap vao phai la mot so thuc!");
                }
            }
        }

        private void rdbAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAbsolute.Checked)
            {
                gCodesToExecute[numberOfCommands] = "G90";
                numberOfCommands++;
            }
        }

        private void rdbRelative_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRelative.Checked)
            {
                gCodesToExecute[numberOfCommands] = "G91";
                numberOfCommands++;
            }
        }

        private void rdbToGcode_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbToGcode.Checked)
            {
                toGcode = true;
            }
        }

        private void rdbMove_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbMove.Checked)
            {
                toGcode = false;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            settingDefaultParameters();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            configHandler();
        }

        private void manual_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            setSlowSpeed();
            isMouseHold = true;
            manual_btn_active = button.Name;

            if (manual_btn_active == "btnYplus")
            {
                gCodesToExecute[numberOfCommands] = "G1 Y" + (_Y + 10).ToString();
                numberOfCommands++;
                last_Y = _Y;
            }
            else if (manual_btn_active == "btnXplus")
            {
                gCodesToExecute[numberOfCommands] = "G1 X" + (_X + 10).ToString();
                numberOfCommands++;
                last_X = _X;
            }
            else if (manual_btn_active == "btnZplus")
            {
                gCodesToExecute[numberOfCommands] = "G1 Z" + (_Z + 10).ToString();
                numberOfCommands++;
                last_Z = _Z;
            }
            else if (manual_btn_active == "btnYminus")
            {
                gCodesToExecute[numberOfCommands] = "G1 Y" + (_Y - 10).ToString();
                numberOfCommands++;
                last_Y = _Y;
            }
            else if (manual_btn_active == "btnXminus")
            {
                gCodesToExecute[numberOfCommands] = "G1 X" + (_X - 10).ToString();
                numberOfCommands++;
                last_X = _X;
            }
            else if (manual_btn_active == "btnZminus")
            {
                gCodesToExecute[numberOfCommands] = "G1 Z" + (_Z - 10).ToString();
                numberOfCommands++;
                last_Z = _Z;
            }


            //time_lastSend = time_ms;
            //lblDebug.Text = time_lastSend.ToString();
        }

        private void manual_MouseUp(object sender, MouseEventArgs e)
        {
            setCurrentSpeed();
            isMouseHold = false;
        }

        private void setSlowSpeed()
        {
                gCodesToExecute[numberOfCommands] = "M203 S20";
                numberOfCommands++;
                gCodesToExecute[numberOfCommands] = "M204 A20";
                numberOfCommands++;
                gCodesToExecute[numberOfCommands] = "M207 P20";
                numberOfCommands++;
        }
        private void setCurrentSpeed()
        {
                gCodesToExecute[numberOfCommands] = "M203 S" + speed.ToString();
                numberOfCommands++;
                gCodesToExecute[numberOfCommands] = "M204 A" + accel.ToString();
                numberOfCommands++;
                gCodesToExecute[numberOfCommands] = "M207 P" + BES.ToString();
                numberOfCommands++;
        }
        private void manualHandler()
        {
            if (isMouseHold)
            {
                if (manual_btn_active == "btnYplus")
                {
                    //if ((time_ms - time_lastSend)>5)
                    //{
                    if (last_Y != _Y)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 Y" + (_Y + 10).ToString();
                        numberOfCommands++;
                        last_Y = _Y;
                    }
                    //time_lastSend = time_ms;
                    //lblDebug.Text = time_lastSend.ToString();
                    //}
                }
                else if (manual_btn_active == "btnYminus")
                {
                    if (last_Y != _Y)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 Y" + (_Y - 10).ToString();
                        numberOfCommands++;
                        last_Y = _Y;
                    }
                }
                else if (manual_btn_active == "btnXplus")
                {
                    if (last_X != _X)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 X" + (_X + 10).ToString();
                        numberOfCommands++;
                        last_X = _X;
                    }
                }
                else if (manual_btn_active == "btnXminus")
                {
                    if (last_X != _X)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 X" + (_X - 10).ToString();
                        numberOfCommands++;
                        last_X = _X;
                    }
                }
                else if (manual_btn_active == "btnZplus")
                {
                    if (last_Z != _Z)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 Z" + (_Z + 10).ToString();
                        numberOfCommands++;
                        last_Z = _Z;
                    }
                }
                else if (manual_btn_active == "btnZminus")
                {
                    if (last_Z != _Z)
                    {
                        gCodesToExecute[numberOfCommands] = "G1 Z" + (_Z - 10).ToString();
                        numberOfCommands++;
                        last_Z = _Z;
                    }
                }
            }
        }
        private void configHandler()
        {
            gCodesToExecute[numberOfCommands] = "M203 S" + this.txtSpeedSetting.Text.ToString();
            numberOfCommands++;
            gCodesToExecute[numberOfCommands] = "M204 A" + this.txtAccelSetting.Text.ToString();
            numberOfCommands++;
            gCodesToExecute[numberOfCommands] = "M206 Z" + this.txtOffsetSetting.Text.ToString();
            numberOfCommands++;
            gCodesToExecute[numberOfCommands] = "M207 P" + this.txtBESSetting.Text.ToString();
            numberOfCommands++;
            gCodesToExecute[numberOfCommands] = "M361 P" + this.txtSegLineSetting.Text.ToString();
            numberOfCommands++;
            gCodesToExecute[numberOfCommands] = "M362 P" + this.txtSegArcSetting.Text.ToString();
            numberOfCommands++;
            if (this.cbxCoorMode.Text == "Absolute")
            {
                gCodesToExecute[numberOfCommands] = "G90";
                numberOfCommands++;
            }
            else if (this.cbxCoorMode.Text == "Relative")
            {
                gCodesToExecute[numberOfCommands] = "G91";
                numberOfCommands++;
            }
        }

        private void circleCmd_TextChanged(object sender, EventArgs e)
        {
            float X_value = 0;
            float Y_value = 0;
            float Z_value = 0;
            float I_value = 0;
            float J_value = 0;
            try
            {
                X_value = float.Parse(textBox3.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                Y_value = float.Parse(textBox2.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                Z_value = float.Parse(textBox1.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                I_value = float.Parse(textBox5.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                J_value = float.Parse(textBox4.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                string circleCmd = comboBox2.Text.ToString()
                    + " I" + I_value.ToString()
                    + " J" + J_value.ToString()
                    + " X" + X_value.ToString()
                    + " Y" + Y_value.ToString()
                    + " Z" + Z_value.ToString();
                txtSend.Text = circleCmd;
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(ex.Message + '\n' + "Gia tri nhap phai la mot so thuc!");
                }
            }
        }
    }
}