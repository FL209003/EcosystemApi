using Domain.Entities;
using Domain.Params;
using Domain.RepositoryInterfaces;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccessLogic.Repositories
{
    public class ParamsRepository : IRepositoryParams
    {
        public EcosystemContext Context { get; set; }

        public ParamsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Param obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Param> FindAll()
        {
            throw new NotImplementedException();
        }

        public Param FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Param? FindParam(string name)
        {
            return Context.Limits.Where(par => par.Name == name).SingleOrDefault();
        }

        public string? FindValue(string name)
        {
            var value = Context.Limits
                        .Where(par => par.Name == name)
                        .Select(par => par.Value)
                        .SingleOrDefault();
            return value;
        }

        public void CheckNameParams(int newMin, int newMax)
        {
            try
            {
                CheckNameMin(newMin);
                CheckNameMax(newMax);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CheckDescParams(int newMin, int newMax)
        {
            try
            {
                CheckDescMin(newMin);
                CheckDescMax(newMax);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CheckNameMin(int newMin)
        {
            var count = Context.Ecosystems.Count(e => e.EcosystemName.Value.Length < newMin)
                        + Context.Species.Count(s => s.SpeciesName.Value.Length < newMin)
                        + Context.Threats.Count(t => t.ThreatName.Value.Length < newMin)
                        + Context.Countries.Count(c => c.CountryName.Value.Length < newMin)
                        + Context.Conservations.Count(c => c.ConservationName.Value.Length < newMin);

            if (count > 0) throw new InvalidOperationException("El nuevo mínimo no es válido con los datos existentes.");
        }

        public void CheckNameMax(int newMax)
        {
            var count = Context.Ecosystems.Count(e => e.EcosystemName.Value.Length > newMax)
                        + Context.Species.Count(s => s.SpeciesName.Value.Length > newMax)
                        + Context.Threats.Count(t => t.ThreatName.Value.Length > newMax)
                        + Context.Countries.Count(c => c.CountryName.Value.Length > newMax)
                        + Context.Conservations.Count(c => c.ConservationName.Value.Length > newMax);

            if (count > 0) throw new InvalidOperationException("El nuevo máximo no es válido con los datos existentes.");
        }

        public void CheckDescMin(int newMin)
        {
            var count = Context.Ecosystems.Count(e => e.EcoDescription.Value.Length < newMin)
                        + Context.Species.Count(s => s.SpeciesDescription.Value.Length < newMin)
                        + Context.Threats.Count(t => t.ThreatDescription.Value.Length < newMin);

            if (count > 0) throw new InvalidOperationException("El nuevo mínimo no es válido con los datos existentes.");
        }

        public void CheckDescMax(int newMax)
        {
            var count = Context.Ecosystems.Count(e => e.EcoDescription.Value.Length > newMax)
                        + Context.Species.Count(s => s.SpeciesDescription.Value.Length > newMax)
                        + Context.Threats.Count(t => t.ThreatDescription.Value.Length > newMax);

            if (count > 0) throw new InvalidOperationException("El nuevo máximo no es válido con los datos existentes.");
        }

        public void Remove(Param obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Param p)
        {
            if (p != null)
            {
                Context.Limits.Update(p);
                Context.SaveChanges();
            }
            else throw new SpeciesException("La especie que intenta actualizar no existe.");
        }
    }
}
