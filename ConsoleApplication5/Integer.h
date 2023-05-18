#pragma once
#include<limits>

class Integer {
private:
    int value;

public:
    Integer(int val);
    int getValue() const;
    void setValue(int val);
    static int getMaxValue();
    static int getMinValue();
};