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
    public class RemoveEcoUC : IRemoveEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public RemoveEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }

        public void Remove(int id)
        {
            EcosRepo.Remove(id);
        }
    }
}