using Microsoft.AspNetCore.Mvc;
using backend_101.Models;
using System.Text;
using System.Text.Json;

// namespace backend_101.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{

    [HttpGet]
    [Route("[controller]/GetCustomerDetail")]
    public string getCustomerDetail()
    {
        CustomerModel customerModel = new CustomerModel();
        customerModel.FirstName = "Ibop";
        customerModel.LastName = "ibip";
        customerModel.BirthPlace = "kalimantan";

        return customerModel.printCustomerDetail("ibob lagi");
    }

    [HttpGet]
    [Route("[controller]/GetCustomerDetailList")]
    public List<CustomerModel> getCustomerDetailList()
    {
        CustomerModel customerModel = new CustomerModel();
        customerModel.FirstName = "Ibop";
        customerModel.LastName = "ibip";
        customerModel.BirthPlace = "kalimantan";

        List<CustomerModel> listCustomer = new List<CustomerModel>();
        for(int i = 0; i < 5; i++)
        {
            listCustomer.Add(customerModel);
        }

        return listCustomer;
    }

    [HttpGet]
    [Route("[controller]/GetCustomerDetailListCount")]
    public List<CustomerModel> getCustomerDetailListCount([FromQuery(Name ="count")] int pageCount)
    {

        CustomerModel customerModel = new CustomerModel();
        customerModel.FirstName = "Ibop";
        customerModel.LastName = "ibip";
        customerModel.BirthPlace = "kalimantan";

        List<CustomerModel> listCustomer = new List<CustomerModel>();
        for(int i = 0; i < pageCount; i++)
        {
            listCustomer.Add(customerModel);
        }

        return listCustomer;
    }

    [HttpPost]
    [Route("[controller]/PostInsertCustomer")]
    public CustomerModel postInsertCustomer([FromBody] string stringRequest)
    {
        byte[] data = Convert.FromBase64String(stringRequest);
        string decodedString = Encoding.UTF8.GetString(data);

        CustomerModel modelCustomer = new CustomerModel();
        modelCustomer = JsonSerializer.Deserialize<CustomerModel>(decodedString);

        return modelCustomer;
    }

}