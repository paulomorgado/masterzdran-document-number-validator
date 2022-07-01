using DocumentNumber.PaymentCardNumber.Generator.Common.Generators;
using System;

namespace DocumentNumber.PaymentCardNumber.Maestro.Generator
{
  public class MaestroPaymentCardGenerator : CreditCardGeneratorBase
  {
     public MaestroPaymentCardGenerator()
    {
      this.ValidStartNumber = new[] { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
      this.ValidDocumentNumberLength = new[] { 12, 13, 14, 15, 16, 17, 18, 19 };
    }

    public override string[] ValidStartNumber { get; }
    public override int[] ValidDocumentNumberLength { get; }

    public override string GenerateDocumentNumber(string startsWith)
    {
      throw new NotImplementedException();
    }
  }
}
