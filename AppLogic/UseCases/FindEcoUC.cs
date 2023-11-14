using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using DTOs;

namespace AppLogic.UseCases
{
    public class FindEcoUC : IFindEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public FindEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }

        public EcosystemDTO Find(int id)
        {
            Ecosystem e = EcosRepo.FindById(id);
            if (e != null)
            {
                return new EcosystemDTO
                {
                    Id = e.Id,
                    Name = e.EcosystemName.Value,
                    GeoDetails = new GeoUbicationDTO { Latitude = e.GeoDetails.Latitude, Longitude = e.GeoDetails.Longitude },
                    Area = e.Area,
                    Description = e.EcoDescription.Value,
                    Conservation = new ConservationDTO { Id = e.Id, Name = e.EcoConservation.ConservationName.Value },
                    ImgRoute = e.ImgRoute,
                    Security = e.Security,
                    //Species = e.Species,
                    //Threats = e.Threats,
                    //Countries = e.Countries
                };
            }
            else return null;
        }
    }
}