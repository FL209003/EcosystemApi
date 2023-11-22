using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LimitDTO
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public LimitDTO() { }

        public LimitDTO(int min, int max) {  Min = min; Max = max; }
    }
}
