using DocumentNumber.PaymentCardNumber.Common.Issuer;
using DocumentNumber.ValidatorAbstractions;
using System;

namespace DocumentNumber.PaymentCardNumber.Common.PaymentCard
{
  public interface IPaymentCardDocumentValidator : IIssuerIdentificationValidator, IPaymentCardValidator
  {
  }
}
