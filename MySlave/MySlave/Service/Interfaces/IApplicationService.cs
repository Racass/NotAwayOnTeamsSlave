using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Service.Interfaces
{
    public interface IApplicationService : IService
    {
        public void ReceiveKeyStroke(string KeyStroke);
    }
}
