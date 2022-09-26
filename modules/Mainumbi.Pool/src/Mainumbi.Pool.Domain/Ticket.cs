using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mainumbi.Pool
{
    public class Ticket : AuditedEntity<Guid>
    {
        public Guid BookId { get; set; }
        public int State { get; set; }

        private Ticket()
        {
                
        }

        internal Ticket(Guid newId, Book book)
        {
            Id = newId;
            BookId = book.Id;
        }
    }
}
