using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using DTOs;
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
        public ThreatDTO Find(int id)
        {
            Threat t = ThreatRepo.FindById(id);
            if (t != null)
            {
                return new ThreatDTO
                {
                    Id = t.Id,
                    Name = t.ThreatName.Value,
                    Description = t.ThreatDescription.Value,
                    Danger = t.Danger,
                    //Ecosystems = t.Ecosystems,
                    //Species = t.Species
                };
            }
            else return null;
        }
    }
}
