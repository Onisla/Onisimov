#include "Integer.h"
#ifndef INTEGER_H
#define INTEGER_H

Integer::Integer(int val) : value(val) {}

int Integer::getValue() const {
    return value;
}

void Integer::setValue(int val) {
    value = val;
}

int Integer::getMaxValue() {
    return INT_MAX;
}

int Integer::getMinValue() {
    return INT_MIN;
}

#endif