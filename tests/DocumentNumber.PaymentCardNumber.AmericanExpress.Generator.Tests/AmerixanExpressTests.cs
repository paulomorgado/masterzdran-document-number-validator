namespace DocumentNumber.PaymentCardNumber.AmericanExpress.Generator.Tests
{
  using Xunit;
  using DocumentNumber.PaymentCardNumber.AmericanExpress.Generator;
  using Shouldly;
  using DocumentNumber.PaymentCardNumber.AmericanExpress.Validator;

  public class AmerixanExpressTests
    {
    [Fact(DisplayName = "For given American Express '341994407069942', the given checkdigit must be '4'")]
    public void Test1()
    {
      // Arrange
      AmericanExpressPaymentCardGenerator generator = new AmericanExpressPaymentCardGenerator();
      
      string uncheckedDocumentNumber = "341994407069942";
      int checkDigit = 4;

      // Act
      int calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }

    [Theory(DisplayName = "Generated Document Number must start with '34' and have 15 chars long.")]
    [InlineData(34)]
    [InlineData(37)]
    public void GeneratedIbanMustStartWithNumber(int startsWith)
    {
      // Arrange
      AmericanExpressPaymentCardGenerator generator = new AmericanExpressPaymentCardGenerator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber(startsWith);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      generatedDocumentNumber.ShouldStartWith($"{startsWith}");
      generatedDocumentNumber.Length.ShouldBe(generator.DocumentNumberCardLenght);
    }

    [Fact(DisplayName = "Generated Document Number must be valid.")]
    public void GeneratedIbanMustBeValid()
    {
      // Arrange
      AmericanExpressPaymentCardGenerator generator = new AmericanExpressPaymentCardGenerator();
      AmericanExpressPaymentCardValidator validator = new AmericanExpressPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool validateDocumentNumber = validator.Validate(generatedDocumentNumber);

      // Assert
      validateDocumentNumber.ShouldBeTrue();
    }
  }
}