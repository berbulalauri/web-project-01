using System;
using System.Runtime.Serialization;

namespace practice_02.Middlewares
{
    [Serializable]
    internal class PageNotFoundException : Exception
    {
        public override string Message => "Page Not Found Exception";
        public static int HttpCode { get; set; } = 404;
    }
}