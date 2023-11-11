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
    public class ListEcosUC : IListEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public ListEcosUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }

        public List<EcosystemDTO> List()
        {
            return EcosRepo.FindAll().Select(e => new EcosystemDTO { Id = e.Id }).ToList();
        }

        public List<EcosystemDTO> ListUninhabitableEcos(int id)
        {
            return EcosRepo.FindUninhabitableEcos(id).Select(e => new EcosystemDTO { Id = e.Id }).ToList();
        }
    }
}