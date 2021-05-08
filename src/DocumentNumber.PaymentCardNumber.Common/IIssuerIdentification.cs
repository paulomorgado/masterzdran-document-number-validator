namespace DocumentNumber.PaymentCardNumber.Common
{
  public interface IIssuerIdentification
  {
    public PaymentCardIssuerEnum SupportedPaymentCardIssuer(string paymentCardNumber);
  }
}