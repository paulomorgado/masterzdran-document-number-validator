using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using System;

namespace DocumentNumber.PaymentCardNumber.MaestroUK.Validator
{
  public sealed class MaestroUKPaymentCardValidator : IMaestroUKPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.MaestroUK;

    public bool IsSupported(string paymentCardNumber)
    {
      if (paymentCardNumber is null ||
          paymentCardNumber.Trim().Length == 0 ||
          !(paymentCardNumber.Trim().Length >= 12 &&
          paymentCardNumber.Trim().Length <=19) )
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
      var iin6 = ValidateIIN6(value);

      if (iin6)
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
      return (iin4 == 6759);
    }

    private bool ValidateIIN6(string value)
    {
      int iin6;
      if (!int.TryParse(value.Substring(0, 6), out iin6))
      {
        return false;
      }

      return (iin6 == 676770 || iin6 == 676774);
    }
  }
}
