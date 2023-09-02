using System.Text.Json;
using backend_101.Constants;
using backend_101.Controllers;
using backend_101.DatabaseConnection;
using backend_101.Function;
using backend_101.Models;
using backend_101.Queries;
using Microsoft.AspNetCore.Mvc;

[ApiController]

public class TransactionController : BaseController
{
    string _hostUrl = WebAddressConstant.STRING_SCHME_HTTP + WebAddressConstant.STRING_SCHME_LOCALHOST + WebAddressConstant.STRING_PORT_KIDZ;
    JsonSerializerOptions serializerOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
    public TransactionQuery _transactionQuery;
    public TransactionController(DatabaseContex databaseContex) : base(databaseContex)
    {
        _transactionQuery = new TransactionQuery(databaseContex);
    }
    [HttpPost]
    [Route("[controller]/insertTransaction")]

    public String insertTransaction([FromBody] String stringRequest)
    {
        HitHistoryModel modelHitHistory = new HitHistoryModel();
        ResultHistoryModel modelResultHistory = new ResultHistoryModel();
        TransactionModel modelTransactionRequest = new TransactionModel();
        UserModel modelUser = new UserModel();
        ResponseModel modelResponse = new ResponseModel();
        RequestModel modelRequest = new RequestModel();
        String stringRequestDecoded = "";
        bool boolException = false;
        bool boolValidation = true;
        

        string stringToken = Request.Headers["Token"];

        try
        {
            stringRequestDecoded = base64Decode(stringRequest);
            modelRequest.Data = stringRequestDecoded;
            modelTransactionRequest = JsonSerializer.Deserialize<TransactionModel>(stringRequestDecoded, serializerOptions);
        }
        catch (Exception exception)
        {
            modelResponse.MessageContent = exception.Message;
            modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_FAIL;
            modelRequest.Data = exception.Message;
            modelResponse.Data = exception.Message;
            boolException = true;
        }

        modelHitHistory.setHitHistoryFromRequest(modelRequest,_hostUrl+"/insertTransaction");
        _hitHistoryQuery.insertHistory(modelHitHistory);

        if(!boolException)
        {
            if(!string.IsNullOrEmpty(stringToken))
            {
                if(stringToken == modelTransactionRequest.CreatedBy)
                {
                    RequestModel modelRequestToUser = new();
                    ResponseModel modelResponseFromUser = new();
                    UserModel modelUserRequest = new UserModel
                    {
                        Token = stringToken
                    };
                    UserModel modelUserResponse = new UserModel();

                    string stringModelUser = JsonSerializer.Serialize<UserModel>(modelUserRequest);
                    string stringModelUserEncoded = base64Encode(stringModelUser);

                    modelRequestToUser.Data = stringModelUserEncoded;

                    string stringModelRequest = JsonSerializer.Serialize<RequestModel>(modelRequestToUser);

                    modelResponseFromUser = UtilityFunction.callInternalService(WebAddressConstant.STRING_SCHME_HTTP + WebAddressConstant.STRING_SCHME_LOCALHOST + WebAddressConstant.STRING_PORT_KIDZ + WebAddressConstant.STRING_KIDZ_VALIDATEUSERTOKEN,stringModelRequest);

                    if(modelResponseFromUser != null)
                    {
                        if(modelResponseFromUser.ServiceResponseCode == ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS && !string.IsNullOrEmpty(modelResponseFromUser.Data))
                        {
                            modelUserResponse = JsonSerializer.Deserialize<UserModel>(modelResponseFromUser.Data, serializerOptions);

                        }
                        else
                        {
                            boolValidation = false;
                            //failed to get user
                        }
                    }
                    else
                    {
                        boolValidation = false;
                        //response empty from user server
                    }

                    if(boolValidation)
                    {
                        if(modelUserResponse.Token == modelTransactionRequest.CreatedBy)
                        {
                            if(_transactionQuery.insertTransaction(modelTransactionRequest))
                            {
                                modelTransactionRequest.Token = base64Encode(modelTransactionRequest.ID.ToString());

                                modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
                                modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_SUCCESS;
                                modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_SUCCESS;

                            }
                            else
                            {
                                modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_FAIL;
                                modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_INSERTFAIL;
                                modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_FAIL;
                            }
                        }
                        else
                        {
                            //user invalid
                        }
                    }
                }
                else
                {
                    // user invalid
                }
            }
            else
            {
                //header token not found
            }
            
        }

        modelResultHistory.setResultHistoryModel(modelResponse);
        _resultHistoryQuery.insertResultHistory(modelResultHistory);

        return base64Encode(JsonSerializer.Serialize<ResponseModel>(modelResponse));
    }
}