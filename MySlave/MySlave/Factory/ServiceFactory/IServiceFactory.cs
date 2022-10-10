using MySlave.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Factory.ServiceFactory
{
    public interface IServiceFactory<T> : IFactory<T>
        where T : IService
    {
    }
}
