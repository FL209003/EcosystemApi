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
                return new EcosystemDTO(e);
            }
            else return null;
        }

        public SimpleEcoDTO FindSimple(int id)
        {
            Ecosystem e = EcosRepo.FindById(id);
            if (e != null)
            {
                return new SimpleEcoDTO(e);
            }
            else return null;
        }
    }
}