using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;

namespace DocumentNumber.PaymentCardNumber.VISAElectron.Generator
{
  public class VisaElectronPaymentCardGenerator : CreditCardGeneratorBase
  {
    public VisaElectronPaymentCardGenerator()
    {
      ValidStartNumbers = new[] { "4026", "4508", "4844", "4913", "4917", "417500" };
      ValidDocumentNumberLengths = new[] { 16 };
    }
  }
}
