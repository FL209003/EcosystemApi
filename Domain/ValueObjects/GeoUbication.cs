using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class GeoUbication : IValidate
    {
        [Required(ErrorMessage = "Latitud requerida.")]
        [Range(-90, 90, ErrorMessage = "Rango de -90 a 90.")]
        public decimal Latitude { get; private set; }

        [Required(ErrorMessage = "Longitud requerida.")]
        [Range(-180, 180, ErrorMessage = "Rango de -180 a 180.")]
        public decimal Longitude { get; private set; }

        public GeoUbication(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        public GeoUbication() { }

        public override string ToString()
        {
            return "Latitud: " + Latitude + "Longitud: " + Longitude;
        }

        public void Validate()
        {
            if (Latitude > 90 || Latitude < -90) throw new ArgumentException("La latitud debe estar entre 90 y -90 grados");
            if (Longitude > 180 || Longitude < -180) throw new ArgumentException("La longitud debe estar entre 180 y -180 grados");
        }
    }
}
