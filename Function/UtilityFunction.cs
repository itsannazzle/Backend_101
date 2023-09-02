using System.Text;
using System.Text.Json;
using backend_101.Constants;
using backend_101.Models;

namespace backend_101.Function
{
    public static class UtilityFunction
    {
        
        public static ResponseModel callInternalService(string stringURL, String stringRequest)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true,
            };
            ResponseModel modelResponse = new ResponseModel();
            string stringEncodedRequest;
            HttpClient client = new();
            Uri uri = new(stringURL);

            try
            {
                using StringContent content = new(JsonSerializer.Serialize(stringRequest),UnicodeEncoding.UTF8,"application/json");

                HttpResponseMessage httpResponseMessage = client.PostAsync(uri, content).Result;

                Console.Write(httpResponseMessage.StatusCode);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringResult = httpResponseMessage.Content.ReadAsStringAsync().Result;

                if(!string.IsNullOrEmpty(stringResult))
                {
                    modelResponse = JsonSerializer.Deserialize<ResponseModel>(stringResult,serializerOptions);
                }
                else
                {
                    modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_FAIL;
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine("error message : "+exception.Message);
            }

            return modelResponse;
        }
    }
}