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
                Task<int> DownloadString1 = ProcessApiAsync("http://get-simple.info/api/extend/");
                Task<int> DownloadString2 = ProcessApiAsync("http://get-simple.info/api/security/");
                Task<int> DownloadString3 = ProcessApiAsync("http://get-simple.info/api/extend/?id=33");

                int result1 = await DownloadString1;
                int result2 = await DownloadString2;
                int result3 = await DownloadString3;

                Console.WriteLine($"http://get-simple.info/api/extend/          {result1}");
                Console.WriteLine($"http://get-simple.info/api/security/        {result2}");
                Console.WriteLine($"http://get-simple.info/api/extend/?id=33    {result3}");

                Console.WriteLine($"\nTotal bytes returned: {result1+result2+result3}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task<int> ProcessApiAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetByteArrayAsync(url);

            //Console.WriteLine(result.Length);

            return result.Length;
        }
        //static async Task<string> ProcessApiAsync(string url)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    var result = await httpClient.GetStringAsync(url);
        //    return result;
        //}
    }
}
