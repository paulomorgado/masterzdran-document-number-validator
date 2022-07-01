namespace DocumentNumber.Portugal.BankAccountNumber.Generator
{
  public interface IIBANGenerator
  {
    int CalculateCheckDigit(string uncheckedNumber);
    string GenerateDocumentNumber();
  }
}