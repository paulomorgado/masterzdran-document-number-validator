using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentNumber.PaymentCardNumber.Mastercard.Validator
{
  public sealed class MastercardPaymentCardValidator : IMastercardPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.Mastercard;

    public bool IsSupported(string paymentCardNumber)
    {
      if (paymentCardNumber is null ||
          paymentCardNumber.Trim().Length == 0 ||
          paymentCardNumber.Trim().Length != 16)
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
      var iin2 = ValidateIIN2(value);

      if (iin2)
      {
        return true;
      }

      return ValidateIIN4(value);
    }

    private bool ValidateIIN4(string value)
    {
      int iin4;
      if (!int.TryParse(value.Substring(0, 4), out iin4))
      {
        return false;
      }
      return (iin4 > 2220 && iin4 < 2721);
    }

    private bool ValidateIIN2(string value)
    {
      int iin2;
      if (!int.TryParse(value.Substring(0, 2), out iin2))
      {
        return false;
      }

      return (iin2 > 50 && iin2 < 56);
    }
  }
}
