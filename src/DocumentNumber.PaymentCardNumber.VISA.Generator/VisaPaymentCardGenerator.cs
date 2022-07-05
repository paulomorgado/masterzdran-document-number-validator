using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;

namespace DocumentNumber.PaymentCardNumber.VISA.Generator
{
  public class VisaPaymentCardGenerator : CreditCardGeneratorBase
  {
    public VisaPaymentCardGenerator()
    {
      ValidStartNumbers = new[] { "4" };
      ValidDocumentNumberLengths = new[] { 13, 16 };
    }
  }
}
