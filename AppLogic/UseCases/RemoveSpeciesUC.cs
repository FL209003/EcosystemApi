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
    public class RemoveSpeciesUC : IRemoveSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public RemoveSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public void Remove(int id)
        {
            SpeciesRepo.Remove(id);
        }
    }
}
