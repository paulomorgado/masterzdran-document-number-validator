using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using Shouldly;
using System;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.Common.Tests
{
  public class PaymentCardNumberCommonTests
  {
    [Theory(DisplayName = "LuhnAlgorithm Return True If Number Is Valid.")]
    [InlineData("4024007141219914")]
    [InlineData("4532415389847475")]
    [InlineData("4929741100844959")]
    [InlineData("4716996961882756")]
    [InlineData("4716991766973454")]
    [InlineData("4716535476367")]
    [InlineData("4862452496697")]
    [InlineData("4556717724204")]
    [InlineData("4556493334731")]
    [InlineData("4024007184084")]

    public void LuhnAlgorithm_Return_True_If_Number_Is_Valid(string value)
    {
      // Arrange


      // Act
      var result = ValidationAlgorithms.LuhnAlgorithm(value);

      // Assert
      result.ShouldBeTrue();

    }
  }
}
