using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost_WCF
{
  class Program
  {
    static void Main(string[] args)
    {
      Uri baseAddress = new Uri("https://localhost:8443/DTEService");

      //Uri baseAddress = new Uri("http://localhost:8080/DTEService");


      using (ServiceHost host = new ServiceHost(typeof(WCFServiceTest.DTEService), baseAddress))
      //using (ServiceHost host = new ServiceHost(typeof(WCFServiceTest.DTEService)))
      {
        // Configure binding with HTTPS
        //WebHttpBinding basicBinding = new WebHttpBinding(WebHttpSecurityMode.Transport);

        WSHttpBinding binding = new WSHttpBinding(SecurityMode.Transport);
        host.AddServiceEndpoint(typeof(WCFServiceTest.IDTEService), binding, "HelloService");
        host.AddServiceEndpoint(typeof(WCFServiceTest.IDTEService), binding, "GetCustomer");
        host.AddServiceEndpoint(typeof(WCFServiceTest.IDTEService), binding, "UpdateCustomer");
        host.AddServiceEndpoint(typeof(WCFServiceTest.IDTEService), binding, "GetToken");

        //Enable metadata exchange
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior
       {
         HttpsGetEnabled = true,
         HttpsGetUrl = new Uri("https://localhost:8443/DTEService")
       };
        host.Description.Behaviors.Add(smb);

        // Open the host

        //host.AddServiceEndpoint(typeof(WCFServiceTest.IDTEService), new WSHttpBinding(SecurityMode.Transport), "GetToken");

        // Enable metadata exchange
        //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        // smb.HttpsGetEnabled = true;
        // host.Description.Behaviors.Add(smb);
        // host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");

        host.Open();
        Console.WriteLine("Service is running at {0}", baseAddress);
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
      }


      //Uri baseAddress = new Uri("https://localhost:8443/YourService");
      //ServiceHost selfHost = new ServiceHost(typeof(YourService), baseAddress);

      //try
      //{
      //  selfHost.AddServiceEndpoint(typeof(IYourService), new WebHttpBinding(WebHttpSecurityMode.Transport), "GetToken");

      //  ServiceEndpoint endpoint = selfHost.Description.Endpoints.Find(typeof(IYourService));
      //  endpoint.Behaviors.Add(new WebHttpBehavior());

      //  ServiceMetadataBehavior smb = new ServiceMetadataBehavior
      //  {
      //    HttpsGetEnabled = true
      //  };
      //  selfHost.Description.Behaviors.Add(smb);

      //  selfHost.Open();
      //  Console.WriteLine("The service is ready at {0}", baseAddress);
      //  Console.WriteLine("Press <Enter> to stop the service.");
      //  Console.ReadLine();

      //  selfHost.Close();
      //}
      //catch (CommunicationException ce)
      //{
      //  Console.WriteLine("An exception occurred: {0}", ce.Message);
      //  selfHost.Abort();
      //}



    }
  }
}

