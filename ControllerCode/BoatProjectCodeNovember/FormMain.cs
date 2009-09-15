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
        enum destinations { rudder = 0 };

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

            sendMessage(destinations.rudder, (char)pos_hi, (char)pos_low);
        }

        private void sendMessage(destinations destinationId, char command1, char command2)
        {
            if (port != null && port.IsOpen)
            {
                string message = "%" + "0"//destinationChar(destinationId)
                    + command1 + command2;

                if (message.Length != 4)
                    throw new Exception("Message Length is not Four Characters!");

                port.Write(message);
            }
        }

        private char destinationChar(destinations destinationId) 
        {
            return Convert.ToChar(((int)destinationId));
        }
    }
}
