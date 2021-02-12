using System;
using System.Collections.Generic;
using DesignPatterns.PrototypePattern;

namespace DesignPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            /* Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3); */
            #endregion

            #region Sample2
            /* ShapeCache.LoadCache();

            var clonedShape = ShapeCache.GetShape("1");
            Console.WriteLine($"Shape : {clonedShape.Type}");		

            var clonedShape2 = ShapeCache.GetShape("2");
            Console.WriteLine($"Shape : {clonedShape2.Type}");		

            var clonedShape3 = ShapeCache.GetShape("3");
            Console.WriteLine($"Shape : {clonedShape3.Type}"); */
            #endregion

            #region Sample3
            /* ColorManager colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color; */
            #endregion

            #region Sample4
            Employees emps = new Employees();
            emps.loadData();

            //Use the clone method to get the Employee object
            Employees empsNew = (Employees)emps.Clone();
            Employees empsNew1 = (Employees)emps.Clone();
            List<string> list = empsNew.GetEmpList();
            list.Add("John");
            List<string> list1 = empsNew1.GetEmpList();
            list1.Remove("Pankaj");

            Console.WriteLine($"emps List: {GetEmployeeList(emps.GetEmpList())}");
            Console.WriteLine($"empsNew List: {GetEmployeeList(list)}");
            Console.WriteLine($"empsNew1 List: {GetEmployeeList(list1)}");
            #endregion

            Console.ReadKey();
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine($"      Name: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate.ToString("MM/dd/yy")}");
            Console.WriteLine($"      ID#: {p.IdInfo.IdNumber}");
        }

        public static string GetEmployeeList(List<string> list)
        {
            string result = "";
            foreach (var item in list)
            {
                result += !string.IsNullOrEmpty(result) ? $", {item}" : $"[{item}";
            }

            return result + "]";
        }
    }
}
