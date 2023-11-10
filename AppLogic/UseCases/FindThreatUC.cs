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
    public class FindThreatUC : IFindThreat
    {

        public IRepositoryThreats ThreatRepo { get; set; }

        public FindThreatUC(IRepositoryThreats repo)
        {
            ThreatRepo = repo;
        }
        public Threat Find(int id)
        {
            return ThreatRepo.FindById(id);
        }
    }
}
