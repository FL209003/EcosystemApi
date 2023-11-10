using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Description
    {        
        [Required(ErrorMessage = "Descripción requerida.")]
        [Column("Descripcion")]
        public string Value { get; private set; }
        public static int MinDescLength { get; set; }
        public static int MaxDescLength { get; set; }

        public Description(string value)
        {
            Value = value;            
            Validate();
        }

        private Description() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("Descripción es requerida.");
            if (Value.Length < MinDescLength || Value.Length > MaxDescLength)
            { throw new Exception("Descripción debe tener entre " + MinDescLength + " y " + MaxDescLength + " caracteres."); }
        }
    }
}
