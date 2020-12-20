using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Laba6
{
    class Program
    {
        delegate object Delegate(int i, double k);
      
        static object Plus(int i, double k)
        {
            object m = i + k;
            return m;
        }
        static object Minus(int i, double k)
        {
            object m = i - k;
            return m;
        }
        static object DelParam(int i,double k,Delegate Param)
        {
            object par = Param(i, k);
            return par;
        }
        static object DelParamFunc(int i, double k, Func<int, double, object> Param)
        {
            object par = Param(i, k);
            return par;
        }
        static void DelParamAction(int i, double k, Action<int, double> Param)
        {
            Param(i, k);
        }
        public class ForInspection : IComparable
        {
            public ForInspection() { }
            public ForInspection(int i) { }
            public ForInspection(string str) { }
            public int Plus(int x, int y) { return x + y; }
            public int Minus(int x, int y) { return x - y; }
            [NewAttribute("Описание для property1")]
            public string property1
            {
                get { return _property1; }
                set { _property1 = value; }
            }
            private string _property1;
            public int property2 { get; set; }
            [NewAttribute(Description = "Описание для property3")]
            public double property3 
            { get; private set; }
            public int field1; 
            public float field2;
            public int CompareTo(object obj)
            { return 0; }
        }
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class NewAttribute : Attribute
        {
            public NewAttribute() { }
            public NewAttribute(string DescriptionParam)
            { 
                Description = DescriptionParam; 
            }
            public string Description { get; set; }
           
        }
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            //Поиск атрибутов с заданным типом 
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 ЧАСТЬ");
            object A = DelParam(5, 4.5, Plus);
            Console.WriteLine("Сумма двух чисел равна " + A.ToString());
            A = DelParam(5, 4.5, Minus);
            Console.WriteLine("Разность двух чисел равна " + A.ToString());
            A = DelParam(5, 4.5, (x,y)=>x*y);
            Console.WriteLine("Использование лямбда-выражения " + A.ToString());
            A = DelParamFunc(5, 4.5, Plus);
            Console.WriteLine("Использование обобщенного делегата Func " + A.ToString());
            A = DelParamFunc(5, 4.5, (x, y) => x * y);
            Console.WriteLine("Использование обобщенного делегата Func и лямбда-выражения " + A.ToString());
            Console.WriteLine("*****************************************");
            Console.WriteLine("2 ЧАСТЬ");
            ForInspection obj = new ForInspection(); 
            Type t = obj.GetType();
            Console.WriteLine("\nИнформация о типе:"); 
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName); 
            Console.WriteLine("Пространство имен " + t.Namespace); 
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);
            Console.WriteLine("\nКонструкторы:"); 
            foreach (var x in t.GetConstructors()) 
            { 
                Console.WriteLine(x); 
            }
            Console.WriteLine("\nМетоды:"); 
            foreach (var x in t.GetMethods()) 
            { 
                Console.WriteLine(x); 
            }
            Console.WriteLine("\nСвойства:"); 
            foreach (var x in t.GetProperties())
            { 
                Console.WriteLine(x); 
            }
            Console.WriteLine("\nПоля данных (public):"); 
            foreach (var x in t.GetFields()) 
            { 
                Console.WriteLine(x); 
            }
            t = typeof(ForInspection);
            Console.WriteLine("\nСвойства, помеченные атрибутом:"); 
            foreach (var x in t.GetProperties()) 
            { 
                object attrObj; 
                if (GetPropertyAttribute (x, typeof(NewAttribute), out attrObj)) 
                {
                    NewAttribute attr = attrObj as NewAttribute; 
                    Console.WriteLine(x.Name + " - " + attr.Description); 
                } 
            }
        }
    }
}
   
        

