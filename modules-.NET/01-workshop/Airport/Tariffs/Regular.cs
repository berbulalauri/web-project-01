using System;
namespace workshop_02.Tariffs
{
    public class Regular : AirLineTypes
    {
        public int MaximumLuggageWeight { get; set; }
        public bool IsBusinessСlassAvailable { get; set; }
        public bool IsPetFriendly { get; set; }

        public Regular(int maximumLuggageWeight, bool isBusinessСlassAvailable, bool isPetFriendly)
        {
            MaximumLuggageWeight = maximumLuggageWeight;
            IsBusinessСlassAvailable = isBusinessСlassAvailable;
            IsPetFriendly = isPetFriendly;
        }
    }
}

