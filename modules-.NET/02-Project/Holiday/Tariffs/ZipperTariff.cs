using System;
namespace workshop2.Tariffs
{
    public class ZipperTariff : ITariff
    {
        public string TariffName { get; set; }
        public double CoefficientOfCoating { get; set; }

        public ZipperTariff()
        {
            TariffName = "XXXX";
            CoefficientOfCoating = 3.6;
        }
    }
}
