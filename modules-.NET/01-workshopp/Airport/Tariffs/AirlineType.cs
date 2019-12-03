using System;
namespace workshop_02.Tariffs
{
    public interface AirLineTypes
    {
        int MaximumLuggageWeight { get; set; }
        bool IsBusinessСlassAvailable { get; set; }
        bool IsPetFriendly { get; set; }

        public int ToString()
        {
            //TariffName = "XXXXXXXXXX";
            return MaximumLuggageWeight;
        }
    }
}

