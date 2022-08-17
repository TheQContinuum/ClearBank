using System;

namespace ClearBank.DeveloperTest.Types
{
    public class MakePaymentResult
    {
       
        public bool Success { get; set; }

        public MakePaymentResult(bool Success)
        {
            this.Success = Success;
        }
    }
}
