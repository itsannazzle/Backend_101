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
            ResponseModel modelResponse = new ResponseModel();
            string stringEncodedRequest;
            HttpClient client = new HttpClient();
            Uri uri = new Uri(stringURL);

            try
            {
                using StringContent content = new StringContent(JsonSerializer.Serialize(stringRequest),UnicodeEncoding.UTF8,"application/json");

                HttpResponseMessage httpResponseMessage = client.PostAsync(uri, content).Result;

                Console.Write(httpResponseMessage.StatusCode);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringResult = httpResponseMessage.Content.ReadAsStringAsync().Result;

                JsonSerializerOptions serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                modelResponse = JsonSerializer.Deserialize<ResponseModel>(stringResult,serializerOptions);


            }
            catch (Exception exception)
            {

                Console.WriteLine("error message : "+exception.Message);
            }

            return modelResponse;
        }
    }
}