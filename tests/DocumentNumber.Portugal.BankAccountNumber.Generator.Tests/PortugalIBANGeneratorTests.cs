using DocumentNumber.Portugal.BankAccountNumber.Validator;
using Shouldly;
using Xunit;
namespace DocumentNumber.Portugal.BankAccountNumber.Generator.Tests
{


  public class PortugalIBANGeneratorTests
  {
    [Fact(DisplayName = "For given NIB '0007427356884896649', the given checkdigit must be '98'")]
    public void Test1()
    {
      // Arrange
      IBANGenerator generator = new PortugalIbanGenerator();
      string unchecdNib = "0007427356884896649";
      int checkDigit = 98;

      // Act
      int calculatedCheckDigit = generator.CalculateCheckDigit(unchecdNib);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }

    [Fact(DisplayName = "Generated IBAN must start with 'PT50' and have 25 chars long.")]
    public void GeneratedIbanMustStartWithPT50()
    {
      // Arrange
      IBANGenerator generator = new PortugalIbanGenerator();

      // Act
      string generatedIban = generator.GenerateDocumentNumber();

      // Assert
      generatedIban.ShouldNotBeNullOrEmpty();
      generatedIban.ShouldStartWith("PT50");
      generatedIban.Length.ShouldBe(25);
    }

    [Fact(DisplayName = "Generated IBAN must be valid.")]
    public void GeneratedIbanMustBeValid()
    {
      // Arrange
      IBANGenerator generator = new PortugalIbanGenerator();
      BankAccountValidator validator = new BankAccountValidator();

      // Act
      string generatedIban = generator.GenerateDocumentNumber();
      bool validatedIban = validator.Validate(generatedIban);

      // Assert
      validatedIban.ShouldBeTrue();
    }
  }
}