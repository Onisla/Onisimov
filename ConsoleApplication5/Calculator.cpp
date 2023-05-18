#include <iostream>
#include "Calculator.h"
#ifndef CALCULATOR_H
#define CALCULATOR_H



int Calculator::add(const Integer& a, const Integer& b) {
    return a.getValue() + b.getValue();
}

float Calculator::divide(const Float& a, const Float& b) {
    return a.getValue()/b.getValue();
}

String Calculator::concatenate(const String& a, const String& b){
    return a.getValue() + b.getValue();
}

#endif