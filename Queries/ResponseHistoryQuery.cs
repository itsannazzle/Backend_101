using backend_101.DatabaseConnection;
using backend_101.Models;

namespace backend_101.Queries
{
    public class ResponseHistoryQuery
    {
        private DatabaseContex _databaseContex;

        public ResponseHistoryQuery(DatabaseContex databaseContex)
        {
            this._databaseContex = databaseContex;
        }

        public bool insertResponseHistory(ResponseHistoryModel modelResponseHistory)
        {
            _databaseContex.entityResponseHistory.Add(modelResponseHistory);
            return _databaseContex.SaveChanges() > 0;
        }
    }
}