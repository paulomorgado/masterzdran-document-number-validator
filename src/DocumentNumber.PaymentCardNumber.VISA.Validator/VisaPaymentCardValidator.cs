using System;
using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;

namespace DocumentNumber.PaymentCardNumber.VISA.Validator
{
  public sealed class VisaPaymentCardValidator : IVisaPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.Visa;

    public bool IsSupported(string paymentCardNumber)
    {
      if (paymentCardNumber is null ||
          paymentCardNumber.Trim().Length == 0 ||
          paymentCardNumber.Trim().Length != 13 &&
          paymentCardNumber.Trim().Length != 16)
      {
        return false;
      }
      return paymentCardNumber[0] == '4';
    }

    public bool Validate(string value)
    {
      if (!IsSupported(value))
      {
        return false;
      }

      double paymentCard = 0;
      if (!Double.TryParse(value, out paymentCard))
      {
        return false;
      }

      return ValidationAlgorithms.LuhnAlgorithm(value);
    }


  }
}
