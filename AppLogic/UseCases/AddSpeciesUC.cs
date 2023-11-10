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
    public class AddSpeciesUC : IAddSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public AddSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public void Add(Species species)
        {
            SpeciesRepo.Add(species);
        }
    }
}
