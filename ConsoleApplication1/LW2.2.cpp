#include <iostream>

using namespace std;

int main()
{
    (setlocale(LC_ALL, "UKR"));
    // Назва компютера
    string compName = "My PC";
    // Тип операційної системи
    string OS = "Windows 10 Pro";
    // ID девайсу
    string deviceID = "B1601F14 - 5B6F - 4868 - 80A4 - 1CAA5637A089";
    // Вік компютера
    unsigned short int copmAge = 5;
    // Працює?
    bool working = true;
    //назва материнської плати
    string motherboardName = "B350 TOMAHAWK (MS-7A34)";
    // Відеокарта
    string GPU = "NVIDIA GeForce GTX 1060 6GB";
    // Процесор
    string CPU = "AMD Ryzen 5 1600 Six-Core Processor";
    // ОЗУ
    string RAM = "16 GB";
    // SDD
    string SSD = "Samsung SSD 850 PRO 128GB";
    // HDD
    string HDD = "WD3001FAEX-32MJRA0";
    unsigned int totalMemoryInBytes =
        sizeof(compName) +
        sizeof(OS) +
        sizeof(deviceID) +
        sizeof(working) +
        sizeof(motherboardName) +
        sizeof(GPU) +
        sizeof(CPU) +
        sizeof(RAM) +
        sizeof(SSD) +
        sizeof(HDD);

    cout << "Назва компютера:\t\t\t" << compName << endl;
    cout << "Тип ОС:\t\t\t\t\t" << OS << endl;
    cout << "ID девайсу:\t\t\t\t" << deviceID << endl;
    cout << "Вiк компютера:\t\t\t\t" << copmAge << endl;
    cout << "Працює:\t\t\t\t\t" << ((working) ? "Так" : "Ні") << endl;
    cout << "Материнська плата:\t\t\t" << motherboardName << endl;
    cout << "Вiдеокарта:\t\t\t\t" << GPU << endl;
    cout << "Процесор:\t\t\t\t" << CPU << endl;
    cout << "ОЗУ:\t\t\t\t\t" << RAM << endl;
    cout << "SSD:\t\t\t\t\t" << SSD << endl;
    cout << "HDD:\t\t\t\t\t" << HDD << endl;
    cout << "Загальний об'єм використанної пам'ятi" << endl;
    cout << "(в байтах):\t\t\t\t" << totalMemoryInBytes << endl;
}