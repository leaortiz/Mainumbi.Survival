using System;
using System.Collections.Generic;
using System.Text;

namespace Mainumbi.Wallet
{
    public enum TransactionType
    {
        Deposit = 1,
        Withdrawal = 2,
        PendingWithdrawal = 7,
        Enroll = 3,
        PoolWinner = 4,
        PoolLastSurvivor = 5,
        PoolCanceled = 6,
    }
}
