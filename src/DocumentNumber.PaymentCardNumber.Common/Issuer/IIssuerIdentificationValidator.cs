using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.ValidatorAbstractions;

namespace DocumentNumber.PaymentCardNumber.Common.Issuer
{
  public interface IIssuerIdentificationValidator : IDocumentNumberValidator
  {
    PaymentCardIssuer IssuerIdentity { get; }

    bool IsSupported(string paymentCardNumber);
  }
}