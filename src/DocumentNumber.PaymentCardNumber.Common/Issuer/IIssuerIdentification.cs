using DocumentNumber.PaymentCardNumber.Common.Enums;

namespace DocumentNumber.PaymentCardNumber.Common.Issuer
{
  public interface IIssuerIdentification
  {
    public PaymentCardIssuer SupportedPaymentCardIssuer(string paymentCardNumber);
  }
}