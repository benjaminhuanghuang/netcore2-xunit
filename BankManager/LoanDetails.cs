namespace BankManager
{
    public class LoanDetails
    {
        public bool IsApproved { get; private set; }
        public int LoanAmount { get; private set; }
        public int LoanLengthInMonths { get; private set; }

        public LoanDetails(bool isApproved, int loanAmount, int loanLengthInMonths)
        {
            IsApproved = isApproved;
            LoanAmount = loanAmount;
            LoanLengthInMonths = loanLengthInMonths;
        }

        public override string ToString()
        {
            return string.Format("Is approved: {0} for loan amount: {1}; with a term length of {2} months.",
                                 IsApproved, LoanAmount, LoanLengthInMonths);
        }

        public bool Equals(LoanDetails other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.IsApproved.Equals(IsApproved) && other.LoanAmount == LoanAmount && other.LoanLengthInMonths == LoanLengthInMonths;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (LoanDetails)) return false;
            return Equals((LoanDetails) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = IsApproved.GetHashCode();
                result = (result*397) ^ LoanAmount;
                result = (result*397) ^ LoanLengthInMonths;
                return result;
            }
        }
    }
}