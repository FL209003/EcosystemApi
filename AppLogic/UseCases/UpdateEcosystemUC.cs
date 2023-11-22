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
    public class UpdateEcosystemUC : IUpdateEcosystem
    {
        public IRepositoryEcosystems EcoRepo { get; set; }

        public UpdateEcosystemUC(IRepositoryEcosystems repo)
        {
            EcoRepo = repo;
        }
        public void Update(EcosystemDTO eco)
        {
            Ecosystem ecosystem = eco.TransformToObj();
            EcoRepo.Update(ecosystem);
        }
    }
}
