using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SimpleEcoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoUbicationDTO GeoDetails { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
        public ConservationDTO Conservation { get; set; }
        public string ImgRoute { get; set; }
        public int Security { get; set; }        

        public SimpleEcoDTO() { }

        public SimpleEcoDTO(Ecosystem eco)
        {
            Id = eco.Id;
            Name = eco.EcosystemName.Value;
            Area = eco.Area;
            ImgRoute = eco.ImgRoute;
            Security = eco.Security;
            if (eco.GeoDetails != null) GeoDetails = new GeoUbicationDTO(eco.GeoDetails);
            if (eco.EcoConservation != null) Conservation = new ConservationDTO(eco.EcoConservation.Id, eco.EcoConservation.Name);
        }

        public Ecosystem TransformToObj()
        {
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
                Species = new List<Species>(),
                Threats = new List<Threat>(),
                Countries = new List<Country>(),
            };
            return e;
        }        
    }
}

