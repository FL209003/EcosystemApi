using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class AddEcoUC : IAddEcosystem
    {

        public IRepositoryEcosystems EcosRepo { get; set; }

        public AddEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }

        public void Add(EcosystemDTO eco)
        {
            Ecosystem ecosystem = new()
            {
                EcosystemName = new Name(eco.Name),
                GeoDetails = new GeoUbication(eco.GeoDetails.Latitude, eco.GeoDetails.Longitude),
                Area = eco.Area,
                EcoDescription = new Description(eco.Description),
                //EcoConservation = new Conservation(eco.Conservation),
                ImgRoute = eco.ImgRoute,
                Security = eco.Security,
                Countries = new List<Country>(eco.Countries.Select(c => new Country { Id = c.Id }).ToList())
            };

            EcosRepo.Add(ecosystem);
            eco.Id = ecosystem.Id;
        }       
    }
}
