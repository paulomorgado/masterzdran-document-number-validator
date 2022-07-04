namespace DocumentNumber.PaymentCardNumber.AmericanExpress.Generator.Tests
{
  using Xunit;
  using DocumentNumber.PaymentCardNumber.AmericanExpress.Generator;
  using Shouldly;
  using DocumentNumber.PaymentCardNumber.AmericanExpress.Validator;

  public class AmericanExpressTests
    {
    [Fact(DisplayName = "For given American Express '341994407069942', the given checkdigit must be '4'")]
    public void Test1()
    {
      // Arrange
      AmericanExpressPaymentCardGenerator generator = new AmericanExpressPaymentCardGenerator();
      
      string uncheckedDocumentNumber = "341994407069942";
      string checkDigit = "4";

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }

    [Theory(DisplayName = "Generated Document Number must start with '34' and have 15 chars long.")]
    [InlineData("34")]
    [InlineData("37")]
    public void GeneratedDocumentNumberMustStartAndHave(string startsWith)
    {
      // Arrange
      AmericanExpressPaymentCardGenerator generator = new AmericanExpressPaymentCardGenerator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber(startsWith);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      generatedDocumentNumber.ShouldStartWith($"{startsWith}");
      generatedDocumentNumber.Length.ShouldBe(15);
    }

    [Fact(DisplayName = "Generated Document Number must be valid.")]
    public void GeneratedDocumentNumberMustMustBeValid()
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