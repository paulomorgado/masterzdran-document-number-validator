namespace DocumentNumber.Portugal.BankAccountNumber.Generator
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public sealed class PortugalIbanGenerator : IBANGenerator
  {
    public override string GenerateDocumentNumber()
    {
      Random random = new Random();
      int part1 = random.Next(1000000, 9999999); // 7
      int part2 = random.Next(1000000, 9999999); // 7
      int part3 = random.Next(10000, 99999); // 5
      string nib = $"{part1}{part2}{part3}";
      string checkDigit = this.CalculateCheckDigit(nib);
      return $"PT50{part1}{part2}{part3}{checkDigit}";
    }
  }
}
