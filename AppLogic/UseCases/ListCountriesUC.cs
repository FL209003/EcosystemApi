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
    public class ListCountriesUC : IListCountries
    {
        public IRepositoryCountries CountriesRepo { get; set; }

        public ListCountriesUC(IRepositoryCountries repo)
        {
            CountriesRepo = repo;
        }

        public List<CountryDTO> List()
        {
            return CountriesRepo.FindAll().Select(c => new CountryDTO { Id = c.Id, Name = c.CountryName.Value, Alpha3 = c.Alpha3 }).ToList();
        }
    }
}
