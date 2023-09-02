

namespace backend_101.Models
{
    public class HitHistoryModel : BaseModel
    {
        public string URL { set; get; }
        public string Data { set; get; }
        public string ClientDeviceID { set; get; }
        public string IPAddress { set; get; }
        public DateTime? RequestedOn { set; get; }

        public HitHistoryModel()
        {
            
        }

        public void setHitHistoryFromRequest(RequestModel modelRequest, String stringUrl)
        {
            this.URL  = stringUrl;
            this.Data = modelRequest.Data;
            this.ClientDeviceID = modelRequest.ClientDeviceID;
            this.IPAddress = modelRequest.IPAddress;
            this.RequestedBy = modelRequest.RequestedBy;
            this.RequestedOn = DateTime.Now;

        }

    }

}