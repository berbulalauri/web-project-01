using System;
namespace workshop2.Tariffs
{
    public class CheetahTariff : ITariff
    {
        public string TariffName { get; set; }
        public double CoefficientOfCoating { get; set; }

        public CheetahTariff()
        {
            TariffName = "YYYY";
            CoefficientOfCoating = 66.6;

        }
    }
}
