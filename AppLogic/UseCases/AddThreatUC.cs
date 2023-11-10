using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class AddThreatUC : IAddThreat
    {
        public IRepositoryThreats ThreatRepo { get; set; }

        public AddThreatUC(IRepositoryThreats repo)
        {
            ThreatRepo = repo;
        }
        
        public void Add(Threat threat)
        {
            ThreatRepo.Add(threat);
        }
    }
}
