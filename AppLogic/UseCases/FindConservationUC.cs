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
    public class FindConservationUC : IFindConservation
    {
        public IRepositoryConservations ConsRepo { get; set; }

        public FindConservationUC(IRepositoryConservations repo)
        {
            ConsRepo = repo;
        }
        public ConservationDTO FindBySecurity(int sec)
        {
            Conservation c = ConsRepo.FindBySecurity(sec);
            if (c != null)
            {
                return new ConservationDTO(c);
            }
            else return null;
        }
    }
}
