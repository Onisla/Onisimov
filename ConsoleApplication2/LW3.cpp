#include <iostream>
#include <Windows.h>

using namespace std;

int main()
{	
	setlocale(LC_ALL, "");
	SetConsoleOutputCP(CP_UTF8);
	string currency;
	int number;
	cout << "������������ ������ - �����" << endl;
	cout << "������ ������: ";
	cin >> currency;
	cout << "������ �����: ";
	cin >> number;
	return 0;
}