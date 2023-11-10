using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class ThreatsRepository : IRepositoryThreats
    {
        public EcosystemContext Context { get; set; }

        public ThreatsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Threat t)
        {
            try
            {
                if (t != null)
                {
                    t.Validate();
                    Context.Threats.Add(t);
                    Context.SaveChanges();
                }
                else throw new InvalidOperationException("Error al crear una amenaza, intente nuevamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Threat> FindAll()
        {
            return Context.Threats;
        }

        public Threat FindById(int id)
        {
            Threat t = Context.Threats.Find(id);
            if (t != null)
            {
                return t;
            }
            throw new InvalidOperationException("No se encontró una amenaza con ese id.");
        }

        public void Remove(Threat t)
        {
            if (t != null)
            {
                Context.Threats.Remove(t);
                Context.SaveChanges();
            }
            throw new InvalidOperationException("La amenaza que intenta eliminar no existe.");
        }

        public void Update(Threat t)
        {
            if (t != null)
            {
                Context.Threats.Update(t);
                Context.SaveChanges();
            }
            throw new InvalidOperationException("La amenaza que intenta actualizar no existe.");
        }
    }
}
