using DocumentNumber.PaymentCardNumber.Mastercard.Validator;
using Shouldly;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.Mastercard.Generator.Tests
{
  public class MastercardGeneratorTests
  {
    [Theory(DisplayName = "For given unchecked document id, the given checkdigit must be match")]
    [InlineData("523808306064192", "4")]
    [InlineData("557019824048640", "8")]
    [InlineData("222808589037358", "5")]
    public void Test1(string uncheckedDocumentNumber, string checkDigit)
    {
      // Arrange
      MastercardPaymentCardGenerator generator = new MastercardPaymentCardGenerator();

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }


    [Theory(DisplayName = "Generated Document Number must start with 'startsWith'.")]
    [InlineData("51")]
    [InlineData("52")]
    [InlineData("55")]
    [InlineData("2221")]
    [InlineData("2229")]
    [InlineData("2250")]
    [InlineData("2300")]
    [InlineData("2720")]
    public void GeneratorDocumentNumbermustStartWith(string startsWith)
    {
      // Arrange
      MastercardPaymentCardGenerator generator = new MastercardPaymentCardGenerator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber(startsWith);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      generatedDocumentNumber.ShouldStartWith($"{startsWith}");
    }

    [Fact(DisplayName = "Ramdom Generated Document Number is valid")]
    public void RandomGeneratedDocumentNumberIsValid()
    {
      // Arrange
      MastercardPaymentCardGenerator generator = new MastercardPaymentCardGenerator();
      MastercardPaymentCardValidator validator = new MastercardPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool documentNumberIsValid = validator.Validate(generatedDocumentNumber);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      documentNumberIsValid.ShouldBeTrue();
    }
  }
}
