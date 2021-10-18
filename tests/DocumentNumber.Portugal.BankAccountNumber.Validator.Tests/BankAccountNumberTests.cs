using Shouldly;
using System;
using Xunit;

namespace DocumentNumber.Portugal.BankAccountNumber.Validator.Tests
{
  public class BankAccountNumberTests
  {
    [Theory(DisplayName = "BBAN Should be Invalid For Invalid lengths.")]
    [InlineData("1234432112345678901723")]
    [InlineData("12344321123456789017")]
    public void BBAN_Should_be_Invalid_for_Invalid_Lengths(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeFalse();
    }

    [Theory(DisplayName = "BBAN Should be Invalid For Invalid Chars.")]
    [InlineData("123443211234567890A72")]
    public void BBAN_Should_be_Invalid_for_Invalid_Chars(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeFalse();
    }

    [Theory(DisplayName = "BBAN Should be Invalid For Foreign IBAN.")]
    [InlineData("GB29 NWBK 6016 1331 9268 19")]
    [InlineData("ES91 2100 0418 4502 0005 1332")]
    [InlineData("FR14 2004 1010 0505 0001 3M02 606")]
    public void BBAN_Should_be_Invalid_for_Foreign_IBAN(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeFalse();
    }

    [Theory(DisplayName = "IBAN Should be InValid For Forign IBAN values with same structure as PT.")]
    [InlineData("GB88123443211234567890172")] // 21 digit NIB but invalid cause country code is GB. Stil, is a Valid IBAN.
    public void BBAN_Should_be_Invalid_for_Foreign_IBAN_Values_With_Same_Structure(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeFalse();
    }

    [Theory(DisplayName = "BBAN Should be Valid For Valid PT  BBAN values.")]
    [InlineData("123443211234567890172")]
    [InlineData("000100001234567890194")]
    [InlineData("1234 4321-1234 5678 9017_2")]
    public void BBAN_Should_be_Valid_for_Valid_PT_BBAN_Values(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeTrue();
    }

    [Theory(DisplayName = "BBAN Should be Valid For PT IBAN values.")]
    [InlineData("PT50123443211234567890172")]
    public void BBAN_Should_be_Valid_for_Valid_PT_IBAN_Values(string value)
    {
      //Arrange
      var subject = new BankAccountValidator();

      //Act
      var result = subject.Validate(value);

      //Assert
      result.ShouldBeTrue();
    }
  }
}
