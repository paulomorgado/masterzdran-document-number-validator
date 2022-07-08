using DocumentNumber.PaymentCardNumber.Maestro.Validator;
using Shouldly;
using System;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.Maestro.Generator.Tests
{
  public class MaestroGeneratorTests
  {
    [Theory(DisplayName = "For given unchecked document id, the given checkdigit must be match")]
    [InlineData("67707723365", "3")]
    [InlineData("677077753498944939", "3")]
    public void Test1(string uncheckedDocumentNumber, string checkDigit)
    {
      // Arrange
      MaestroPaymentCardGenerator generator = new MaestroPaymentCardGenerator();

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }


    [Theory(DisplayName = "Generated Document Number must start with 'startsWith'.")]
    [InlineData("5018")]
    [InlineData("5020")]
    [InlineData("5038")]
    [InlineData("5893")]
    [InlineData("6304")]
    [InlineData("6759")]
    [InlineData("6761")]
    [InlineData("6762")]
    [InlineData("6763")]
    public void GeneratedIbanMustStartWithNumber(string startsWith)
    {
      // Arrange
      MaestroPaymentCardGenerator generator = new MaestroPaymentCardGenerator();

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
      MaestroPaymentCardGenerator generator = new MaestroPaymentCardGenerator();
      MaestroPaymentCardValidator validator = new MaestroPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool documentNumberIsValid = validator.Validate(generatedDocumentNumber);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      documentNumberIsValid.ShouldBeTrue();
    }
  }
}
