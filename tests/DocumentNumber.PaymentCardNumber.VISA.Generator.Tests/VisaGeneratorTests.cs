using DocumentNumber.PaymentCardNumber.VISA.Validator;
using Shouldly;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.VISA.Generator.Tests
{
  public class VisaGeneratorTests
  {
    [Theory(DisplayName = "For given unchecked document id, the given checkdigit must be match")]
    [InlineData("402400714479947", "4")]
    [InlineData("455618797022369", "4")]
    [InlineData("471677832683865", "1")]
    public void Test1(string uncheckedDocumentNumber, string checkDigit)
    {
      // Arrange
      VisaPaymentCardGenerator generator = new VisaPaymentCardGenerator();

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }


    [Theory(DisplayName = "Generated Document Number must start with 'startsWith'.")]
    [InlineData("4")]
    public void GeneratorDocumentNumbermustStartWith(string startsWith)
    {
      // Arrange
      VisaPaymentCardGenerator generator = new VisaPaymentCardGenerator();

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
      VisaPaymentCardGenerator generator = new VisaPaymentCardGenerator();
      VisaPaymentCardValidator validator = new VisaPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool documentNumberIsValid = validator.Validate(generatedDocumentNumber);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      documentNumberIsValid.ShouldBeTrue();
    }
  }
}
