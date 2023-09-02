

using backend_101.DatabaseConnection;
using backend_101.Models;

namespace backend_101.Queries
{
    public class TransactionQuery
    {
        private DatabaseContex _databaseContex;

        public TransactionQuery(DatabaseContex databaseContex)
        {
            this._databaseContex = databaseContex;
        }

        public Boolean insertTransaction(TransactionModel modelTransaction)
        {
            ResponseModel modelResponse = new ResponseModel();

            _databaseContex.entityTransaction.Add(modelTransaction);

            return _databaseContex.SaveChanges() > 0;
        }

        // public ResponseModel insertTransactionToken (TransactionModel modelTransaction)
        // {
        //     UserModel modelUserResult = selectUser(modelUser);
        //     modelUserResult.Token = modelUser.Token;
        //     _databaseContex.entityUser.Update(modelUserResult);

        //     if(_databaseContex.SaveChanges() > 0)
        //     {
        //         modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_SUCCESS;
        //         modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_SUCCESS;
        //         modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_SUCCESS;

        //     }
        //     else
        //     {
        //         modelResponse.ServiceResponseCode = ServiceResponseCodeConstant.STRING_RESPONSECODE_MODULE_FAIL;
        //         modelResponse.MessageContent = StringConstant.STRING_MESSAGE_CONTENT_INSERTFAIL;
        //         modelResponse.MessageTitle = StringConstant.STRING_MESSAGE_TITLE_FAIL;
        //     }

        //     return modelResponse;
        // }

        public TransactionModel selectTransaction(TransactionModel modelTransaction)
        {
            return _databaseContex.entityTransaction.Where(trx => trx.ID == modelTransaction.ID).FirstOrDefault<TransactionModel>();
        }


    }
}