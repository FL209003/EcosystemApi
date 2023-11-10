using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IModifyLengthParam
    {
        void ModifyNameParams(int newMinValue, int newMaxValue);

        void ModifyDescParams(int newMinValue, int newMaxValue);
    }
}
