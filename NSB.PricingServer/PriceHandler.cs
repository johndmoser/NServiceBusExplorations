using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSB.Commands;
using NSB.Events;
using NServiceBus;

namespace NSB.PricingServer
{
    public class PriceHandler : IHandleMessages<UpdateSecurityPrice>, IHandleMessages<MasterSecurityWasAdded>
    {
        private IBus bus;

        public PriceHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(MasterSecurityWasAdded message)
        {
            Console.WriteLine(@"Adding new Security {0} to pricing lookup tables...", message.SecurityGuid);
            // Update your lookup tables for pricing later on
        }

        public void Handle(UpdateSecurityPrice message)
        {
            // Update your pricing tables
            Console.WriteLine(@"Security {0} has new price ${1}", message.SecurityName, message.Price);
            Console.WriteLine();

            // Let others know about the update
            bus.Publish(new PriceWasUpdated() {SecurityName = message.SecurityName, Price = message.Price});
        }



    }
 
}
