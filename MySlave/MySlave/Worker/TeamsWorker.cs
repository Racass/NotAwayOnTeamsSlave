using Microsoft.Extensions.Hosting;
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
        private readonly int TIMER_INTERVAL_IN_MINUTES = 1;
        public TeamsWorker(IApplicationServiceFactory<ITeamsService> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(TIMER_INTERVAL_IN_MINUTES));
            ITeamsService service = _applicationFactory.GetInstance();
            service.ReceiveKeyStroke("F13");

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                service.ReceiveKeyStroke("F13");
            }
        }
    }
}
