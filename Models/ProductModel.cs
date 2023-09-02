namespace backend_101.Models;
public class ProductModel : BaseModel
{    
    public string Token { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    public double? Price{ get; set;}

}