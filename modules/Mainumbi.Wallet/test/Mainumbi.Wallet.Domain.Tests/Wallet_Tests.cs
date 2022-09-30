using Mainumbi.Pool;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Xunit;

namespace Mainumbi.Wallet
{
    public class Wallet_Tests : WalletDomainTestBase
    {
        [Fact]
        public void Will_Create_Wallet()
        {
            Wallet wallet = GetWallet();

            wallet.Transactions.Count.ShouldBe(0);
            wallet.PendingWithdrawal.ShouldBe(0);
            wallet.Balance.ShouldBe(0);
        }

        [Fact]
        public void Will_Fail_To_Add_Chips_With_Amount_Less_Than_One()
        {
            Wallet wallet = GetWallet();

            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => wallet.Add(0, new Transaction(Guid.NewGuid(), TransactionType.Deposit)));

            wallet.Transactions.Count.ShouldBe(0);
            wallet.PendingWithdrawal.ShouldBe(0);
            wallet.Balance.ShouldBe(0);
            ex.Message.ShouldBe(WalletErrorCodes.NotPositive);
        }

        [Fact]
        public void Will_Add_Chips()
        {
            Wallet wallet = GetWallet();

            wallet.Add(100, new Transaction(Guid.NewGuid(), TransactionType.Deposit));
            wallet.Add(100, new Transaction(Guid.NewGuid(), TransactionType.Deposit));

            wallet.Transactions.Count.ShouldBe(2);
            wallet.PendingWithdrawal.ShouldBe(0);
            wallet.Balance.ShouldBe(200);
            wallet.Transactions.First().Type.ShouldBe(TransactionType.Deposit);
            wallet.Transactions.First().Amount.ShouldBe(100);
            wallet.Transactions.First().Balance.ShouldBe(100);
            wallet.Transactions.Last().Amount.ShouldBe(100);
            wallet.Transactions.Last().Balance.ShouldBe(200);
            wallet.Transactions.Last().Type.ShouldBe(TransactionType.Deposit);
        }

        [Fact]
        public void Will_Withdraw_Chips()
        {
            Wallet wallet = GetWallet();
            wallet.Add(100, new Transaction(Guid.NewGuid(), TransactionType.Deposit));

            wallet.Withdraw(50, new Transaction(Guid.NewGuid(), TransactionType.Withdrawal));
            BusinessException notEnoughFunds = Assert.Throws<BusinessException>
                (() => wallet.Withdraw(100, new Transaction(Guid.NewGuid(), TransactionType.Deposit)));


            wallet.Transactions.Count.ShouldBe(2);
            wallet.PendingWithdrawal.ShouldBe(50);
            wallet.Balance.ShouldBe(50);
            wallet.Transactions.Last().Type.ShouldBe(TransactionType.Withdrawal);
            wallet.Transactions.Last().Amount.ShouldBe(50);
            wallet.Transactions.Last().Balance.ShouldBe(50);
            notEnoughFunds.Code.ShouldBe(WalletErrorCodes.NotEnoghFunds);
        }

        [Fact]
        public void Will_Confirm_Withdrawal_Chips()
        {
            Wallet wallet = GetWallet();
            wallet.Add(100, new Transaction(Guid.NewGuid(), TransactionType.Deposit));

            wallet.Withdraw(50, new Transaction(Guid.NewGuid(), TransactionType.Withdrawal));
            wallet.ConfirmWithdrawal();

            wallet.PendingWithdrawal.ShouldBe(0);
            wallet.Balance.ShouldBe(50);
        }

    }
}
