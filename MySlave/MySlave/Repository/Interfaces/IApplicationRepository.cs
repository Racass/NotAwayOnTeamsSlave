using MySlave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Repository.Interfaces
{
    public interface IApplicationRepository : IRepository
    {
        public void ReceiveKeyStroke(KeyEnum keyStroke);
    }
}
