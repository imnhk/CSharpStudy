using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpStudy
{
    class Stream
    {
        static void Main(string[] args)
        {
            BasicIO();
        }
        static void BasicIO()
        {
            long someValue = 0x123456789ABCDEF0;
            Console.WriteLine("{0, -1} : 0x{1:X16}", "Original Data", someValue);

            FileStream outStream = new FileStream("a.dat", FileMode.Create);
            byte[] wBytes = BitConverter.GetBytes(someValue);

            Console.Write("{0, -13} : ", "Byte Array");

            foreach (byte b in wBytes)
                Console.Write("{0:X2} ", b);
            Console.WriteLine();

            outStream.Write(wBytes, 0, wBytes.Length);
            outStream.Close();
             
            FileStream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rBytes = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
                rBytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rBytes, 0);

            Console.WriteLine("{0,-13} : 0x{1:x16} ", "Read Data", readValue);
            inStream.Close();
        }
    }

}
