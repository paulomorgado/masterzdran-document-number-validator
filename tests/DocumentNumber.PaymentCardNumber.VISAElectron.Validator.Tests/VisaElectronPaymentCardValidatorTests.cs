using DocumentNumber.ValidatorAbstractions;
using Shouldly;
using System;
using Xunit;
using Xunit.Sdk;

namespace DocumentNumber.PaymentCardNumber.VISAElectron.Validator.Tests
{
  public class VisaElectronPaymentCardValidatorTests
  {
    [Theory(DisplayName = "Payment Card Number Should be Invalid For Null Input.")]
    [InlineData(null)]
    public void PaymentCardNumber_Is_Invalid_If_Input_Is_Null(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

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
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

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
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }

    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has Length not equal 16.")]
    [InlineData("012345678901")]
    [InlineData("01234567890123")]
    [InlineData("012345678901234")]
    [InlineData("01234567890123456")]
    [InlineData("4539836982077")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_Length_Not_Equal_to_16(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

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
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }


    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has invalid Issuer identification number (INN) number.")]
    [InlineData("4539836982077")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_invalid_INN_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }



    [Theory(DisplayName = "Payment Card Number Should be Invalid if Input has 16 characters Length invalid number.")]
    [InlineData("4716026020591600")]
    [InlineData("4716468911892962")]
    [InlineData("4716553288864833")]
    public void PaymentCardNumber_Is_Invalid_If_Input_Has_16_characters_length_invalid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeFalse();

    }



    [Theory(DisplayName = "Payment Card Number Should be Valid if Input has 16 characters Length valid number.")]
    [InlineData("4508602493609715")]
    [InlineData("4175007986729040")]
    [InlineData("4026932201252323")]
    [InlineData("4913808759163466")]
    [InlineData("4844812014632244")]
    [InlineData("4917833236511745")]
    public void PaymentCardNumber_Is_Valid_If_Input_Has_16_characters_length_valid_number(string value)
    {
      // Arrange
      IDocumentNumberValidator visaPaymentCardValidator = new VisaElectronPaymentCardValidator();

      // Act
      var result = visaPaymentCardValidator.Validate(value);

      // Assert
      result.ShouldBeTrue();

    }

  }
}
