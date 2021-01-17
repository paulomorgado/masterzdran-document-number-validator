namespace DocumentNumber.Portugal.CitizenCard.Validator
{
  public sealed class CitizenCardValidator :ICitizenCardValidator
  {
    private const int CharTranslationValue = 55;
    private const int CharTranslationNumberValue = 48;
    
    ///<inheritdoc/>
    public bool Validate(string value)
    {
      if (!IsInputValid(value))
      {
        return false;
      }

      int sum = 0;
      for (int index = 0; index < value.Trim().Length; index++)
      {
        int translatedValue = this.TranslatedValue(value[index]);
        if ((index % 2) == 0 )
        {
          translatedValue *= 2;
          if (translatedValue > 9)
          {
            translatedValue -= 9;
          }
        }
        sum += translatedValue;
      }

      return (sum % 10) == 0;
    }

    private int TranslatedValue(char c)
    {
      if (c >= '0' && c <= '9')
      {
        return c - CharTranslationNumberValue;
      }
      return c - CharTranslationValue;
    }


    private bool IsInputValid( string value)
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