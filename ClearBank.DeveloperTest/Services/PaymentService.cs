using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            //var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            DataStoreType dataStoreType = (ConfigurationManager.AppSettings["DataStoreType"] == "Backup"? DataStoreType.Backup:DataStoreType.Normal);
            
            AccountStore accountDataStore = null;

            Account account = null;

            if (dataStoreType == DataStoreType.Backup)
            {
                accountDataStore = new BackupAccountDataStore();
            }
            else
            {
                accountDataStore = new AccountDataStore();
            }

            account = accountDataStore.GetAccount(request.DebtorAccountNumber);
 
            var result = new MakePaymentResult(true);
           
            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    if (account == null)
                    {
                        result.Success = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:
                    if (account == null)
                    {
                        result.Success = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                    {
                        result.Success = false;
                    }
                    else if (account.Balance < request.Amount)
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.Chaps:
                    if (account == null)
                    {
                        result.Success = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                    {
                        result.Success = false;
                    }
                    else if (account.Status != AccountStatus.Live)
                    {
                        result.Success = false;
                    }
                    break;
            }

            if (result.Success)
            {
                account.Balance -= request.Amount;

                accountDataStore.UpdateAccount(account);

            }

            return result;
        }
    }
}
