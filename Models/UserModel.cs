using System.ComponentModel.DataAnnotations.Schema;

namespace backend_101.Models
{
    [NotMapped]
    public class UserModel : BaseModel
    {

    public int ID { set; get; }
    public string Username { set; get; }
    public string Password { set; get; }
    public string FirstName { set; get; }
    public string MiddleName { set; get; }
    public string LastName { set; get; }
    public string DeviceId { set; get; }
    public string Token { set; get; }

    public PersegiModel modelPersegi { set; get; }

    public UserModel()
    {

    }

    public bool validateUser()
    {
        return Username != null && Password != null;
    }



    }
}

