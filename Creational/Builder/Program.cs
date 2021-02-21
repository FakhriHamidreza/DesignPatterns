using System;
using DesignPatterns.BuilderPattern;

namespace DesignPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            /* MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.showItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("\nNon-Veg Meal");
            nonVegMeal.showItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetCost()); */
            #endregion

            #region Sample2
            /*Waiter waiter = new Waiter();
             PizzaBuilder hawaiianPizzabuilder = new HawaiianPizzaBuilder();
             waiter.SetPizzaBuilder(hawaiianPizzabuilder);
             waiter.ConstructPizza();

             PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
             waiter.SetPizzaBuilder(spicyPizzaBuilder);
             waiter.ConstructPizza();

             Pizza pizza = waiter.GetPizza(); */
            #endregion

            #region Sample3
            /* VehicleBuilder builder;

            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Construct and display vehicles
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            builder = new CarBuilder();
            shop.Construct(builder);

            builder.Vehicle.Show();
            builder = new MotorCycleBuilder();

            shop.Construct(builder);
            builder.Vehicle.Show(); */
            #endregion

            #region Sample4
            /* Console.WriteLine("***Builder Pattern Demo***");
            Director director = new Director();

            IBuilder b1 = new Car("Ford");
            IBuilder b2 = new MotorCycle("Honda");

            // Making Car
            director.Construct(b1);
            Product p1 = b1.GetVehicle();
            p1.Show();
                        
            //Making MotorCycle
            director.Construct(b2);
            Product p2 = b2.GetVehicle();
            p2.Show(); */
            #endregion

            #region Sample5
            /* Report report;
            ReportDirector reportDirector = new ReportDirector();
            // Construct and display Reports
            report = reportDirector.MakeReport(new PDFReport());
            report.DisplayReport();
            Console.WriteLine("-------------------");
            
            report = reportDirector.MakeReport(new ExcelReport());
            report.DisplayReport(); */
            #endregion

            #region Sample6
            var director = new DirectorNew();

            var builder = new CarNewBuilder();
            director.ConstructSportsCar(builder);
            var car = builder.GetProduct();
            car.GetResult();

            System.Console.WriteLine("*********************************");

            var manualBuilder = new CarManualBuilder();
            director.ConstructCityCar(manualBuilder);
            var manual = manualBuilder.GetProduct();
            manual.GetResult();
            System.Console.WriteLine("-------------------------------");
            manual.Print();
            #endregion

            #region Sample7
            /* var localGameBuilder = new LocalGameBuilder()
                                    .AiStrength(20)
                                    .BoardSize(10)
                                    .Level(2)
                                    .Present()
                                    .Build();

            var onlineGameBuilder = new OnlineGameBuilder()
                                    .ServerUrl("http://myGame.ca/")
                                    .BoardSize(20)
                                    .Level(5)
                                    .Present()
                                    .Build(); */
            #endregion

            #region Sample8
            /* var builder = new ProductStockReportBuilder(
               new System.Collections.Generic.List<ProductNew> {
                    new ProductNew { Name = "Monitor", Price = 200.50 },
                    new ProductNew { Name = "Mouse", Price = 20.41 },
                    new ProductNew { Name = "Keyboard", Price = 30.15}
                });
            var ProductStockReportDirector = new ProductStockReportDirector(builder);

            ProductStockReportDirector.BuildStockReport();
            var report = builder.GetReport();

            Console.WriteLine(report); */
            #endregion

            #region Sample9
            /* Window window = new WindowBuilder()
                .Width(800)
                .Height(400)
                .Build();
            
            Console.WriteLine();
            Console.WriteLine("-----------");
            
            Dialog dialog = new DialogBuilder()
                .Width(500)
                .Message("Hello")
                .Height(400)
                .Build(); */
            #endregion

            #region Sample10
            /* OrderBuilder builder = new OrderBuilder();

            OrderedItems orderedItems = builder.PreparePizza();

            orderedItems.ShowItems();

            Console.WriteLine("\n");
            Console.WriteLine("Total Cost : " + orderedItems.GetCost()); */
            #endregion

            Console.ReadKey();
        }
    }
}
