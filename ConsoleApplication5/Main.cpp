#include <iostream>
#include "Calculator.h"

int main() {
    Integer intData(5);
    Integer intData2(3);

    std::cout << "Sum: " << Calculator::add(intData, intData2) << std::endl;

    Float floatData(7.5);
    Float floatData2(2.5);

    std::cout << "Division: " << Calculator::divide(floatData, floatData2) << std::endl;

    String strData("Hello ");
    String strData2("World ");

    std::cout << "Concatenation: " << Calculator::concatenate(strData, strData2).getValue() << std::endl;

    return 0;
}