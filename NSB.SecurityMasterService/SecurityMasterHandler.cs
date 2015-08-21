using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSB.Commands;
using NSB.Events;
using NServiceBus;

namespace NSB.SecurityMasterServer
{
    
    public class SecurityMasterHandler : IHandleMessages<AddMasterSecurity>
    {
        private IBus bus;

        public SecurityMasterHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(AddMasterSecurity message)
        {
            Console.WriteLine(@"Security '{0}' with id '{1}", message.SecurityName, message.SecurityGuid);

            MasterSecurityAdded securityAdded = new MasterSecurityAdded() {SecurityGuid = message.SecurityGuid};
            Console.WriteLine("Publishing SecurityAdded event.");
            bus.Publish<MasterSecurityAdded>();
        }
    }
}
