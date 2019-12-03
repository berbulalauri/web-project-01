using System;
namespace workshop2.Tariffs
{
    public interface ITariff
    {
        string TariffName { get; set; }
        double CoefficientOfCoating { get; set; }

        public string ToString()
        {
            return TariffName;
        }
    }
}
