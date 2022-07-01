namespace DocumentNumber.PaymentCardNumber.Generator.Common.Generators
{
  using DocumentNumber.PaymentCardNumber.Common.Algorithms;
  using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public abstract class CreditCardGeneratorBase
  {
    public abstract string[] ValidStartNumber { get; }
    public abstract int[] ValidDocumentNumberLength { get; }

    public string CalculateCheckDigit(string uncheckedNumber)
    {
      return $"{ComputingAlgorithms.LuhnAlgorithm($"{uncheckedNumber}0"):0}";
    }
    public string GenerateDocumentNumber()
    {
      Random random = new Random();
      string startWith = ValidStartNumber[random.Next(0, ValidDocumentNumberLength.Length-1)];
      string generatedDocumentNumber = this.GenerateDocumentNumber(startWith);
      return generatedDocumentNumber;
    }
    public abstract string GenerateDocumentNumber(string startsWith);

  }
}
