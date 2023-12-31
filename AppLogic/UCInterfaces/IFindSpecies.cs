﻿using Domain.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IFindSpecies
    {
        SpeciesDTO Find(int id);

        SimpleSpecDTO FindSimple(int id);
    }
}
