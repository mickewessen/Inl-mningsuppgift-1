using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        //private string _url = "https://google.com/";

        public Random random = new Random();

        //private HttpClient _client;
        //private HttpResponseMessage _result;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            //_client = new HttpClient();
            _logger.LogInformation("The service has been started");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            _logger.LogInformation("The service has been stopped");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync (CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var temp = random.Next(15, 40);

                if (temp < 30)
                    Console.WriteLine($"The temperature is {temp}C, everything is fine");

                else
                    Console.WriteLine($"The temperature is at a dangerous level of {temp}, please go inside");

                await Task.Delay(60 * 1000, stoppingToken);
            }
        }
    }
}
