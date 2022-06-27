namespace DocumentNumber.Portugal.Niss.Generator
{
  public interface INissGenerator
  {
    int CalculateCheckDigit(long uncheckedNumber);
    string GenerateDocumentNumber();
  }
}