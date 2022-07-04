using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
using System;

namespace DocumentNumber.PaymentCardNumber.MaestroUK.Generator
{
    public class MaestroUKPaymentCardGenerator : CreditCardGeneratorBase
    {
      public MaestroUKPaymentCardGenerator()
      {
        ValidStartNumbers = new[] { "6759", "676770", "676774" };
        ValidDocumentNumberLengths = new[] { 12, 13, 14, 15, 16, 17, 18, 19 };
      }
    }
}
