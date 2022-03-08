using SampleProject.Domain.SeedWork;

namespace SampleProject.Domain.Customers.Rules
{
    public class CustomerEmailMustBeNackademinRule : IBusinessRule
    {
        private readonly string _email;

        public CustomerEmailMustBeNackademinRule(string email)
        {
            _email = email;
        }

        public bool IsBroken() => !_email.ToLower().Contains("nackademin.se");

        public string Message => "Email must contain nackademin.se";
    }
}
