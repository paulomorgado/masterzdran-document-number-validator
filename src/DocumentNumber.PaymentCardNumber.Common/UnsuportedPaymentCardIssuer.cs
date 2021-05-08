using System;
namespace DocumentNumber.PaymentCardNumber.Common
{
  public sealed class UnsuportedPaymentCardIssuer : Exception
  {
    public UnsuportedPaymentCardIssuer()
    {
    }
    public UnsuportedPaymentCardIssuer(string message)
    : base(message)
    {
    }

    public UnsuportedPaymentCardIssuer(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}
