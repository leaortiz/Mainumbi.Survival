using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Wallet
{
    public class Wallet : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal PendingWithdrawal { get; protected set; }
        public List<Transaction> Transactions { get; set; }

        protected Wallet()
        {
            Transactions = new List<Transaction>();
        }

        public Wallet(Guid userId)
        {
            UserId = userId;
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public Wallet Add(decimal amount, [NotNull] Transaction transaction)
        {
            if (amount < 1) throw new ArgumentException(WalletErrorCodes.NotPositive);

            Balance += amount;
            AddTransaction(amount, transaction);

            return this;
        }

        public Wallet Withdraw(decimal amount, [NotNull] Transaction transaction)
        {
            if (amount < 1) throw new ArgumentException(WalletErrorCodes.NotPositive);
            if (amount > Balance) throw new BusinessException(WalletErrorCodes.NotEnoghFunds);

            PendingWithdrawal += amount;
            Balance -= amount;
            AddTransaction(amount, transaction);
            return this;
        }

        public Wallet Substract(decimal entryFee, [NotNull] Transaction transaction)
        {
            if (Balance < entryFee) throw new ApplicationException(WalletErrorCodes.NotEnoghFunds);
            Balance -= entryFee;
            transaction.SetNewBalance(Balance);
            return this;
        }

        public Wallet ConfirmWithdrawal()
        {
            PendingWithdrawal = 0;
            return this;
        }

        private void AddTransaction(decimal amount, [NotNull] Transaction transaction)
        {
            transaction.SetAmount(amount);
            transaction.SetNewBalance(Balance);
            Transactions.Add(transaction);
        }

    }
}
