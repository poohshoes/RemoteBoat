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

        // Rudder id
        public const char RUDDER_ID = '0';
        // Motor Ids
        public const char TOP_SAIL_HOIST_ID = '1';
        public const char JIB_HOIST_ID = '2';
        public const char TOP_SAIL_SHEET = '3';
        public const char HEAD_SAIL_SHEET = '4';
        public const char MAIN_SAIL_SHEET = '5';

        // motor commands that are mirrored on the arduino board
        public const char MOTOR_ON = 'n';
        public const char MOTOR_OFF = 'f';

        public const char ROTATE_LEFT = 'l';
        public const char ROTATE_RIGHT = 'r';

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
