namespace DocumentNumber.Portugal.CitizenCard.Validator
{
  using DocumentNumber.Portugal.CitizenCard.Generator;
  using System;

  public sealed class CitizenCardValidator : ICitizenCardValidator
  {

    ///<inheritdoc/>
    public bool Validate(string value)
    {
      if (!IsInputValid(value))
      {
        return false;
      }
      int inputCheckDigit = Int32.Parse($"{value[value.Length - 1]}");
      string unckecedCitizenCard = value.Substring(0, value.Length - 1);
      CitizenCardNumberGenerator citizenCardGenerator = new CitizenCardNumberGenerator();
      int calculatedCheckDigit = citizenCardGenerator.CalculateCheckDigit(unckecedCitizenCard);
      return inputCheckDigit == calculatedCheckDigit;
    }


    private bool IsInputValid(string value)
    {
      if (value == null)
      {
        return false;
      }

      if (value.Trim().Length == 0)
      {
        return false;
      }

      if (value.Trim().Length != 12)
      {
        return false;
      }

      for (int index = 0; index < 9; index++)
      {
        if (value[index] < '0' || value[index] > '9')
          return false;
      }

      if (value[9] < 'A' || value[9] > 'Z')
      {
        return false;
      }
      if (value[10] < 'A' || value[9] > 'Z')
      {
        return false;
      }
      if (value[11] < '0' || value[11] > '9')
      {
        return false;
      }
      return true;
    }
  }
}