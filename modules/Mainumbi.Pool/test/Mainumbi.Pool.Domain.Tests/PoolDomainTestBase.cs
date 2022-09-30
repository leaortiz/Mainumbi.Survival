using NSubstitute;
using Volo.Abp.Domain.Repositories;

namespace Mainumbi.Pool;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class PoolDomainTestBase : PoolTestBase<PoolDomainTestModule>
{
    public readonly IRepository<Book> bookRepository;

    public PoolDomainTestBase()
    {
        bookRepository = Substitute.For<IRepository<Book>>();
    }
    internal static Pool NewPool()
    {
        return new(100, 10, 1, 1, 3, 2, 1, 1, 10.0m);
    }
}
