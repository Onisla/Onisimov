#include "Float.h"
#ifndef FLOAT_H
#define FLOAT_H

Float::Float(float val) : value(val) {}

float Float::getValue() const {
    return value;
}

void Float::setValue(float val) {
    value = val;
}

float Float::getMaxValue() {
    return std::numeric_limits<float>::max();
}

float Float::getMinValue() {
    return std::numeric_limits<float>::min();
}

#endif