using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class LoandAdvisorTests
    {
        [Test]
        public void RequestApprovalFor_LoanAmountEqualToYearlyIncomeMinusTotalDebt_IsNotApproved()
        {
            const int loanAmountRequested = 100;
            const int yearlyIncome = 200;
            const int totalDebt = 100;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            Assert.That(loanDetails, Is.EqualTo(LoanDetailsDefaults.UnapprovedDetails));
        }

        [Test]
        public void RequestApprovalFor_LoanAmountEqualToMoreThanYearlyIncomeMinusTotalDebt_IsNotApproved()
        {
            const int loanAmountRequested = 101;
            const int yearlyIncome = 200;
            const int totalDebt = 100;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            Assert.That(loanDetails, Is.EqualTo(LoanDetailsDefaults.UnapprovedDetails));
        }

        [Test]
        public void RequestApprovalFor_LoanAmountEqualToLessThanYearlyIncomeMinusTotalDebtAndIsUnderTenThousandDollars_IsApprovedForRequestedAmountForTwelveMonths()
        {
            const int loanAmountRequested = 99;
            const int yearlyIncome = 200;
            const int totalDebt = 100;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            var approvalDetails = LoanDetailsDefaults.ApprovedDetailsFor(loanAmountRequested)
                .WithTermLengthInMonthsOf(12);
            Assert.That(loanDetails, Is.EqualTo(approvalDetails));
        }

        [Test]
        public void RequestApprovalFor_LoanAmountEqualToLessThanYearlyIncomeMinusTotalDebtAndIsOverTenThousandDollars_IsApprovedForRequestedAmountForTwentyFourMonths()
        {
            const int loanAmountRequested = 10001;
            const int yearlyIncome = 10002;

            const int totalDebt = 0;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            var approvalDetails = LoanDetailsDefaults.ApprovedDetailsFor(loanAmountRequested)
                .WithTermLengthInMonthsOf(24);
            Assert.That(loanDetails, Is.EqualTo(approvalDetails));
        }
    }

    public class LoanDetailsDefaults
    {
        public static LoanDetails UnapprovedDetails = new LoanDetails(false, 0, 0);

        public static LoanDetails ApprovedDetailsFor(int loanAmount)
        {
            return new LoanDetails(true, loanAmount, 0);
        }
    }

    public static class LoanDetailsExtensions
    {
        public static LoanDetails WithTermLengthInMonthsOf(this LoanDetails existing, int termLength)
        {
            return new LoanDetails(existing.IsApproved, existing.LoanAmount, termLength);
        }
    }
}
