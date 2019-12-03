using System;
using System.Collections.Generic;
using System.Text;

namespace workshop_02.Tariffs
{
    class BasicTypes : AirLineTypes
    {
        public int MaximumLuggageWeight { get; set; }
        public bool IsBusinessСlassAvailable { get; set; }
        public bool IsPetFriendly { get; set; }

    }
}

