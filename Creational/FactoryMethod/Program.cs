using System;

namespace DesignPatterns.FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            /* Console.WriteLine("***Factory Pattern Demo***\n");
            // Creating a Tiger Factory 
            IAnimalFactory tigerFactory =new TigerFactory();
            // Creating a tiger using the Factory Method
            IAnimal aTiger = tigerFactory.CreateAnimal();
            aTiger.Speak();
            aTiger.Action();

            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            // Creating a dog using the Factory Method 
            IAnimal aDog = dogFactory.CreateAnimal();
            aDog.Speak();
            aDog.Action(); */
            #endregion

            #region Sample2
            /* DecodedImage decodedImage;
            ImageReader reader = null;
            //string image = args[0];
            string image = "myPic.gif";

            Console.WriteLine(image.IndexOf('.') + 1);
            System.Console.WriteLine(image.Length);

            string format = image.Substring(image.IndexOf('.') + 1, (image.Length - image.IndexOf('.') - 1));

            if (format.Equals("gif"))
            {
                reader = new GifReader(image);
            }
            else if (format.Equals("jpeg"))
            {
                reader = new JpegReader(image);
            }

            System.Diagnostics.Debug.Assert(!(reader is null), "I dont you what do you want!");
            decodedImage = reader.getDecodeImage();
            Console.WriteLine(decodedImage); */    
            #endregion

            #region Sample3
            /* GetPlanFactory planFactory = new GetPlanFactory();

            string planName = "DOMESTICPLAN";
            int units = 5;

            Plan p = planFactory.getPlan(planName);
            //call getRate() method and calculateBill()method of DomesticPaln.  

            Console.WriteLine("Bill amount for " + planName + " of  " + units + " units is: ");
            p.getRate();
            p.calculateBill(units); */
            #endregion

            #region Sample4
            /* var pc = ComputerFactory.getComputer("pc", "2 GB", "500 GB", "2.4 GHz");
            va server = ComputerFactory.getComputer("server", "16 GB", "1 TB", "2.9 GHz");
            Console.WriteLine(pc);
            Console.WriteLine(server); */
            #endregion

            #region Sample5
                        // An array of creators
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
