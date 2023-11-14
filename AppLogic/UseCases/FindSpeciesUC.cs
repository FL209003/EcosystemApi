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
                return new SpeciesDTO
                {
                    Id = s.Id,
                    CientificName = s.CientificName,
                    Name = s.SpeciesName.Value,
                    Description = s.SpeciesDescription.Value,
                    WeightRangeMin = s.WeightRangeMin,
                    WeightRangeMax = s.WeightRangeMax,
                    LongRangeAdultMin = s.LongRangeAdultMin,
                    LongRangeAdultMax = s.LongRangeAdultMax,
                    Conservation = new ConservationDTO { Id = s.Id, Name = s.SpeciesConservation.ConservationName.Value },
                    ImgRoute = s.ImgRoute,
                    Security = s.Security,
                    //Ecosystems = s.Ecosystems,
                    //Threats = s.Threats
                };
            }
            else return null;
        }
    }
}
