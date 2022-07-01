namespace DocumentNumber.PaymentCardNumber.Generator.Common.Generators
{
  using DocumentNumber.PaymentCardNumber.Common.Algorithms;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public abstract class CreditCardGeneratorBase
  {
    public int CalculateCheckDigit(string uncheckedNumber)
    {
      return ComputingAlgorithms.LuhnAlgorithm($"{uncheckedNumber}0");
    }
    public abstract string GenerateDocumentNumber();
    public abstract string GenerateDocumentNumber(int startsWith);
  }
}
