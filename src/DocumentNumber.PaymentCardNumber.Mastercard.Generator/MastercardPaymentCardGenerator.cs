namespace DocumentNumber.PaymentCardNumber.Mastercard.Generator
{
  using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
  using System;

  public class MastercardPaymentCardGenerator : CreditCardGeneratorBase
  {
    public MastercardPaymentCardGenerator()
    {
      /// IIN = 2221–2720
      /// IIN = 51–55
      ValidDocumentNumberLengths = new[] { 16 };
    }
    public override string GenerateDocumentNumber()
    {
      Random random = new Random();
      bool isIIN2 = random.Next(1, 10) % 2 == 0;
      string startWith;
      if (isIIN2)
      {
        int number = random.Next(51, 56); //upper is exclued
        startWith = $"{number}";
      }
      else
      {
        int number = random.Next(2221, 2721); //upper is exclued
        startWith = $"{number}";
      }
      string generatedDocumentNumber = this.GenerateDocumentNumber(startWith);
      return generatedDocumentNumber;
    }
  }
}
