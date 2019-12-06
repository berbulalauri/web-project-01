using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace practice_01
{
    public class SaverMiddleware
    {
        RequestDelegate _next;
        public SaverMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            string subPath = $"E:/param.txt";
            string userInputValue = context.Request.Query.FirstOrDefault(x => x.Key == "param").Value;
            if (!string.IsNullOrEmpty(userInputValue))
            {
                string fileInput = $"{userInputValue}\n";
                using (StreamWriter writer = new StreamWriter(subPath, true))
                {
                    writer.Write(fileInput);
                }
                await context.Response.WriteAsync($"<h1>value is: {userInputValue}</h1>");
            } else
            {
                await context.Response.WriteAsync($"No Param!" +
                    $"\nPlease Specify File Path, In order To Create And Write Content Corectlly." +
                    $"\nCurrent File Path is asigned in E: Drive.");
            }
        }

    }
}