using System;
namespace DocumentNumber.Portugal.Niss.Validator
{
  public sealed class NissValidator : INissValidator
  {
    ///<inheritdoc/>
    public bool Validate(string value)
    {
      if (value is null)
      {
        return false;
      }
      if (value.Trim().Length != 11)
      {
        return false;
      }

      long valueAsInt = 0;

      if (!Int64.TryParse(value, out valueAsInt))
      {
        return false;
      }

      return ValidateNiss(valueAsInt);
    }

    private bool ValidateNiss(long valueAsInt)
    {
      var validationFactors = new int[] { 29, 23, 19, 17, 13, 11, 7, 5, 3, 2, 0 };

      long number = valueAsInt;
      long sum = 0;
      long remainer = 0;

      for (int index = 10; index >= 0; index--)
      {
        remainer = number % 10;
        sum += remainer * validationFactors[index];
        number = number / 10;
      }
      var remaining = sum % 10;
      var calculatedCheckDigit = 9 - remaining;
      return (valueAsInt % 10) == calculatedCheckDigit;
    }
  }
}
