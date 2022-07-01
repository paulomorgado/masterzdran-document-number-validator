namespace DocumentNumber.Portugal.BankAccountNumber.Generator
{
  public abstract class IBANGenerator : IIBANGenerator
  {
    public int CalculateCheckDigit(string uncheckedNumber)
    {
      var result = 0;

      for (var nibIndex = 0; nibIndex < 19; nibIndex++)
      {
        string number = $"{uncheckedNumber[nibIndex]}";
        var digit = int.Parse(number);

        result = (result + digit) * 10 % 97;
      }

      int checkdigit = 98 - ((result * 10) % 97);
      return checkdigit;
    }
    public abstract string GenerateDocumentNumber();
  }
}