
using backend_101.Constants;
using backend_101.Models;

namespace backend_101.Models
{
    public class ResponseModel : BaseModel
    {
        public EnumConstant.ENUM_HTTP_STATUS? HTTPResponseCode { set; get; }
        public string ServiceResponseCode { set; get; }
        public string MessageTitle { set; get; }
        public string MessageContent { set; get; }
        public string Data { set; get; }

        public ResponseModel()
        {

        }
    }
}