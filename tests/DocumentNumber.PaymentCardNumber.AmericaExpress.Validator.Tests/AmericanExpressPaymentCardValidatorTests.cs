using DocumentNumber.PaymentCardNumber.AmericanExpress.Validator;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.PaymentCardNumber.Common.PaymentCard;
using DocumentNumber.ValidatorAbstractions;
using Shouldly;
using System;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.AmericaExpress.Validator.Tests
{
    public sealed class AmericanExpressPaymentCardValidatorTests
    {

    [Fact(DisplayName = "PaymentCard Issuer should be AmericanExpress.")]
    public void PaymentCard_IssuerIdentity_Should_is_Valid()
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.IssuerIdentity;

      // Assert
      result.ShouldBe(PaymentCardIssuer.AmericanExpress);
    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Null/Empty/Spaces Input.")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Null(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has Length not equal to 15.")]
    [InlineData("012345678901")]
    [InlineData("01234567890123")]
    [InlineData("012345678901234")]
    [InlineData("01234567890123456")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Length_Not_Equal_to_15(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has non numeric characters.")]
    [InlineData("01234567890123A")]
    [InlineData("A01234567890123")]
    [InlineData("A0123456789012 ")]
    [InlineData(" A0123456789012")]
    [InlineData(" A012345678902 ")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Non_Numeric_Character(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has invalid Issuer identification number (INN) number.")]
    [InlineData("01234567890123")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_invalid_INN_number(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 15 characters Length invalid number.")]
    [InlineData("132435418436821")]
    [InlineData("161986526252846")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_15_characters_length_invalid_number(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

   
    [Theory(DisplayName = "Payment Card Number Should be Valid if Input has 15 characters Length valid number.")]
    [InlineData("374469473065790")]
    [InlineData("347805889981522")]
    [InlineData("347289298939126")]
    [InlineData("376465892854424")]
    [InlineData("377526593341638")]
    public void PaymentCardNumber_Is_Valid_If_Input_Has_15_characters_length_valid_number(string value)
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new AmericanExpressPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }
  }
}
