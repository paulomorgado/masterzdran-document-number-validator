namespace DocumentNumber.Portugal.Niss.Generator
{
  using System;

  public class NissGenerator : INissGenerator
  {

    public int CalculateCheckDigit(long uncheckedNumber)
    {
      var validationFactors = new int[] { 29, 23, 19, 17, 13, 11, 7, 5, 3, 2, 0 };

      long number = uncheckedNumber * 10;
      long sum = 0;
      long remainer;

      for (int index = 10; index >= 0; index--)
      {
        remainer = number % 10;
        sum += remainer * validationFactors[index];
        number = number / 10;
      }
      var remaining = sum % 10;
      var calculatedCheckDigit = 9 - remaining;
      return (int)calculatedCheckDigit;
    }

    public string GenerateDocumentNumber()
    {
      long random_number_niss = GenerateRandomNissNumber();
      long checkDigit_niss = CalculateCheckDigit(random_number_niss);
      string generatedNiss = $"{random_number_niss}{checkDigit_niss}";
      return generatedNiss;
    }
    private static long GenerateRandomNissNumber()
    {
      Random random = new Random();

      int high = random.Next(10000, 19999);
      int low = random.Next(10000, 19999);

      long randomNiss = (high * 100000) + low;
      return randomNiss;
    }
  }

}