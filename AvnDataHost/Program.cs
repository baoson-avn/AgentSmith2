using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AvnDataHost
{
    class Program
    {
        private static ServiceHost serviceHost;

        static void Main(string[] args)
        {
            HostDataServices();
            Console.ReadLine();
        }

        /// <summary>
        /// Create a self-hosted service
        /// </summary>
        private static void HostDataServices()
        {
            //Host the data service
            try
            {
                //Create the service host
                serviceHost = new ServiceHost(typeof(AvnDataService.StaffService), new Uri("net.tcp://localhost:9009"));

                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();

                ////Set the HttpGetEnabled property to True
                //smb. = true;

                //The ServiceMetadataBehavior contains a MetadataExporter property. 
                //The MetadataExporter contains a PolicyVersion property. 
                //Set the value of the PolicyVersion property to Policy15. 
                //The PolicyVersion property can also be set to Policy12. 
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

                //Add the ServiceMetadataBehavior instance to the service host's behaviors collection. 
                serviceHost.Description.Behaviors.Add(smb);

                // Add MEX endpoint
                serviceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                // Add application endpoint
                serviceHost.AddServiceEndpoint(typeof(AvnDataService.IStaffService), new NetTcpBinding(), "net.tcp://localhost:9010/staff");

                // Open the service host to accept incoming calls
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("Data Service Hosted");
            }
            catch (Exception ex)
            {
                //There was a communication problem
                Console.WriteLine("Data Service Hosting Error:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
