using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsyncStuffInMain().GetAwaiter().GetResult(); /*.ConfigureAwait(false)*/
            Task.Run(() => RunAsyncStuffInMain());
        }
        static async Task RunAsyncStuffInMain()
        {
            try
            {
                string result1 = await ProcessApiAsync("http://get-simple.info/api/extend?id=1");
                Task<string> DownloadString1 = ProcessApiAsync("http://get-simple.info/api/start/");

                string result2 = await DownloadString1;
                Console.WriteLine(result1);
                Console.WriteLine(result2);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task<string> ProcessApiAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            return result;
        }
    }
}
