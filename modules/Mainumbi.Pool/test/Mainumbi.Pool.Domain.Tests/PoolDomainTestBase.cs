namespace Mainumbi.Pool;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class PoolDomainTestBase : PoolTestBase<PoolDomainTestModule>
{
    internal static Pool NewPool()
    {
        return new(100, 10, 1, 1, 3, 2, 1, 1, 10.0m);
    }
}
