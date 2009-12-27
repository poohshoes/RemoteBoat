using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatProjectCodeNovember
{
    public enum MotorState 
    {
        Left,
        Right,
        Stop
    }

    class Boat
    {
        private ArduinoCommunicationHandler communicationHandler;

        Dictionary<char, MotorState> motorStates;

        // safe values are between 900 and 4700
        public int rudder;

        public int rudderPosition 
        {
            get 
            {
                return rudder;
            }
            set 
            {
                if (900 <= value && value <= 4700)
                {
                    rudder = value;
                    updateRudderPosition(rudder);
                }
            }
        }

        public Boat(ArduinoCommunicationHandler arduinoCommunicationHandler)
        {
            communicationHandler = arduinoCommunicationHandler;
            motorStates = new Dictionary<char, MotorState>();
            motorStates.Add(ArduinoCommunicationHandler.HEAD_SAIL_SHEET, MotorState.Stop);
            motorStates.Add(ArduinoCommunicationHandler.JIB_HOIST_ID, MotorState.Stop);
            motorStates.Add(ArduinoCommunicationHandler.MAIN_SAIL_SHEET, MotorState.Stop);
            motorStates.Add(ArduinoCommunicationHandler.TOP_SAIL_HOIST_ID, MotorState.Stop);
            motorStates.Add(ArduinoCommunicationHandler.TOP_SAIL_SHEET, MotorState.Stop);
        }

        private void updateRudderPosition(int newRudderPosition) 
        {
            // One final check just to be sure (errors here could break the servo).
            if (newRudderPosition < 900 || newRudderPosition > 4700)
                throw new Exception("Track Bar Rudder Value is out of range.");

            uint temp;
            byte pos_hi, pos_low;

            temp = (uint)newRudderPosition & 0x1f80;  //get bits 8 thru 13 of position
            pos_hi = (byte)(temp >> 7);     //shift bits 8 thru 13 by 7
            pos_low = (byte)((uint)newRudderPosition & 0x7f); //get lower 7 bits of position

            communicationHandler.sendMessage(ArduinoCommunicationHandler.RUDDER_ID, (char)pos_hi, (char)pos_low);
        }

        public void topSailTrim(MotorState motorState)
        {
            if(motorStates[ArduinoCommunicationHandler.TOP_SAIL_SHEET] != motorState)
            {
                motorStates[ArduinoCommunicationHandler.TOP_SAIL_SHEET] = motorState;
                setMotor(ArduinoCommunicationHandler.TOP_SAIL_SHEET, motorState);
            }
        }

        public void jibTrim(MotorState motorState)
        {
            if (motorStates[ArduinoCommunicationHandler.HEAD_SAIL_SHEET] != motorState)
            {
                motorStates[ArduinoCommunicationHandler.HEAD_SAIL_SHEET] = motorState;
                setMotor(ArduinoCommunicationHandler.HEAD_SAIL_SHEET, motorState);
            }
        }

        public void topHoist(MotorState motorState) 
        {
            if (motorStates[ArduinoCommunicationHandler.TOP_SAIL_HOIST_ID] != motorState)
            {
                motorStates[ArduinoCommunicationHandler.TOP_SAIL_HOIST_ID] = motorState;
                setMotor(ArduinoCommunicationHandler.TOP_SAIL_HOIST_ID, motorState);
            }
        }

        public void jibHoist(MotorState motorState) 
        {
            if (motorStates[ArduinoCommunicationHandler.JIB_HOIST_ID] != motorState)
            {
                motorStates[ArduinoCommunicationHandler.JIB_HOIST_ID] = motorState;
                setMotor(ArduinoCommunicationHandler.JIB_HOIST_ID, motorState);
            }
        }

        public void mainSheet(MotorState motorState)
        {
            if (motorStates[ArduinoCommunicationHandler.MAIN_SAIL_SHEET] != motorState)
            {
                motorStates[ArduinoCommunicationHandler.MAIN_SAIL_SHEET] = motorState;
                setMotor(ArduinoCommunicationHandler.MAIN_SAIL_SHEET, motorState);
                motorStates[ArduinoCommunicationHandler.HEAD_SAIL_SHEET] = motorState;
                setMotor(ArduinoCommunicationHandler.HEAD_SAIL_SHEET, motorState);
                // The top sail sheet works opposite of the main and head sail sheets.
                MotorState topSailSheetMotorState;
                switch (motorState)
                {
                    case MotorState.Left:
                        topSailSheetMotorState = MotorState.Right;
                        break;
                    case MotorState.Right:
                        topSailSheetMotorState = MotorState.Left;
                        break;
                    case MotorState.Stop:
                        topSailSheetMotorState = MotorState.Stop;
                        break;
                    default:
                        throw new Exception("Motor state is not handled.");
                }
                motorStates[ArduinoCommunicationHandler.TOP_SAIL_SHEET] = topSailSheetMotorState;
                setMotor(ArduinoCommunicationHandler.TOP_SAIL_SHEET, topSailSheetMotorState);
            }
        }

        private void setMotor(char motorId, MotorState motorState) 
        {
            communicationHandler.sendMessage(motorId,
                getMotorOnOffFlag(motorState),
                getMotorRotationFlag(motorState));
        }

        private char getMotorRotationFlag(MotorState motorState) 
        {
            switch (motorState) 
            {
                case MotorState.Left:
                    return ArduinoCommunicationHandler.ROTATE_LEFT;
                case MotorState.Right:
                    return ArduinoCommunicationHandler.ROTATE_RIGHT;
                case MotorState.Stop:
                    // this value is not used anyway so we will return rotate left as a filler
                    return ArduinoCommunicationHandler.ROTATE_LEFT;
                default:
                    throw new Exception("Motor state is not handled.");
            }
        }

        private char getMotorOnOffFlag(MotorState motorState) 
        {
            switch (motorState)
            {
                case MotorState.Left:
                case MotorState.Right:
                    return ArduinoCommunicationHandler.MOTOR_ON;
                case MotorState.Stop:
                    return ArduinoCommunicationHandler.MOTOR_OFF;
                default:
                    throw new Exception("Motor state not handled.");
            }
        }
    }
}
