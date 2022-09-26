using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mainumbi.Pool
{
    public class Book_Tests : PoolDomainTestBase
    {
        [Fact]
        public void Will_Create_New_Book()
        {
            Pool pool = NewPool();
            Book book = new(Guid.NewGuid(), TestData.UserId1, pool);

            book.PoolId.ShouldBe(pool.Id);
            book.UserId.ShouldBe(TestData.UserId1);
            book.Tickets.Count.ShouldBe(0);
        }

        [Fact]
        public void Will_Buy_Ticket()
        {
            Pool pool = NewPool();
            Book book = new(Guid.NewGuid(), TestData.UserId1, pool);

            book = book.NewTicket(Guid.NewGuid());

            book.PoolId.ShouldBe(pool.Id);
            book.UserId.ShouldBe(TestData.UserId1);
            book.Tickets.Count.ShouldBe(1);
        }
    }
}
