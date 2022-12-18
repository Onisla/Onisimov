#include <iostream>
#include <Windows.h>

using namespace std;

int main()
{	
	setlocale(LC_ALL, "");
	SetConsoleOutputCP(CP_UTF8);
	string currency;
	int number;
	cout << "≤нформац≥йна модель - грош≥" << endl;
	cout << "¬вед≥ть валюту: ";
	cin >> currency;
	cout << "¬вед≥ть число: ";
	cin >> number;
	return 0;
}