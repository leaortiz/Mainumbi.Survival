using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Mainumbi.Pool.EntityFrameworkCore;

[ConnectionStringName(PoolDbProperties.ConnectionStringName)]
public interface IPoolDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
