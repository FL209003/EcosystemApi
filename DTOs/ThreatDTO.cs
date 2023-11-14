using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
    }
}