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

    public ResponseModel calculatePersegi([FromBody] RequestModel modelRequest)
    {
        PersegiModel modelPersegi = new PersegiModel();
        UserModel modelUser = new UserModel();
        ResponseModel modelResponse = new ResponseModel();

        string stringToken = Request.Headers["Token"];

        if(stringToken != null)
        {

            RequestModel modelRequestInternal = new RequestModel();
            modelUser.Token = stringToken;

            string stringData = base64Decode(modelRequest.Data);

            if(!(string.IsNullOrEmpty(stringData)))
            {
                string stringModelRequestDataSerialize = JsonSerializer.Serialize<UserModel>(modelUser);
                modelRequestInternal.Data = base64Encode(stringModelRequestDataSerialize);

                modelResponse = UtilityFunction.callInternalService(WebAddressConstant.STRING_SCHME_HTTP + WebAddressConstant.STRING_SCHME_LOCALHOST + WebAddressConstant.STRING_PORT_KIDZ +  WebAddressConstant.STRING_KIDZ_VALIDATEUSERTOKEN,modelRequestInternal);

                if (modelResponse.ServiceResponseCode == ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS)
                {
                    JsonSerializerOptions serializerOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    modelUser = JsonSerializer.Deserialize<UserModel>(modelResponse.Data, serializerOptions);
                    modelPersegi = JsonSerializer.Deserialize<PersegiModel>(stringData, serializerOptions);;
                    modelPersegi.Result = modelPersegi.countLuasBangunan();
                    modelUser.modelPersegi = modelPersegi;
                    Console.Write(modelPersegi.detailBangunan());

                    modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
                    modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_SUCCESS;
                    string modelUserSerialize = JsonSerializer.Serialize<UserModel>(modelUser, serializerOptions);
                    modelResponse.Data = base64Encode(modelUserSerialize);

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


        return modelResponse;
    }


}