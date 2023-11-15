﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EcosystemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoUbicationDTO GeoDetails { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
        public ConservationDTO Conservation { get; set; }
        public string ImgRoute { get; set; }
        public int Security { get; set; }
        public List<SpeciesDTO>? Species { get; set; }
        public List<ThreatDTO>? Threats { get; set; }
        public List<CountryDTO> Countries { get; set; }

        public EcosystemDTO()
        {

        }
        public EcosystemDTO(Ecosystem eco) {
            Id = eco.Id;
            Name = eco.EcosystemName.Value;
            Area = eco.Area;
            ImgRoute = eco.ImgRoute;
            Security = eco.Security;
            if(eco.GeoDetails != null) GeoDetails = new GeoUbicationDTO(eco.GeoDetails);
            if(eco.EcoConservation != null) Conservation = new ConservationDTO(eco.EcoConservation);
            if(eco.Species != null) Species = new List<SpeciesDTO>(eco.Species.Select(s => new SpeciesDTO(s)).ToList());
            if(eco.Threats != null) Threats = new List<ThreatDTO>(eco.Threats.Select(t => new ThreatDTO(t)).ToList());
            if(eco.Countries != null) Countries = new List<CountryDTO>(eco.Countries.Select(c => new CountryDTO(c)).ToList());
        }
    }
}
