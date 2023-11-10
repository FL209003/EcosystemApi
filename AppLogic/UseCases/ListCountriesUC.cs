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
    public class ListCountriesUC : IListCountries
    {
        public IRepositoryCountries CountriesRepo { get; set; }

        public ListCountriesUC(IRepositoryCountries repo)
        {
            CountriesRepo = repo;
        }

        public List<Country> List()
        {
            return CountriesRepo.FindAll().ToList();
        }
    }
}
