using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.PaymentCardNumber.Common.PaymentCard;
using DocumentNumber.ValidatorAbstractions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.Mastercard.Validator.Tests
{
    public class MastercardPaymentCardValidatorTests
    {

    [Fact(DisplayName = "PaymentCard Issuer should be Mastercard.")]
    public void PaymentCard_IssuerIdentity_Should_is_Valid()
    {
      // Arrange
      IPaymentCardDocumentValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.IssuerIdentity;

      // Assert
      result.ShouldBe(PaymentCardIssuer.Mastercard);
    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid For Null Input.")]
    [InlineData(null)]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Null(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

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
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

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
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has Length not equal to 16.")]
    [InlineData("012345678901")]
    [InlineData("01234567890123")]
    [InlineData("012345678901234")]
    [InlineData("01234567890123456")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Length_Not_Equal_to_16(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has non numeric characters.")]
    [InlineData("01234567890123A")]
    [InlineData("A012345678901234")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Non_Numeric_Character(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

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
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 16 characters Length invalid number.")]
    [InlineData("575300832170")]
    [InlineData("5753008321701")]
    [InlineData("57530083217012")]
    [InlineData("575300832170123")]
    [InlineData("57530083217012345")]
    [InlineData("575300832170123456")]
    [InlineData("5753008321701234567")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_16_characters_length_invalid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }
    [Theory(DisplayName = "Payment Card Number Should be Valid if Input for 2221–2720,51-55 	codes.")]
    [InlineData("5123242845742989")]
    [InlineData("5259903165899354")]
    [InlineData("5302375314725359")]
    [InlineData("5451658388527325")]
    [InlineData("5597691365246838")]
    [InlineData("2720208642935385")]
    [InlineData("2221482481074630")]
    [InlineData("2222420000001113")]
    [InlineData("2223000048410010")]
    public void PaymentCardNumber_Is_Valid_If_Input_for_valid_codes(string value)
    {
      // Arrange
      IDocumentNumberValidator paymentCardValidator = new MastercardPaymentCardValidator();

      // Act
      var result = paymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }
  }
}
