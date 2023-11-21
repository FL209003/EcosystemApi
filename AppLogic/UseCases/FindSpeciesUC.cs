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
    public class FindSpeciesUC : IFindSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public FindSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public SpeciesDTO Find(int id)
        {
            Species s = SpeciesRepo.FindById(id);
            if (s != null)
            {
                return new SpeciesDTO(s);                
            }
            else return null;
        }

        public SimpleSpecDTO FindSimple(int id)
        {
            Species s = SpeciesRepo.FindById(id);
            if (s != null)
            {
                return new SimpleSpecDTO(s);
            }
            else return null;
        }
    }
}
