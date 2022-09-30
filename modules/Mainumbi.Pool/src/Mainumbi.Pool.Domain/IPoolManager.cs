using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mainumbi.Pool
{
    public interface IPoolManager
    {
        Task<Pool> CreatePool(decimal entryFee,
                              int? spots,
                              int maxEntriesPerUser,
                              int startingRound,
                              int endingRound,
                              int minEnrollments,
                              int sport,
                              int gameType,
                              decimal rake);

        Task<Pool> ChangeState(Pool pool, PoolState newState);
    }
}
