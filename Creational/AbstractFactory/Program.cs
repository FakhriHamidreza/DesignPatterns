using System;
using DesignPatterns.AbstractFactoryPattern;

namespace DesignPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            /* var pc = ComputerFactory.getComputer(new PCFactory("2 GB", "500 GB", "2.4 GHz"));
            var server = ComputerFactory.getComputer(new ServerFactory("16 GB", "1 TB", "2.9 GHz"));
            
            Console.WriteLine(pc);
            Console.WriteLine(server); */
            #endregion

            #region Sample2
            //get shape factory
            /* var RectangleShapeFactory = ShapeFactoryProducer<IRegularShape>.getFactory();
            //get an object of Shape Rectangle
            var ShapeRectangle = RectangleShapeFactory.getShape(new RectangleFactory());
            //call draw method of Shape Rectangle
            ShapeRectangle.draw();
            //get an object of Shape Square 
            var ShapeSquare = RectangleShapeFactory.getShape(new SquareFactory());
            //call draw method of Shape Square
            ShapeSquare.draw();
            //get shape factory
            var SquareShapeFactory = ShapeFactoryProducer<IRoundedShape>.getFactory();
            //get an object of Shape Rectangle
            var ShapeRoundedRectangle = SquareShapeFactory.getShape(new RoundedRectangleFactory());
            //call draw method of Shape Rectangle
            ShapeRoundedRectangle.draw();
            //get an object of Shape Square 
            var ShapeRoundedSquare = SquareShapeFactory.getShape(new RoundedSquareFactory());
            //call draw method of Shape Square
            ShapeRoundedSquare.draw(); */
            #endregion

            #region Sample3
            /* // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain(); */
            #endregion

            #region Sample4
            /* Console.WriteLine("Enter the name of Bank from where you want to take loan amount: ");
            string bankName = Console.ReadLine();

            Console.WriteLine("Enter the type of loan e.g. home loan or business loan or education loan : ");

            string loanName = Console.ReadLine();
            AbstractFactory bankFactory = FactoryCreator.getFactory("Bank");
            Bank b = bankFactory.getBank(bankName);

            Console.WriteLine($"Enter the interest rate for {b.GetBankName()}: ");

            double rate = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the loan amount you want to take: ");

            double loanAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of years to pay your entire loan amount: ");
            int years = int.Parse(Console.ReadLine());

            Console.WriteLine($"you are taking the loan from {b.GetBankName()}");

            AbstractFactory loanFactory = FactoryCreator.getFactory("Loan");
            Loan l = loanFactory.getLoan(loanName);
            l.GetInterestRate(rate);
            l.CalculateLoanPayment(loanAmount, years); */
            #endregion

            #region Sample5
            /* MyCompanyAbstractFactory factory = MyCompanyAbstractFactory.GetFactory(Architecture.EMBER);
            CPU cpu = factory.CreateCPU(); */
            #endregion

            #region Sample7
            AnimalFactory animalFactory = null;
            string speakSound = null;
            // Create the Sea Factory object by passing the factory type as Sea
            animalFactory = AnimalFactory.CreateAnimalFactory("Sea");

            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();
            // Get Octopus Animal object by passing the animal type as Octopus
            var animal = animalFactory.GetAnimal("Octopus");

            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();

            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            Console.WriteLine();
            Console.WriteLine("--------------------------");

            // Create Land Factory object by passing the factory type as Land
            animalFactory = AnimalFactory.CreateAnimalFactory("Land");
            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();

            // Get Lion Animal object by passing the animal type as Lion
            animal = animalFactory.GetAnimal("Lion");
            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();
            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            Console.WriteLine();

            // Get Cat Animal object by passing the animal type as Cat
            animal = animalFactory.GetAnimal("Cat");
            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();
            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            #endregion

            Console.ReadKey();
        }
    }
}
