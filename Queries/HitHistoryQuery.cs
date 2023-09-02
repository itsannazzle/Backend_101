

using backend_101.DatabaseConnection;
using backend_101.Models;

namespace backend_101.Queries
{
    public class HitHistoryQuery
    {
        private DatabaseContex _databaseContex;

        public HitHistoryQuery(DatabaseContex databaseContex)
        {
            this._databaseContex = databaseContex;
        }

        public bool insertHistory(HitHistoryModel modelHitHistory)
        {
            _databaseContex.entityHitHistory.Add(modelHitHistory);
            return _databaseContex.SaveChanges() > 0;
        }
    }
}