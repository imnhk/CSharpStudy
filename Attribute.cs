using System;

namespace CSharpStudy
{
    /*
    class MyClass
    {
        [Obsolete("폐기된 method입니다. NewMethod를 사용하세요.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm old");
        }

        public void NewMethod()
        {
            Console.WriteLine("New");
        }

    }

    public static class Trace
    {
        public static void WriteLine(string message, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string member = "")
        {
            Console.WriteLine($"(Line: {line}) {member} : {message}");
        }
    }
    */

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "First release";
        }

        public string GetProgrammer()
        {
            return programmer;
        }
    }

    [History("Sean", version = 0.1, changes = "Created class stub")]
    [History("Bean", version = 0.2, changes = "Added Func()")]
    class NewClass
    {
        public void Func()
        {
            Console.WriteLine("Func()");
        }
    }


    class Attribute
    {
        static void Main(string[] args)
        {
            /*
            MyClass obj = new MyClass();

            obj.OldMethod();
            obj.NewMethod();

            Trace.WriteLine("멧시지");
            */
            Type type = typeof(NewClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            Console.WriteLine("MyClass change history");

            foreach(Attribute a in attributes)
            {
                History h = a as History;
                if(h != null)
                {
                    Console.WriteLine($"Ver: {h.version}, Programmer: {h.GetProgrammer()}, Changes: {h.changes}");
                }
            }
        }
    }
}
