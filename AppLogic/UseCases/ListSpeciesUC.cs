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
    public class ListSpeciesUC : IListSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public ListSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public List<SpeciesDTO> List()
        {
            return SpeciesRepo.FindAll().Select(s => new SpeciesDTO(s)).ToList();
        }

        public List<SpeciesDTO> ListByCientificName()
        {
            return SpeciesRepo.FindByCientificName().Select(s => new SpeciesDTO(s)).ToList();
        }

        public List<SpeciesDTO> ListByDangerOfExtinction()
        {
            return SpeciesRepo.FindByDangerOfExtinction().Select(s => new SpeciesDTO (s)).ToList();
        }

        public List<SpeciesDTO> ListByWeight(int min, int max)
        {
            return SpeciesRepo.FindByWeight(min, max).Select(s => new SpeciesDTO (s)).ToList();
        }        

        public List<SpeciesDTO> ListByEco(int idEco)
        {
            return SpeciesRepo.FindByEco(idEco).Select(s => new SpeciesDTO (s)).ToList();
        }
    }
}
