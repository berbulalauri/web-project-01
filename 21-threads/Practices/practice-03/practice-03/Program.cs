using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Threading;

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
                object obj = new object();
                var listint = new List<int>();
                //var mm = new object[20];
                Console.WriteLine("I create array of 20 elemets:");
                for (int i = 0; i < 20; i++)
                {
                    object result = programNext.Invoke(randomObj, new object[] { -100, 100 });
                    Console.Write($"{(int)result} ");
                    //mm[i] = (int)result;
                    listint.Add((int)result);
                }
                Console.WriteLine();
                Thread thr1 = new Thread(PositiveNumbers);
                thr1.Start(listint);

                Thread thr2 = new Thread(NegativeNumbers);
                thr2.Start(listint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PositiveNumbers(object numcollection)
        {
            IList collection = (IList)numcollection;

            for (int i = 0; i < collection.Count; i++)
            {
                if (0 < (int)collection[i])
                {
                    Thread.Sleep(10);
                    Console.WriteLine("" + collection[i]);
                }
            }
        }
        static void NegativeNumbers(object numcollection)
        {
            IList collection = (IList)numcollection;

            for (int i = 0; i < collection.Count; i++)
            {
                if ((int)collection[i] < 0)
                {
                    Thread.Sleep(10);
                    Console.WriteLine("Negative Number is " + collection[i]);
                }

            }
        }
    }

}
