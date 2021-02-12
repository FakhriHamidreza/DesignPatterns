using System.Collections.Generic;

namespace DesignPatterns.PrototypePattern
{
    #region Sample1
    public class Person
    {
        public int Age;
        public System.DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy() =>
            (Person)this.MemberwiseClone();

        public Person DeepCopy()
        {
            Person clone = this.MemberwiseClone() as Person;
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = Name.Substring(0, Name.Length); //string.Copy(Name); // System.Span<char>

            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
    #endregion
    // --------------------------------------------

    #region Sample2
    public abstract class Shape : System.ICloneable
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public abstract void Draw();

        public object Clone()
        {
            object clone = null;

            try
            {
                clone = this.MemberwiseClone();
            }
            catch (System.Exception e)
            {
                Print.ToConsol(e.StackTrace);
            }

            return clone;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle() =>
            Type = "Rectangle";

        public override void Draw() =>
            Print.ToConsol("Inside Rectangle::draw() method.");
    }

    public class Square : Shape
    {
        public Square() =>
            Type = "Square";

        public override void Draw() =>
            Print.ToConsol("Inside Square::draw() method.");
    }

    public class Circle : Shape
    {
        public Circle() =>
            Type = "Circle";

        public override void Draw() =>
            Print.ToConsol("Inside Circle::draw() method.");
    }

    public class ShapeCache
    {
        private static Dictionary<string, Shape> shapeMap = new Dictionary<string, Shape>();

        public static Shape GetShape(string shapeId)
        {
            Shape cachedShape = shapeMap[shapeId]; //TryGetValue
            return (Shape)cachedShape.Clone();
        }

        // for each shape run database query and create shape
        // shapeMap.put(shapeKey, shape);
        // for example, we are adding three shapes

        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.Id = "1";
            shapeMap.Add(circle.Id, circle);

            Square square = new Square();
            square.Id = "2";
            shapeMap.Add(square.Id, square);

            Rectangle rectangle = new Rectangle();
            rectangle.Id = "3";
            shapeMap.Add(rectangle.Id, rectangle);
        }
    }
    #endregion
    // --------------------------------------------

    #region Sample3
    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype
    {
        private int _red;

        private int _green;

        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Print.ToConsol($"Cloning color RGB: {_red},{_green},{_blue}");

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
    #endregion

    #region Sample4
    public class Employees : System.ICloneable
    {
        private List<string> empList;

        public Employees() =>
            empList = new List<string>();

        public Employees(List<string> list) =>
            this.empList = list;

        public void loadData()
        {
            //read all employees from database and put into the list
            empList.Add("Pankaj");
            empList.Add("Raj");
            empList.Add("David");
            empList.Add("Lisa");
        }

        public List<string> GetEmpList() =>
            empList;

        public object Clone()
        {
            List<string> temp = new List<string>();

            foreach (string s in this.GetEmpList())
            {
                temp.Add(s);
            }

            return new Employees(temp);
        }
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}