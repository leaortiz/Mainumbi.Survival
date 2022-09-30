using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mainumbi.Pool
{
    public interface IBookManager
    {
        Task<Book> NewTicket(Pool pool, Guid userId);
        Task<Book> RemoveTicket(Guid ticketId);
    }
}
