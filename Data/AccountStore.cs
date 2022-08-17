using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountStore
    {
        public virtual Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public virtual void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
