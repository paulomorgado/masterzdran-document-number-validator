using System;
using System.Runtime.Serialization;

namespace DocumentNumber.PaymentCardNumber.Common.Exceptions
{

  public sealed class UnsuportedPaymentCardIssuerException : Exception
  {
    public UnsuportedPaymentCardIssuerException()
    {
    }
    public UnsuportedPaymentCardIssuerException(string message)
    : base(message)
    {
    }

    public UnsuportedPaymentCardIssuerException(string message, Exception inner)
        : base(message, inner)
    {
    }

  }
}
