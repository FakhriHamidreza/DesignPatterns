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
                MyCompanyAbstractFactory factory = MyCompanyAbstractFactory.GetFactory(Architecture.EMBER);
                CPU cpu = factory.CreateCPU();
            #endregion

            Console.ReadKey();
        }
    }
}
