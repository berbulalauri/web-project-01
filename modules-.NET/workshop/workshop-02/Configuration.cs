﻿using System;
using System.Collections.Generic;
using System.Text;

namespace workshop2
{
    public class Configuration
    {
        public static string FileName { get; set; } = "../../../subscribers.json";
        public static string LogPath { get; set; } = $"../../../subscribersLog.json";
    }
}