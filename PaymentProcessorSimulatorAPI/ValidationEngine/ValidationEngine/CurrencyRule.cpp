#include "IValidationRule.h"
#include "Payment.h"
#include "pch.h"

class CurrencyRule : public IValidationRule<Payment> {
public:
    void validate(const Payment& p, ValidationResult& result) const override {
        if (p.currency != "USD" && p.currency != "EUR")
            result.addError("Currency must be USD or EUR.");
    }
};