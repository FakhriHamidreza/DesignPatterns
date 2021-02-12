namespace DesignPatterns.AbstractFactoryPattern
{
    #region Sample1
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

    public interface ComputerAbstractFactory
    {
        Computer createComputer();
    }

    public class PCFactory : ComputerAbstractFactory
    {

        private string ram;
        private string hdd;
        private string cpu;

        public PCFactory(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }

        public Computer createComputer() =>
            new PC(ram, hdd, cpu);
    }

    public class ServerFactory : ComputerAbstractFactory
    {

        private string ram;
        private string hdd;
        private string cpu;

        public ServerFactory(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }

        public Computer createComputer() =>
            new Server(ram, hdd, cpu);
    }

    public class ComputerFactory
    {
        public static Computer getComputer(ComputerAbstractFactory factory) =>
            factory.createComputer();
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample2
    public interface IShape
    {
        void draw();
    }

    public interface IRegularShape : IShape { }
    
    public interface IRoundedShape : IShape { }

    public class RoundedRectangle : IRoundedShape
    {
        public void draw() =>
             Print.ToConsol("Inside RoundedRectangle::draw() method.");
    }

    public class RoundedSquare : IRoundedShape
    {
        public void draw() =>
             Print.ToConsol("Inside RoundedSquare::draw() method.");
    }

    public class Rectangle : IRegularShape
    {
        public void draw() =>
             Print.ToConsol("Inside Rectangle::draw() method.");
    }

    public class Square : IRegularShape
    {
        public void draw() =>
             Print.ToConsol("Inside Square::draw() method.");
    }

    public abstract class ShapeAbstractFactory
    {
        public abstract IShape getShape();
    }

    public class RectangleFactory : ShapeAbstractFactory
    {
        public override IShape getShape() =>
            new Rectangle();
    }

    public class SquareFactory : ShapeAbstractFactory
    {
        public override IShape getShape() =>
            new Square();
    }

    public class RoundedRectangleFactory : ShapeAbstractFactory
    {
        public override IShape getShape() =>
            new RoundedRectangle();
    }

    public class RoundedSquareFactory : ShapeAbstractFactory
    {
        public override IShape getShape() =>
            new RoundedSquare();
    }

    public interface IShapeFactory
    {
        IShape getShape(ShapeAbstractFactory factory) =>
            factory.getShape();
    }

    public class RegularShapeFactory : IShapeFactory
    {
        public static IShape getShape(ShapeAbstractFactory factory) =>
            factory.getShape();
    }

    public class RoundedShapeFactory : IShapeFactory
    {
        public static IShape getShape(ShapeAbstractFactory factory) =>
            factory.getShape();
    }

    public class ShapeFactoryProducer<T>
    {
        public static IShapeFactory getFactory()
        {
            if (typeof(T) == typeof(IRegularShape))
            {
                return new RegularShapeFactory();
            }
            else if (typeof(T) == typeof(IRoundedShape))
            {
                return new RoundedShapeFactory();
            }

            throw new System.Exception("Invalid type!");
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample3
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore() =>
            new Wildebeest();

        public override Carnivore CreateCarnivore() =>
            new Lion();
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore() =>
            new Bison();

        public override Carnivore CreateCarnivore() =>
            new Wolf();
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore { }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Wildebeest : Herbivore { }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h) =>
            // Eat Wildebeest
            Print.ToConsol($"{this.GetType().Name} eats {h.GetType().Name}");
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bison : Herbivore { }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h) =>
            // Eat Bison
            Print.ToConsol($"{this.GetType().Name} eats {h.GetType().Name}");
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class AnimalWorld
    {
        private Herbivore _herbivore;

        private Carnivore _carnivore;

        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample4
    interface Bank
    {
        string GetBankName();
    }

    class HDFC : Bank
    {
        private string BANKNAME;

        public HDFC()
        {
            BANKNAME = "HDFC BANK";
        }

        public string GetBankName() =>
            BANKNAME;
    }

    class ICICI : Bank
    {
        private string BANKNAME;

        public ICICI()
        {
            BANKNAME = "ICICI BANK";
        }

        public string GetBankName() =>
            BANKNAME;
    }

    class SBI : Bank
    {
        private string BANKNAME;

        public SBI()
        {
            BANKNAME = "SBI BANK";
        }

        public string GetBankName() =>
            BANKNAME;
    }

    abstract class Loan
    {
        protected double rate;

        public abstract void GetInterestRate(double rate);

        public void CalculateLoanPayment(double loanamount, int years)
        {
            /* to calculate the monthly loan payment i.e. EMI   
                                
               rate=annual interest rate/12*100; 
               n=number of monthly installments;            
               1year=12 months. 
               so, n=years*12;*/

            double EMI;
            int n;

            n = years * 12;
            rate = rate / 1200;
            EMI = ((rate * System.Math.Pow((1 + rate), n)) / ((System.Math.Pow((1 + rate), n)) - 1)) * loanamount;

            Print.ToConsol($"your monthly EMI is {EMI} for the amount {loanamount} you have borrowed");
        }
    }// end of the Loan abstract class.  

    class HomeLoan : Loan
    {
        public override void GetInterestRate(double r)
        {
            rate = r;
        }
    }//End of the HomeLoan class.  

    class BussinessLoan : Loan
    {
        public override void GetInterestRate(double r)
        {
            rate = r;
        }

    }//End of the BusssinessLoan class.  

    class EducationLoan : Loan
    {
        public override void GetInterestRate(double r)
        {
            rate = r;
        }
    }//End of the EducationLoan class.

    abstract class AbstractFactory
    {
        public abstract Bank getBank(string bank);
        public abstract Loan getLoan(string loan);
    }

    class BankFactory : AbstractFactory
    {
        public override Bank getBank(string bank)
        {
            if (bank == null)
            {
                return null;
            }

            if (bank.Equals("HDFC", System.StringComparison.OrdinalIgnoreCase))
            {
                return new HDFC();
            }
            else if (bank.Equals("ICICI", System.StringComparison.OrdinalIgnoreCase))
            {
                return new ICICI();
            }
            else if (bank.Equals("SBI", System.StringComparison.OrdinalIgnoreCase))
            {
                return new SBI();
            }

            return null;
        }

        public override Loan getLoan(string loan) =>
            null;
    }//End of the BankFactory class.  

    class LoanFactory : AbstractFactory
    {
        public override Bank getBank(string bank) =>
            null;

        public override Loan getLoan(string loan)
        {
            if (loan == null)
            {
                return null;
            }

            if (loan.Equals("Home", System.StringComparison.OrdinalIgnoreCase))
            {
                return new HomeLoan();
            }
            else if (loan.Equals("Business", System.StringComparison.OrdinalIgnoreCase))
            {
                return new BussinessLoan();
            }
            else if (loan.Equals("Education", System.StringComparison.OrdinalIgnoreCase))
            {
                return new EducationLoan();
            }

            return null;
        }
    }

    class FactoryCreator
    {
        public static AbstractFactory getFactory(string choice)
        {
            if (choice.Equals("Bank", System.StringComparison.OrdinalIgnoreCase))
            {
                return new BankFactory();
            }
            else if (choice.Equals("Loan", System.StringComparison.OrdinalIgnoreCase))
            {
                return new LoanFactory();
            }
            return null;
        }
    }//End of the FactoryCreator.

    #endregion

    #region Sample5
    // class CPU
    abstract class CPU { }

    // class EmberCPU
    class EmberCPU : CPU { }

    // class EnginolaCPU
    class EnginolaCPU : CPU { }

    // class MMU
    abstract class MMU { }

    // class EmberMMU
    class EmberMMU : MMU { }

    // class EnginolaMMU
    class EnginolaMMU : MMU { }

    // class EmberFactory
    class EmberToolkit : MyCompanyAbstractFactory
    {
        public override CPU CreateCPU() =>
            new EmberCPU();

        public override MMU CreateMMU() =>
            new EmberMMU();
    }

    // class EnginolaFactory
    class EnginolaToolkit : MyCompanyAbstractFactory
    {
        public override CPU CreateCPU() =>
            new EnginolaCPU();

        public override MMU CreateMMU() =>
            new EnginolaMMU();
    }

    enum Architecture
    {
        ENGINOLA,
        EMBER
    }

    abstract class MyCompanyAbstractFactory
    {
        private static EmberToolkit EMBER_TOOLKIT = new EmberToolkit();
        private static EnginolaToolkit ENGINOLA_TOOLKIT = new EnginolaToolkit();

        // Returns a concrete factory object that is an instance of the
        // concrete factory class appropriate for the given architecture.
        public static MyCompanyAbstractFactory GetFactory(Architecture architecture)
        {
            MyCompanyAbstractFactory factory = null;

            switch (architecture)
            {
                case Architecture.ENGINOLA:
                    factory = ENGINOLA_TOOLKIT;
                    break;
                case Architecture.EMBER:
                    factory = EMBER_TOOLKIT;
                    break;
            }
            return factory;
        }

        public abstract CPU CreateCPU();

        public abstract MMU CreateMMU();
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}
