using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EcosystemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoDetailsDTO GeoDetails { get; set; }
        public decimal Area { get; set; }
        public string EcoDescription { get; set; }
        public int EcoConservation { get; set; }
        public string ImgRoute { get; set; }
        public int Security { get; set; }
        public List<SpeciesDTO>? Species { get; set; }
        public List<ThreatDTO>? Threats { get; set; }
        public List<CountryDTO> Countries { get; set; }
    }
}
