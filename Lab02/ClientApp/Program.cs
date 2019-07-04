using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("client - wait for server");
            Console.ReadLine();
            var container = RegisterServices();
            var runner = container.GetService<ClientRunner>();
            await runner.GetBooksAsync();
            await runner.PostBookAsync();
            await runner.GetBooksAsync();

            Console.WriteLine("end Main");
            Console.ReadLine();
        }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(options =>
            {
                options.AddFilter(level => true);
                options.AddConsole();
                options.AddDebug();
            });
            services.AddHttpClient<ClientRunner>("localhost", config =>
            {
                config.BaseAddress = new Uri("https://localhost:5001/");
            }).AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(5) }))  // network failures, HTTP 5xx, HTTP 408
                .AddTypedClient<ClientRunner>();  // one constructor parameter - HttpClient
                                                  //            services.AddTransient<ClientRunner>();
            return services.BuildServiceProvider();
        }
    }
}
