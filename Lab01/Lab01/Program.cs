using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab01
{
    class  rogram
    {  
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
               {
                   services.AddHostedService<DemoHost>();
                   services.AddTransient<IDemoService, DemoService>();
                   services.AddTransient<DemoController>();
               })
                .ConfigureLogging(options =>
               {
                   options.AddFilter(logLevel => true);
                   options.AddConsole();
                   options.AddDebug();
               })
                .RunConsoleAsync();

        }
    }
}
