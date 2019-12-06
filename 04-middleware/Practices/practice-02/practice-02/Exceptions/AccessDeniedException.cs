using System;
using System.Runtime.Serialization;

namespace practice_02.Middlewares
{
    [Serializable]
    internal class AccessDeniedExcepiton : Exception
    {
        public override string Message => "<h1> Payment Required!</h1>";
    }
}