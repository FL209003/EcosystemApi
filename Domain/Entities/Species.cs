using Domain.DomainInterfaces;
using Domain.ValueObjects;
using Exceptions;
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
    public class Species : IValidate
    {
        public int Id { get; set; }

        [Column("Nombre científico")]
        public string CientificName { get; set; }

        public Name SpeciesName { get; set; }

        [Column("Descripción")]
        public Description SpeciesDescription { get; set; }

        [Column("Min weight")]
        public decimal WeightRangeMin { get; set; }

        [Column("Max weight")]
        public decimal WeightRangeMax { get; set; }

        [Column("Min length")]
        public decimal LongRangeAdultMin { get; set; }

        [Column("Max length")]
        public decimal LongRangeAdultMax { get; set; }

        [Column("Estado de conservación")]
        public Conservation SpeciesConservation { get; set; }

        [Column("Image")]
        [Display(Name = "Imagen")]
        public string ImgRoute { get; set; }

        [Column("Seguridad")]
        public int Security { get; set; }
        public List<Ecosystem>? Ecosystems { get; set; }
        public List<Threat>? Threats { get; set; }

        public Species(string cientificName, Name name, Description description, decimal weightRangeMin, decimal weightRangeMax, decimal longRangeAdultMin, decimal longRangeAdultMax, Conservation speciesConservation, string imgRoute, List<Ecosystem>? ecosystems, List<Threat>? threats, int security)
        {
            CientificName = cientificName;
            SpeciesName = name;
            SpeciesDescription = description;
            WeightRangeMin = weightRangeMin;
            WeightRangeMax = weightRangeMax;
            LongRangeAdultMin = longRangeAdultMin;
            LongRangeAdultMax = longRangeAdultMax;
            SpeciesConservation = speciesConservation;
            ImgRoute = imgRoute;
            Ecosystems = ecosystems;
            Security = security;
            Threats = threats;
        }

        public Species() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CientificName)) throw new SpeciesException("El nombre científico de la especie es requerido.");
            if (WeightRangeMin <= 0 || WeightRangeMax <= 0 || LongRangeAdultMin <= 0 || LongRangeAdultMax <= 0)
            { throw new SpeciesException("Los rangos no pueden ser menores a 1."); }
            if (string.IsNullOrEmpty(SpeciesName.Value)) throw new SpeciesException("El nombre de la especie es requerido.");
            if (string.IsNullOrEmpty(SpeciesDescription.Value)) throw new SpeciesException("La descripción es requerida.");
            if (string.IsNullOrEmpty(ImgRoute)) throw new SpeciesException("La imagen de la especie es requerida.");
            if (Security < 0 || Security > 100) throw new Exception("Indique un valor entre 0 y 100 para la seguridad.");

        }
    }
}
