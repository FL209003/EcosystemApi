using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace AppLogic.UseCases
{
    public class FindEcoUC : IFindEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public FindEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }
        
        public Ecosystem Find(int id) 
        {
            return EcosRepo.FindById(id);
        }
    }
}