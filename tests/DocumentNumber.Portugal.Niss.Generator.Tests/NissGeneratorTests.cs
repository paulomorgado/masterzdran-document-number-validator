namespace DocumentNumber.Portugal.Niss.Generator.Tests
{
  using DocumentNumber.Portugal.Niss.Validator;
  using Shouldly;
  using Xunit;
  public class NissGeneratorTests
  {
    private readonly int NISS_NUMBER_LENGHT = 11;

    [Fact(DisplayName = "For Given unchecekd NISS '1234567890', the result check digit should be '2'. ")]
    public void Test1()
    {
      // Arrange
      INissGenerator nissGenerator = new NissGenerator();
      long uncheckedNumber = 1234567890;
      int resultCheckDigit = 2;

      // Act
      int checkDigit = nissGenerator.CalculateCheckDigit(uncheckedNumber);

      // Assert
      checkDigit.ShouldBe(resultCheckDigit);
    }
    [Fact(DisplayName = "Generated NISS number should be valid.")]
    public void GeneratedNissNumbershouldHaveElevenCharactersLong()
    {
      // Arrange
      INissGenerator nissGenerator = new NissGenerator();
      INissValidator nissValidator = new NissValidator();

      // Act
      string generatedNiss = nissGenerator.GenerateDocumentNumber();
      bool validationResult = nissValidator.Validate(generatedNiss);

      // Assert
      generatedNiss.ShouldNotBeNullOrEmpty();
      generatedNiss.Length.ShouldBe(NISS_NUMBER_LENGHT);
      validationResult.ShouldBeTrue();
    }
  }
}