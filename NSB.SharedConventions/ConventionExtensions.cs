using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.SharedConventions
{
    using NServiceBus;
    public static class ConventionExtensions
    {
        public static void ApplyCustomConventions(this BusConfiguration busConfiguration)
        {
            var conventions = busConfiguration.Conventions();
            conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("NSB") && t.Namespace.EndsWith("Commands"));
            conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("NSB") && t.Namespace.EndsWith("Events"));
            conventions.DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("NSB") && t.Namespace.EndsWith("Messages"));
            // In a similar fashion you can define conventions for EncrypedProperties, DataBusProperties, ExpressMessages and TimeToBeRecevied            
        }
    }
}
