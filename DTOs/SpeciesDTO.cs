using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Xml.Linq;
using Domain.Entities;
using Domain.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace DTOs
{
    public class SpeciesDTO
    {
        public int Id { get; set; } 
        public string CientificName { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal WeightRangeMin { get; set; } 
        public decimal WeightRangeMax { get; set; } 
        public decimal LongRangeAdultMin { get; set; } 
        public decimal LongRangeAdultMax { get; set; } 
        public ConservationDTO Conservation { get; set; } 
        public string ImgRoute { get; set; } 
        public int Security { get; set; } 
        public List<SimpleEcoDTO>? Ecosystems { get; set; } 
        public List<SimpleThreatDTO>? Threats { get; set; } 

        public SpeciesDTO() { }

        public SpeciesDTO(Species s)
        {
            Id = s.Id;
            Name = s.SpeciesName.Value;
            CientificName = s.CientificName;
            Description = s.SpeciesDescription.Value;
            WeightRangeMax = s.WeightRangeMax;
            WeightRangeMin = s.WeightRangeMin;
            LongRangeAdultMax = s.LongRangeAdultMax;
            LongRangeAdultMin = s.LongRangeAdultMin;
            ImgRoute = s.ImgRoute;
            Security = s.Security;
            if (s.SpeciesConservation != null) Conservation = new ConservationDTO(s.SpeciesConservation.Id, s.SpeciesConservation.Name);
            if (s.Ecosystems != null) Ecosystems = new List<SimpleEcoDTO>(s.Ecosystems.Select(e => new SimpleEcoDTO(e)).ToList());
            if (s.Threats != null) Threats = new List<SimpleThreatDTO>(s.Threats.Select(t => new SimpleThreatDTO() { Id = t.Id, Name = t.ThreatName.Value }).ToList());
        }

        public Species TransformToObj()
        {
            Species s = new()
            {
                Id = Id,
                CientificName = CientificName,
                SpeciesName = new Name(Name),
                SpeciesDescription = new Description(Description),
                WeightRangeMax = WeightRangeMax,
                WeightRangeMin = WeightRangeMin,
                LongRangeAdultMax = LongRangeAdultMax,
                LongRangeAdultMin = LongRangeAdultMin,
                SpeciesConservation = Conservation.TransformToObj(),
                ImgRoute = ImgRoute,
                Security = Security,
                Ecosystems = Ecosystems != null ? new List<Ecosystem>(Ecosystems.Select(e => e.TransformToObj()).ToList()) : new List<Ecosystem>(),
                Threats = Threats != null ? new List<Threat>(Threats.Select(t => t.TransformToObj()).ToList()) : new List<Threat>(),
            };
            return s;
        }        
    }
}