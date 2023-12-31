﻿using AppLogic.UCInterfaces;
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
    public class AddUserUC : IAddUser
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public AddUserUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }

        public void Add(UserDTO user)
        {
            User DomainUser = user.TransformToObj();
            UsersRepo.Add(DomainUser);
            user.Id = DomainUser.Id;
        }
    }
}
