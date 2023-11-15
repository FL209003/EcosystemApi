using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace DTOs
{
    public class ThreatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Danger { get; set; }
        public List<EcosystemDTO> Ecosystems { get; set; }
        public List<SpeciesDTO> Species { get; set; }
        public ThreatDTO() { }
        public ThreatDTO(Threat t)
        {
            Id = t.Id;
            Name = t.ThreatName.Value;
            Description = t.ThreatDescription.Value;
            Danger = t.Danger;
            if(t.Species != null) Species = new List<SpeciesDTO>(t.Species.Select(s => new SpeciesDTO(s)).ToList());
            if(t.Ecosystems != null) Ecosystems = new List<EcosystemDTO>(t.Ecosystems.Select(e => new EcosystemDTO(e)).ToList());
        }
    }
}