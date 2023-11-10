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
    public class UpdateSpeciesUC : IUpdateSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public UpdateSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }
        public void UpdateSpecies(Species species)
        {
            SpeciesRepo.Update(species);
        }
    }
}
