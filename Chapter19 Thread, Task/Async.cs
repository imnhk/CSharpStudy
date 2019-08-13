using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpStudy
{
    class Async
    {
        static void Main(string[] args)
        {
            // AsyncTest();
            AsyncCopy(args);
        }

        static async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            using(var fromStream = new FileStream(FromPath, FileMode.Open))
            {
                long totalCopied = 0;

                using(var toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int nRead = 0;
                    while((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;
                    }
                }

                return totalCopied;
            }
        }


        static void AsyncCopy(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Usage: SCharpStucy <Source> <Destination>");
                return;
            }

            DoCopy(args[0], args[1]);

            Console.ReadLine();
        }

        static async void DoCopy(string FromPath, string ToPath)
        {
            long totalCopied = await CopyAsync(FromPath, ToPath);
            Console.WriteLine($"Copied Total {totalCopied} bytes.");
        }
        
        static void AsyncTest()
        {
            Caller();

            Console.ReadLine();
        }

        static void Caller()
        {
            Console.WriteLine("A");
            Console.WriteLine("B");

            MyMethodAsync(5);

            Console.WriteLine("E");
            Console.WriteLine("F");

        }

        async static private void MyMethodAsync(int count)
        {
            Console.WriteLine("C");
            Console.WriteLine("D");

            await Task.Run(async () =>
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{i}/{count} ...");
                    await Task.Delay(100);
                }
            });

            Console.WriteLine("G");
            Console.WriteLine("H");
        }
    }
}
