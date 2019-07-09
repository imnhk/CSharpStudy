using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Generic
    {
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
                target[i] = source[i];
        }

    }

    class MyList<T> : IEnumerator, IEnumerable
    {
        private T[] array;
        int position = -1;

        public MyList()
        {
            array = new T[3];
        }
        public T this[int index]
        {
            get { return array[index]; }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize(ref array, index + 1);
                    Console.WriteLine("Array resized");
                }
                array[index] = value;
            }
        }
        public int Length
        {
            get { return array.Length; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(var i=0; i<array.Length; i++)
            {
                yield return (array[i]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for(var i=0; i<array.Length; i++)
            {
                yield return (array[i]);
            }
        }

        public T Current
        {
            get { return array[position]; }
        }
        object IEnumerator.Current
        {
            get { return array[position]; }
        }
        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }
            position++;
            return (position < array.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose()
        {

        }
    }

    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] source) where T : U
        {
            source.CopyTo(Array, 0);
        }
    }

    class MainApp
    {

        static void Main(string[] args)
        {
            MyList<string> strList = new MyList<string>();
            strList[0] = "asdf";
            strList[1] = "34gd";
            strList[2] = "cdsdfs";
            strList[3] = "d3bcd";
            strList[4] = "as3";
            strList[5] = "898934";

            for (var i = 0; i < strList.Length; i++)
                Console.WriteLine(strList[i]);

            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue("한글");
            queue.Enqueue(3.14);

            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(10);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["asdf"] = "f아아ㅏㅇ";
            
        }
    }
}
