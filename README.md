
# ![DocumentNumber.Portugal](./images/cards.32.png "document-number-validator") document-number-validator
An set of libraries to validate the document number for a particular document and particular country.

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

## [Unreleased]
## [1.3.0] - 2021-10-23
### Added
- Portugal NIB Validator (netcoreapp3.1; netstandard2.1) - Contribuition of [@joaomatossilva](https://github.com/joaomatossilva)
- International Bank Account Number (IBAN) Validator (netcoreapp3.1; netstandard2.1) - Contribuition of [@joaomatossilva](https://github.com/joaomatossilva)

## [1.2.0] - 2021-09-17
### Added
- DocumentNumber.PaymentCardNumber.AmericanExpress.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.PaymentCardNumber.Maestro.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.PaymentCardNumber.MaestroUK.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.PaymentCardNumber.Mastercard.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.PaymentCardNumber.VISA.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.PaymentCardNumber.VISAElectron.Validator (netcoreapp3.1; netstandard2.1)

## [1.1.0] - 2021-01-17
### Added
- DocumentNumber.Portugal.CitizenCard.Validator (netcoreapp3.1; netstandard2.1)
- DocumentNumber.ValidatorAbstractions (netstandard2.1)
- DocumentNumber.Portugal.Nif.Validator (netstandard2.1)
- DocumentNumber.Portugal.Niss.Validator (netstandard2.1)
## [1.0.0] - 2020-12-30
### Added
- DocumentNumber.ValidatorAbstractions (netcoreapp3.1)
- DocumentNumber.Portugal.Nif.Validator (netcoreapp3.1)
- DocumentNumber.Portugal.Niss.Validator (netcoreapp3.1)




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
