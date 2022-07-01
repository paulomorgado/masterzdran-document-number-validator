namespace DocumentNumber.PaymentCardNumber.AmericanExpress.Generator
{
  using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
  using System;

  public class AmericanExpressPaymentCardGenerator : CreditCardGeneratorBase
  {
    private int[] validStartNumber = { 34, 37 };
    public readonly int DocumentNumberCardLenght = 15;
    public override string GenerateDocumentNumber()
    {
      Random random = new Random();
      int startWith = validStartNumber[random.Next(0,1)];
      string generatedDocumentNumber = this.GenerateDocumentNumber(startWith);
      return generatedDocumentNumber;
    }
    public override string GenerateDocumentNumber(int startWith)
    {
      Random random = new Random();
      int part1 = random.Next(100000, 999999);
      int part2 = random.Next(100000, 999999);
      string uncheckedDocumentNumber = $"{startWith}{part1}{part2}";
      int checkDigit = CalculateCheckDigit(uncheckedDocumentNumber);
      string generatedDocumentNumber = $"{uncheckedDocumentNumber}{checkDigit}";

      return generatedDocumentNumber;
    }
  }
}