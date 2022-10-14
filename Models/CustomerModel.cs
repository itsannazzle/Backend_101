
namespace backend_101.Models;
public class CustomerModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthPlace { get; set; }

    public CustomerModel()
    {
        this.FirstName = "Anna";
        this.LastName = "Karenina";
        this.BirthPlace = "";

    }

    public CustomerModel(string FirstNameParam, string LastNameParam, string BirthPlaceParam)
    {
        this.FirstName = FirstNameParam;
        this.LastName = LastNameParam;
        this.BirthPlace = BirthPlaceParam;

    }

    public bool validateFirstName()
    {
        return FirstName != null;
    }

    public void printCustomerDetail()
    {
        Console.Write(string.Format("User firstname {0} , lastname : {1} , birthplace : {2} ",FirstName,LastName,BirthPlace));
    }

    public string printCustomerDetail(string FirstNameParam)
    {
        return string.Format("User firstname {0} , lastname : {1} , birthplace : {2} ",FirstNameParam,LastName,BirthPlace);
    }

}