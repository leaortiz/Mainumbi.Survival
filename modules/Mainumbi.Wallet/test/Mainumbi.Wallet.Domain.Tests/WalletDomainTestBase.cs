using Mainumbi.Pool;

namespace Mainumbi.Wallet;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class WalletDomainTestBase : WalletTestBase<WalletDomainTestModule>
{
    public Wallet GetWallet()
    {
        return new(TestData.UserId1);
    }
}
