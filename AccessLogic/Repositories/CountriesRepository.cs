using Domain.Entities;
using Domain.RepositoryInterfaces;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class CountriesRepository : IRepositoryCountries
    {
        public EcosystemContext Context { get; set; }

        public CountriesRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Country obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> FindAll()
        {
            return Context.Countries;
        }

        public Country FindById(int id)
        {
            Country? e = Context.Countries.Find(id);
            if (e != null)
            {
                return e;
            }
            throw new EcosystemException("No se encontró un ecosistema con ese id.");
        }

        public void Remove(Country obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
