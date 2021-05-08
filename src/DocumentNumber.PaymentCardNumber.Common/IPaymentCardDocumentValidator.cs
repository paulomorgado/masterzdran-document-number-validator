
using DocumentNumber.ValidatorAbstractions;
using System;

namespace DocumentNumber.PaymentCardNumber.Common
{
  public interface IPaymentCardDocumentValidator : IIssuerIdentificationValidator, IPaymentCardValidator
  {
  }
}
