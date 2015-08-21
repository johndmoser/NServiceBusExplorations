using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Commands
{
    public class AddMasterSecurity
    {
        public Guid SecurityGuid { get; set; }
        public string SecurityName { get; set; }

        public string Exchange { get; set; }
    }
}
