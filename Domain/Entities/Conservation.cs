using Domain.DomainInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conservation : IValidate
    {
        public int Id { get; set; }

        [Column("Estado")]
        public Name ConservationName { get; set; }

        [Column("Rango de seguridad mínimo")]
        public int MinSecurityRange { get; set; }

        [Column("Rango de seguridad máximo")]
        public int MaxSecurityRange { get; set; }

        public List<Ecosystem>? ConservationEcosystems { get; set; }

        public List<Species>? ConservationSpecies { get; set; }

        public Conservation(Name conservationName)
        {
            ConservationName = conservationName;
            MinSecurityRange = SetMinSecurityRange(conservationName.Value);
            MaxSecurityRange = SetMaxSecurityRange(conservationName.Value);
        }

        public Conservation() { }

        public void Validate() { }

        public static int SetMinSecurityRange(string conservationName)
        {
            if (conservationName == "Malo") return 0;
            if (conservationName == "Aceptacble") return 60;
            if (conservationName == "Bueno") return 71;
            else return 95;
        }

        public static int SetMaxSecurityRange(string conservationName)
        {
            if (conservationName == "Malo") return 59;
            if (conservationName == "Aceptacble") return 70;
            if (conservationName == "Bueno") return 94;
            else return 100;
        }
    }
}
