using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class DataTypes
    {
        class MainApp
        {
            enum EnumTest { ASDF, SDFDS, SDFSDF, EEFEF_ASDF }

            static void Main(string[] args)
            {
                Console.WriteLine("Enter width");
                string width = Console.ReadLine();

                Console.WriteLine("Enter height");
                string height = Console.ReadLine();

                Console.WriteLine("Area is : {0}", int.Parse(width) * int.Parse(height));


            }
            void Test()
            {
                byte a = 255;
                sbyte b = (sbyte)a;

                Console.WriteLine("a={0}, b={1}", a, b);

                int c = int.MaxValue;
                int d = c + 1;
                Console.WriteLine("c={0}, d={1}", c, d);

                float e = 3.14159265358979323846f; // 유효숫자 7자리
                double f = 3.14159265358979323846; // 15~16자리
                decimal g = 3.14159265358979323846m; // 29자리
                Console.WriteLine("e={0}, f={1}, g = {2}", e, f, g);

                object h = a;
                object i = g;
                Console.WriteLine("h={0}, i={1}", h, i);

                a.ToString();
                int.Parse("123");

                int? j = null;
                bool k = j.HasValue;

                var l = 2333.5343;
                var m = "sdfsfdsfsdf";
            }
        }
    }
}
