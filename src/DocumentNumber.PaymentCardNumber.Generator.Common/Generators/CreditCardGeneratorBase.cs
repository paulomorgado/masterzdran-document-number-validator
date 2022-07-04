namespace DocumentNumber.PaymentCardNumber.Generator.Common.Generators
{
  using DocumentNumber.PaymentCardNumber.Common.Algorithms;
  using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public abstract class CreditCardGeneratorBase
  {
    protected string[] ValidStartNumbers { get; set; }
    protected int[] ValidDocumentNumberLengths { get; set; }

    public string CalculateCheckDigit(string uncheckedNumber)
    {
      return $"{ComputingAlgorithms.LuhnAlgorithm($"{uncheckedNumber}0"):0}";
    }
    public string GenerateDocumentNumber()
    {
      Random random = new Random();
      string startWith = ValidStartNumbers[random.Next(0, ValidDocumentNumberLengths.Length-1)];
      string generatedDocumentNumber = this.GenerateDocumentNumber(startWith);
      return generatedDocumentNumber;
    }
    public string GenerateDocumentNumber(string startsWith)
    {
      Random random = new Random();
      int ValidDocumentNumberLengthIndex = random.Next(0, ValidDocumentNumberLengths.Length - 1);
      int documentNumberLength = ValidDocumentNumberLengths[ValidDocumentNumberLengthIndex];
      StringBuilder randomNumber = new StringBuilder();
      int number;

      while (randomNumber.Length < documentNumberLength - (startsWith.Length + 1))
      {
        number = random.Next(0, 9);
        randomNumber.Append(number);
      }
      string checkDigit = CalculateCheckDigit($"{startsWith}{randomNumber.ToString()}");
      string randomDocumentNumber = $"{startsWith}{randomNumber.ToString()}{checkDigit}";
      return randomDocumentNumber;
    }

  }
}
