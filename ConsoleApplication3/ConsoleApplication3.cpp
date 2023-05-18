#include <iostream>
#include <string>

using namespace std;

// ������������ �����������

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

    cout << "����i�� �i�� �����: ";
    cin >> intValue;

    cout << "����i�� ������� �����: ";
    cin >> floatValue;

    cout << "����i�� �����: ";
    cin.ignore();
    getline(cin, stringValue);

    IntegerData integerData(intValue);
    FloatData floatData(floatValue);
    StringData stringData(stringValue);

    cout << "�i�� �����: " << integerData.getValue() << endl;
    cout << "������� �����: " << floatData.getValue() << endl;
    cout << "�����: " << stringData.getValue() << endl;

    return 0;
}
