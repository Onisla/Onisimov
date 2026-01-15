using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПІБ студента: Онісімов Владислав");
            Console.WriteLine("Група: ІПЗ-41");
            Console.WriteLine();

            Console.WriteLine("Оберіть варіант обчислення:");
            Console.WriteLine("1 – Площа паралелограма");
            Console.WriteLine("2 – Площа трикутника (формула Герона)");
            Console.WriteLine("3 – Площа бічної поверхні піраміди");
            Console.WriteLine("4 – Об’єм піраміди");
            Console.WriteLine("5 – Об’єм сфери");
            Console.Write("Ваш вибір: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть основу паралелограма: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введіть висоту: ");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Площа паралелограма = {a * h}");
                    break;

                case 2:
                    Console.Write("Введіть сторону a: ");
                    double a1 = double.Parse(Console.ReadLine());
                    Console.Write("Введіть сторону b: ");
                    double b1 = double.Parse(Console.ReadLine());
                    Console.Write("Введіть сторону c: ");
                    double c1 = double.Parse(Console.ReadLine());

                    double p = (a1 + b1 + c1) / 2;
                    double s = Math.Sqrt(p * (p - a1) * (p - b1) * (p - c1));
                    Console.WriteLine($"Площа трикутника = {s}");
                    break;

                case 3:
                    Console.Write("Введіть периметр основи піраміди: ");
                    double P = double.Parse(Console.ReadLine());
                    Console.Write("Введіть апофему: ");
                    double l = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Площа бічної поверхні піраміди = {0.5 * P * l}");
                    break;

                case 4:
                    Console.Write("Введіть площу основи піраміди: ");
                    double Sbase = double.Parse(Console.ReadLine());
                    Console.Write("Введіть висоту піраміди: ");
                    double H = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Об’єм піраміди = {Sbase * H / 3}");
                    break;

                case 5:
                    Console.Write("Введіть радіус сфери: ");
                    double r = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Об’єм сфери = {4.0 / 3.0 * Math.PI * Math.Pow(r, 3)}");
                    break;

                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}