using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Dto;
using Tienda.Logic;

namespace TiendaWeb
{
    public class Program
    { 

        public static UserLogic session = new UserLogic();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var session = new UserLogic();
        }

        public static UserLogic RetrieveSession()
        {
            return session;
        }
        public static void NewSession(UserLogic newSession)
        {

            session = newSession;

        }
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                      webBuilder.UseStartup<Startup>();
                });
    }
}
