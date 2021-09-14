using DocumentNumber.PaymentCardNumber.Common.Enums;
using DocumentNumber.PaymentCardNumber.Common.Issuer;
using System;
using System.Collections.Generic;

namespace DocumentNumber.PaymentCardNumber.Common
{
  public sealed class IssuerIdentification : IIssuerIdentification
  {
    public IEnumerable<IIssuerIdentificationValidator> IssuerIdentificationValidators { get; private set; }

    public IssuerIdentification()
    {
      this.IssuerIdentificationValidators = new HashSet<IIssuerIdentificationValidator>();
    }

    public IssuerIdentification(IEnumerable<IIssuerIdentificationValidator> issuerIdentificationValidators)
    {
      this.IssuerIdentificationValidators = issuerIdentificationValidators;
    }

    public PaymentCardIssuer SupportedPaymentCardIssuer(string paymentCardNumber)
    {

      foreach (IIssuerIdentificationValidator issuer in IssuerIdentificationValidators)
      {
        if (issuer.IsSupported(paymentCardNumber))
        {
          return issuer.IssuerIdentity;
        }
      }

      return PaymentCardIssuer.Unsuportted;
    }


  }
}
