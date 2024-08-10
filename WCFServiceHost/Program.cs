using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using System.Configuration;

namespace WCFServiceHost
{
  class Program
  {
    static void Main()
    {
      //var cn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

      //var dal = CreateDataLayer(false, cn);
      //UnitOfWork unitOfWork = new UnitOfWork(dal);

      using (ServiceHost host = new ServiceHost(typeof(WCFServiceTest.DTEService)))
      {
        host.Open();
        Console.WriteLine("Host Started @ " + DateTime.Now.ToString());
        Console.ReadLine();
      }

      // Https hosting
      //BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
      //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

      //Uri baseAddress = new Uri("https://yourdomain.com/YourService");

      //ServiceHost host = new ServiceHost(typeof(YourService), baseAddress);
      //host.AddServiceEndpoint(typeof(IYourService), binding, "");

      //ServiceMetadataBehavior smb = new ServiceMetadataBehavior
      //{
      //  HttpsGetEnabled = true
      //};
      //host.Description.Behaviors.Add(smb);

      //host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");

      //host.Open();



    }

    //static IDataLayer CreateDataLayer(bool threadSafe, string connStr)
    //{
    //  ReflectionDictionary dictionary = new ReflectionDictionary();
    //  AutoCreateOption autoCreateOption = AutoCreateOption.SchemaAlreadyExists;
    //  IDataStore provider = XpoDefault.GetConnectionProvider(connStr, autoCreateOption);
    //  var localdl = threadSafe ? (IDataLayer)new ThreadSafeDataLayer(dictionary, provider) : new SimpleDataLayer(dictionary, provider);
    //  return localdl;
    //}

  }
}
