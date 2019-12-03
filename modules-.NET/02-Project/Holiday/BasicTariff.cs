using System;
using System.Collections.Generic;
using System.Text;
using workshop2.Tariffs;

namespace workshop2
{
    public class BasicTariff : ITariff
    {
        public string TariffName { get; set; }
        public double CoefficientOfCoating { get; set ; }
    }
}
