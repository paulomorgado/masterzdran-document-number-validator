using DocumentNumber.PaymentCardNumber.VISAElectron.Validator;
using Shouldly;
using Xunit;

namespace DocumentNumber.PaymentCardNumber.VISAElectron.Generator.Tests
{
  public class VisaElectronGeneratorTests
  {
    [Theory(DisplayName = "For given unchecked document id, the given checkdigit must be match")]
    [InlineData("450860249360971", "5")]
    [InlineData("417500798672904", "0")]
    [InlineData("402693220125232", "3")]
    [InlineData("491380875916346", "6")]
    [InlineData("484481201463224", "4")]
    [InlineData("491783323651174", "5")]
    public void Test1(string uncheckedDocumentNumber, string checkDigit)
    {
      // Arrange
      VisaElectronPaymentCardGenerator generator = new VisaElectronPaymentCardGenerator();

      // Act
      string calculatedCheckDigit = generator.CalculateCheckDigit(uncheckedDocumentNumber);

      // Assert
      calculatedCheckDigit.ShouldBe(checkDigit);

    }


    [Theory(DisplayName = "Generated Document Number must start with 'startsWith'.")]
    [InlineData("4026")]
    [InlineData("4508")]
    [InlineData("4844")]
    [InlineData("4913")]
    [InlineData("4917")]
    [InlineData("417500")]
    public void GeneratorDocumentNumbermustStartWith(string startsWith)
    {
      // Arrange
      VisaElectronPaymentCardGenerator generator = new VisaElectronPaymentCardGenerator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber(startsWith);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      generatedDocumentNumber.ShouldStartWith($"{startsWith}");
      generatedDocumentNumber.Length.ShouldBe(16);
    }

    [Fact(DisplayName = "Ramdom Generated Document Number is valid")]
    public void RandomGeneratedDocumentNumberIsValid()
    {
      // Arrange
      VisaElectronPaymentCardGenerator generator = new VisaElectronPaymentCardGenerator();
      VisaElectronPaymentCardValidator validator = new VisaElectronPaymentCardValidator();

      // Act
      string generatedDocumentNumber = generator.GenerateDocumentNumber();
      bool documentNumberIsValid = validator.Validate(generatedDocumentNumber);

      // Assert
      generatedDocumentNumber.ShouldNotBeNullOrEmpty();
      documentNumberIsValid.ShouldBeTrue();
    }
  }
}
