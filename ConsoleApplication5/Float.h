#pragma once
#include<limits>

class Float {
private:
    float value;

public:
    Float(float val);
    float getValue() const;
    void setValue(float val);
    static float getMaxValue();
    static float getMinValue();
};

