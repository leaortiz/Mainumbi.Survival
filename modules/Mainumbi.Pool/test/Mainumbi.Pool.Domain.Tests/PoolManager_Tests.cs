using Mainumbi.Wallet;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mainumbi.Pool
{
    public class PoolManager_Tests : PoolDomainTestBase
    {
        [Fact]
        public async void Will_Add_New_Ticket()
        {
            Pool pool = NewPool();

            IBookManager bookManager = new BookManager(bookRepository);

            Book book = await bookManager.NewTicket(pool, TestData.UserId1);

            book.ShouldNotBe(null);

        }
    }
}
