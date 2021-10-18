using DocumentNumber.InternationalBankAccountNumber.Validator;
using System.Text.RegularExpressions;

namespace DocumentNumber.Portugal.BankAccountNumber.Validator
{
  public sealed class BankAccountValidator : InternationalBankAccountNumberValidator, IBankAccountValidatorcs
  {
    private static readonly Regex PortugueseBBANStructure = new Regex("^([0-9]{19})([0-9]{2})$");
    private const string CountryPrefix = "PT";

    protected override bool ValidateDomesticAccountNumber(string value)
    {
      var match = PortugueseBBANStructure.Match(value);
      if(!match.Success)
      {
        return false;
      }

      return ValidateIntegrity(value);
    }

    protected override bool ValidateNonIBAN(string value)
    {
      var possibleBBAN = AlphaCharacters.Replace(value, EvaluateAlphaReplace);
      return ValidateDomesticAccountNumber(possibleBBAN);
    }

    protected override bool ValidateCountry(string value)
    {
      return value.StartsWith(CountryPrefix);
    }
  }
}
