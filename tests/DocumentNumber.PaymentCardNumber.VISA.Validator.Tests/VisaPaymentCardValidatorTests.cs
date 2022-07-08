using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.PaymentCardNumber.Common.PaymentCard;
using DocumentNumber.ValidatorAbstractions;
using Shouldly;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.VISA.Validator.Tests
{
  public class VisaPaymentCardValidatorTests
  {
    [Fact(DisplayName = "PaymentCard Issuer should be Visa.")]
    public void PaymentCard_IssuerIdentity_Should_is_Valid()
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = paymentCardValidator.IssuerIdentity;

      // Assert
      result.ShouldBe(PaymentCardIssuer.Visa);
    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Null Input.")]
    [InlineData(null)]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Null(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Empty Input.")]
    [InlineData("")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Empty(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid For Spaces Input.")]
    [InlineData("  ")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Spaces(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has Length not equal to 13 or 16.")]
    [InlineData("012345678901")]
    [InlineData("01234567890123")]
    [InlineData("012345678901234")]
    [InlineData("01234567890123456")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Length_Not_Equal_to_13_or_16(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has non numeric characters.")]
    [InlineData("01234567890123A")]
    [InlineData("A012345678901234")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Non_Numeric_Character(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has invalid Issuer identification number (INN) number.")]
    [InlineData("01234567890123")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_invalid_INN_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 13 characters Length invalid number.")]
    [InlineData("4716535476368")]
    [InlineData("4862452496698")]
    [InlineData("4556717724205")]
    [InlineData("4556493334732")]
    [InlineData("4024007184085")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_13_characters_length_invalid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 16 characters Length invalid number.")]
    [InlineData("4024007141219915")]
    [InlineData("4532415389847476")]
    [InlineData("4929741100844950")]
    [InlineData("4716996961882757")]
    [InlineData("4716991766973455")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_16_characters_length_invalid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }
    [Theory(DisplayName = "Payment Card Number Should be Valid if Input has 13 characters Length valid number.")]
    [InlineData("4716535476367")]
    [InlineData("4862452496697")]
    [InlineData("4556717724204")]
    [InlineData("4556493334731")]
    [InlineData("4024007184084")]
    public void PaymentCardNumber_Is_Valid_If_Input_Has_13_characters_length_valid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }

    [Theory(DisplayName = "Payment Card Number Should be Valid if Input has 16 characters Length valid number.")]
    [InlineData("4024007141219914")]
    [InlineData("4532415389847475")]
    [InlineData("4929741100844959")]
    [InlineData("4716996961882756")]
    [InlineData("4716991766973454")]
    public void PaymentCardNumber_Is_Valid_If_Input_Has_16_characters_length_valid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }

  }
}
