using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class MyClass
    {
        public int myValue;

        public MyClass()
        {
            myValue = 0;
        }

        public MyClass(int val)
        {
            myValue = val;
        }

        public MyClass DeepCopy()
        {
            MyClass copy = new MyClass();
            copy.myValue = myValue;
            return copy;
        }
    }

    class MyDerivedClass : MyClass
    {
        public int newVal;
        public MyDerivedClass(int val) : base(val)
        {
            newVal = 100;
        }
    }

    public class MyClonableClass : ICloneable
    {
        public int myValue;
        public Object Clone()
        {
            MyClonableClass copy = new MyClonableClass();
            copy.myValue = myValue;
            return copy;
        }
    }

    class ArmorSuite
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Armored");
        }
    }

    class Ironman : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Repulsor Rays Armed");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Cannons Armed");
        }
    }

    public static class IntegerExtension
    {
        public static int Square(this int myint)
        {
            return myint * myint;
        }

        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (var i = 1; i < exponent; i++)
                result *= myInt;
            return result;
        }
    }

    class Class
    {
        static void Main(string[] arge)
        {
            ArmorSuite armorSuite = new ArmorSuite();
            ArmorSuite ironMan = new Ironman();
            ArmorSuite warMachine = new WarMachine();

            armorSuite.Initialize();
            ironMan.Initialize();
            warMachine.Initialize();

            Console.WriteLine(3.Square());
            Console.WriteLine(4.Power(4));

        }
    }
}


