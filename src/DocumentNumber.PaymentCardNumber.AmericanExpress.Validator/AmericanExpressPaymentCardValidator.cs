using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentNumber.PaymentCardNumber.AmericanExpress.Validator
{
  public sealed class AmericanExpressPaymentCardValidator : IAmericanExpressPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.AmericanExpress;

    public bool IsSupported(string paymentCardNumber)
    {
      if (paymentCardNumber is null ||
          paymentCardNumber.Trim().Length == 0 ||
          paymentCardNumber.Trim().Length != 15)
      {
        return false;
      }
      return ValidateIIN(paymentCardNumber);
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
    private bool ValidateIIN(string value)
    {
      return ValidateIIN2(value);
    }

    private bool ValidateIIN2(string value)
    {
      int iin2;
      if (!int.TryParse(value.Substring(0, 2), out iin2))
      {
        return false;
      }

      switch (iin2)
      {
        case 34:
        case 37:
          return true;
        default:
          return false;
      }
    }
  }
}
