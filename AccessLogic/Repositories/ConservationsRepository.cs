using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace AccessLogic.Repositories
{
    public class ConservationsRepository : IRepositoryConservations
    {

        public EcosystemContext Context { get; set; }

        public ConservationsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Conservation obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conservation> FindAll()
        {
            throw new NotImplementedException();
        }

        public Conservation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Conservation FindBySecurity(int security)
        {
            var con = Context.Conservations
                .Where(cons => cons.MaxSecurityRange >= security && cons.MinSecurityRange < security)
                .SingleOrDefault();
            
            return con ?? throw new InvalidOperationException("No se ha encontrado ninguna conservacion que corresponda a ese nivel de seguridad.");
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Conservation obj)
        {
            throw new NotImplementedException();
        }
    }
}
