namespace backend_101.Models;

public class BaseModel
{
    public DateTime CreatedOn { set; get; }
    public string RequestedBy { set;  get; }

    public BaseModel()
    {

    }

}