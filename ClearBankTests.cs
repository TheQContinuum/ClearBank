using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class ClearBankTests
    {
        [TestMethod]
        public void MakePayment_BACS_Style()
        {
            PaymentService paymentService = new PaymentService();

            MakePaymentRequest request = new MakePaymentRequest();
            request.PaymentScheme = PaymentScheme.Bacs;
            request.PaymentDate = DateTime.Now;
            request.Amount = 100;
            request.CreditorAccountNumber = "00010017";
            request.DebtorAccountNumber = "99988811";

            MakePaymentResult result = paymentService.MakePayment(request);

            Assert.AreEqual(false, result.Success);

        }

        [TestMethod]
        public void MakePayment_Chaps_Style()
        {
            PaymentService paymentService = new PaymentService();

            MakePaymentRequest request = new MakePaymentRequest();
            request.PaymentScheme = PaymentScheme.Chaps;
            request.PaymentDate = DateTime.Now;
            request.Amount = 100;
            request.CreditorAccountNumber = "00010017";
            request.DebtorAccountNumber = "99988811";

            MakePaymentResult result = paymentService.MakePayment(request);

            Assert.AreEqual(false, result.Success);

        }

        [TestMethod]
        public void MakePayment_FasterPayments_Style()
        {
            PaymentService paymentService = new PaymentService();

            MakePaymentRequest request = new MakePaymentRequest();
            request.PaymentScheme = PaymentScheme.FasterPayments;
            request.PaymentDate = DateTime.Now;
            request.Amount = 100;
            request.CreditorAccountNumber = "00010017";
            request.DebtorAccountNumber = "99988811";

            MakePaymentResult result = paymentService.MakePayment(request);

            Assert.AreEqual(false, result.Success);

        }
    }
}
