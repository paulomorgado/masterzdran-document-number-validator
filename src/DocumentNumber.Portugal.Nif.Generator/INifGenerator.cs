namespace DocumentNumber.Portugal.Nif.Generator
{
  public interface INifGenerator
  {
    int CalculateCheckDigit(long uncheckedNumber);
    string GenerateDocumentNumber();
    string GenerateDocumentNumber(int startWithNumber);
  }
}