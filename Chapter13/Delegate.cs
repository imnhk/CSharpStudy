using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Delegate
    {
        delegate int MyDelegate(int a, int b);

        class Calculator
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }
            public static int Minus(int a, int b)
            {
                return a - b;
            }
        }

        delegate int Compare<T>(T a, T b);

        delegate void Notify(string message);

        class Notifier
        {
            public Notify EventOccured;
        }

        class EventListener
        {
            private string name;
            public EventListener(string name)
            {
                this.name = name;
            }
            public void SomethingHappened(string message)
            {
                Console.WriteLine("{0}.SomethingHappened : {1}", name, message);
            }
        }

        class MainApp
        {
            static int AscendCompare<T>(T a, T b) where T:IComparable<T>
            {
                return a.CompareTo(b);
            }
            static int DescendCompare<T>(T a, T b) where T: IComparable<T>
            {
                return a.CompareTo(b) * -1;
            }

            static void BubbleSort<T>(T[] DataSet, Compare<T> comparer)
            {
                T temp;
                for(var i = 0; i<DataSet.Length-1; i++)
                {
                    for (var j = 0; j < DataSet.Length - 1 - i; j++)
                    {
                        if (comparer(DataSet[j], DataSet[j + 1]) > 0)
                        {
                            temp = DataSet[j + 1];
                            DataSet[j + 1] = DataSet[j];
                            DataSet[j] = temp;
                        }
                    }
                }
            }

            delegate void Eventhandler(string message);

            class MyNotifier
            {
                public event Eventhandler SomethingHappened;
                public void DoSomething(int number)
                {
                    int temp = number % 10;
                    if (temp != 0 && temp % 3 == 0)
                        SomethingHappened(String.Format("{0} : 짝", number));
                }
            }

            static public void MyHandler(string message)
            {
                Console.WriteLine(message);
            }

            // Ex13_1
            //delegate int MyDelegate(int a, int b);

            // Ex13_2
            delegate void MyDelegate(int a);
            class Market
            {
                public event MyDelegate CustomerEvent;
                public void BuySomething(int CustomerNo)
                {
                    if (CustomerNo == 30)
                        CustomerEvent(CustomerNo);
                }
            }

            static void Main(string[] args)
            {
                Market market = new Market();
                market.CustomerEvent += new MyDelegate(delegate(int customerNo) { Console.WriteLine("당첨! {0}", customerNo); }) ;

                for (int customerNo = 0; customerNo < 100; customerNo++)
                    market.BuySomething(customerNo);


                /*
                MyDelegate callback;
                callback = delegate (int a, int b) { return a + b; };
                Console.WriteLine(callback(3, 4));

                callback = delegate (int a, int b) { return a - b; };
                Console.WriteLine(callback(7, 5));

                MyNotifier myNotifier = new MyNotifier();
                myNotifier.SomethingHappened += new Eventhandler(MyHandler);

                for(var i=0; i<30; i++)
                {
                    myNotifier.DoSomething(i);
                }

                Notifier notifier = new Notifier();
                EventListener listener1 = new EventListener("Listener1");
                EventListener listener2 = new EventListener("Listener2");
                EventListener listener3 = new EventListener("Listener3");

                notifier.EventOccured += listener1.SomethingHappened;
                notifier.EventOccured += listener2.SomethingHappened;
                notifier.EventOccured += listener3.SomethingHappened;

                notifier.EventOccured("Got mail");
                Console.WriteLine();

                notifier.EventOccured -= listener1.SomethingHappened;
                notifier.EventOccured("Got note");
                Console.WriteLine();

                int[] array = { 3, 7, 4, 2, 10 };
                string[] str = { "asdf", "234", "33", "vcxvx" };

                BubbleSort<string>(str, AscendCompare<string>);
                foreach (string n in str)
                    Console.Write("{0} ", n);
                Console.WriteLine();

                BubbleSort<string>(str, DescendCompare<string>);
                foreach (string n in str)
                    Console.Write("{0} ", n);
                Console.WriteLine();

                Calculator calc = new Calculator();
                MyDelegate callback;

                callback = new MyDelegate(calc.Plus);
                Console.WriteLine(callback(3, 4));

                callback = new MyDelegate(Calculator.Minus);
                Console.WriteLine(callback(4, 6));
                */
            }
        }
    }
}
