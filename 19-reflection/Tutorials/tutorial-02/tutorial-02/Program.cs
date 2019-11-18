using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
        try
            {
                var ass = Assembly.GetExecutingAssembly();
                //Type type = ass.GetType("betterFuture.Program", false, true);
                Type type = typeof(Random);

                //var randomType = new Random().GetType();
                object randomObj = Activator.CreateInstance(type);
                MethodInfo programNext = type.GetMethod("Next", new Type[] { typeof(int), typeof(int) });
                //MethodInfo randomNext = randomType.GetMethod("Next");
                
                object result = programNext.Invoke(randomObj, new object[] { 50, 100 });
                Console.WriteLine($"result is: {(int)result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}
