using DocumentNumber.PaymentCardNumber.MaestroUK.Validator;
using Shouldly;
using System;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.MaestroUK.Generator.Tests
{
  public class MaestroUKGeneratorTests
  {
    [Theory(DisplayName = "For given unchecked document id, the given checkdigit must be match")]
    [InlineData("675938017688739", "2")]
    [InlineData("67677093191560", "8")]
    [InlineData("676774215486801793", "6")]
    public void Test1(string uncheckedDocumentNumber, string checkDigit)
    {
      // Arrange
      MaestroUKPaymentCardGenerator generator = new MaestroUKPaymentCardGenerator();

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }


    [Theory(DisplayName = "Generated Document Number must start with 'startsWith'.")]
    [InlineData("6759")]
    [InlineData("676770")]
    [InlineData("676774")]
    public void GeneratorDocumentNumbermustStartWith(string startsWith)
    {
      // Arrange
      MaestroUKPaymentCardGenerator generator = new MaestroUKPaymentCardGenerator();

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
      MaestroUKPaymentCardGenerator generator = new MaestroUKPaymentCardGenerator();
      MaestroUKPaymentCardValidator validator = new MaestroUKPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool documentNumberIsValid = validator.Validate(generatedDocumentNumber);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      documentNumberIsValid.ShouldBeTrue();
    }
  }
}
