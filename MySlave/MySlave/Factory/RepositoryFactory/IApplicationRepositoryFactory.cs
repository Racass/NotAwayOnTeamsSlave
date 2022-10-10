using MySlave.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Factory.RepositoryFactory
{
    public interface IApplicationRepositoryFactory<T> : IRepositoryFactory<T>
        where T : IApplicationRepository
    {
    }
}
