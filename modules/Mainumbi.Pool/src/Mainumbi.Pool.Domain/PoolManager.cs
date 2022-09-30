using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Mainumbi.Pool
{
    public class PoolManager : DomainService, IPoolManager
    {
        public Task<Pool> CreatePool(decimal entryFee, int? spots, int maxEntriesPerUser, int startingRound, int endingRound, int minEnrollments, int sport, int gameType, decimal rake)
        {
            Pool pool = new(entryFee,
                spots,
                maxEntriesPerUser,
                startingRound,
                endingRound,
                minEnrollments,
                sport,
                gameType,
                rake);

            return Task.FromResult(pool);
        }
        public Task<Pool> ChangeState(Pool pool, PoolState newState)
        {
            switch (newState)
            {
                case PoolState.Open:
                    throw new BusinessException(PoolErrorCodes.NewStateCannotBeOpen);
                case PoolState.InProgress:
                    pool.SetInProgress();
                    break;
                case PoolState.Canceled:
                    pool.SetAsCanceled();
                    break;
                case PoolState.Ended:
                    pool.SetAsEnded();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return Task.FromResult(pool);
        }
    }
}
