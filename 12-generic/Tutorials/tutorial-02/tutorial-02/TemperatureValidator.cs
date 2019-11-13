using System;

namespace tutorial_02
{
    public class TemperatureValidator
    {
        private const int minValue = -60;
        private const int maxValue = 60;

        public static void CheckTemp(double temp)
        {
            if (temp < -60 || temp > 60)
            {
                throw new IncreadibleTemperatureException();
            }
        }
    }
}
