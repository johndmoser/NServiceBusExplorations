using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Events
{
    public class PositionWasUpdated
    {
        public string Security { get; set; }
        public int Quantity { get; set; }
    }
}
