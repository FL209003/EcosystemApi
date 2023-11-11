using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alpha3 { get; set; }
    }
}