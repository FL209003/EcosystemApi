﻿using System.ComponentModel.DataAnnotations.Schema;

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
    }
}