#pragma once
#include <string>
#include <vector>

struct ValidationResult {
    bool isValid = true;
    std::vector<std::string> errors;

    void addError(const std::string& err) {
        isValid = false;
        errors.push_back(err);
    }
};