using System;
using System.Runtime.Serialization;

namespace tutorial_01.Middlewares
{
    [Serializable]
    internal class WebException : Exception
    {
        public static int HttpCode { get; set; } = 403;
        //public override string Message => "Access denied! Sorryyyyyy!";
    }
}