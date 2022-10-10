using MySlave.Factory.RepositoryFactory;
using MySlave.Repository;
using MySlave.Repository.Interfaces;
using MySlave.Service;
using MySlave.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Factory.ServiceFactory
{
    internal class TeamsServiceFactory : IApplicationServiceFactory<ITeamsService>
    {
        private readonly IApplicationRepositoryFactory<ITeamsRepository> _applicationRepoFactory;

        public TeamsServiceFactory(IApplicationRepositoryFactory<ITeamsRepository> applicationRepoFactory)
        {
            _applicationRepoFactory = applicationRepoFactory;
        }

        public ITeamsService GetInstance()
        {
            TeamsService service = new TeamsService(_applicationRepoFactory.GetInstance());
            return service;
        }
    }
}
