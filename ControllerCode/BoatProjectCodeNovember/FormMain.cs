using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BoatProjectCodeNovember
{
    public partial class FormMain : Form
    {
        ArduinoCommunicationHandler communicationHandler;
        MotorControllerList motorControllerList;
        XBoxControllerManager xboxControllerManager;
        Boat boat;

        public FormMain()
        {
            InitializeComponent();

            communicationHandler = new ArduinoCommunicationHandler();
            motorControllerList = new MotorControllerList(communicationHandler);
            boat = new Boat(communicationHandler);
            xboxControllerManager = new XBoxControllerManager();

            string[] portlist = communicationHandler.getCOMPorts();

            foreach (String s in portlist)
            {
                comboBoxCOMPort.Items.Add(s);
            }
        }

        private void buttonTrimIn_Click(object sender, EventArgs e)
        {
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            communicationHandler.connectToCOMPort(comboBoxCOMPort.SelectedItem.ToString());

            comboBoxCOMPort.Enabled = false;
            buttonConnect.Enabled = false;
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

            communicationHandler.sendMessage(ArduinoCommunicationHandler.RUDDER_ID, (char)pos_hi, (char)pos_low);
        }

        private void controllerUpdateTimer_Tick(object sender, EventArgs e)
        {
            xboxControllerManager.Update();
            processControllerInput();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int change = Convert.ToInt32(numericUpDownRudderSpeed.Value);

            if (e.KeyCode == System.Windows.Forms.Keys.Left)
            {
                if (trackBarRudder.Value - change < 900)
                    trackBarRudder.Value = 900;
                else
                    trackBarRudder.Value -= Convert.ToInt32(change);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                if (trackBarRudder.Value + change > 4700)
                    trackBarRudder.Value = 4700;
                else
                    trackBarRudder.Value += Convert.ToInt32(change);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Space)
                trackBarRudder.Value = ((trackBarRudder.Maximum - trackBarRudder.Minimum) / 2) + trackBarRudder.Minimum;

            motorControllerList.notifyMotorsOfKeyPress(e.KeyCode);
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            motorControllerList.notifyMotorsOfKeyRelease(e.KeyCode);
        }

        private void processControllerInput() 
        {
            PlayerIndex playerIndex = PlayerIndex.One;

            // currently we only have one boat so I am using controller 1 for boat 1 and ignoring the others
            if (xboxControllerManager[playerIndex].isConnected())
            {
                SetControllerConnectedLabel(true);

                if (xboxControllerManager[playerIndex].thumbStickStateHasChanged()) 
                {
                    // the right thumbstick is mapped to the rudder.
                    boat.rudderPosition = XBoxControllerToBoatMapping.getRudderPosition(xboxControllerManager[PlayerIndex.One].gamePadState.ThumbSticks.Right.X);

                    double leftY = xboxControllerManager[playerIndex].gamePadState.ThumbSticks.Left.Y;
                    if (-1d <= leftY && leftY <= -0.05) 
                    {
                        boat.mainSheet(MotorState.Left);
                    }
                    else if (0.5 <= leftY && leftY <= 1)
                    {
                        boat.mainSheet(MotorState.Right);
                    }
                    else 
                    {
                        boat.mainSheet(MotorState.Stop);
                    }
                }

                GamePadChangeSet gamePadChanges = xboxControllerManager.getGamePadStateChange(playerIndex);
                foreach (ButtonChange bc in gamePadChanges.buttonChanges) 
                {
                    switch (bc.button) 
                    {
                        case Buttons.A:
                            if(bc.state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                                boat.topHoist(MotorState.Left);
                            else
                                boat.topHoist(MotorState.Stop);
                            break;
                    }
                }
            }
            else 
            {
                SetControllerConnectedLabel(false);
            }
        }

        private void SetControllerConnectedLabel(bool isConnected)
        {
            if (isConnected)
            {
                controllerConnectedLabel.ForeColor = Color.Green;
                controllerConnectedLabel.Text = "Controller One Found";
            }
            else
            {
                controllerConnectedLabel.ForeColor = Color.Red;
                controllerConnectedLabel.Text = "No Controller Detected";
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            controllerUpdateTimer.Start();
        }
    }
}
