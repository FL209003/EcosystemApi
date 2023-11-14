using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Xml.Linq;

namespace DTOs
{
    public class SpeciesDTO
    {
        public int Id { get; set; }        
        public string CientificName { get; set; }
        public string Name { get; set; }        
        public string Description  { get; set; }       
        public decimal WeightRangeMin { get; set; }     
        public decimal WeightRangeMax { get; set; }     
        public decimal LongRangeAdultMin { get; set; }        
        public decimal LongRangeAdultMax { get; set; }       
        public ConservationDTO Conservation { get; set; }       
        public string ImgRoute { get; set; }        
        public int Security { get; set; }
        public List<EcosystemDTO>? Ecosystems { get; set; }
        public List<ThreatDTO>? Threats { get; set; }
    }
}