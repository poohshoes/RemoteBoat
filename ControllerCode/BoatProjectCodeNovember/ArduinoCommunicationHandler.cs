using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace BoatProjectCodeNovember
{
    class ArduinoCommunicationHandler
    {
        SerialPort port;

        public void sendMessage(char destinationId, char command1, char command2)
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

        public string[] getCOMPorts() 
        {
            return SerialPort.GetPortNames();
        }

        public void connectToCOMPort(string comPort) 
        {
            if (port != null)
            {
                port.Close();
                port.Dispose();
            }

            port = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
        }

        ~ArduinoCommunicationHandler()
        {
            if (port != null)
            {
                port.Close();
                port.Dispose();
            }
        }
    }
}
