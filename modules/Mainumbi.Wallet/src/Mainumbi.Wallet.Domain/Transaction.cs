using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Wallet
{
    public class Transaction : AuditedEntity<Guid>
    {
        public TransactionType Type { get; protected set; }
        public decimal Amount { get; protected set; }
        public decimal Balance { get; protected set; }
        public Guid WalletId { get; protected set; }

        protected Transaction()
        {

        }

        public Transaction(Guid id, TransactionType type)
        {
            Id = id;
            Type = type;
        }

        public void SetNewBalance(decimal chips)
        {
            Balance = chips;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}
