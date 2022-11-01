using Microsoft.AspNetCore.Mvc;
using backend_101.Models;
using System.Text;
using System.Text.Json;
using backend_101.Constants;
using backend_101.Function;
using backend_101.Controllers;

[ApiController]

public class BangunRuangController : BaseController
{
    [HttpPost]
    [Route("[controller]/calculatePersegi")]

    public String calculatePersegi([FromBody] String stringRequest)
    {
        PersegiModel modelPersegi = new PersegiModel();
        UserModel modelUser = new UserModel();
        ResponseModel modelResponse = new ResponseModel();
        RequestModel modelRequest = new RequestModel();
        String stringRequestDecoded = "";
        bool boolException = false;

        string stringToken = Request.Headers["Token"];

        try
        {
            stringRequestDecoded = base64Decode(stringRequest);
        }
        catch (Exception exception)
        {
            modelResponse.MessageContent = exception.Message;
            modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_FAIL;
            modelRequest.Data = exception.Message;
            modelResponse.Data = exception.Message;
            boolException = true;
        }

        if(!boolException)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if(stringToken != null)
            {
            RequestModel modelRequestInternal = new RequestModel();
            modelUser.Token = stringToken;

            if(!(string.IsNullOrEmpty(stringRequestDecoded)))
            {
                modelRequest = JsonSerializer.Deserialize<RequestModel>(stringRequestDecoded,serializerOptions);

                string stringModelRequestDataSerialize = JsonSerializer.Serialize<RequestModel>(modelRequest);
                string stringRequestToken = base64Encode(stringModelRequestDataSerialize);

                modelResponse = UtilityFunction.callInternalService(WebAddressConstant.STRING_SCHME_HTTP + WebAddressConstant.STRING_SCHME_LOCALHOST + WebAddressConstant.STRING_PORT_KIDZ +  WebAddressConstant.STRING_KIDZ_VALIDATEUSERTOKEN,stringRequestToken);

                if (modelResponse.ServiceResponseCode == ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS)
                {

                    modelUser = JsonSerializer.Deserialize<UserModel>(modelResponse.Data, serializerOptions);
                    UserModel modelUserResponse = new UserModel();
                    modelUserResponse = JsonSerializer.Deserialize<UserModel>(modelRequest.Data, serializerOptions);
                    modelPersegi = modelUserResponse.modelPersegi;
                    modelPersegi.Result = modelPersegi.countLuasBangunan();
                    modelUser.modelPersegi = modelPersegi;
                    Console.Write(modelPersegi.detailBangunan());

                    modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
                    modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_SUCCESS;
                    string modelUserSerialize = JsonSerializer.Serialize<UserModel>(modelUser, serializerOptions);
                    modelResponse.Data = modelUserSerialize;

                }
                else
                {
                    modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_FAIL;
                    modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_TOKEN_NOTFOUND;
                    modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_CONTENT_ACCESS_DENY;
                }

            }
            else
            {
                modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
                modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_JSONSERIALIZE_FAIL;
                modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_FAIL;
            }
        }
    }

        string stringResponseModel = base64Encode(JsonSerializer.Serialize<ResponseModel>(modelResponse));
        return stringResponseModel;
    }


}