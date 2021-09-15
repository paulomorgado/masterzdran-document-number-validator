using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentNumber.PaymentCardNumber.Maestro.Validator
{
  public sealed class MaestroPaymentCardValidator : IMaestroPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.Maestro;

    public bool IsSupported(string paymentCardNumber)
    {
      if (paymentCardNumber is null ||
          paymentCardNumber.Trim().Length == 0 ||
          !(paymentCardNumber.Trim().Length >= 12 &&
          paymentCardNumber.Trim().Length <= 19))
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
      return ValidateIIN4(value);
    }

    private bool ValidateIIN4(string value)
    {
      int iin4;
      if (!int.TryParse(value.Substring(0, 4), out iin4))
      {
        return false;
      }

      switch (iin4)
      {
        case 5018:
        case 5020:
        case 5038:
        case 5893:
        case 6304:
        case 6759:
        case 6761:
        case 6762:
        case 6763:
          return true;
        default:
          return false;
      }
    }
  }
}
