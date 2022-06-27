namespace DocumentNumber.Portugal.CitizenCard.Generator
{
  public interface ICitizenCardNumberGenerator
  {
    int CalculateCheckDigit(string uncheckedNumber);
    string GenerateDocumentNumber();
  }
}