using System;
using System.Collections.Generic;
using System.Text;

namespace tutorial_02
{
    class IncreadibleTemperatureException : Exception
    {
        public override string Message => "Temperature is big";

    }
}
