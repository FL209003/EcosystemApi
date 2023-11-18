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
    public class ListThreatsUC : IListThreats
    {
        public IRepositoryThreats ThreatsRepo { get; set; }

        public ListThreatsUC(IRepositoryThreats repo)
        {
            ThreatsRepo = repo;
        }

        public List<ThreatDTO> List()
        {
            return ThreatsRepo.FindAll().Select(t => new ThreatDTO (t)).ToList();
        }
    }
}
