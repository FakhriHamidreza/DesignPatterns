using System;
using System.Collections.Generic;

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
        public void Speak() =>
            Print.ToConsol("Dog says: Bow-Wow.");

        public void Action() =>
            Print.ToConsol("Dogs prefer barking...\n");
    }

    public class Tiger : IAnimal
    {
        public void Speak() =>
            Print.ToConsol("Tiger says: Halum.");

        public void Action() =>
            Print.ToConsol("Tigers prefer hunting...\n");
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
        DecodedImage GetDecodeImage();
    }

    public class DecodedImage
    {
        private string image;

        public DecodedImage(string image) =>
            this.image = image;

        public override string ToString() =>
            image + ": is decoded";
    }

    public class GifReader : ImageReader
    {
        private DecodedImage decodedImage;

        public GifReader(string image) =>
            this.decodedImage = new DecodedImage(image);

        public DecodedImage GetDecodeImage() =>
            decodedImage;
    }

    public class JpegReader : ImageReader
    {
        private DecodedImage decodedImage;

        public JpegReader(string image) =>
            decodedImage = new DecodedImage(image);

        public DecodedImage GetDecodeImage() =>
            decodedImage;
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample3
    public abstract class Plan
    {
        protected double rate;
        public abstract void GetRate();

        public void CalculateBill(int units) =>
             Print.ToConsol((units * rate).ToString());
    }//end of Plan class.  

    class DomesticPlan : Plan
    {
        public override void GetRate() =>
            rate = 3.50;
    }//end of DomesticPlan class.  

    class CommercialPlan : Plan
    {
        public override void GetRate() =>
            rate = 7.50;
    }//end of CommercialPlan class.  

    class InstitutionalPlan : Plan
    {
        public override void GetRate() =>
            rate = 5.50;
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
        public abstract string GetRAM();
        public abstract string GetHDD();
        public abstract string GetCPU();

        public override string ToString() =>
            $"{this.GetType().Name} Config:: RAM = {this.GetRAM()}, HDD = {this.GetHDD()}, CPU = {this.GetCPU()}";
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

        public override string GetRAM() =>
            this.ram;

        public override string GetHDD() =>
            this.hdd;

        public override string GetCPU() =>
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

        public override string GetRAM() =>
            this.ram;

        public override string GetHDD() =>
            this.hdd;

        public override string GetCPU() =>
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
    // ---------------------------------------------------------------

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
    // ---------------------------------------------------------------

    #region Sample7

    abstract class Toy
    {
        public string Name { get; set; }

        public int Price { get; set; } = 0;

        public void Prepare() =>
            Print.ToConsol($"{this.Name} is prepared");

        public void Package() =>
            Print.ToConsol($"{this.Name} is packaged");

        public void Label() =>
            Print.ToConsol($"{this.Name} is priced at {this.Price}");
    }

    class Car : Toy
    {
        public Car()
        {
            this.Name = "Car";
            this.Price = 20;
        }
    }

    class NyCar : Car { }

    class CaCar : Car { }

    class Helicopter : Toy
    {
        public Helicopter()
        {
            this.Name = "Helicopter";
            this.Price = 100;
        }
    }

    class NyHelicopter : Helicopter { }

    class CaHelicopter : Helicopter { }

    class NySimpleFactory
    {
        public Toy CreateToy(string toyName)
        {
            Toy toy = null;

            if ("car" == toyName)
            {
                toy = new NyCar();
            }
            else if ("helicopter" == toyName)
            {
                toy = new NyHelicopter();
            }

            return toy;
        }
    }

    class CaSimpleFactory
    {
        public Toy CreateToy(string toyName)
        {
            Toy toy = null;

            if ("car" == toyName)
            {
                toy = new CaCar();
            }
            else if ("helicopter" == toyName)
            {
                toy = new CaHelicopter();
            }

            return toy;
        }
    }

    abstract class ToysFactory
    {
        public Toy ProduceToy(string toyName)
        {
            var toy = this.CreateToy(toyName);
            toy.Prepare();
            toy.Package();
            toy.Label();

            return toy;
        }

        abstract public Toy CreateToy(string toyName);
    }

    class NyToysFactory : ToysFactory
    {
        public NySimpleFactory SimpleFactory;

        public NyToysFactory(NySimpleFactory simpleFactory) =>
            this.SimpleFactory = simpleFactory;

        public override Toy CreateToy(string toyName)
        {
            var toy = this.SimpleFactory.CreateToy(toyName);
            toy.Prepare();
            toy.Package();
            toy.Label();

            return toy;
        }
    }

    class CaToysFactory : ToysFactory
    {
        public CaSimpleFactory SimpleFactory;

        public CaToysFactory(CaSimpleFactory simpleFactory) =>
            this.SimpleFactory = simpleFactory;

        public override Toy CreateToy(string toyName)
        {
            var toy = this.SimpleFactory.CreateToy(toyName);
            toy.Prepare();
            toy.Package();
            toy.Label();

            return toy;
        }
    }

    #endregion
    // ---------------------------------------------------------------

    #region Sample8
    public interface CreditCard
    {
        string GetCardType();

        int GetCreditLimit();

        int GetAnnualCharge();
    }

    public class MoneyBack : CreditCard
    {
        public string GetCardType() =>
            "MoneyBack";

        public int GetCreditLimit() =>
            15000;

        public int GetAnnualCharge() =>
            500;
    }

    public class Titanium : CreditCard
    {
        public string GetCardType() =>
            "Titanium Edge";

        public int GetCreditLimit() =>
            25000;

        public int GetAnnualCharge() =>
            1500;
    }

    public class Platinum : CreditCard
    {
        public string GetCardType() =>
            "Platinum Plus";

        public int GetCreditLimit() =>
            35000;

        public int GetAnnualCharge() =>
            2000;
    }

    public abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeProduct();

        public CreditCard CreateProduct() =>
            this.MakeProduct();
    }

    public class MoneyBackFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new MoneyBack();

            return product;
        }
    }

    public class PlatinumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Platinum();

            return product;
        }
    }

    public class TitaniumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();

            return product;
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample9
    public interface IAirConditioner
    {
        void Operate();
    }

    public class CoolingManager : IAirConditioner
    {
        private readonly double _temperature;

        public CoolingManager(double temperature) =>
            _temperature = temperature;

        public void Operate() =>
            Print.ToConsol($"Cooling the room to the required temperature of {_temperature} degrees");
    }

    public class WarmingManager : IAirConditioner
    {
        private readonly double _temperature;

        public WarmingManager(double temperature) =>
            _temperature = temperature;

        public void Operate() =>
            Print.ToConsol($"Warming the room to the required temperature of {_temperature} degrees.");
    }

    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }

    public class CoolingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) =>
            new CoolingManager(temperature);
    }

    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) =>
            new WarmingManager(temperature);
    }

    public enum Actions
    {
        Cooling,
        Warming
    }

    public class AirConditioner
    {
        private readonly Dictionary<Actions, AirConditionerFactory> _factories;

        public AirConditioner()
        {
            /*_factories = new Dictionary<Actions, AirConditionerFactory>
                            {
                                { Actions.Cooling, new CoolingFactory() },
                                { Actions.Warming, new WarmingFactory() }
                            };*/

            _factories = new Dictionary<Actions, AirConditionerFactory>();
            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
                _factories.Add(action, factory);
            }
        }

        public IAirConditioner ExecuteCreation(Actions action, double temperature) =>
            _factories[action].Create(temperature);
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}