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
    public class FindCountryUC : IFindCountry
    {
        public IRepositoryCountries CountriesRepo { get; set; }

        public FindCountryUC(IRepositoryCountries repo)
        {
            CountriesRepo = repo;
        }

        public CountryDTO Find(int id)
        {
            Country e = CountriesRepo.FindById(id);
            if (e != null)
            {
                return new CountryDTO(e);
            }
            else return null;
        }
    }
}
