#pragma once

#include "Integer.h"
#include "Float.h"
#include "String.h"

class Calculator {
public:
    static int add(const Integer& a, const Integer& b);
    static float divide(const Float& a, const Float& b);
    static String concatenate(const String& a, const String& b);
};

