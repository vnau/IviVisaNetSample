using Ivi.Visa;
using System;
using System.Diagnostics;

namespace IviVisaNetSample
{
    class Program
    {
        /// <summary>
        /// Suppress DllNotFoundException exception in Ivi.Visa destructor.
        /// </summary>
        private static void GetReadyToDie()
        {
            System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                var dllNotFoundException = ex as DllNotFoundException;
                if (dllNotFoundException != null && ex.Source == "Ivi.Visa")
                {
                    // Dead programs tell no lies
                    Process.GetCurrentProcess().Kill();
                }

                throw ex;
            };
        }

        static void Main(string[] args)
        {
            try
            {
                using (var res = GlobalResourceManager.Open("TCPIP:localhost::inst0::INSTR"))
                {
                    if (res is IMessageBasedFormattedIO session)
                    {
                        session.WriteLine("*IDN?");
                        var idn = session.ReadLine();
                        Console.WriteLine(string.Format("Connected to {0}", idn));
                    }
                }
            }
            catch (TypeInitializationException ex)
            {
                if (ex.InnerException != null && ex.InnerException is DllNotFoundException)
                {
                    Console.WriteLine("VISA implementation compatible with VISA.NET Shared Components {0} not found. Please install corresponding vendor-specific VISA implementation first.", GlobalResourceManager.ImplementationVersion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            GetReadyToDie();
        }
    }
}
