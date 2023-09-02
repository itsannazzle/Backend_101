using backend_101.DatabaseConnection;
using backend_101.Models;

namespace backend_101.Queries
{
    public class ResultHistoryQuery
    {
        private DatabaseContex _databaseContex;

        public ResultHistoryQuery(DatabaseContex databaseContex)
        {
            this._databaseContex = databaseContex;
        }

        public bool insertResultHistory(ResultHistoryModel modelResultHistory)
        {
            _databaseContex.entityResultHistory.Add(modelResultHistory);
            return _databaseContex.SaveChanges() > 0;
        }
    }
}