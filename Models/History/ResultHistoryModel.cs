

using backend_101.Constants;

namespace backend_101.Models
{
    public class ResultHistoryModel : BaseModel
    {
        public EnumConstant.ENUM_HTTP_STATUS? HTTPResponseCode { set; get; }
        public string ServiceResponseCode { set; get; }
        public string MessageTitle { set; get; }
        public string MessageContent { set; get; }
        public string Data { set; get; }
        public string ReceivedBy { set; get; }
        public DateTime? ReceivedOn { set; get; }
        public int? HitHistoryID { set; get; }

        public ResultHistoryModel()
        {
            
        }

        public void setResultHistoryModel(ResponseModel modelResponse)
        {
            this.HTTPResponseCode = modelResponse.HTTPResponseCode;
            this.ServiceResponseCode = modelResponse.ServiceResponseCode;
            this.MessageTitle = modelResponse.MessageTitle;
            this.MessageContent = modelResponse.MessageContent;
            this.Data = modelResponse.Data;
            this.ReceivedOn = DateTime.Now;
            this.CreatedOn = DateTime.Now;

        }
    }

}