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
    public class FindUserUC : IFindUser
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public FindUserUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }
        
        public User Find(string username) 
        {
            return UsersRepo.FindByName(username);
        }
    }
}
