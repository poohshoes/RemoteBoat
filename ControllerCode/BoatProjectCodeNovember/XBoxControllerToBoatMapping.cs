using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BoatProjectCodeNovember
{
    static class XBoxControllerToBoatMapping
    {
        static public int getRudderPosition(double thumbstickValue) 
        {
            Debug.Assert(-1 <= thumbstickValue && thumbstickValue <= 1, "Input value is out of range.");
            // The goal of this is a mapping of -1 to 1 TO 900 to 4700

            // This gives us 0 to 2
            thumbstickValue += 1;

            // 4700 - 900 is 3800, so with the below we get 0 to 3800
            thumbstickValue *= 1900;

            thumbstickValue += 900;

            Debug.Assert(900 <= thumbstickValue && thumbstickValue <= 4700, "Derived value is out of range.");
            return System.Convert.ToInt32(thumbstickValue);
        }
    }
}
