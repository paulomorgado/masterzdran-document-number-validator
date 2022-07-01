namespace DocumentNumber.PaymentCardNumber.AmericanExpress.Generator
{
  using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
  using System;

  public class AmericanExpressPaymentCardGenerator : CreditCardGeneratorBase
  {
    public AmericanExpressPaymentCardGenerator()
    {
      this.ValidStartNumber = new[] { "34", "37" };
      this.ValidDocumentNumberLength = new[] { 15 };
    }
    
    public override string[] ValidStartNumber { get; }
    public override int[] ValidDocumentNumberLength { get;  }

    public override string GenerateDocumentNumber(string startWith)
    {
      Random random = new Random();
      int part1 = random.Next(100000, 999999);
      int part2 = random.Next(100000, 999999);
      string uncheckedDocumentNumber = $"{startWith}{part1}{part2}";
      string checkDigit = CalculateCheckDigit(uncheckedDocumentNumber);
      string generatedDocumentNumber = $"{uncheckedDocumentNumber}{checkDigit}";

      return generatedDocumentNumber;
    }
  }
}