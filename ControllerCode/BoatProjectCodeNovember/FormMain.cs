using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;

namespace BoatProjectCodeNovember
{
    public partial class FormMain : Form
    {
        const char rudderId = '0';
        const char topsailHoistId = '1';

        SerialPort port;

        public FormMain()
        {
            InitializeComponent(); 
            
            string[] portlist = SerialPort.GetPortNames();

            foreach (String s in portlist)
            {
                comboBoxCOMPort.Items.Add(s);
            }
        }

        private void buttonTrimIn_Click(object sender, EventArgs e)
        {
            function();
        }

        private void function() { }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (port != null)
            {
                port.Close();
                port.Dispose();
            }

            port = new SerialPort(comboBoxCOMPort.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
            port.Open();

            comboBoxCOMPort.Enabled = false;
            buttonConnect.Enabled = false;
        }

        ~FormMain()
        {
            if (port != null)
            {
                port.Close();
                port.Dispose();
            }
        }

        private void trackBarRudder_ValueChanged(object sender, EventArgs e)
        {
            if (trackBarRudder.Value < 900 || trackBarRudder.Value > 4700)
                throw new Exception("Track Bar Rudder Value is out of range.");

            uint temp;
            byte pos_hi,pos_low;

            temp = (uint)trackBarRudder.Value & 0x1f80;  //get bits 8 thru 13 of position
            pos_hi = (byte)(temp >> 7);     //shift bits 8 thru 13 by 7
            pos_low = (byte)((uint)trackBarRudder.Value & 0x7f); //get lower 7 bits of position

            sendMessage(rudderId, (char)pos_hi, (char)pos_low);
        }

        private void sendMessage(char destinationId, char command1, char command2)
        {
            if (port != null && port.IsOpen)
            {
                string message = "%" + destinationId
                    + command1 + command2;

                if (message.Length != 4)
                    throw new Exception("Message Length is not Four Characters!");

                port.Write(message);
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int change = Convert.ToInt32(numericUpDownRudderSpeed.Value);

            if (e.KeyCode == Keys.Left)
            {
                if (trackBarRudder.Value - change < 900)
                    trackBarRudder.Value = 900;
                else
                    trackBarRudder.Value -= Convert.ToInt32(change);
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (trackBarRudder.Value + change > 4700)
                    trackBarRudder.Value = 4700;
                else
                    trackBarRudder.Value += Convert.ToInt32(change);
            }
            else if (e.KeyCode == Keys.Space)
                trackBarRudder.Value = ((trackBarRudder.Maximum - trackBarRudder.Minimum) / 2) + trackBarRudder.Minimum;
            else if (e.KeyCode == Keys.E) 
            {
                sendMessage(topsailHoistId, 'n', 'l');
            }
            else if (e.KeyCode == Keys.D)
            {
                sendMessage(topsailHoistId, 'n', 'r');
            }

        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E) 
            {
                sendMessage(topsailHoistId, 'f', 'l');
            }
            else if (e.KeyCode == Keys.D) 
            {
                sendMessage(topsailHoistId, 'f', 'l');
            }
        }     
    }
}
