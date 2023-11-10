using Domain.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IListEcosystem
    {
        List<EcosystemDTO> List();
        List<Ecosystem> ListUninhabitableEcos(int id);
    }
}