using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class ConservationDTO
    {
        private Conservation ecoConservation;

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
            Name = ecoConservation.ConservationName.Value;
            MinSecurityRange = ecoConservation.MinSecurityRange;
            MaxSecurityRange = ecoConservation.MaxSecurityRange;
            if (ecoConservation.ConservationEcosystems != null) ConservationEcosystems = new List<EcosystemDTO>(ecoConservation.ConservationEcosystems.Select(e => new EcosystemDTO(e)).ToList());
            if (ecoConservation.ConservationSpecies != null) ConservationSpecies = new List<SpeciesDTO>(ecoConservation.ConservationSpecies.Select(s => new SpeciesDTO(s)).ToList());
        }
    }
}