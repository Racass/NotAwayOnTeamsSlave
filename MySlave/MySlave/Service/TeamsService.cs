using MySlave.Enums;
using MySlave.Repository;
using MySlave.Repository.Interfaces;
using MySlave.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySlave.Service
{
    public class TeamsService : ITeamsService
    {
        private IApplicationRepository _teamsRepository;
        public TeamsService(IApplicationRepository teamsRepository)
        {
            _teamsRepository = teamsRepository; 
        }
        public void ReceiveKeyStroke(string KeyStroke)
        {
            var key = ConvertKeyStrokeEnum(KeyStroke);
            _teamsRepository.ReceiveKeyStroke(key);
        }

        private KeyEnum ConvertKeyStrokeEnum(string KeyStroke)
        {
            switch(KeyStroke)
            {
                case "F13":
                    return KeyEnum.F13;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
