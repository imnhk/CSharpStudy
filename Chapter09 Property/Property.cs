using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class BirthdayInfo
    {
        public string Name
        {
            get;
            set;
        }

        public DateTime BirthDay
        {
            get;
            set;
        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(BirthDay).Ticks).Year;
            }
        }
    }

    class NameCard
    {
        public int Age
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }

    class Property
    {
        static void Main(string[] args)
        {
            BirthdayInfo birthday = new BirthdayInfo()
            {
                Name = "myname",
                BirthDay = new DateTime(1892, 3, 23)
            };

            var anonBirthday = new { Name = "anon", Age = 99 };

            Console.WriteLine("Name: {0}", anonBirthday.Name);
            Console.WriteLine("Birthday: {0}", birthday.BirthDay);
            Console.WriteLine("Age: {0}", birthday.Age);

            // EX9_1
            NameCard myCard = new NameCard();
            myCard.Name = "Who";
            myCard.Age = 222;

            Console.WriteLine("Name: {0}", myCard.Name);
            Console.WriteLine("Age: {0}", myCard.Age);

            // EX9_2
            var otherCard = new { Name = "Somebody", Age = 1000 };
            Console.WriteLine("Name: {0}, Age: {1}", otherCard.Name, otherCard.Age);

            var complex = new { Real = 3, Imaginary = -12 };
            Console.WriteLine("Real: {0}, Imaginary: {1}", complex.Real, complex.Imaginary);


        }
    }
}
