using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoatProjectCodeNovember
{
    class MotorController
    {
        char motorId;
        ArduinoCommunicationHandler communicationHandler;

        // which keys to rotate left/right on
        List<Keys> rotateLeftKeys;
        List<Keys> rotateRightKeys;

        // motor commands that are mirrored on the arduino board
        const char motorOn = 'n';
        const char motorOff = 'f';

        const char rotateLeft = 'l';
        const char rotateRight = 'r';

        public MotorController(char motorId, ArduinoCommunicationHandler communicationHandler,
            List<Keys> rotateLeftKeys, List<Keys> rotateRightKeys) 
        {
            this.motorId = motorId;
            this.communicationHandler = communicationHandler;
            this.rotateLeftKeys = rotateLeftKeys;
            this.rotateRightKeys = rotateRightKeys;
        }

        public void keyPress(Keys key) 
        {
            if (rotateLeftKeys.Contains(key))
                RotateLeft();
            else if (rotateRightKeys.Contains(key))
                RotateRight();
        }

        public void keyRelease(Keys key) 
        {
            if (rotateLeftKeys.Contains(key) || rotateRightKeys.Contains(key))
                StopRotating();
        }

        private void RotateLeft() 
        {
            communicationHandler.sendMessage(motorId, motorOn, rotateLeft);
        }

        private void RotateRight()
        {
            communicationHandler.sendMessage(motorId, motorOn, rotateRight);
        }

        private void StopRotating() 
        {
            // note that rotateLeft is only a placeholder
            communicationHandler.sendMessage(motorId, motorOff, rotateLeft);
        }
    }
}
