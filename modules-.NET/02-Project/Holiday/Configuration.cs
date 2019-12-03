using System;
using System.Collections.Generic;
using System.Text;

namespace workshop2
{
    public class Configuration
    {
        public static string FileName { get; set; } = "../../../Holidayers.json";
        public static string LogPath { get; set; } = $"../../../subscribersLog.json";
    }
}
