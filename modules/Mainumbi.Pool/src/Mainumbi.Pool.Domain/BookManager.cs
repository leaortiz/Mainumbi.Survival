using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Mainumbi.Pool
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IRepository<Book> _bookRepository;

        public BookManager(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> NewTicket(Pool pool, Guid userId)
        {
            var guid = GuidGenerator.Create();
            Book book = await _bookRepository.FindAsync(b => b.PoolId == pool.Id && b.UserId == userId)
                ?? new(GuidGenerator.Create(), userId, pool);

            return book.NewTicket(GuidGenerator.Create());
        }

        public async Task<Book> RemoveTicket(Guid ticketId)
        {
            Book book = await _bookRepository.FindAsync(b => b.Tickets.Any(t => t.Id == ticketId));

            if (book != null)
                book.RemoveTicket(ticketId);

            return book;
        }
    }
}
