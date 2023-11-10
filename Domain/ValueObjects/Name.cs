using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name : IValidate
    {
        [Column("Nombre")]
        [Required(ErrorMessage = "Ingrese nombre")]
        public string Value { get; private set; }
        public static int MinNameLength { get; set; }
        public static int MaxNameLength { get; set; }

        public Name(string value)
        {
            Value = value;
            Validate();
        }

        private Name() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("Nombre es requerido.");
            if (Value.Length < MinNameLength || Value.Length > MaxNameLength)
            { throw new Exception("Nombre debe tener entre " + MinNameLength + " y " + MaxNameLength + " caracteres."); }
            if (MinNameLength < 0 || MaxNameLength < 0) throw new Exception("Debe ser un número positivo.");
        }
    }
}
