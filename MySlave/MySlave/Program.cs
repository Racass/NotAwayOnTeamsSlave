using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySlave.Factory.RepositoryFactory;
using MySlave.Factory.ServiceFactory;
using MySlave.Repository;
using MySlave.Repository.Interfaces;
using MySlave.Service;
using MySlave.Service.Interfaces;
using MySlave.Worker;
using System.Diagnostics;

namespace MySlave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowHeaders();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical Error.");

                Exception? temp = ex;
                while (temp != null)
                {
                    Console.WriteLine($"StackTrace: <{temp.StackTrace}>");
                    Console.WriteLine($"Message: <{temp.Message}");
                    temp = temp.InnerException;
                }
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            Console.WriteLine($"Host builder...");
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IApplicationServiceFactory<ITeamsService>, TeamsServiceFactory>();
                    services.AddScoped<IApplicationRepositoryFactory<ITeamsRepository>, TeamsRepositoryFactory>();
                    services.AddHostedService<TeamsWorker>();
                });
        }

        static void ShowHeaders()
        {
            Console.WriteLine("#################################");
            Console.WriteLine("#################################");
            Console.WriteLine("######### RCA Present's");
            Console.WriteLine("######### Simple Teams Slave");
            Console.WriteLine($"######### Version: {typeof(Program).Assembly.GetName().Version}");
            Console.WriteLine("#################################");
            Console.WriteLine("#################################");
        }
    }
}