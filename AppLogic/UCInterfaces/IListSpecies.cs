using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IListSpecies
    {
        List<Species> List();
        List<Species> ListByCientificName();
        List<Species> ListByDangerOfExtinction();
        List<Species> ListByWeight(int min, int max);
        List<Species> ListByEco(int idEco);
    }
}
