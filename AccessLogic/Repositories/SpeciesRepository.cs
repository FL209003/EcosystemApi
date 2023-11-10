using Domain.Entities;
using Domain.RepositoryInterfaces;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class SpeciesRepository : IRepositorySpecies
    {
        public EcosystemContext Context { get; set; }

        public SpeciesRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Species s)
        {
            try
            {
                if (s != null)
                {
                    s.Validate();
                    ValidateEcosystems(s);
                    Context.Species.Add(s);
                    Context.SaveChanges();
                }
                else throw new SpeciesException("Error al crear una especie, intente nuevamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void ValidateEcosystems(Species s)
        {
            var speciesThreatIds = s.Threats.Select(t => t.Id).ToList();
            var invalidEcosystem = Context.Ecosystems
                .Include(e => e.Threats)
                .Where(e => s.Ecosystems.Contains(e) && (e.Threats.Any(et => speciesThreatIds.Contains(et.Id)) || s.Security > e.Security))
                .FirstOrDefault();

            if (invalidEcosystem != null)
            {
                throw new EcosystemException("Error al crear una especie: La especie " + s.SpeciesName.Value + " no puede ser asignada a " + invalidEcosystem.EcosystemName.Value);
            }

        }

        public IEnumerable<Species> FindAll()
        {
            return Context.Species.Include(s => s.SpeciesConservation).Include(s => s.Ecosystems).ToList();
        }

        public Species FindById(int id)
        {
            Species? s = Context.Species
                .Include(s => s.Ecosystems)
                .ThenInclude(e => e.Threats)
                .Include(e => e.Threats)
                .FirstOrDefault(s => s.Id == id);
            if (s != null)
            {
                return s;
            }
            else throw new SpeciesException("No se encontró una especie con ese id.");
        }

        public void Remove(Species s)
        {
            if (s != null)
            {
                Context.Species.Remove(s);
                Context.SaveChanges();
            }
            else throw new SpeciesException("La especie que intenta eliminar no existe.");
        }

        public void Update(Species s)
        {
            if (s != null)
            {
                Context.Species.Update(s);
                Context.SaveChanges();
            }
            else throw new SpeciesException("La especie que intenta actualizar no existe.");
        }

        public IEnumerable<Species> FindByCientificName()
        {
            return Context.Species.OrderBy(s => s.CientificName).Include(s => s.Ecosystems).Include(s => s.SpeciesConservation).ToList();
        }

        public IEnumerable<Species> FindByDangerOfExtinction()
        {
            try
            {
                //en dos pasos por que linq me tiraba excepcion de que no podia traducirlo a una consulta sql
                int minSecurityForExtinction = 60;
                int maxThreatsForExtinction = 3;
                var speciesWithEcosystemsAndThreats = Context.Species
                    .Include(s => s.Ecosystems)
                    .Include(s => s.Threats)
                    .ToList();

                var filteredSpecies = speciesWithEcosystemsAndThreats
                    .Where(s => s.Security < minSecurityForExtinction ||
                                (s.Ecosystems != null && s.Ecosystems.Any(e => e.Security < minSecurityForExtinction)))
                    .Where(s => s.Threats != null && s.Threats.Count > maxThreatsForExtinction)
                    .ToList();

                return filteredSpecies;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Species> FindByWeight(int min, int max)
        {
            return Context.Species
                .Include(s => s.SpeciesConservation)
                .Include(s => s.Ecosystems)
                .Where(s=> s.WeightRangeMin >= min && s.WeightRangeMax <= max)
                .ToList();
        }

        public IEnumerable<Species> FindByEco(int idEco)
        {
            try
            {
                return Context.Ecosystems
                    .Where(e => e.Id == idEco)
                    .SelectMany(e => e.Species)
                    .Include(s => s.SpeciesConservation)
                    .Include(s => s.Ecosystems)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
