using System;
using System.Runtime.Serialization;

namespace tutorial_01.Middlewares
{
    [Serializable]
    internal class AccessDeniedExcepiton : Exception
    {
        public override string Message => "Access denied! Sorryyyyyy!";
    }
}