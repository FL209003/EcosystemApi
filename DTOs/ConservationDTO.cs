using Domain.Entities;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DTOs
{
    public class ConservationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinSecurityRange { get; set; }
        public int MaxSecurityRange { get; set; }
        public List<EcosystemDTO>? ConservationEcosystems { get; set; }
        public List<SpeciesDTO>? ConservationSpecies { get; set; }

        public ConservationDTO() { }

        public ConservationDTO(Conservation ecoConservation)
        {
            Id = ecoConservation.Id;
            Name = ecoConservation.Name;
            MinSecurityRange = ecoConservation.MinSecurityRange;
            MaxSecurityRange = ecoConservation.MaxSecurityRange;
        }
        public Conservation TransformToObj()
        {
            Conservation c = new()
            {
                Id = Id,
                Name = Name,
                MinSecurityRange = MinSecurityRange,
                MaxSecurityRange = MaxSecurityRange,
            };
            return c;
        }
    }
}