using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class FindUserUC : IFindUser
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public FindUserUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }

        public UserDTO Find(string username)
        {
            User u = UsersRepo.FindByName(username);
            if (u != null)
            {
                return new UserDTO(u);
            }
            else return null;
        }

        public UserDTO Login(string username, string password)
        {
            User user = UsersRepo.Login(username, password);
            if (user != null) return new UserDTO(user);
            return null; 
        }
    }
}
