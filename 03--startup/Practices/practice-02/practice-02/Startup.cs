using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace practice_02
{
    public class Startup
    {
        public static int mm = 0;
        public static List<Books> book;
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            book = new List<Books>
            {
                new Books{ Name ="William Shakespaere" , Author="Romea And Juliet", Year=1596 },
                new Books{ Name ="Anton Checkov" , Author="three sister", Year=1900 },
                new Books{ Name ="vladimir pushkin" , Author="poetry book", Year=1930 }

                //new Books("William Shakespaere","Romea And Juliet",1596),
                //new Books("Anton Checkov","three sister",1900),
                //new Books("vladimir pushkin","poetry book",1930)
            };
            app.Map("", Home);
        }
        private static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<div class=\"container\"><table style=\"margin-left:1%; margin-top:1%; border: 1px solid black;\" class=\"table\"><thead><tr><th>Name</th><th>Author</th><th>Release Year</th></tr></thead><tbody>");
                foreach (var item in book)
                {
                    await context.Response.WriteAsync($"<tr><td>{item.Author}</td><td>{item.Name}</td><td>{item.Year}</td></tr>");
                }
                await context.Response.WriteAsync($"</tbody></table></div>");

            });
        }

    }
}
