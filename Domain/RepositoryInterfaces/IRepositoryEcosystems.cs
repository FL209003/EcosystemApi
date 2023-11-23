using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryEcosystems : IRepository<Ecosystem>
    {
        void Add(Ecosystem eco);
        IEnumerable<Ecosystem> FindUninhabitableEcos(int id);

        IEnumerable<Ecosystem> FindNotAssignedEcosBySpecies(int speciesId);
    }
}
