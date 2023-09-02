namespace backend_101.Models;

public class BaseModel
{
    public int ID { get; set;}
    public DateTime CreatedOn { set; get; }
    public string CreatedBy { get; set;}
    public string RequestedBy { set;  get; }

    public BaseModel()
    {
        this.ID = 0;

    }

}