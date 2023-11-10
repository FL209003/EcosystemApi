using Domain.DomainInterfaces;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(Alpha3), IsUnique = true)]
    public class Country : IValidate
    {
        public int Id { get; set; }

        [Column("Nombre")]
        public Name CountryName { get; set; }

        [Column("Código alfa-3")]
        public string Alpha3 { get; set; }

        public List<Ecosystem> Ecosystems { get; set; }

        public Country(Name name, string alpha3)
        {
            Ecosystems = new List<Ecosystem>();
            CountryName = name;
            Alpha3 = alpha3;
        }

        public Country() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Alpha3)) throw new Exception("El codigo alfanumérico del país es requerido.");
            if (Alpha3.Length != 3) throw new Exception("Se requieren 3 caracteres.");
        }
    }
}
