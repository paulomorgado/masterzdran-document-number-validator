using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.PaymentCardNumber.Common.PaymentCard;
using DocumentNumber.ValidatorAbstractions;
using Shouldly;
using System;
using Xunit;
using Xunit.Sdk;

namespace DocumentNumber.PaymentCardNumber.MaestroUK.Validator.Tests
{
    public class MaestroUKPaymentCardValidatorTests
    {
    [Fact(DisplayName = "PaymentCard Issuer should be Maestro UK.")]
    public void PaymentCard_IssuerIdentity_Should_is_Valid()
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.IssuerIdentity;

      // Assert
      result.ShouldBe(PaymentCardIssuer.MaestroUK);
    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Null Input.")]
    [InlineData(null)]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Null(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Empty Input.")]
    [InlineData("")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Empty(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid For Spaces Input.")]
    [InlineData("  ")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Spaces(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has Length not equal to 12 to 19.")]
    [InlineData("012345678901")]
    [InlineData("01234567890123")]
    [InlineData("012345678901234")]
    [InlineData("01234567890123456")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Length_Not_Equal_to_12_to_19(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has non numeric characters.")]
    [InlineData("01234567890123A")]
    [InlineData("A012345678901234")]
    [InlineData(" A02345678901234")]
    [InlineData("A01234567890123 ")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Non_Numeric_Character(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

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
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 12 to 19 characters Length invalid number.")]
    [InlineData("675900832171")]
    [InlineData("6767708321701")]
    [InlineData("67677483217012")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_12_to_19_characters_length_invalid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }
    [Theory(DisplayName = "Payment Card Number Should be Valid if Input for 6759, 676770, 676774 codes.")]
    [InlineData("67594257773525")]
    [InlineData("6767705500276360216")]
    [InlineData("67677412043720067")]
    public void PaymentCardNumber_Is_Valid_If_Input_for_valid_codes(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MaestroUKPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }
  }
}
