using Microsoft.AspNetCore.Mvc;
using backend_101.Models;
using System.Text;
using System.Text.Json;
using backend_101.Constants;
using backend_101.Function;

[ApiController]

public class BangunRuangController : ControllerBase
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

            modelRequestInternal.Data = JsonSerializer.Serialize<UserModel>(modelUser);

             modelResponse = UtilityFunction.callInternalService(WebAddressConstant.STRING_SCHME_HTTP + WebAddressConstant.STRING_SCHME_LOCALHOST + WebAddressConstant.STRING_PORT_KIDZ +  WebAddressConstant.STRING_KIDZ_VALIDATEUSERTOKEN,modelRequestInternal);

            if (modelResponse.ServiceResponseCode == ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS)
            {
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                modelUser = JsonSerializer.Deserialize<UserModel>(modelRequest.Data, serializerOptions);
                modelPersegi = modelUser.modelPersegi;
                modelPersegi.Result = modelPersegi.countLuasBangunan();
                modelUser.modelPersegi = modelPersegi;
                Console.Write(modelPersegi.detailBangunan());

                modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
                modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_SUCCESS;
                modelResponse.Data = JsonSerializer.Serialize<UserModel>(modelUser, serializerOptions);

            }
            else
            {
                modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_FAIL;
                modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_TOKEN_NOTFOUND;
                modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_CONTENT_ACCESS_DENY;
            }

        }


        return modelResponse;
    }


}