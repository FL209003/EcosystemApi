using Domain.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IFindThreat
    {
        ThreatDTO Find(int id);

        SimpleThreatDTO FindSimple(int id);
    }
}
