namespace DesignPatterns.FactoryMethodPattern
{
    #region Sample1
    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    public class Dog : IAnimal
    {
        public void Speak()
        {
            Print.ToConsol("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Print.ToConsol("Dogs prefer barking...\n");
        }
    }
    public class Tiger : IAnimal
    {
        public void Speak()
        {
            Print.ToConsol("Tiger says: Halum.");
        }
        public void Action()
        {
            Print.ToConsol("Tigers prefer hunting...\n");
        }
    }
    public abstract class IAnimalFactory
    {
        //Remember the GoF definition which says "....Factory method lets a class defer instantiation to subclasses."
        //Following method will create a Tiger or Dog.But at this point it does not know whether 
        //it will get a Dog or a Tiger.It will be decided by the subclasses i.e.DogFactory or TigerFactory.
        //So, the following method is acting like a factory (of creation).
        //protected abstract IAnimal CreateAnimal();
        public abstract IAnimal CreateAnimal();
    }
    public class DogFactory : IAnimalFactory
    {
        //protected override IAnimal CreateAnimal()
        public override IAnimal CreateAnimal()
        {
            //Creating a Dog
            return new Dog();
        }
    }
    public class TigerFactory : IAnimalFactory
    {
        //protected override IAnimal CreateAnimal()
        public override IAnimal CreateAnimal()
        {
            //Creating a Tiger
            return new Tiger();
        }
    }

    #endregion
    // ---------------------------------------------------------------

    #region Sample2
    public interface ImageReader
    {
        DecodedImage getDecodeImage();
    }

    public class DecodedImage
    {
        private string image;

        public DecodedImage(string image)
        {
            this.image = image;
        }

        public override string ToString()
        {
            return image + ": is decoded";
        }
    }

    public class GifReader : ImageReader
    {
        private DecodedImage decodedImage;

        public GifReader(string image)
        {
            this.decodedImage = new DecodedImage(image);
        }

        public DecodedImage getDecodeImage()
        {
            return decodedImage;
        }
    }

    public class JpegReader : ImageReader
    {
        private DecodedImage decodedImage;

        public JpegReader(string image)
        {
            decodedImage = new DecodedImage(image);
        }

        public DecodedImage getDecodeImage()
        {
            return decodedImage;
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample3
    public abstract class Plan
    {
        protected double rate;
        public abstract void getRate();

        public void calculateBill(int units) =>
             Print.ToConsol((units * rate).ToString());
    }//end of Plan class.  

    class DomesticPlan : Plan
    {
        public override void getRate()
        {
            rate = 3.50;
        }
    }//end of DomesticPlan class.  

    class CommercialPlan : Plan
    {
        public override void getRate()
        {
            rate = 7.50;
        }
    }//end of CommercialPlan class.  

    class InstitutionalPlan : Plan
    {
        public override void getRate()
        {
            rate = 5.50;
        }
    }//end of InstitutionalPlan class.  

    public class GetPlanFactory
    {
        //use getPlan method to get object of type Plan   
        public Plan getPlan(string planType)
        {
            if (planType is null)
            {
                return null;
            }
            else if (planType.Equals("DOMESTICPLAN", System.StringComparison.OrdinalIgnoreCase))
            {
                return new DomesticPlan();
            }
            else if (planType.Equals("COMMERCIALPLAN", System.StringComparison.OrdinalIgnoreCase))
            {
                return new CommercialPlan();
            }
            else if (planType.Equals("INSTITUTIONALPLAN", System.StringComparison.OrdinalIgnoreCase))
            {
                return new InstitutionalPlan();
            }

            return null;
        }
    }//end of GetPlanFactory class.  
    #endregion
    // ---------------------------------------------------------------

    #region Sample4
    public abstract class Computer
    {
        public abstract string getRAM();
        public abstract string getHDD();
        public abstract string getCPU();

        public override string ToString() =>
            $"{this.GetType().Name} Config:: RAM = {this.getRAM()}, HDD = {this.getHDD()}, CPU = {this.getCPU()}";
    }

    public class PC : Computer
    {
        private string ram;
        private string hdd;
        private string cpu;

        public PC(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }

        public override string getRAM() =>
            this.ram;

        public override string getHDD() =>
            this.hdd;

        public override string getCPU() =>
            this.cpu;
    }

    public class Server : Computer
    {
        private string ram;
        private string hdd;
        private string cpu;

        public Server(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }

        public override string getRAM() =>
            this.ram;

        public override string getHDD() =>
            this.hdd;

        public override string getCPU() =>
            this.cpu;
    }

    public class ComputerFactory
    {
        public static Computer getComputer(string type, string ram, string hdd, string cpu)
        {
            if ("PC".Equals(type, System.StringComparison.OrdinalIgnoreCase))
            {
                return new PC(ram, hdd, cpu);
            }
            else if ("Server".Equals(type, System.StringComparison.OrdinalIgnoreCase))
            {
                return new Server(ram, hdd, cpu);
            }

            return null;
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample5
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    public abstract class Product { }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class ConcreteProductA : Product { }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class ConcreteProductB : Product { }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() =>
            new ConcreteProductA();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() =>
            new ConcreteProductB();
    }
    #endregion

    #region Sample6
    public interface IShape
    {
        void draw();
    }

    public class Rectangle : IShape
    {
        public void draw() =>
           Print.ToConsol("Inside Rectangle::draw() method.");
    }

    public class Square : IShape
    {
        public void draw() =>
           Print.ToConsol("Inside Square::draw() method.");
    }

    public class Circle : IShape
    {
        public void draw() =>
           Print.ToConsol("Inside Circle::draw() method.");
    }

    public class ShapeFactory
    {
        //use getShape method to get object of type shape 
        public IShape getShape(string shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }

            if (shapeType.Equals("CIRCLE", System.StringComparison.OrdinalIgnoreCase))
            {
                return new Circle();
            }
            else if (shapeType.Equals("RECTANGLE", System.StringComparison.OrdinalIgnoreCase))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("SQUARE", System.StringComparison.OrdinalIgnoreCase))
            {
                return new Square();
            }

            return null;
        }
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}