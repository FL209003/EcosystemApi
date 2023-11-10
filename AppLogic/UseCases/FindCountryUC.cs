using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class FindCountryUC : IFindCountry
    {
        public IRepositoryCountries CountriesRepo { get; set; }

        public FindCountryUC(IRepositoryCountries repo)
        {
            CountriesRepo = repo;
        }

        public Country FindById(int id)
        {
            return CountriesRepo.FindById(id);
        }
    }
}
