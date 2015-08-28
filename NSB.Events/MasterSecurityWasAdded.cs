using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Events
{
    public class MasterSecurityWasAdded
    {
        public Guid SecurityGuid { get; set; }
        public string ConfirmedSecurityName { get; set; }

    }
}
