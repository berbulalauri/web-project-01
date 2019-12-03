using System;
namespace workshop_02.Tariffs
{
    public class Lowcost : AirLineTypes
    {
        public int MaximumLuggageWeight { get; set; }
        public bool IsBusinessСlassAvailable { get; set; }
        public bool IsPetFriendly { get; set; }
        public Lowcost(int maximumLuggageWeight)
        {
            MaximumLuggageWeight = maximumLuggageWeight;
        }
    }
}

