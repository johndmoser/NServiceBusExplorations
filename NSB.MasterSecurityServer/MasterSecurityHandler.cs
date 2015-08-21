﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSB.Commands;
using NSB.Events;
using NServiceBus;

namespace NSB.MasterSecurityServer
{
    public class MasterSecurityHandler : IHandleMessages<AddMasterSecurity>
    {
        private IBus bus;

        public MasterSecurityHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(AddMasterSecurity message)
        {
            Console.WriteLine(@"Security '{0}' was added with Id '{1}' on the {2} exchange.", message.SecurityName, message.SecurityGuid, message.Exchange);

            MasterSecurityAdded securityAdded = new MasterSecurityAdded() { SecurityGuid = message.SecurityGuid };
            Console.WriteLine();
            Console.WriteLine("Publishing SecurityAdded event.");
            bus.Publish(new MasterSecurityAdded() {SecurityGuid = message.SecurityGuid});
        }
    }
}