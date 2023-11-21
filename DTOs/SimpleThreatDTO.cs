using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SimpleThreatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Danger { get; set; }

        public SimpleThreatDTO() { }
        public SimpleThreatDTO(Threat t)
        {
            Id = t.Id;
            Name = t.ThreatName.Value;
            Description = t.ThreatDescription.Value;
            Danger = t.Danger;
        }

        public Threat TransformToObj()
        {
            Threat t = new()
            {
                Id = Id,
                ThreatName = new Name(Name),
                ThreatDescription = new Description(Description),
                Danger = Danger,
                Ecosystems = new List<Ecosystem>(),
                Species = new List<Species>(),
            };
            return t;
        }
    }
}
