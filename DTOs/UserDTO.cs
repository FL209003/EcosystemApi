using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }        
        public string Username { get; set; }        
        public string Password { get; set; }
        public string HashPassword { get; set; }        
        public string Role { get; set; }      
        public DateTime RegDate { get; set; }

        public User TransformToObj()
        {
            User u = new User()
            {
                Id = Id,
                Username = Username,
                Password = Password,
                HashPassword = HashPassword,
                Role = Role,
                RegDate = RegDate
            };
            return u;
        }
    }
}
