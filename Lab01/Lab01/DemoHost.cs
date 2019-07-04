using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab01
{
    public class DemoHost : BackgroundService
    {
        private readonly DemoController _demoController;

        public DemoHost(DemoController demoController)
        {
            _demoController = demoController;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string result = _demoController.Index("Max", "Mustermann");
            Console.WriteLine(result);
            return Task.CompletedTask;
        }
    }
}
