/*
Factory Design Pattern/ SimpleFactory
 it’s not a design pattern, but a technique we use very often. It encapsulates the object instantiation process.

 This design pattern provides the client with a simple mechanism to create the object. So, we need to use the Factory Design Pattern in C# when

    The Object needs to be extended to the subclasses
    Classes don’t know what exact sub-classes it has to create
    The Product implementation going to change over time and the Client remains unchanged

Problems of Simple Factory Pattern in C#
    If we need to add any new product (i.e. new credit card) then we need to add a new if else condition in the GetCreditCard method of the CreditCardFactory class. This violates the open/closed design principle.
    We also have a tight coupling between the Factory (CreditCardFactory) class and product classes (MoneyBack, Titanium, and Platinum).
*/
using System;

namespace DesignPatterns.SimpleFactoryPattern
{
    #region Sample1
    abstract class Toy
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public void Prepare() =>
            Console.WriteLine($"{this.Name} is prepared");

        public void Package() =>
            Console.WriteLine($"{this.Name} is Packaged");

        public void Lable() =>
            Console.WriteLine($"{this.Name} is priced at {this.Price.ToString()}");
    }

    class Car : Toy
    {
        public Car()
        {
            this.Name = "Car";
            this.Price = 20;
        }
    }

    class Helicopter : Toy
    {
        public Helicopter()
        {
            this.Name = "Helicopter";
            this.Price = 100;
        }
    }

    class SimpleFactory
    {
        public Toy CreateToy(string toyName)
        {
            Toy toy = null;

            if ("car" == toyName)
            {
                toy = new Car();
            }
            else if ("helicopter" == toyName)
            {
                toy = new Helicopter();
            }

            return toy;
        }
    }

    abstract class ToysFactory
    {
        public SimpleFactory SimpleFactory;

        public ToysFactory(SimpleFactory simpleFactory) =>
            this.SimpleFactory = simpleFactory;

        public abstract void Prepare();

        public abstract void Package();

        public abstract void Lable();

        public Toy ProduceToy(string toyName)
        {
            var toy = this.SimpleFactory.CreateToy(toyName);

            toy.Prepare();
            toy.Package();
            toy.Lable();

            return toy;
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample2Before
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

    class Program1
    {
        static void Main(string[] args)
        {
            //Generally we will get the Card Type from UI.
            //Here we are hardcoded the card type
            string cardType = "MoneyBack";
            CreditCard cardDetails = null;
            //Based of the CreditCard Type we are creating the
            //appropriate type instance using if else condition

            if (cardType == "MoneyBack")
            {
                cardDetails = new MoneyBack();
            }
            else if (cardType == "Titanium")
            {
                cardDetails = new Titanium();
            }
            else if (cardType == "Platinum")
            {
                cardDetails = new Platinum();
            }

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }

            Console.ReadLine();
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample2After
    /*
    The above code implementation introduces the following problems

    - First, the tight coupling between the client class (Program) and Product Class (MoneyBack, Titanium, and Platinum).
    - Secondly, if we add a new Credit Card, then also we need to modify the Main method by adding an extra if-else condition which not only overheads in the development but also in the testing process
    */
    class CreditCardFactory
    {
        public static CreditCard GetCreditCard(string cardType)
        {
            CreditCard cardDetails = null;

            if (cardType == "MoneyBack")
            {
                cardDetails = new MoneyBack();
            }
            else if (cardType == "Titanium")
            {
                cardDetails = new Titanium();
            }
            else if (cardType == "Platinum")
            {
                cardDetails = new Platinum();
            }
            return cardDetails;
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            CreditCard cardDetails = CreditCardFactory.GetCreditCard("Platinum");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }
    }
    #endregion
}