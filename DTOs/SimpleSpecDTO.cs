using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SimpleSpecDTO
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

        public SimpleSpecDTO() { }

        public SimpleSpecDTO(Species s)
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
                Ecosystems = new List<Ecosystem>(),
                Threats =  new List<Threat>(),
            };
            return s;
        }
    }
}
