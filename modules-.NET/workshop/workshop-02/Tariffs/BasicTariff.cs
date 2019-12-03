using System;
using System.Collections.Generic;
using System.Text;

namespace workshop2.Tariffs
{
    class BasicTariff : ITariff
    {
        public string TariffName { get; set; }
        public double CoefficientOfCoating { get; set; }

    }
}
