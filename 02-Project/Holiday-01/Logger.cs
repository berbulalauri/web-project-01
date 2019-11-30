using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace workshop2
{
    public class Logger
    {
        public static void Log(string methodName, string message, params string[] parameter)
        {
            try
            {
                var msg = ComposeLogMessage(methodName, message, parameter);

                File.AppendAllText(Configuration.LogPath, msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something weng wrong with This code: {ex.Message}");
                throw;
            }
        }

        public static string ComposeLogMessage(string methodName, string message, params string[] parameter)
        {

            return $"{DateTime.Now.ToString("s")} : {message}, methods: {methodName}, parans: {string.Join(", ", parameter)}";

        }

    }
}
