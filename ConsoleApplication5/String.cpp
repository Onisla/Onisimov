#include "String.h"
#ifndef STRING_H
#define STRING_H

String::String(const std::string& val) : value(val) {}

std::string String::getValue() const {
    return value;
}

void String::setValue(const std::string& val) {
    value = val;
}

std::string String::getDefaultString() {
    return "Default";
}

#endif