using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpStudy
{
    class Stream
    {
        static void Main(string[] args)
        {
            // BasicIO();
            //TypeIO();
            // TextIO();
            Serialization();
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

        static void TypeIO()
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));

            bw.Write(int.MaxValue);
            bw.Write("Good Morning");
            bw.Write(double.MaxValue);

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));

            Console.WriteLine($"File size: {br.BaseStream.Length} bytes");
            Console.WriteLine(br.ReadInt32().ToString());
            Console.WriteLine(br.ReadString().ToString());
            Console.WriteLine(br.ReadDouble().ToString());

            br.Close();
        }

        static void TextIO()
        {
            StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create));

            sw.WriteLine(int.MaxValue);
            sw.WriteLine("Good Morning");
            sw.WriteLine(double.MaxValue);

            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("a.txt", FileMode.Open));

            Console.WriteLine($"File size: {sr.BaseStream.Length} bytes");

            while (sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
        }

        static void Serialization()
        {
            FileStream ws = new FileStream("s.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            NameCard nc = new NameCard();
            nc.name = "kname";
            nc.phone = "000-000-0001";
            nc.age = 111;

            serializer.Serialize(ws, nc);

            ws.Close();

            FileStream rs = new FileStream("s.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            NameCard nc2;
            nc2 = (NameCard)deserializer.Deserialize(rs);

            rs.Close();

            Console.WriteLine("Name: {0}", nc2.name);
            Console.WriteLine("Phone: {0}", nc2.phone);
            Console.WriteLine("Age: {0}", nc2.age);
        }

    }

    [Serializable]
    class NameCard
    {
        public string name;
        public string phone;
        public int age;
    }
}
