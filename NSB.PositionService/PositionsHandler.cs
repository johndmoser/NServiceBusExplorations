using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSB.Commands;
using NSB.Events;

using NServiceBus;


namespace NSB.PositionService
{
    public class PositionsHandler : IHandleMessages<PriceWasUpdated>, IHandleMessages<UpdatePosition>
    {
        private IBus bus;

        public PositionsHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(UpdatePosition message)
        {
            Console.WriteLine();
            Console.WriteLine(@"Security {0} now has {1} shares.", message.SecurityName, message.Quantity);
        }

        public void Handle(PriceWasUpdated message)
        {
            Console.WriteLine();
            Console.WriteLine(@"Security {0} has had a price update to ${1}", message.SecurityName, message.Price);
            Console.WriteLine();
            Console.WriteLine("Recalculating portfolio positions...");
         
        }
    }
}
