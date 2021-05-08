using DocumentNumber.PaymentCardNumber.Common;
using DocumentNumber.PaymentCardNumber.VISA.Validator;
using System;
using System.Collections.Generic;

namespace DocumentNumber.PaymentCardNumber.Validator
{
  public sealed class PaymentCardValidator : IPaymentCardValidator
  {
    private IEnumerable<IPaymentCardDocumentValidator> issuerIdentificationValidators;


    public PaymentCardValidator(IVisaPaymentCardValidator visaPaymentCardValidator)
    {
      var validators = new HashSet<IPaymentCardDocumentValidator>();

      validators.Add(visaPaymentCardValidator);

      issuerIdentificationValidators = validators;
    }

    public bool Validate(string value)
    {
      if (value is null || value.Trim().Length == 0)
      {
        return false;
      }

      foreach (var issuer in issuerIdentificationValidators)
      {
        if (issuer.IsSupported(value))
        {
          return issuer.Validate(value);
        }
      }
      throw new UnsuportedPaymentCardIssuer(value);
    }
  }
}
