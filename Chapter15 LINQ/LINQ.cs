using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class LINQ
    {
        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }

        class Product
        {
            public string Title { get; set; }
            public string Star { get; set; }
        }


        static void Main(string[] args)
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 67, 9, 4, 3, 7 };
            var result = from number in numbers
                         where number % 2 == 0
                         orderby number descending
                         select number;

            foreach (int number in result)
                Console.WriteLine(number);

            Profile[] arrProfile =
            {
                new Profile(){Name = "smklf", Height=233},
                new Profile(){Name = "ㄴㅇㅇㄴ", Height=2},
                new Profile(){Name = "vsvd", Height=12},
                new Profile(){Name = "sdvsvd", Height=444},
            };
            Product[] arrProduct =
            {
                new Product(){Title = "ASDASDASD", Star = "smklf"},
                new Product(){Title = "324324234", Star = "vsvd"},
                new Product(){Title = "890890890890", Star = "pweorpiop"},
                new Product(){Title = "@@@@@@", Star = "dankedanke"},
                new Product(){Title = "#############", Star = "smklf"},

            };
            var listProfile = from profile in arrProfile
                              join product in arrProduct on profile.Name equals product.Star
                              select new
                              {
                                  Name = profile.Name,
                                  Work = product.Title,
                                  Height = profile.Height
                              };

            foreach(var profile in listProfile)
            {
                Console.WriteLine($"Name: {profile.Name}, WORK: {profile.Work}, Height: {profile.Height}");
            }

            listProfile = from profile in arrProfile
                          join product in arrProduct on profile.Name equals product.Star into ps
                          from product in ps.DefaultIfEmpty(new Product() { Title = "없음" })
                          select new
                          {
                              Name = profile.Name,
                              Work = product.Title,
                              Height = profile.Height
                          };

            foreach (var profile in listProfile)
            {
                Console.WriteLine($"Name: {profile.Name}, WORK: {profile.Work}, Height: {profile.Height}");
            }

            var heightStat = from profile in arrProfile
                             group profile by profile.Height < 300 into g
                             select new
                             {
                                 Group = g.Key,
                                 Count = g.Count(),
                                 Max = g.Max(profile => profile.Height),
                                 Min = g.Min(profile => profile.Height),
                                 Average = g.Average(profile => profile.Height)
                             };

            foreach(var stat in heightStat)
            {
                Console.WriteLine($"{stat.Group} - Count: {stat.Count}, Max: {stat.Max}, Min: {stat.Min}, Average: {stat.Average}");
            }

        }
    }
}
