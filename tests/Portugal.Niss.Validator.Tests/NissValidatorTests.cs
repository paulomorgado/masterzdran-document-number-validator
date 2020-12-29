using Shouldly;
using System;
using Xunit;

namespace Portugal.Niss.Validator.Tests
{
  public class NissValidatorTests
  {
    [Theory(DisplayName = "Null NISS should return false.")]
    [InlineData(null)]
    public void Niss_ShouldBe_InValid_If_Value_Is_NULL(string niss)
    {
      //Arrange
      var validator = new NissValidator();

      // Act
      bool validationResult = validator.Validate(niss);

      // Assert
      validationResult.ShouldBeFalse();
    }

    [Theory(DisplayName = "Valid NISS with 11 digit characters long.")]
    [InlineData("12345678902")]
    public void Niss_ShouldBe_Valid_If_Have_Eleven_Characters_Digits_Length(string niss)
    {
      //Arrange
      var validator = new NissValidator();

      // Act
      bool validationResult = validator.Validate(niss);

      // Assert
      validationResult.ShouldBeTrue();
    }

    [Theory(DisplayName = "Valid NISS with alpha-numeric characters long should return false.")]
    [InlineData("1133726711Z")]
    [InlineData("V1337267113")]
    public void Niss_ShouldBe_InValid_If_Have_Alpha_Numeric(string niss)
    {
      //Arrange
      var validator = new NissValidator();

      // Act
      bool validationResult = validator.Validate(niss);

      // Assert
      validationResult.ShouldBeFalse();
    }

    [Theory(DisplayName = "Valid NISS with non 11 long should return false.")]
    [InlineData("123456789011")]
    [InlineData("12345")]
    public void Niss_ShouldBe_InValid_If_Have_Non_Eleven_Digit_Charater(string niss)
    {
      //Arrange
      var validator = new NissValidator();

      // Act
      bool validationResult = validator.Validate(niss);

      // Assert
      validationResult.ShouldBeFalse();
    }
  }
}
