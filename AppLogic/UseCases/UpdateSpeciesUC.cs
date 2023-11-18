using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using DTOs;
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
        public void Update(Species species)
        {
            SpeciesRepo.Update(species);
        }

        public void Update(SpeciesDTO species)
        {
            Species s = SpeciesRepo.FindById(species.Id);

            s.SpeciesName = new Name(species.Name);
            s.CientificName = species.CientificName;
            s.SpeciesDescription = new Description(species.Description);
            s.WeightRangeMin = species.WeightRangeMin;
            s.WeightRangeMax = species.WeightRangeMax;
            s.LongRangeAdultMin = species.LongRangeAdultMin;
            s.LongRangeAdultMax = species.LongRangeAdultMax;
            s.ImgRoute = species.ImgRoute;
            s.SpeciesConservation = species.Conservation.TransformToObj();

            SpeciesRepo.Update(s);
        }
    }
}
