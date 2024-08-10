using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebServicePrototype.Module.BusinessObjects;
using System.IO;
using Newtonsoft.Json;
using DevExpress.Data.Filtering;
using System.Security.Claims;

namespace WCFServiceTest
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DTEService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select DTEService.svc or DTEService.svc.cs at the Solution Explorer and start debugging.
  public class DTEService : IDTEService
  {
    public String GetCustomer()
    {
      // Commented while testing the http version
      //var principal = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] as ClaimsPrincipal;
      //var userName = principal?.Identity?.Name;

      var cn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

      var dal = CreateDataLayer(false, cn);
      UnitOfWork unitOfWork = new UnitOfWork(dal);

      XPCollection<Customer> dataCollection = new XPCollection<Customer>(unitOfWork);

      CustomerResponse response = new CustomerResponse();
      response.CustomerData = new List<CustomerData>();

      foreach (Customer dataItem in dataCollection)
      {

        CustomerData customerRecord = new CustomerData();
        //customerRecord.Oid = dataItem.ToString();
        customerRecord.Name = dataItem.Name;
        customerRecord.Address = dataItem.Address;
        customerRecord.PhoneNumber = dataItem.PhoneNumber;
        customerRecord.Email = dataItem.Email;
        response.CustomerData.Add(customerRecord);
      }

      //, Encoding.UTF8, "application/json"

      var strResponse = JsonConvert.SerializeObject(response);

      return strResponse;
    }

    public String UpdateCustomer(String request)
    {
      var cn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

      var dal = CreateDataLayer(false, cn);
      UnitOfWork unitOfWork = new UnitOfWork(dal);
      UpdateResponse response = new UpdateResponse();

      string message = string.Empty;

      var req = JsonConvert.DeserializeObject<CustomerToUpdate>(request);

      try
      {
        foreach (var itemUpdate in req.CustomersToUpdate)
        {
          Customer objToUupdate = unitOfWork.FindObject<Customer>(new BinaryOperator("Name", itemUpdate.Name));

          if (!ReferenceEquals(objToUupdate, null))
          {
            objToUupdate.Name = itemUpdate.Name;
            objToUupdate.Address = itemUpdate.Address;
            objToUupdate.PhoneNumber = itemUpdate.PhoneNumber;
            objToUupdate.Email = itemUpdate.Email;
          }
        }

        if (unitOfWork.InTransaction)
          unitOfWork.CommitTransaction();

        //response.Message = "Success";
        message = "Success";
      }
      catch (Exception e)
      {
        //response.Message = e.Message;
        message = e.Message;
      }

      //var strResponse = JsonConvert.SerializeObject(response);

      return message;
    }



    public string GetMessage(string name)
    {
      return "Hello " + name;
    }

    static IDataLayer CreateDataLayer(bool threadSafe, string connStr)
    {
      ReflectionDictionary dictionary = new ReflectionDictionary();
      AutoCreateOption autoCreateOption = AutoCreateOption.SchemaAlreadyExists;
      IDataStore provider = XpoDefault.GetConnectionProvider(connStr, autoCreateOption);
      var localdl = threadSafe ? (IDataLayer)new ThreadSafeDataLayer(dictionary, provider) : new SimpleDataLayer(dictionary, provider);
      return localdl;
    }

    public string GetToken(string request)
    {

      var req = JsonConvert.DeserializeObject<LoginRequest>(request);

      return JwtTokenIssuer.GenerateJwtToken(req.UserName);
    }

    //public class WebApiGetEntitiesRequest : RequestBase
    //{
    //  public WebApiGetEntitiesRequest()
    //  {

    //  }
    //  public string EntityName { get; set; }
    //  public int Limit { get; set; }
    //  public int Offset { get; set; }
    //  public string Properties { get; set; }
    //  public string Criteria { get; set; }
    //  public string OrderBy { get; set; }

    //}

    //public class RequestBase : RequestResponseBase
    //{

    //}


    //public class ResponseBase : RequestResponseBase, IStatusResponse
    //{
    //  public string Message { get; set; }
    //  public ResponseStatus Status { get; set; }

    //  public void SetResponseSuccess()
    //  {
    //    Status = ResponseStatus.Success;
    //  }

    //  public void SetResponseError(string message)
    //  {
    //    Status = ResponseStatus.Error;
    //    Message = message;
    //  }
    //}

    //public class RequestResponseBase
    //{
    //  public string PartnerLocationId { get; set; }
    //}

    //public enum ResponseStatus
    //{
    //  Success,
    //  Cancelled,
    //  Error
    //}

    //public interface IStatusResponse
    //{
    //  void SetResponseSuccess();
    //  void SetResponseError(string message);
    //}

  }
}
