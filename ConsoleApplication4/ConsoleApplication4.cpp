#include <iostream>

using namespace std;

int main()
{
    int x = 9;
    int y;

    cout << "Enter number y: ";
    cin >> y;
    if (x / y < 3)
    {
        cout << "Condition is fulfilled" << endl;
    }

    if (x / y >= 3)
    {
        cout << "Condition is not fulfilled" << endl;
    }
    return 0;
}