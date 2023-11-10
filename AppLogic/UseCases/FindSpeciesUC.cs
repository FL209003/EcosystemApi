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
    public class FindSpeciesUC : IFindSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public FindSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public Species Find(int id)
        {
            return SpeciesRepo.FindById(id);
        }
    }
}
