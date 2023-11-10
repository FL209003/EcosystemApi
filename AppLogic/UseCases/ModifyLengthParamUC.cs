using AppLogic.UCInterfaces;
using Domain.Params;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class ModifyLengthParamUC : IModifyLengthParam
    {
        public IRepositoryParams Repo { get; set; }

        public ModifyLengthParamUC(IRepositoryParams repo)
        {
            Repo = repo;
        }

        public void ModifyNameParams(int newMinLength, int newMaxLength)
        {
            try
            {
                Repo.CheckNameParams(newMinLength, newMaxLength);
                Param minLength = Repo.FindParam("MinNameLength");
                minLength.Value = newMinLength.ToString();
                Repo.Update(minLength);

                Param maxLength = Repo.FindParam("MaxNameLength");
                maxLength.Value = newMaxLength.ToString();
                Repo.Update(maxLength);

                Name.MinNameLength = newMinLength;
                Name.MaxNameLength = newMaxLength;
            }
            catch (Exception)
            {
                throw;
            }     
        }

        public void ModifyDescParams(int newMinLength, int newMaxLength)
        {
            try
            {
                Repo.CheckDescParams(newMinLength, newMaxLength);
                Param minLength = Repo.FindParam("MinDescLength");
                minLength.Value = newMinLength.ToString();
                Repo.Update(minLength);

                Param maxLength = Repo.FindParam("MaxDescLength");
                maxLength.Value = newMaxLength.ToString();
                Repo.Update(maxLength);

                Description.MinDescLength = newMinLength;
                Description.MaxDescLength = newMaxLength;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
