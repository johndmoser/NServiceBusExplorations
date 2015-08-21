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
    public class PriceHandler : IHandleMessages<UpdateSecurityPrice>
    {
        private IBus bus;

        public PriceHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(UpdateSecurityPrice message)
        {
            Console.WriteLine(@"Security {0} has new price ${1}", message.SecurityName, message.Price);
            Console.WriteLine();
            bus.Publish(new PriceUpdated() {SecurityName = message.SecurityName, Price = message.Price});
        }
    }
 
}
