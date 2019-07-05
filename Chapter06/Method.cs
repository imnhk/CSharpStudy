using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Method
    {
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        static int Plus(int a, int b)
        {
            return a + b;
        }

        static double Plus(double a  = 0, double b = 0)
        {
            return a + b;
        }

        static int Plus(params int[] args)
        {
            int sum = 0;
            foreach (int num in args)
                sum += num;
            return sum;
        }

        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"Name: {name}, Phone: {phone}");
        }

        // EX6_1
        static double Square(double arg)
        {
            return arg * arg;
        }

        static void Main(string[] args)
        {
            int a = 20;
            int b = 3;
            int c;
            int d;

            Divide(a, b, out c, out d);

            Console.WriteLine($"{a}, {b}, {c}, {d}");
            Console.WriteLine(Plus(a,b,c,d));
            PrintProfile(phone: "000-00002-22", name: "nameme");

            Console.WriteLine(Square(3));
            Console.WriteLine(Square(34.2));

        }
    }
}
