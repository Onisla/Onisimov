#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

int main()
{
    setlocale(LC_CTYPE, "ukr");

    // ϲ�
    string studentFullName = "������� 1";
    // ������������� ��������/������� ������
    unsigned int studentID = 1;
    // ³� ��������
    unsigned short int studentAge = 20;
    // �������� �� �������� (����)
    unsigned short int currentStudyYear = 1;
    // �� ��������� �������?
    bool isStuding = true;
    // ������ �������� ��������
    string originAddress = "���, ������";
    // ������ ������ ��������
    string degree = "��������";
    // ��������� �����
    string group = degree + to_string(currentStudyYear);
    unsigned int totalMemoryInBytes = sizeof(studentFullName) +
        sizeof(group) +
        sizeof(studentID) +
        sizeof(studentAge) +
        sizeof(currentStudyYear) +
        sizeof(isStuding) +
        sizeof(originAddress) +
        sizeof(degree);

    cout << "�I� ��������:\t\t" << studentFullName << endl;
    cout << "�����:\t\t\t" << group << endl;
    cout << "����� ���i���� ������:\t" << studentID << endl;
    cout << "�i� ��������:\t\t" << studentAge << endl;
    cout << "�i� ��������:\t\t" << currentStudyYear << endl;
    cout << "�� �� ���������:\t" << ((isStuding) ? "���" : "ͳ") << endl;
    cout << "������:\t\t\t" << originAddress << endl;
    cout << "���i��i� ����i��:\t" << degree << endl;
    cout << "��������� ��'�� ������������ ���'��i (� ������):\t" << totalMemoryInBytes << endl;
    return 0;
}
