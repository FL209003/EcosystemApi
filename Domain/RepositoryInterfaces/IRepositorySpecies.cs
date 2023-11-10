using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositorySpecies : IRepository<Species>
    {
        IEnumerable<Species> FindByCientificName();
        IEnumerable<Species> FindByDangerOfExtinction();
        IEnumerable<Species> FindByEco(int idEco);
        IEnumerable<Species> FindByWeight(int min, int max);
    }
}
