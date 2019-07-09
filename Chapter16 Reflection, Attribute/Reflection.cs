using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharpStudy
{
    class Reflection
    {

        // GetType/MainApp.cs

        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("----- Interfaces -----");

            Type[] interfaces = type.GetInterfaces();
            foreach (Type i in interfaces)
                Console.WriteLine("Name: {0}", i.Name);

            Console.WriteLine();
        }

        static void PrintFields(Type type)
        {
            Console.WriteLine("----- Fields -----");

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                string accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine("Access: {0}, Type: {1}, Name: {2}", accessLevel, field.FieldType, field.Name);
            }

            Console.WriteLine();
        }

        static void PrintMethods(Type type)
        {
            Console.WriteLine("----- Methods -----");

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write("Type: {0}, Name: {1}, Parameter: ", method.ReturnType.Name, method.Name);

                ParameterInfo[] args = method.GetParameters();
                for(var i=0; i<args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintProperties(Type type)
        {
            Console.WriteLine("----- Properties -----");

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("Type: {0}, Name: {1}", property.PropertyType.Name, property.Name);
            }

            Console.WriteLine();
        }




        static void Main(string[] args)
        {
            /* GetType
             * 
            int a = 0;
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintFields(type);
            PrintProperties(type);
            PrintMethods(type);
            */

            /* Dynamic Instance
             * 
            Type type = Type.GetType("CSharpStudy.Profile");
            MethodInfo methodInfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "이름", "123-4535");
            methodInfo.Invoke(profile, null);

            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "새이름", null);
            phoneProperty.SetValue(profile, "99-9993", null);

            Console.WriteLine("{0}, {1}", nameProperty.GetValue(profile, null), phoneProperty.GetValue(profile, null));
            */

            // Emit
            AssemblyBuilder newAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("CalculatorAssembly"), AssemblyBuilderAccess.Run);

            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");
            TypeBuilder newType = newModule.DefineType("Sum1To100");

            MethodBuilder newMethod = newType.DefineMethod("Calculate", MethodAttributes.Public, typeof(int), new Type[0]);

            ILGenerator generator = newMethod.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1);
            for(int i=2; i<=100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }

            generator.Emit(OpCodes.Ret);
            newType.CreateType();

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1To100, null));

        }
    }

    // DynamicInstance/MainApp.cs

    class Profile
    {
        private string name;
        private string phone;

        public Profile()
        {
            name = "";
            phone = "";
        }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void Print()
        {
            Console.WriteLine($"{name}, {phone}");
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; } 
        }
    }
}
