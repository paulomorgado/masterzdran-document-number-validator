namespace DocumentNumber.Portugal.Nif.Generator.Tests
{
  using DocumentNumber.Portugal.Nif.Generator;
  using global::Portugal.Nif.Validator;
  using Shouldly;
  using Xunit;
  public class NifGeneratorTests
  {
    private readonly int NIF_LENGHT = 9;

    [Fact(DisplayName = "For given unchecked nif '19214394', the return checkdigit must be '8'")]
    public void Test1()
    {

      // Arrange
      long uncheckedNif = 19214394;
      int resultCheckDigit = 8;
      INifGenerator nifGenerator = new NifGenerator();

      // Act
      int checkDigit = nifGenerator.CalculateCheckDigit(uncheckedNif);

      // Assert
      checkDigit.ShouldBe(resultCheckDigit);

    }

    [Fact(DisplayName = "Random Generated Nif should have 9 characters long.")]
    public void GeneratedNifShouldHaveNineDigits()
    {
      // Arrange
      NifGenerator nifGenerator = new NifGenerator();

      // Act
      string generatedNif = nifGenerator.GenerateDocumentNumber();

      // Assert
      generatedNif.ShouldNotBeNullOrEmpty();
      generatedNif.Length.ShouldBe(NIF_LENGHT);

    }

    [Theory(DisplayName = "For Given input, Generated Nifs should be valid.")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(45)]
    [InlineData(70)]
    [InlineData(71)]
    [InlineData(72)]
    [InlineData(77)]
    [InlineData(78)]
    [InlineData(79)]
    [InlineData(90)]
    [InlineData(98)]
    [InlineData(99)]
    public void GivenNumberGeneratedNifShouldHaveNineDigits(int expected)
    {
      // Arrange
      INifGenerator nifGenerator = new NifGenerator();
      INifValidator nifValidator = new NifValidator();

      // Act
      string generatedNif = nifGenerator.GenerateDocumentNumber(expected);
      bool isValid = nifValidator.Validate(generatedNif);

      // Assert
      generatedNif.ShouldNotBeNullOrEmpty();
      isValid.ShouldBeTrue();
    }
  }
}