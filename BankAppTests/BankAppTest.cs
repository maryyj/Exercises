using BankApp;
using System.Net.WebSockets;

namespace BankAppTests
{
    public class BankAppTest
    {
        private readonly Bank bank;
        public BankAppTest()
        {
            bank = new Bank("accountName", "accountNumber");
            
        }
        [Fact]
        public void DepositValidAmountShouldIncreaseBalance()
        {
            //Arrange
            double initialBalance = bank.Balance;
            double depositAmount = 50;
            var expected = initialBalance + depositAmount;

            // Act
            bool result = bank.Deposit(depositAmount);

            // Assert
            Assert.True(result);
            Assert.Equal(expected, bank.Balance);
        }

        [Fact]
        public void DepositInvalidAmountShouldNotChangeBalance()
        {
            double expected = bank.Balance;
            double depositAmount = -50.00;

            // Act
            bool result = bank.Deposit(depositAmount);

            // Assert
            Assert.False(result);
            Assert.Equal(expected, bank.Balance);
        }

        [Theory]
        [InlineData(100,50)]
        public void WithdrawalValidAmountShouldDecreaseBalance(double balance, double amount)
        {
            ////Arrange
            //Set the balance to 100
            bank.Balance = balance;
            double withdrawtAmount = amount;
            var expected = bank.Balance - withdrawtAmount;

            // Act
            bool result = bank.Withdraw(withdrawtAmount);

            // Assert
            Assert.True(result);
            Assert.Equal(expected, bank.Balance);
        }

        [Theory]
        [InlineData(0,50)]
        public void WithdrawalInvalidAmountShouldNotChangeBalance(double balance,double amount)
        {
            //Arrange
            var expected = balance;
            double withdrawtAmount = amount;
            // Act
            bool result = bank.Withdraw(withdrawtAmount);
            // Assert
            Assert.False(result);
            Assert.Equal(expected, bank.Balance);

        }
        //[Theory]
        //[InlineData(100, 50)]
        //public void TransferValidAmountShouldDecreaseBalance(double balance, double amount)
        //{
        //    ////Arrange
        //    //Set the balance to 100
        //    bank.Balance = balance;
        //    double withdrawtAmount = amount;
        //    var expected = bank.Balance - withdrawtAmount;

        //    // Act
        //    bool result = bank.Withdraw(withdrawtAmount);

        //    // Assert
        //    Assert.True(result);
        //    Assert.Equal(expected, bank.Balance);
        //}
    }
}