namespace DocumentNumber.Portugal.BankAccountNumber.Generator
{
  public interface IIBANGenerator
  {
    string CalculateCheckDigit(string uncheckedNumber);
    string GenerateDocumentNumber();
  }
}