using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Module15.HomeWork
{
    class Program
    {
        static void Main()
        {
            ReflectionExamples.PrintConsoleMethods();
            Console.WriteLine("____________________________________________________");
            ReflectionExamples.PrintObjectProperties();
            Console.WriteLine("____________________________________________________");
            ReflectionExamples.SubstringExample();
            Console.WriteLine("____________________________________________________");
            ReflectionExamples.PrintListConstructors();

            Console.ReadLine();
        }
    }

    class MyClass
    {
        public int MyIntProperty { get; set; }
        public string MyStringProperty { get; set; }
    }

    class ReflectionExamples
    {
        // 1. С помощью рефлексии получить список методов класса Console и вывести на экран:
        public static void PrintConsoleMethods()
        {
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        // 2. Описать класс с несколькими свойствами, создать экземпляр и вывести свойства и их значения:
        public static void PrintObjectProperties()
        {
            MyClass myObject = new MyClass
            {
                MyIntProperty = 42,
                MyStringProperty = "Hi, Broflection!!"
            };

            Type myObjectType = myObject.GetType();
            PropertyInfo[] properties = myObjectType.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(myObject);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }

        // 3. С помощью рефлексии вызвать метод Substring класса String и извлечь из строки подстроку заданного размера:
        public static void SubstringExample()
        {
            string originalString = "Hi, Broflection!";
            Type stringType = typeof(string);

            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            Console.WriteLine(stringType);
            object[] arguments = { 5, 9 };
            object result = substringMethod.Invoke(originalString, arguments);

            Console.WriteLine(result);
        }

        // 4. Получить список конструкторов класса List<T>:
        public static void PrintListConstructors()
        {
            Type listType = typeof(List<>);
            Type genericArgument = typeof(int); 
            Type specificListType = listType.MakeGenericType(genericArgument);
            ConstructorInfo[] constructors = specificListType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
        }
    }
}
