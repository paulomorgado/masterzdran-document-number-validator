namespace Portugal.CitizenCard.Validator.Tests
{
  using Shouldly;
  using System;
  using DocumentNumber.Portugal.CitizenCard.Validator;
  using Xunit;
  public class CitizenCardValidatorTests
  {

    private const string CITIZEN_CARD_FOR_TESTING = "127384952ZW9";
    
    [Theory(DisplayName = "Citizen Card Should be Invalid For Null Or Empty Input.")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Citizen_Card_Should_be_Invalid_For_Null_Or_Empty_Input(string value)
    {
      // Arrange
      var validator = new CitizenCardValidator();
      
      // Act
      var result = validator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }
    
    [Theory(DisplayName = "Citizen Card Should be Invalid For Value with more than 12 characters.")]
    [InlineData("1234567890112")]
    [InlineData("12345612345612345")]
    [InlineData("  ")]
    public void Citizen_Card_Should_be_Invalid_For_Value_with_more_than_12_characters(string value)
    {
      // Arrange
      var validator = new CitizenCardValidator();
      
      // Act
      var result = validator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }
    
    [Theory(DisplayName = "Citizen Card Should be Invalid For Value with less than 12 characters.")]
    [InlineData("123")]
    [InlineData("123456")]
    [InlineData("  ")]
    public void Citizen_Card_Should_be_Invalid_For_Value_with_less_than_12_characters(string value)
    {
      // Arrange
      var validator = new CitizenCardValidator();
      
      // Act
      var result = validator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }
    
    [Theory(DisplayName = "Citizen Card Should be Invalid For invalid structure with  12 characters.")]
    [InlineData("123123123123")]
    [InlineData("123123123Z3Z")]
    [InlineData("1231231233ZZ")]
    [InlineData("12312312ZZ33")]
    public void Citizen_Card_Should_be_Invalid_For_invalid_structure_with_12_characters(string value)
    {
      // Arrange
      var validator = new CitizenCardValidator();
      
      // Act
      var result = validator.Validate(value);

      // Assert
      result.ShouldBeFalse();
    }
    
    [Theory(DisplayName = "Citizen Card Should be Valid for Valid number.")]
    [InlineData(CITIZEN_CARD_FOR_TESTING)]
    public void Citizen_Card_Should_be_Valid_For_Valid_Number(string value)
    {
      // Arrange
      var validator = new CitizenCardValidator();
      
      // Act
      var result = validator.Validate(value);

      // Assert
      result.ShouldBeTrue();
    }
  }
}