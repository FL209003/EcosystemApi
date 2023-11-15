using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alpha3 { get; set; }

        public CountryDTO() { }
        public CountryDTO(Country c)
        {
            Id = c.Id;
            Name = c.CountryName.Value;
            Alpha3 = c.Alpha3;
        }
    }
}