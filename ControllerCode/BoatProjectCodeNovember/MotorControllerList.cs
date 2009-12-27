using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoatProjectCodeNovember
{
    class MotorControllerList
    {
        List<MotorController> motorControllers;

        public MotorControllerList(ArduinoCommunicationHandler communicationHandler) 
        {
            motorControllers = new List<MotorController>();

            // create the motors
            motorControllers.Add(
                new MotorController(
                    ArduinoCommunicationHandler.TOP_SAIL_HOIST_ID,
                    communicationHandler,
                    new[] { Keys.E }.ToList(),
                    new[] { Keys.D }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    ArduinoCommunicationHandler.JIB_HOIST_ID,
                    communicationHandler,
                    new[] { Keys.R }.ToList(),
                    new[] { Keys.F }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    ArduinoCommunicationHandler.TOP_SAIL_SHEET,
                    communicationHandler,
                    new[] { Keys.Down, Keys.W }.ToList(),
                    new[] { Keys.Up, Keys.S }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    ArduinoCommunicationHandler.HEAD_SAIL_SHEET,
                    communicationHandler,
                    new[] { Keys.Up, Keys.Q }.ToList(),
                    new[] { Keys.Down, Keys.A }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    ArduinoCommunicationHandler.MAIN_SAIL_SHEET,
                    communicationHandler,
                    new[] { Keys.Up }.ToList(),
                    new[] { Keys.Down }.ToList()
                )
            );
        }

        public void notifyMotorsOfKeyPress(Keys key)
        {
            foreach (MotorController m in motorControllers) 
            {
                m.keyPress(key);
            }
        }

        public void notifyMotorsOfKeyRelease(Keys key) 
        {
            foreach (MotorController m in motorControllers) 
            {
                m.keyRelease(key);
            }
        }
    }
}
