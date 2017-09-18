namespace BankManager
{
    public class LoanAdvisor
    {
        public static LoanDetails RequestApprovalFor(int loanAmount, int yearlyIncome, int currentDebt)
        {
            var isApproved = loanAmount < yearlyIncome - currentDebt;
            var amountApproved = isApproved ? loanAmount : 0;
            int termLength;
            if (isApproved)
                termLength = amountApproved > 10000 ? 24 : 12;
            else termLength = 0;
            return new LoanDetails(isApproved, amountApproved, termLength);
        }
    }
}