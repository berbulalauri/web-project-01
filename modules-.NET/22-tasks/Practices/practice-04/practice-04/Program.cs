using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int breakIndex = 3;
            var random = new Random();
            var locker = new object();
            List<string> sitelist = new List<string>();

            sitelist.Add("www.gol.ge");
            sitelist.Add("www.avoe.ge");
            sitelist.Add("www.fafadsasda.ge");
            sitelist.Add("www.eqweqwdwd32.ge");
            sitelist.Add("www.drive.google.com");
            sitelist.Add("www.google.com");
            sitelist.Add("www.yahoo.com");
            sitelist.Add("www.faceook.com");
            sitelist.Add("www.gmail.com");
            sitelist.Add("www.amazon.com");
            sitelist.Add("www.wikimedia.com");
            sitelist.Add("www.taobao.com");
            sitelist.Add("www.alibaba.com");
            sitelist.Add("www.ebay.com");
            sitelist.Add("www.forever21.com");

            var numbers = Enumerable.Range(1, sitelist.Count - 1);
            Parallel.ForEach(numbers, (i, state) => {
                bool isSitePingable = false;
                Ping pinging = null;
                try
                {
                    pinging = new Ping();
                    PingReply pingReply = pinging.Send(sitelist[i]);
                    isSitePingable = pingReply.Status == IPStatus.Success;
                }
                catch (PingException ex)
                {
                    //Console.WriteLine("ping EX: "+ex.Message);
                }
                finally
                {
                    if (pinging != null)
                    {
                        pinging.Dispose();
                    }
                }
                if (isSitePingable) { Console.WriteLine($" Site {sitelist[i]} is online!"); } else { Console.WriteLine($" Site {sitelist[i]} is OFFLINE!"); }

                lock (locker)
                {
                    var delay = random.Next(500, 3000);
                    Task.Delay(delay).GetAwaiter().GetResult();

                }

                if (i == breakIndex)
                {
                    //Console.WriteLine($"Breaking Iteration {i} {sitelist[i]}");
                    state.Break();
                }
                //Console.WriteLine($"Compliting Iteration {i} {sitelist[i]} ");
            });
        }

    }
}
