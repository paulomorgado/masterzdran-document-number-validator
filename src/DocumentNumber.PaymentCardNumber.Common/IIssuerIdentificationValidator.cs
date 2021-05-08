using DocumentNumber.ValidatorAbstractions;

namespace DocumentNumber.PaymentCardNumber.Common
{
  public interface IIssuerIdentificationValidator : IDocumentNumberValidator
  {
    PaymentCardIssuerEnum IssuerIdentity { get; }

    bool IsSupported(string paymentCardNumber);
  }
}