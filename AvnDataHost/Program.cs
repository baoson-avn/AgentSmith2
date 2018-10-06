using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AvnDataHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(AvnDataService.Service1), new Uri("http://localhost:9009"));
            serviceHost.AddServiceEndpoint(typeof(AvnDataService.IStaffService), new NetTcpBinding(), "net.tcp://localhost:9091");
            serviceHost.Open();
            Console.WriteLine("Service hosted;");
            Console.ReadLine();
        }
    }
}
