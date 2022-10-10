using MySlave.Repository;
using MySlave.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Factory.RepositoryFactory
{
    public class TeamsRepositoryFactory : IApplicationRepositoryFactory<ITeamsRepository>
    {
        public ITeamsRepository GetInstance()
        {
            return new TeamsRepository();
        }
    }
}
