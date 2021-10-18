
# ![DocumentNumber.Portugal](./images/cards.32.png "document-number-validator") document-number-validator
An set of libraries to validate the document number for a particular document and particular country.

# Projects
* DocumentNumber.ValidatorAbstractions
    * Interface to be implemented on each validator.
* DocumentNumber.Portugal.Nif.Validator
    * Interface for Dependency Injection.
    * Implementation of NIF validation algorithm.
* DocumentNumber.Portugal.Niss.Validator
    * Interface for Dependency Injection.
    * Implementation of NISS validation algorithm.
* DocumentNumber.Portugal.CitizenCard.Validator
    * Interface for Dependency Injection.
    * Implementation of Citizen Card validation algorithm.
* DocumentNumber.Portugal.BankAccountNumber.Validator
    * Interface for Dependency Injection.
    * Implementation of NIB validation algorithm.
    * Allows both Domestic (NIB) and International (IBAN) formats
* DocumentNumber.InternationalBankAccountNumber.Validator
    * Interface for Dependency Injection.
    * Implementation on the IBAN validation algorithm.
* DocumentNumber.PaymentCardNumber.Common
    * Interface to be implemented on each validator.
    * Exceptions and models.
* DocumentNumber.PaymentCardNumber.AmericanExpress.Validator
    * Interface for Dependency Injection.
    * Implementation of AmericanExpress validation algorithm.
* DocumentNumber.PaymentCardNumber.Maestro.Validator
    * Interface for Dependency Injection.
    * Implementation of Maestro validation algorithm.
* DocumentNumber.PaymentCardNumber.MaestroUK.Validator
    * Interface for Dependency Injection.
    * Implementation of MaestroUK validation algorithm.
* DocumentNumber.PaymentCardNumber.Mastercard.Validator
    * Interface for Dependency Injection.
    * Implementation of Mastercard validation algorithm.
* DocumentNumber.PaymentCardNumber.VISA.Validator
    * Interface for Dependency Injection.
    * Implementation of VISA validation algorithm.
* DocumentNumber.PaymentCardNumber.VISAElectron.Validator
    * Interface for Dependency Injection.
    * Implementation of VISAElectron validation algorithm.


# Validators
* Portugal NIF Number Validator
* Portugal NISS Number Validator
* Portugal Citizen Card Number Validator
* Portugal NIB Validator
* International Bank Account Number (IBAN) Validator
* AmericanExpress Validator
* Maestro Validator
* MaestroUK Validator
* Mastercard Validator
* VISA Validator
* VISAElectron Validator

# Usage
Check the unit tests projects, under /tests/ for usage, 
```csharp
    IDocumentNumberValidator visaPaymentCardValidator = new VisaPaymentCardValidator();
    var result = visaPaymentCardValidator.Validate(visacard);
```
```csharp
      IDocumentNumberValidator validator = new NifValidator();
      bool validationResult = validator.Validate(nif);
```

# Contributors
* [@masterzdran](https://github.com/masterzdran)
* [@joaomatossilva](https://github.com/joaomatossilva)
   * Portugal NIB Validator
   * International Bank Account Number (IBAN) Validator


# Attribution 
Icons made by [Pixel perfect](https://icon54.com/) from [www.flaticon.com](https://www.flaticon.com/)
