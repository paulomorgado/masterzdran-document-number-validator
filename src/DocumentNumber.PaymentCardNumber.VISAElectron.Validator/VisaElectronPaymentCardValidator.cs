using DocumentNumber.PaymentCardNumber.Common.Algorithms;
using DocumentNumber.PaymentCardNumber.Common.Enums;
using System;
namespace DocumentNumber.PaymentCardNumber.VISAElectron.Validator
{
  public class VisaElectronPaymentCardValidator : IVisaElectronPaymentCardValidator
  {
    public PaymentCardIssuer IssuerIdentity => PaymentCardIssuer.VisaElectron;

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
      if (value[0] != '4')
      {
        return false;
      }

      var iin4 = value.Substring(0, 4);

      switch (iin4)
      {
        case "4026":
        case "4508":
        case "4844":
        case "4913":
        case "4917":
          return true;
        default:
          break;
      }
      var iin6 = value.Substring(0, 6);

      return "417500".Equals(iin6);
    }

  }
}
