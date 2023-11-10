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
    public class ListSpeciesUC : IListSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public ListSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public List<Species> List()
        {
            return SpeciesRepo.FindAll().ToList();
        }

        public List<Species> ListByCientificName()
        {
            return SpeciesRepo.FindByCientificName().ToList();
        }

        public List<Species> ListByDangerOfExtinction()
        {
            return SpeciesRepo.FindByDangerOfExtinction().ToList();
        }

        public List<Species> ListByWeight(int min, int max)
        {
            return SpeciesRepo.FindByWeight(min, max).ToList();
        }        

        public List<Species> ListByEco(int idEco)
        {
            return SpeciesRepo.FindByEco(idEco).ToList();
        }
    }
}
