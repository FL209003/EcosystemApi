using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SpeciesException : Exception
    {
        public SpeciesException() : base() { }

        public SpeciesException(string msg) : base(msg) { }

        public SpeciesException(string msg, Exception ex) : base(msg, ex) { }
    }
}
