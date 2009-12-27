using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace BoatProjectCodeNovember
{
    class GamePadStateChanges
    {
        static public GamePadChangeSet getGamePadStateChange(GamePadState newState, GamePadState oldState) 
        {
            GamePadChangeSet gamePadStateChanges;
            gamePadStateChanges.buttonChanges = new List<ButtonChange>();

            foreach (Buttons but in Enum.GetValues(typeof(Buttons)))
            {
                if (newState.IsButtonDown(but) != oldState.IsButtonDown(but))
                    gamePadStateChanges.buttonChanges.Add(
                        new ButtonChange() 
                        { button = but, 
                          state = newState.IsButtonDown(but) ? 
                            ButtonState.Pressed : 
                            ButtonState.Released 
                        }
                    );
            }

            return gamePadStateChanges;
        }
    }

    struct GamePadChangeSet 
    {
        public List<ButtonChange> buttonChanges;
    }

    struct ButtonChange 
    {
        public Buttons button;
        public ButtonState state;
    }
}
