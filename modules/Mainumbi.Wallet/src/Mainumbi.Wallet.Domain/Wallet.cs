using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Wallet
{
    public class Wallet : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public decimal Chips { get; set; }

    }
}
