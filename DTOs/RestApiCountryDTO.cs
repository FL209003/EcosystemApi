using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RestApiCountryDTO
    {
        public CountryNameDTO Name { get; set; }
        public string Cca3 { get; set; }

        public Country TransformToObj()
        {
            Country country = new ()
            {
                CountryName = new Name(Name.Common),
                Alpha3 = Cca3,
            };

            return country;
        }
    }
}
