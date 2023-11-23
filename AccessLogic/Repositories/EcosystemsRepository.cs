using Domain.Entities;
using Domain.RepositoryInterfaces;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class EcosystemsRepository : IRepositoryEcosystems
    {
        public EcosystemContext Context { get; set; }

        public EcosystemsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Ecosystem e)
        {
            try
            {
                if (e != null)
                {
                    e.Validate();
                    Context.Entry(e.EcoConservation).State = EntityState.Unchanged;
                    e.Countries.ForEach(e => Context.Entry(e).State = EntityState.Unchanged);
                    e.Species.ForEach(s => Context.Entry(s).State = EntityState.Unchanged);
                    e.Threats.ForEach(t => Context.Entry(t).State = EntityState.Unchanged);
                    Context.Ecosystems.Add(e);
                    Context.SaveChanges();
                }
                else throw new EcosystemException("El ecosystema enviado es nulo.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Ecosystem> FindAll()
        {
            return Context.Ecosystems.Include(e => e.EcoConservation).Include(e=>e.Species).Include(e => e.Countries).Include(e => e.Threats).ToList();
        }

        public IEnumerable<Ecosystem> FindUninhabitableEcos(int id)
        {
                Species targetSpecies = Context.Species
                    .Include(s => s.Ecosystems)
                    .ThenInclude(e => e.Threats)
                    .Include(s => s.Threats)
                    .Include(s => s.SpeciesConservation)
                    .FirstOrDefault(s => s.Id == id);

                    var sharedThreatIds = targetSpecies.Threats.Select(t => t.Id).ToList();

                    return Context.Ecosystems
                        .Where(e =>
                            !e.Species.Any(s => s.Id == id) &&
                            e.Security < targetSpecies.Security &&
                            e.Threats.Any(t => sharedThreatIds.Contains(t.Id)))
                        .ToList();

            }
     
            public IEnumerable<Ecosystem> FindNotAssignedEcosBySpecies(int speciesId)
            {
                var targetSpecies = Context.Species
                    .Include(s => s.Threats)
                    .FirstOrDefault(s => s.Id == speciesId);

                if (targetSpecies == null)
                {
                    
                    return Enumerable.Empty<Ecosystem>();
                }

                var ecosystems = Context.Ecosystems
                    .Include(e => e.EcoConservation)
                    .Include(e => e.Species)
                    .Include(e => e.Threats)
                    .Include(e => e.Countries)
                    .ToList(); 

                return ecosystems
                    .Where(e =>
                        !e.Species.Any(s => s.Id == speciesId) &&
                        e.Security > targetSpecies.Security &&
                        !e.Threats.Any(t => targetSpecies.Threats.Any(st => st.Id == t.Id)))
                    .ToList();
            }

        
        public Ecosystem FindById(int id)
        {
            Ecosystem? e = Context.Ecosystems.Include(e => e.EcoConservation).Include(e => e.Species).Include(e => e.Countries).FirstOrDefault(e => e.Id == id);
            if (e != null)
            {
                return e;
            }
            else throw new EcosystemException("No se encontró un ecosistema con ese id.");
        }

        public void Remove(int id)
        {
            Ecosystem? e = Context.Ecosystems.Find(id);
            if (e != null)
            {
                if (e.Species == null || e.Species.Count == 0)
                {
                    Context.Ecosystems.Remove(e);
                    Context.SaveChanges();
                }
                else throw new EcosystemException("El ecosistema no debe tener especies que lo habiten para poder eliminarlo.");
            }
            else throw new EcosystemException("No se encontró un ecosistema con ese id.");
        }

        public void Update(Ecosystem e)
        {
            if (e != null)
            {
                e.Validate();
                Context.Entry(e).State = EntityState.Modified;
                Context.Entry(e.EcoConservation).State = EntityState.Unchanged;
                e.Countries.ForEach(e => Context.Entry(e).State = EntityState.Unchanged);
                e.Species.ForEach(s => Context.Entry(s).State = EntityState.Unchanged);
                e.Threats.ForEach(t => Context.Entry(t).State = EntityState.Unchanged);
                Context.Ecosystems.Update(e);
                Context.SaveChanges();
            }
            else throw new EcosystemException("El ecosistema que intenta actualizar no existe.");
        }
    }
}
