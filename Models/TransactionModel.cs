using backend_101.Constants;

namespace backend_101.Models;
public class TransactionModel : BaseModel
{
    public string Token { get; set; }
    public string CreatedBy { get; set;}
    public string ProductToken { get; set;}
    public string ProductQTY { get; set;}
    public double? TotalPrice { get; set;}
    public EnumConstant.ENUM_PAYMENT_STATUS? PaymentStatus { set; get; }
    


}