using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Input = Microsoft.Xna.Framework.Input; // to provide shorthand to clear up ambiguities

namespace BoatProjectCodeNovember
{
    class XBoxControllerManager
    {
        private Dictionary<PlayerIndex, XBoxController> controllers = new Dictionary<PlayerIndex, XBoxController>();

        public XBoxController this[PlayerIndex index]
        {
            get
            {
                return controllers[index];
            }
        }

        public XBoxControllerManager()
        {
            foreach (PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
            {
                controllers.Add(playerIndex, new XBoxController(playerIndex));
            }
        }

        public void stopAllVibration()
        {
            foreach (XBoxController controller in controllers.Values)
                controller.setVibration(0.0f, 0.0f);
        }

        public void setVibration(PlayerIndex player, float leftMotorValue, float rightMotorValue)
        {
            controllers[player].setVibration(leftMotorValue, rightMotorValue);
        }

        public void Update() 
        {
            foreach (XBoxController x in controllers.Values)
                x.UpdateState();
        }

        public GamePadChangeSet getGamePadStateChange(PlayerIndex player) 
        {
            return controllers[player].getGamePadChanges();
        }
    }

    class XBoxController
    {
        //To keep track of the current and previous state of the gamepad
        /// <summary>
        /// The current state of the controller
        /// </summary>
        public GamePadState gamePadState { get; private set; }
        /// <summary>
        /// The previous state of the controller
        /// </summary>
        private GamePadState previousState;
        /// <summary>
        /// Keeps track of the current controller
        /// </summary>
        private PlayerIndex playerIndex { get; set; }

        public XBoxController(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
        }

        public void setVibration(float leftMotorValue, float rightMotorValue)
        {
            GamePad.SetVibration(playerIndex, leftMotorValue, rightMotorValue);
        }

        public void UpdateState() 
        {
            previousState = gamePadState;
            gamePadState = GamePad.GetState(playerIndex);
        }

        public bool isConnected() 
        {
            return gamePadState.IsConnected;
        }

        public bool buttonStateHasChanged()
        {
            return !gamePadState.Buttons.Equals(previousState.Buttons);
        }

        public bool dpadStateHasChanged()
        {
            return !gamePadState.DPad.Equals(previousState.DPad);
        }

        public bool thumbStickStateHasChanged() 
        {
            return !gamePadState.ThumbSticks.Equals(previousState.ThumbSticks);
        }

        public GamePadChangeSet getGamePadChanges() 
        {
            return GamePadStateChanges.getGamePadStateChange(gamePadState, previousState);
        }
    }
}
