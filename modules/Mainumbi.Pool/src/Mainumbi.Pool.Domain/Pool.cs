using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Pool
{
    public class Pool : AuditedAggregateRoot<Guid>
    {
        public decimal EntryFee { get; protected set; }
        public int? Spots { get; protected set; }  
        public int? Entries { get; protected set; }
        public int MaxEntriesPerUser { get; protected set; }
        public int MinEnrollments { get; protected set; }
        public int StartingRound { get; protected set; }
        public int EndingRound { get; protected set; }
        public int Sport { get; protected set; }
        public int GameType { get; protected set; }
        public PoolState State { get; protected set; }
        public decimal Rake { get; protected set; }

        private Pool()
        {

        }

        public Pool(decimal entryFee, 
                    int? spots, 
                    int maxEntriesPerUser, 
                    int startingRound, 
                    int endingRound, 
                    int minEnrollments,
                    int sport, 
                    int gameType, 
                    decimal rake)
        {
            EntryFee = entryFee;
            Spots = spots;
            Entries = 0;
            MaxEntriesPerUser = maxEntriesPerUser;
            StartingRound = startingRound;
            EndingRound = endingRound;
            Sport = sport;
            GameType = gameType;
            State = PoolState.Open;
            Rake = rake;
            MinEnrollments = minEnrollments;
        }

        public Pool Enroll()
        {
            if(Spots == null || Spots > Entries)
                Entries += 1;

            return this;
        }

        public Pool UnRoll()
        {
            if(Entries > 1)
                Entries--;

            return this;
        }

        public decimal GetPayout()
        {
            return EntryFee * (decimal)Entries * (100-Rake) / 100 ;
        }

        public decimal GetPayroll()
        {
            return EntryFee * (decimal)Entries - GetPayout();
        }

        public Pool SetInProgress()
        {
            if (Entries < 2)
                throw new BusinessException(PoolErrorCodes.PoolNotEnoughEnrollments);
            if (State != PoolState.Open)
                throw new BusinessException(PoolErrorCodes.PoolShouldBeOpen);

            State = PoolState.InProgress;

            return this;
        }

        public Pool SetAsCanceled()
        {
            if (State != PoolState.Open)
                throw new BusinessException(PoolErrorCodes.PoolShouldBeOpen);

            State = PoolState.Canceled;

            return this;
        }

        public Pool SetAsEnded()
        {
            if (State != PoolState.InProgress)
                throw new BusinessException(PoolErrorCodes.PoolShouldBeInProgress);

            State = PoolState.Ended;

            return this;
        }


    }
}
