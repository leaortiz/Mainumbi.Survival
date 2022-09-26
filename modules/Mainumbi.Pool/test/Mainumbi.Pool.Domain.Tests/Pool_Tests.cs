using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Xunit;

namespace Mainumbi.Pool
{
    public class Pool_Tests
    {   
        [Fact]
        public void Will_Create_New_Valid_Pool()
        {
            Pool pool = NewPool();

            pool.Entries.ShouldBe(0);
            pool.State.ShouldBe(PoolState.Open);
        }

        [Fact]
        public void Will_Add_Enroll()
        {
            Pool pool = NewPool();

            pool = pool.Enroll();

            pool.Entries.ShouldBe(1);
            pool.GetPayout().ShouldBe(90);
            pool.GetPayroll().ShouldBe(10);
        }


        [Fact]
        public void Will_Unroll()
        {
            Pool pool = NewPool();

            pool = pool.Enroll();
            pool = pool.UnRoll();

            pool.Entries.ShouldBe(1);
        }

        [Fact]
        public void Set_In_Progress_Will_Fail_If_Not_Enough_Enrollments()
        {
            Pool pool = NewPool();

            pool = pool.Enroll();

            var ex = Assert.Throws<BusinessException>(() => pool.SetInProgress());
            ex.Code.ShouldBe(PoolErrorCodes.PoolNotEnoughEnrollments);
        }

        [Fact]
        public void Set_In_Progress()
        {
            Pool pool = NewPool();

            pool = pool.Enroll();
            pool = pool.Enroll();

            pool.SetInProgress();
            

            pool.Entries.ShouldBe(2);
            pool.State.ShouldBe(PoolState.InProgress);

            var ex = Assert.Throws<BusinessException>(() => pool.SetInProgress());
            ex.Code.ShouldBe(PoolErrorCodes.PoolShouldBeOpen);
        }

        [Fact]
        public void Set_As_Canceled()
        {
            Pool pool = NewPool();

            pool = pool.Enroll();
            pool = pool.Enroll();

            pool.SetAsCanceled();

            pool.Entries.ShouldBe(2);
            pool.State.ShouldBe(PoolState.Canceled);

            var ex = Assert.Throws<BusinessException>(() => pool.SetInProgress());
            ex.Code.ShouldBe(PoolErrorCodes.PoolShouldBeOpen);
        }

        private static Pool NewPool()
        {
            return new(100, 10, 1, 1, 3, 2, 1, 1, 10.0m);
        }
    }
}
