using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using System.Data;
using Domain.ValueObjects;

namespace DTOs
{
    public class ThreatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Danger { get; set; }
        public List<EcosystemDTO>? Ecosystems { get; set; }
        public List<SpeciesDTO>? Species { get; set; }
        public ThreatDTO() { }
        public ThreatDTO(Threat t)
        {
            Id = t.Id;
            Name = t.ThreatName.Value;
            Description = t.ThreatDescription.Value;
            Danger = t.Danger;
            if (t.Species != null) Species = new List<SpeciesDTO>(t.Species.Select(s => new SpeciesDTO() { Id = s.Id }).ToList());
            if (t.Ecosystems != null) Ecosystems = new List<EcosystemDTO>(t.Ecosystems.Select(e => new EcosystemDTO() { Id = e.Id }).ToList());
        }

        public Threat TransformToObj()
        {
            Threat t = new()
            {
                Id = Id,
                ThreatName = new Name(Name),
                ThreatDescription = new Description(Description),
                Danger = Danger,
                Ecosystems = new List<Ecosystem>(Ecosystems.Select(e => e.TransformToObj()).ToList()),
                Species = new List<Species>(Species.Select(s => s.TransformToObj()).ToList()),
            };
            return t;
        }
    }
}