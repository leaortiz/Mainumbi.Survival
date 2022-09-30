using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Pool
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public Guid PoolId { get; set; }
        public Guid UserId { get; set; }
        public List<Ticket> Tickets { get; set; }

        private Book()
        {

        }

        public Book(Guid newGuid, Guid userId, Pool pool)
        {
            Id = newGuid;
            PoolId = pool.Id;
            UserId = userId;
            Tickets = new();
        }

        public Book NewTicket(Guid newId)
        {
            Ticket ticket = new(newId, this);
            Tickets.Add(ticket);

            return this;
        }

        public Book RemoveTicket(Guid ticketId)
        {
            Ticket ticket = Tickets.Find(t => t.Id == ticketId);
            if(ticket != null)
                Tickets.Add(ticket);

            return this;
        }
    }
}
