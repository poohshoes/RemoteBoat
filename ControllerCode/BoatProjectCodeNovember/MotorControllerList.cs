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

        const char topsailHoistId = '1';
        const char jibHoistId = '2';
        const char topSailSheet = '3';
        const char headSailSheet = '4';
        const char mainSailSheet = '5';

        public MotorControllerList(ArduinoCommunicationHandler communicationHandler) 
        {
            motorControllers = new List<MotorController>();

            // create the motors
            motorControllers.Add(
                new MotorController(
                    topsailHoistId,
                    communicationHandler,
                    new[] { Keys.E }.ToList(),
                    new[] { Keys.D }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    jibHoistId,
                    communicationHandler,
                    new[] { Keys.R }.ToList(),
                    new[] { Keys.F }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    topSailSheet,
                    communicationHandler,
                    new[] { Keys.Down, Keys.W }.ToList(),
                    new[] { Keys.Up, Keys.S }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    headSailSheet,
                    communicationHandler,
                    new[] { Keys.Up, Keys.Q }.ToList(),
                    new[] { Keys.Down, Keys.A }.ToList()
                )
            );

            motorControllers.Add(
                new MotorController(
                    mainSailSheet,
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
