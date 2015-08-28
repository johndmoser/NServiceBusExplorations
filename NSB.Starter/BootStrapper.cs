using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSB.Commands;
using NServiceBus;

namespace NSB.Starter
{
    
    public class BootStrapper : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 'T' for new Trade.");
                Console.WriteLine("Press 'P' for Position Update.");
                Console.WriteLine("Press 'A' to Add a Security.");
                Console.WriteLine("Press '$' to Update a Security Price.");
                Console.WriteLine("Press 'X' to Exit.");
                Console.WriteLine();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                
                if (char.ToUpper(keyInfo.KeyChar) == 'T')
                {
                    Console.WriteLine();
                    Console.WriteLine("No implementation for Trade at this time..");
                    Console.ReadLine();
                }

                if (char.ToUpper(keyInfo.KeyChar) == 'P')
                {
                    Console.WriteLine();
                    Console.Write("Enter the Security Name:  ");
                    var securityName = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write(@"Enter the Number of Shares of {0}:  ", securityName);
                    var quantity = Console.ReadLine();

                    Bus.Send("NSB.PositionServer", new UpdatePosition()
                    {
                        SecurityName = securityName,
                        Quantity = quantity
                    }
                        );

                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                }

                if (char.ToUpper(keyInfo.KeyChar) == 'A')
                {
                    Console.WriteLine();
                    Console.Write("Enter the security name:  ");
                    var securityName = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter the exchange:  ");
                    var exchange = Console.ReadLine();

                    Bus.Send("NSB.MasterSecurityServer", new AddMasterSecurity()
                    {
                        SecurityGuid = Guid.NewGuid(),
                        SecurityName = securityName,
                        Exchange = exchange
                    });
                }

                if (keyInfo.KeyChar == '$')
                {
                    Console.WriteLine();
                    Console.Write("Update price for what security? ");
                    var securityName = Console.ReadLine();
                    Console.Write(@"Enter the price for {0}:  ", securityName);
                    var securityPrice = Console.ReadLine();
                    Bus.Send("NSB.PricingServer", new UpdateSecurityPrice()
                    {
                        SecurityName = securityName,
                        Price = Convert.ToDecimal(securityPrice)
                    });

                }

                if (char.ToUpper(keyInfo.KeyChar) == 'X')
                {
                    Console.WriteLine();
                    Console.Write("Exiting the system...");
                }

            }

            
            
        }

        public void Stop()
        {
            
        }
    }
}
