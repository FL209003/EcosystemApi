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
    public class AddCountryUC : IAddCountry
    {
        public IRepositoryCountries CountriesRepo { get; set; }

        public AddCountryUC(IRepositoryCountries repo)
        {
            CountriesRepo = repo;
        }

        public void Add(Country c)
        {            
            CountriesRepo.Add(c);            
        }
    }
}
