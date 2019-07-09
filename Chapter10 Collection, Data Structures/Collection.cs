using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Collection
    {
        class MyList : IEnumerable, IEnumerator
        {
            private int[] array;
            int position = -1;

            public MyList()
            {
                array = new int[3];
            }

            // IEnumerator 
            public object Current
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

            // IEnumerable
            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < array.Length; i++)
                    yield return (array[i]);
            }

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if (index >= array.Length)
                    {
                        Array.Resize<int>(ref array, index + 1);
                        Console.WriteLine("Array resized: {0}", array.Length);
                    }

                    array[index] = value;
                }
            }

            public int Length
            {
                get { return array.Length; }
            }

        }

        class MainApp
        {
            static void Main(string[] args)
            {
                MyList list = new MyList();
                for (var i = 0; i < 5; i++)
                    list[i] = i;

                foreach (int e in list)
                    Console.WriteLine(e);
            }
        }
    }
}   