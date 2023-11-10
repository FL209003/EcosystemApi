using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class AddUserUC : IAddUser
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public AddUserUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }

        public void Add(User user)
        {
            UsersRepo.Add(user);
        }
    }
}
