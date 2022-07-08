using DocumentNumber.PaymentCardNumber.Common.Issuer;

namespace DocumentNumber.PaymentCardNumber.Common.PaymentCard
{
  public interface IPaymentCardDocumentValidator : IIssuerIdentificationValidator, IPaymentCardValidator
  {
  }
}
