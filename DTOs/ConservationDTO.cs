using Domain.Entities;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DTOs
{
    public class ConservationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }           

        public ConservationDTO() { }

        public ConservationDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Conservation TransformToObj()
        {
            Conservation c = new()
            {
                Id = Id,
                Name = Name,
            };
            return c;
        }
    }
}