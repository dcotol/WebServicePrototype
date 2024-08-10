using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebServicePrototype.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WCFServiceTest
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDTEService" in both code and config file together.
  [ServiceContract]
  public interface IDTEService
  {
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/GetCustomer")]
    String GetCustomer();

    [OperationContract]
    [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/UpdateCustomer")]
    String UpdateCustomer(String Request);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/GetToken")]
    String GetToken(String Request);

    [OperationContract]
    string GetMessage(string Name);

    // TODO: Add your service operations here
  }

  [DomainComponent]
  public class CustomerResponse
  {
    public List<CustomerData> CustomerData;
  }

  [DomainComponent]
  public class CustomerToUpdate
  {
    public List<CustomerData> CustomersToUpdate;
  }

  [DomainComponent]
  public class UpdateResponse
  {
    public String Message;
  }

  [DomainComponent]
  public class LoginResponse
  {
    public String Token; 
  }


  [DomainComponent]
  public class LoginRequest
  {
    public String UserName;

    public String UserPassword;
  }



  [DataContract]
  public class CustomerData
  {
    string oid;
    string email;
    string phoneNumber;
    string address;
    string name;

    [DataMember]
    public string Oid
    {
      get { return oid; }
      set { oid = value; }
    }

    [DataMember]
    public string Address
    {
      get { return address; }
      set { address = value; }
    }

    [DataMember]
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    [DataMember]
    public string PhoneNumber
    {
      get { return phoneNumber; }
      set { phoneNumber = value; }
    }

    [DataMember]
    public string Email
    {
      get { return email; }
      set { email = value; }
    }
  }


}
