using System;
using Xunit;

namespace BankManager.Tests
{
    public class TellerTests
    {
        [Fact]
        public void CheckBalance_WithNoTrasactions_Returns0Balance()
        {
            var teller = new Teller();
            var accountBalance = teller.CheckBalance();

            const int expectedBalance = 0;
            Assert.That()
        }
    }
}
