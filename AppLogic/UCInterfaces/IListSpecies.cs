using Domain.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IListSpecies
    {
        List<SpeciesDTO> List();
        List<SpeciesDTO> ListByCientificName();
        List<SpeciesDTO> ListByDangerOfExtinction();
        List<SpeciesDTO> ListByWeight(int min, int max);
        List<SpeciesDTO> ListByEco(int idEco);
    }
}
