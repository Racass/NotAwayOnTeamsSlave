using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySlave.Factory.ServiceFactory;
using MySlave.Service;
using MySlave.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Worker
{
    public class TeamsWorker : BackgroundService
    {
        private readonly IApplicationServiceFactory<ITeamsService> _applicationFactory;
        private readonly ILogger _logger;
        private readonly int TIMER_INTERVAL_IN_MINUTES = 1;
        public TeamsWorker(IApplicationServiceFactory<ITeamsService> applicationFactory, ILogger<TeamsWorker> logger)
        {
            _applicationFactory = applicationFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(TIMER_INTERVAL_IN_MINUTES));
            ITeamsService service = _applicationFactory.GetInstance();

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    _logger.LogInformation("Enviando stroke...");
                    service.ReceiveKeyStroke("F13");
                    _logger.LogInformation("Key stroke enviada..");
                }
                catch (Exception ex)
                {
                    Exception? temp = ex;
                    string errorStr = "";
                    while (temp != null)
                    {
                        
                        errorStr += ($"StackTrace: <{temp.StackTrace}>\n");
                        errorStr += ($"Message: <{temp.Message}\n");
                        temp = temp.InnerException;
                    }

                    _logger.LogError(errorStr);
                }
            }
        }
    }
}
