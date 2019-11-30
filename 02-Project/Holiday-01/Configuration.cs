using System;
using System.Collections.Generic;
using System.Text;

namespace workshop2
{
    public class Configuration
    {
        public static string FileName { get; set; } = "../../../holidays.json";
        public static string LogPath { get; set; } = $"../../../holidaysLog.log";
    }
}
