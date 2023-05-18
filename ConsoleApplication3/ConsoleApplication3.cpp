#include <iostream>
#include <string>

using namespace std;

// Математичний калькулятор

class IntegerData {
private:
    int value;

public:
    IntegerData(int val) : value(val) {}

    int getValue() {
        return value;
    }
};

class FloatData {
private:
    float value;

public:
    FloatData(float val) : value(val) {}

    float getValue() {
        return value;
    }
};

class StringData {
private:
    string value;

public:
    StringData(const string& val) : value(val) {}

    string getValue() {
        return value;
    }
};

int main() {

    setlocale(LC_ALL, "");

    int intValue;
    float floatValue;
    string stringValue;

    cout << "Введiть цiле число: ";
    cin >> intValue;

    cout << "Введiть дробове число: ";
    cin >> floatValue;

    cout << "Введiть рядок: ";
    cin.ignore();
    getline(cin, stringValue);

    IntegerData integerData(intValue);
    FloatData floatData(floatValue);
    StringData stringData(stringValue);

    cout << "Цiле число: " << integerData.getValue() << endl;
    cout << "Дробове число: " << floatData.getValue() << endl;
    cout << "Рядок: " << stringData.getValue() << endl;

    return 0;
}
