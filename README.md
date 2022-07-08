
# ![DocumentNumber.Portugal](https://raw.githubusercontent.com/masterzdran/document-number-validator/develop/images/cards.64.png "document-number-validator") document-number-validator
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

# Generators (for testing purposes)
* Portugal NIF Number Generator
* Portugal NISS Number Generator
* Portugal Citizen Card Number Generator
* AmericanExpress Generator
* Maestro Generator
* MaestroUK Generator
* Mastercard Generator
* VISA Generator
* VISAElectron Generator
* BankAccountNumber Generator
# Changelog
[Change log.](https://raw.githubusercontent.com/masterzdran/document-number-validator/develop/CHANGELOG.md)

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
