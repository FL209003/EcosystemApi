﻿using Domain.Entities;
using Domain.ValueObjects;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
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
        public List<SimpleSpecDTO>? Species { get; set; }
        public List<SimpleThreatDTO>? Threats { get; set; }
        public List<CountryDTO> Countries { get; set; }

        public EcosystemDTO() { }

        public EcosystemDTO(Ecosystem eco)
        {
            Id = eco.Id;
            Name = eco.EcosystemName.Value;
            Area = eco.Area;
            Description = eco.EcoDescription.Value;
            ImgRoute = eco.ImgRoute;
            Security = eco.Security;
            if (eco.GeoDetails != null) GeoDetails = new GeoUbicationDTO(eco.GeoDetails);
            if (eco.EcoConservation != null) Conservation = new ConservationDTO(eco.EcoConservation.Id, eco.EcoConservation.Name);
            if (eco.Species != null) Species = new List<SimpleSpecDTO>(eco.Species.Select(s => new SimpleSpecDTO(s)).ToList());
            if (eco.Threats != null) Threats = new List<SimpleThreatDTO>(eco.Threats.Select(t => new SimpleThreatDTO(t)).ToList());
            if (eco.Countries != null) Countries = new List<CountryDTO>(eco.Countries.Select(c => new CountryDTO(c) ).ToList());
        }

        public Ecosystem TransformToObj()
        {
            try {
                Ecosystem e = new()
                {
                    Id = Id,
                    EcosystemName = new Name(Name),
                    GeoDetails = new GeoUbication(GeoDetails.Latitude, GeoDetails.Longitude),
                    Area = Area,
                    EcoDescription = new Description(Description),
                    EcoConservation = Conservation.TransformToObj(),
                    ImgRoute = ImgRoute,
                    Security = Security,
                    Species = new List<Species>(Species.Select(s => s.TransformToObj()).ToList()),
                    Threats = new List<Threat>(Threats.Select(t => t.TransformToObj()).ToList()),
                    Countries = Countries != null ? new List<Country>(Countries.Select(c => c.TransformToObj()).ToList()) : new List<Country>(),
                };
                return e;
            }

            catch(Exception ex) {
                throw new EcosystemException(ex.Message);
            }
            
        }        
    }
}
