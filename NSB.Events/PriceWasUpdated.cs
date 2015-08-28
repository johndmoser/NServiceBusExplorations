using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Events
{
    public class PriceWasUpdated
    {
        public string SecurityName { get; set; }
        public decimal Price { get; set; }
    }
}
