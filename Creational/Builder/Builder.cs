using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.BuilderPattern
{
    #region Sample1
    public interface Item
    {
        string Name();
        Packing Packing();
        float Price();
    }

    public interface Packing
    {
        string Pack();
    }

    public class Wrapper : Packing
    {
        public string Pack() =>
            "Wrapper";
    }

    public class Bottle : Packing
    {
        public string Pack() =>
            "Bottle";
    }

    public abstract class Burger : Item
    {
        public abstract string Name();

        public Packing Packing() =>
            new Wrapper();

        public abstract float Price();
    }

    public abstract class ColdDrink : Item
    {
        public abstract string Name();

        public Packing Packing() =>
            new Bottle();

        public abstract float Price();
    }

    public class VegBurger : Burger
    {
        public override float Price() =>
            25.0f;

        public override string Name() =>
            "Veg Burger";
    }

    public class ChickenBurger : Burger
    {
        public override float Price() =>
            50.5f;

        public override string Name() =>
            "Chicken Burger";
    }

    public class Coke : ColdDrink
    {
        public override float Price() =>
            30.0f;

        public override string Name() =>
            "Coke";
    }

    public class Pepsi : ColdDrink
    {
        public override float Price() =>
            35.0f;

        public override string Name() =>
            "Pepsi";
    }

    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item) =>
            items.Add(item);

        public float GetCost()
        {
            float cost = 0.0f;

            foreach (var item in items)
            {
                cost += item.Price();
            }

            return cost;
        }

        public void showItems()
        {
            foreach (var item in items)
            {
                Print.ToConsol($"Item : {item.Name()}");
                Print.ToConsol($", Packing : {item.Packing().Pack()}");
                Print.ToConsolLine($", Price : {item.Price()}");
            }
        }
    }
    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());

            return meal;
        }

        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());

            return meal;
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample2
    public class Pizza
    {
        public string Dough { get; set; }

        public string Sauce { get; set; }

        public string Topping { get; set; }
    }

    /* "Abstract Builder" */
    public abstract class PizzaBuilder
    {
        protected Pizza Pizza;

        public Pizza GetPizza()
        {
            Print.ToConsol($"Pizza:: Dough: {Pizza.Dough}, Sauce:{Pizza.Sauce}, Topping: {Pizza.Topping}");
            return Pizza;
        }

        public void CreateNewPizzaProduct() =>
            Pizza = new Pizza();

        public abstract void BuildDough();

        public abstract void BuildSauce();

        public abstract void BuildTopping();
    }

    /* "ConcreteBuilder" */
    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() =>
            Pizza.Dough = "cross";

        public override void BuildSauce() =>
            Pizza.Sauce = "mild";

        public override void BuildTopping() =>
            Pizza.Topping = "ham + pineapple";
    }

    /* "ConcreteBuilder" */
    class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() =>
            Pizza.Dough = "pan baked";

        public override void BuildSauce() =>
            Pizza.Sauce = "hot";

        public override void BuildTopping() =>
            Pizza.Topping = "pepperoni + salami";
    }

    /* "Director" */
    public class Waiter
    {
        private PizzaBuilder PizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder pb) =>
            PizzaBuilder = pb;

        public Pizza GetPizza() =>
            PizzaBuilder.GetPizza();

        public void ConstructPizza()
        {
            PizzaBuilder.CreateNewPizzaProduct();
            PizzaBuilder.BuildDough();
            PizzaBuilder.BuildSauce();
            PizzaBuilder.BuildTopping();
        }
    }

    #endregion
    // --------------------------------------------------

    #region Sample3
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        // Abstract build methods
        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder() =>
            vehicle = new Vehicle("MotorCycle");

        public override void BuildFrame() =>
            vehicle["frame"] = "MotorCycle Frame";

        public override void BuildEngine() =>
            vehicle["engine"] = "500 cc";

        public override void BuildWheels() =>
            vehicle["wheels"] = "2";

        public override void BuildDoors() =>
            vehicle["doors"] = "0";
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder() =>
            vehicle = new Vehicle("Car");

        public override void BuildFrame() =>
            vehicle["frame"] = "Car Frame";

        public override void BuildEngine() =>
            vehicle["engine"] = "2500 cc";

        public override void BuildWheels() =>
            vehicle["wheels"] = "4";

        public override void BuildDoors() =>
            vehicle["doors"] = "4";
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder() =>
            vehicle = new Vehicle("Scooter");

        public override void BuildFrame() =>
            vehicle["frame"] = "Scooter Frame";

        public override void BuildEngine() =>
            vehicle["engine"] = "50 cc";

        public override void BuildWheels() =>
            vehicle["wheels"] = "2";

        public override void BuildDoors() =>
            vehicle["doors"] = "0";
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;

        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        // Constructor
        public Vehicle(string vehicleType) =>
            this._vehicleType = vehicleType;

        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Print.ToConsol("\n---------------------------");
            Print.ToConsol($"Vehicle Type: {_vehicleType}");
            Print.ToConsol($" Frame : {_parts["frame"]}");
            Print.ToConsol($" Engine : {_parts["engine"]}");
            Print.ToConsol($" #Wheels: {_parts["wheels"]}");
            Print.ToConsol($" #Doors : {_parts["doors"]}");
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample4
    // Builders common interface
    public interface IBuilder
    {
        void StartUpOperations();

        void BuildBody();

        void InsertWheels();

        void AddHeadlights();

        void EndOperations();

        Product GetVehicle();
    }

    // "Product" 
    public class Product
    {
        // We can use any data structure that you prefer e.g.List<string> etc.
        private LinkedList<string> parts;

        public Product() =>
            parts = new LinkedList<string>();

        public void Add(string part) =>
            //Adding parts
            parts.AddLast(part);

        public void Show()
        {
            Print.ToConsolLine("\nProduct completed as below :");

            foreach (string part in parts)
                Print.ToConsolLine(part);
        }
    }

    // ConcreteBuilder: Car 
    public class Car : IBuilder
    {
        private string brandName;

        private Product product;

        public Car(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }

        public void StartUpOperations() =>
            //Starting with brandname
            product.Add($"Car Model name {this.brandName}");

        public void BuildBody() =>
            product.Add("This is a body of a Car");

        public void InsertWheels() =>
            product.Add("4 wheels are added");

        public void AddHeadlights() =>
            product.Add("2 Headlights are added");

        public void EndOperations()
        { /*Nothing in this case*/ }

        public Product GetVehicle() =>
            product;
    }

    // ConcreteBuilder:Motorcycle 
    public class MotorCycle : IBuilder
    {
        private string brandName;

        private Product product;

        public MotorCycle(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }

        public void StartUpOperations()
        {  /*Nothing in this case*/ }

        public void BuildBody() =>
            product.Add("This is a body of a Motorcycle");

        public void InsertWheels() =>
            product.Add("2 wheels are added");

        public void AddHeadlights() =>
            product.Add("1 Headlights are added");

        public void EndOperations() =>
            //Finishing up with brandname
            product.Add(string.Format("Motorcycle Model name :{0}", this.brandName));

        public Product GetVehicle() =>
            product;
    }

    // "Director" 
    public class Director
    {
        IBuilder builder;
        // A series of steps -in real life, steps are complex.

        public void Construct(IBuilder builder)
        {
            this.builder = builder;

            builder.StartUpOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample5

    // Product
    public class Report
    {
        public string ReportType { get; set; }

        public string ReportHeader { get; set; }

        public string ReportFooter { get; set; }

        public string ReportContent { get; set; }

        public void DisplayReport()
        {
            Print.ToConsolLine("Report Type :" + ReportType);
            Print.ToConsolLine("Header :" + ReportHeader);
            Print.ToConsolLine("Content :" + ReportContent);
            Print.ToConsolLine("Footer :" + ReportFooter);
        }
    }

    // Abstract Builder
    public abstract class ReportBuilder
    {
        protected Report reportObject;

        public abstract void SetReportType();

        public abstract void SetReportHeader();

        public abstract void SetReportContent();

        public abstract void SetReportFooter();

        public void CreateNewReport() =>
            reportObject = new Report();

        public Report GetReport() =>
            reportObject;
    }

    // Concrete Builder
    class ExcelReport : ReportBuilder
    {
        public override void SetReportContent() =>
            reportObject.ReportContent = "Excel Content Section";

        public override void SetReportFooter() =>
            reportObject.ReportFooter = "Excel Footer";

        public override void SetReportHeader() =>
            reportObject.ReportHeader = "Excel Header";

        public override void SetReportType() =>
            reportObject.ReportType = "Excel";
    }

    public class PDFReport : ReportBuilder
    {
        public override void SetReportContent() =>
            reportObject.ReportContent = "PDF Content Section";

        public override void SetReportFooter() =>
            reportObject.ReportFooter = "PDF Footer";

        public override void SetReportHeader() =>
            reportObject.ReportHeader = "PDF Header";

        public override void SetReportType() =>
            reportObject.ReportType = "PDF";
    }

    // Director
    public class ReportDirector
    {
        public Report MakeReport(ReportBuilder reportBuilder)
        {
            reportBuilder.CreateNewReport();
            reportBuilder.SetReportType();
            reportBuilder.SetReportHeader();
            reportBuilder.SetReportContent();
            reportBuilder.SetReportFooter();

            return reportBuilder.GetReport();
        }
    }
    #endregion
    // --------------------------------------------------

    #region Sample6
    public abstract class Machine
    {
        public int Seats;
    }

    public class CarNew : Machine { }

    public class Manual : Machine { }

    public interface Builder
    {
        void Reset();

        void SetSeats(int seatCount);

        void SetEngine(IEngin engin);

        void SetTripComputer(bool hasTripComputer);

        void SetGPS(bool hasGPS);
    }

    public class CarNewBuilder : Builder
    {
        private CarNew Car;

        public CarNewBuilder() =>
            Reset();

        public void Reset() =>
            Car = new CarNew();

        public void SetSeats(int seatCount)
        {
            this.Car.Seats = seatCount;
            Print.ToConsolLine($"Set {this.Car.Seats} Seats");
        }

        public void SetEngine(IEngin engin) =>
            Print.ToConsolLine($"Set Engin");

        public void SetTripComputer(bool hasTripComputer) =>
            Print.ToConsolLine($"Set {hasTripComputer} TripComputer");

        public void SetGPS(bool hasGPS) =>
            Print.ToConsolLine($"Set {hasGPS} GPS");

        public CarNew GetProduct()
        {
            var product = this.Car;

            this.Reset();

            return product;
        }
    }
    public class CarManualBuilder : Builder
    {
        private Manual Manual;

        public CarManualBuilder() =>
            Reset();

        public void Reset() =>
            Manual = new Manual();

        public void SetSeats(int seatCount)
        {
            this.Manual.Seats = seatCount;
            Print.ToConsolLine($"Set {this.Manual.Seats} Seats");
        }
        public void SetEngine(IEngin engin) =>
            Print.ToConsolLine($"Set Engin");

        public void SetTripComputer(bool hasTripComputer) =>
            Print.ToConsolLine($"Set {hasTripComputer} TripComputer");

        public void SetGPS(bool hasGPS) =>
            Print.ToConsolLine($"Set {hasGPS} GPS");

        public Manual GetProduct()
        {
            var product = this.Manual;

            this.Reset();

            return product;
        }
    }

    public interface IEngin
    {

    }

    public class SportEngine : IEngin
    {

    }

    public class DirectorNew
    {
        private Builder builder;

        public void SetBuilder(Builder builder) =>
            this.builder = builder;

        public void ConstructSportsCar(Builder builder)
        {
            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine(new SportEngine());
            builder.SetTripComputer(true);
            builder.SetGPS(true);
        }

        public void constructSUV(Builder builder) { }
    }
    #endregion
    // --------------------------------------------------

    #region Sample7
    public abstract class GameBuilder
    {
        protected int _boardSize = 8;

        protected int _level = 1;


        public GameBuilder BoardSize(int boardSize)
        {
            _boardSize = boardSize;
            return this;
        }

        public GameBuilder Level(int level)
        {
            _level = level;
            return this;
        }

        public abstract Game Build();

        public virtual GameBuilder Present()
        {
            Print.ToConsolLine($"BoardSize: {this._boardSize.ToString()}, Lelev: {this._level.ToString()}");
            return this;
        }
    }

    public class LocalGameBuilder : GameBuilder
    {
        private int _aiStrength = 3;

        public LocalGameBuilder AiStrength(int aiStrength)
        {
            _aiStrength = aiStrength;
            return this;
        }

        public override Game Build() =>
            new LocalGame(_aiStrength, _boardSize, _level);

        public override LocalGameBuilder Present()
        {
            base.Present();

            Print.ToConsolLine($"AiStrength: {this._aiStrength.ToString()}");
            return this;
        }
    }

    public class OnlineGameBuilder : GameBuilder
    {
        private string _serverUrl = "http://example.com/";

        public OnlineGameBuilder ServerUrl(string serverUrl)
        {
            _serverUrl = serverUrl;
            return this;
        }

        public override Game Build() =>
            new OnlineGame(_serverUrl, _boardSize, _level);

        public override OnlineGameBuilder Present()
        {
            base.Present();
            Print.ToConsolLine($"ServerURL: {this._serverUrl}");
            return this;
        }
    }

    public class Game
    {
        protected int _boardSize = 8;

        protected int _level = 1;

        public Game(string _serverUrl, int _boardSize, int _level) { }
    }

    public class LocalGame : Game
    {
        private int _aiStrength = 3;

        public LocalGame(int _aiStrength, int _boardSize, int _level) : base(_serverUrl: "", _boardSize, _level) { }
    }

    public class OnlineGame : Game
    {
        public OnlineGame(string _serverUrl, int _boardSize, int _level) : base(_serverUrl, _boardSize, _level) { }
    }

    #endregion
    // --------------------------------------------------

    #region Sample8
    //Version #1
    public class ProductNew
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

    public class ProductStockReport
    {
        public string HeaderPart { get; set; }

        public string BodyPart { get; set; }

        public string FooterPart { get; set; }

        public override string ToString() =>
            new System.Text.StringBuilder()
            .AppendLine(HeaderPart)
            .AppendLine(BodyPart)
            .AppendLine(FooterPart)
            .ToString();
    }

    public interface IProductStockReportBuilder
    {
        void BuildHeader();

        void BuildBody();

        void BuildFooter();

        #region #Version2OfSample8
        /* IProductStockReportBuilder BuildHeader();
        IProductStockReportBuilder BuildBody();
        IProductStockReportBuilder BuildFooter(); */
        #endregion

        ProductStockReport GetReport();
    }

    public class ProductStockReportBuilder : IProductStockReportBuilder
    {
        private ProductStockReport _productStockReport;

        private IEnumerable<ProductNew> _products;

        public ProductStockReportBuilder(IEnumerable<ProductNew> products)
        {
            _products = products;
            _productStockReport = new ProductStockReport();
        }

        public void BuildHeader() =>
            _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {System.DateTime.Now}\n";
        #region #Version2OfSample8
        /* return this;*/
        #endregion

        public void BuildBody()
        =>
            _productStockReport.BodyPart = string.Join(System
                                                        .Environment
                                                        .NewLine,
                                                      _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
        #region #Version2OfSample8
        /* return this;*/
        #endregion

        public void BuildFooter() =>
            _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
        #region #Version2OfSample8
        /* return this;*/
        #endregion

        public ProductStockReport GetReport()
        {
            var productStockReport = _productStockReport;
            Clear();

            return productStockReport;
        }

        private void Clear() =>
            _productStockReport = new ProductStockReport();
    }

    public class ProductStockReportDirector
    {
        private readonly IProductStockReportBuilder _productStockReportBuilder;

        public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder) =>
            _productStockReportBuilder = productStockReportBuilder;

        public void BuildStockReport()
        {
            _productStockReportBuilder.BuildHeader();
            _productStockReportBuilder.BuildBody();
            _productStockReportBuilder.BuildFooter();

            #region #Version2OfSample8
            /*_productStockReportBuilder
            .BuildHeader()
            .BuildBody()
            .BuildFooter();*/
            #endregion
        }
    }
    #endregion
    // --------------------------------------------------

    // Hierarchically Builder
    #region Sample9
    class BuilderBase<T, P>
            where T : BuilderBase<T, P>
            where P : class, new()
    {
        protected P obj;

        protected T _this;

        protected BuilderBase()
        {
            obj = new P();
            _this = (T)this;

            Print.ToConsolLine("Builder Base Constractor");
        }

        public P Build()
        {
            P result = obj;
            obj = null;

            Print.ToConsolLine("Builder base Build");
            return result;
        }
    }

    class Window
    {
        public int Width { get; set; }

        public int Height { get; set; }
    }

    class Dialog : Window
    {
        public string Message { get; set; }
    }

    class WindowBuilder<T, P> : BuilderBase<T, P>
        where T : WindowBuilder<T, P>
        where P : Window, new()
    {
        public T Width(int width)
        {
            obj.Width = width;

            Print.ToConsolLine($"Width: {obj.Width}");
            return _this;
        }
        public T Height(int height)
        {
            obj.Height = height;

            Print.ToConsolLine($"Height: {obj.Height}");
            return _this;
        }
    }

    class WindowBuilder : WindowBuilder<WindowBuilder, Window> { }

    class DialogBuilder<T, P> : WindowBuilder<T, P>
        where T : DialogBuilder<T, P>
        where P : Dialog, new()
    {
        public T Message(string message)
        {
            obj.Message = message;

            Print.ToConsolLine($"Message: {obj.Message}");
            return _this;
        }
    }

    class DialogBuilder : DialogBuilder<DialogBuilder, Dialog> { }
    #endregion
    // --------------------------------------------------

    #region Sample10
    public interface ItemNew
    {
        string Name();

        string Size();

        float Price();
    }// End of the interface Item.  

    public interface PizzaNew : ItemNew { }

    public interface ColdDrinkNew : ItemNew { }

    public abstract class VegPizza : PizzaNew
    {
        public abstract float Price();

        public abstract string Name();

        public abstract string Size();
    }// End of the abstract class VegPizza.   

    public abstract class NonVegPizza : PizzaNew
    {
        public abstract float Price();

        public abstract string Name();

        public abstract string Size();
    }// End of the abstract class NonVegPizza. 

    public class SmallCheezePizza : VegPizza
    {
        public override float Price() =>
            170.0f;

        public override string Name() =>
            "Cheeze Pizza";

        public override string Size() =>
            "Small size";
    }// End of the SmallCheezePizza class.  

    public class MediumCheezePizza : VegPizza
    {
        public override float Price() =>
            220.0f;

        public override string Name() =>
            "Cheeze Pizza";

        public override string Size() =>
            "Medium Size";
    }// End of the MediumCheezePizza class. 

    public class LargeCheezePizza : VegPizza
    {
        public override float Price() =>
            260.0f;

        public override string Name() =>
            "Cheeze Pizza";

        public override string Size() =>
            "Large Size";
    }// End of the LargeCheezePizza class.      

    public class ExtraLargeCheezePizza : VegPizza
    {
        public override float Price() =>
            300.0f;

        public override string Name() =>
            "Cheeze Pizza";

        public override string Size() =>
            "Extra-Large Size";
    }// End of the ExtraLargeCheezePizza class.  

    public class SmallOnionPizza : VegPizza
    {
        public override float Price() =>
            120.0f;

        public override string Name() =>
            "Onion Pizza";

        public override string Size() =>
            "Small Size";
    }// End of the SmallOnionPizza class. 

    public class MediumOnionPizza : VegPizza
    {
        public override float Price() =>
            150.0f;

        public override string Name() =>
            "Onion Pizza";

        public override string Size() =>
            "Medium Size";
    }// End of the MediumOnionPizza class.  

    public class LargeOnionPizza : VegPizza
    {
        public override float Price() =>
            180.0f;

        public override string Name() =>
            "Onion Pizza";

        public override string Size() =>
            "Large size";
    }// End of the LargeOnionPizza class.  

    public class ExtraLargeOnionPizza : VegPizza
    {
        public override float Price() =>
            200.0f;

        public override string Name() =>
            "Onion Pizza";

        public override string Size() =>
            "Extra-Large Size";
    }// End of the ExtraLargeOnionPizza class  

    public class SmallMasalaPizza : VegPizza
    {
        public override float Price() =>
            100.0f;

        public override string Name() =>
            "Masala Pizza";

        public override string Size() =>
            "Samll Size";
    }// End of the SmallMasalaPizza class  

    public class MediumMasalaPizza : VegPizza
    {
        public override float Price() =>
            120.0f;

        public override string Name() =>
            "Masala Pizza";

        public override string Size() =>
            "Medium Size";
    }

    public class LargeMasalaPizza : VegPizza
    {
        public override float Price() =>
            150.0f;

        public override string Name() =>
            "Masala Pizza";

        public override string Size() =>
            "Large Size";
    } //End of the LargeMasalaPizza class  

    public class ExtraLargeMasalaPizza : VegPizza
    {
        public override float Price() =>
            180.0f;

        public override string Name() =>
            "Masala Pizza";

        public override string Size() =>
            "Extra-Large Size";
    }// End of the ExtraLargeMasalaPizza class   

    public class SmallNonVegPizza : NonVegPizza
    {
        public override float Price() =>
            180.0f;

        public override string Name() =>
            "Non-Veg Pizza";

        public override string Size() =>
            "Samll Size";
    }// End of the SmallNonVegPizza class  

    public class MediumNonVegPizza : NonVegPizza
    {
        public override float Price() =>
            200.0f;

        public override string Name() =>
            "Non-Veg Pizza";

        public override string Size() =>
            "Medium Size";
    }

    public class LargeNonVegPizza : NonVegPizza
    {
        public override float Price() =>
            220.0f;

        public override string Name() =>
            "Non-Veg Pizza";

        public override string Size() =>
            "Large Size";
    }// End of the LargeNonVegPizza class  

    public class ExtraLargeNonVegPizza : NonVegPizza
    {
        public override float Price() =>
            250.0f;

        public override string Name() =>
            "Non-Veg Pizza";

        public override string Size() =>
            "Extra-Large Size";
    } // End of the ExtraLargeNonVegPizza class  

    public abstract class PepsiNew : ColdDrinkNew
    {
        public abstract string Name();

        public abstract string Size();

        public abstract float Price();
    }// End of the Pepsi class  

    public abstract class CokeNew : ColdDrinkNew
    {
        public abstract string Name();

        public abstract string Size();

        public abstract float Price();
    }// End of the Coke class  

    public class SmallPepsi : PepsiNew
    {
        public override string Name() =>
            "300 ml Pepsi";

        public override float Price() =>
            25.0f;

        public override string Size() =>
            "Small Size";
    }// End of the SmallPepsi class  

    public class MediumPepsi : PepsiNew
    {
        public override string Name() =>
            "500 ml Pepsi";

        public override string Size() =>
            "Medium Size";

        public override float Price() =>
            35.0f;
    }// End of the MediumPepsi class  

    public class LargePepsi : PepsiNew
    {
        public override string Name() =>
            "750 ml Pepsi";

        public override string Size() =>
            "Large Size";

        public override float Price() =>
            50.0f;
    }// End of the LargePepsi class  

    public class SmallCoke : CokeNew
    {
        public override string Name() =>
            "300 ml Coke";

        public override string Size() =>
            "Small Size";

        public override float Price() =>
            25.0f;
    }// End of the SmallCoke class  

    public class MediumCoke : CokeNew
    {
        public override string Name() =>
            "500 ml Coke";

        public override string Size() =>
            "Medium Size";

        public override float Price() =>
            35.0f;
    }// End of the MediumCoke class  

    public class LargeCoke : CokeNew
    {
        public override string Name() =>
            "750 ml Coke";

        public override string Size() =>
            "Large Size";

        public override float Price() =>
            50.0f;
    }// End of the LargeCoke class  

    public class OrderedItems
    {
        List<ItemNew> items = new List<ItemNew>();

        public void AddItems(ItemNew item) =>
            items.Add(item);

        public float GetCost()
        {
            float cost = 0.0f;

            foreach (var item in items)
            {
                cost += item.Price();
            }

            return cost;
        }

        public void ShowItems()
        {
            var itemNumber = 0;
            Print.ToConsolLine("**************************");

            foreach (var item in items)
            {
                itemNumber++;
                Print.ToConsolLine($"| Item {itemNumber}:   {item.Name()}");
                Print.ToConsolLine($"|     Size is: {item.Size()}");
                Print.ToConsolLine($"|     Price is: {item.Price()}");
            }
            Print.ToConsolLine("**************************");
        }
    }// End of the OrderedItems class  

    public class OrderBuilder
    {
        public OrderedItems PreparePizza()
        {
            try
            {
                OrderedItems itemsOrder = new OrderedItems();

                Print.ToConsolLine("============================");
                Print.ToConsolLine("| Enter the choice of Pizza|");
                Print.ToConsolLine("|        1. Veg-Pizza      |");
                Print.ToConsolLine("|        2. Non-Veg Pizza  |");
                Print.ToConsolLine("|        3. Exit           |");
                Print.ToConsolLine("============================");

                int pizzaandcolddrinkchoice = int.Parse(System.Console.ReadLine());

                switch (pizzaandcolddrinkchoice)
                {
                    case 1:
                        {
                            Print.ToConsolLine("------------------------------");
                            Print.ToConsolLine("|You ordered Veg Pizza        |");
                            Print.ToConsolLine("|\n\n");
                            Print.ToConsolLine(" Enter the types of Veg-Pizza |");
                            Print.ToConsolLine("|        1.Cheeze Pizza       |");
                            Print.ToConsolLine("|        2.Onion Pizza        |");
                            Print.ToConsolLine("|        3.Masala Pizza       |");
                            Print.ToConsolLine("|        4.Exit               |");
                            Print.ToConsolLine("------------------------------");

                            int vegpizzachoice = int.Parse(System.Console.ReadLine());

                            switch (vegpizzachoice)
                            {
                                case 1:
                                    {
                                        Print.ToConsolLine("You ordered Cheeze Pizza");

                                        Print.ToConsolLine("------------------------------------");
                                        Print.ToConsolLine("|Enter the cheeze pizza size        |");
                                        Print.ToConsolLine("|    1. Small Cheeze Pizza          |");
                                        Print.ToConsolLine("|    2. Medium Cheeze Pizza         |");
                                        Print.ToConsolLine("|    3. Large Cheeze Pizza          |");
                                        Print.ToConsolLine("|    4. Extra-Large Cheeze Pizza    |");
                                        Print.ToConsolLine("------------------------------------");

                                        int cheezepizzasize = int.Parse(System.Console.ReadLine());
                                        switch (cheezepizzasize)
                                        {
                                            case 1:
                                                itemsOrder.AddItems(new SmallCheezePizza());
                                                break;
                                            case 2:
                                                itemsOrder.AddItems(new MediumCheezePizza());
                                                break;
                                            case 3:
                                                itemsOrder.AddItems(new LargeCheezePizza());
                                                break;
                                            case 4:
                                                itemsOrder.AddItems(new ExtraLargeCheezePizza());
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        Print.ToConsolLine("------------------------------------");
                                        Print.ToConsolLine("|You ordered Onion Pizza            |");
                                        Print.ToConsolLine("|Enter the Onion pizza size         |");
                                        Print.ToConsolLine("|    1. Small Onion Pizza           |");
                                        Print.ToConsolLine("|    2. Medium Onion Pizza          |");
                                        Print.ToConsolLine("|    3. Large Onion Pizza           |");
                                        Print.ToConsolLine("|    4. Extra-Large Onion Pizza     |");
                                        Print.ToConsolLine("------------------------------------");

                                        int onionpizzasize = int.Parse(System.Console.ReadLine());

                                        switch (onionpizzasize)
                                        {
                                            case 1:
                                                itemsOrder.AddItems(new SmallOnionPizza());
                                                break;

                                            case 2:
                                                itemsOrder.AddItems(new MediumOnionPizza());
                                                break;

                                            case 3:
                                                itemsOrder.AddItems(new LargeOnionPizza());
                                                break;

                                            case 4:
                                                itemsOrder.AddItems(new ExtraLargeOnionPizza());
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        Print.ToConsolLine("------------------------------------");
                                        Print.ToConsolLine("|You ordered Masala Pizza           |");
                                        Print.ToConsolLine("|Enter the Masala pizza size        |");
                                        Print.ToConsolLine("|    1. Small Masala Pizza          |");
                                        Print.ToConsolLine("|    2. Medium Masala Pizza         |");
                                        Print.ToConsolLine("|    3. Large Masala Pizza          |");
                                        Print.ToConsolLine("|    4. Extra-Large Masala Pizza    |");
                                        Print.ToConsolLine("------------------------------------");

                                        int masalapizzasize = int.Parse(System.Console.ReadLine());
                                        switch (masalapizzasize)
                                        {
                                            case 1:
                                                itemsOrder.AddItems(new SmallMasalaPizza());
                                                break;

                                            case 2:
                                                itemsOrder.AddItems(new MediumMasalaPizza());
                                                break;

                                            case 3:
                                                itemsOrder.AddItems(new LargeMasalaPizza());
                                                break;

                                            case 4:
                                                itemsOrder.AddItems(new ExtraLargeMasalaPizza());
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;// Veg- pizza choice completed.  
                    case 2:
                        {
                            Print.ToConsolLine("You ordered Non-Veg Pizza");
                            Print.ToConsolLine("\n\n");

                            Print.ToConsolLine("------------------------------------");
                            Print.ToConsolLine("|Enter the Non-Veg pizza size       |");
                            Print.ToConsolLine("|    1. Small Non-Veg  Pizza        |");
                            Print.ToConsolLine("|    2. Medium Non-Veg  Pizza       |");
                            Print.ToConsolLine("|    3. Large Non-Veg  Pizza        |");
                            Print.ToConsolLine("|    4. Extra-Large Non-Veg  Pizza  |");
                            Print.ToConsolLine("------------------------------------");

                            int nonvegpizzasize = int.Parse(System.Console.ReadLine());

                            switch (nonvegpizzasize)
                            {
                                case 1:
                                    itemsOrder.AddItems(new SmallNonVegPizza());
                                    break;
                                case 2:
                                    itemsOrder.AddItems(new MediumNonVegPizza());
                                    break;
                                case 3:
                                    itemsOrder.AddItems(new LargeNonVegPizza());
                                    break;
                                case 4:
                                    itemsOrder.AddItems(new ExtraLargeNonVegPizza());
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 3:
                    default:
                        System.Environment.Exit(0);
                        break;
                }//end of main Switch  

                //continued?..  
                Print.ToConsolLine("================================");
                Print.ToConsolLine("| Enter the choice of ColdDrink |");
                Print.ToConsolLine("|        1. Pepsi               |");
                Print.ToConsolLine("|        2. Coke                |");
                Print.ToConsolLine("|        3. Exit                |");
                Print.ToConsolLine("================================");

                int coldDrink = int.Parse(System.Console.ReadLine());
                switch (coldDrink)
                {
                    case 1:
                        {
                            Print.ToConsolLine("------------------------");
                            Print.ToConsolLine("|You ordered Pepsi      |");
                            Print.ToConsolLine("|Enter the Pepsi Size   |");
                            Print.ToConsolLine("|    1. Small Pepsi     |");
                            Print.ToConsolLine("|    2. Medium Pepsi    |");
                            Print.ToConsolLine("|    3. Large Pepsi     |");
                            Print.ToConsolLine("------------------------");

                            int pepsisize = int.Parse(System.Console.ReadLine());
                            switch (pepsisize)
                            {
                                case 1:
                                    itemsOrder.AddItems(new SmallPepsi());
                                    break;

                                case 2:
                                    itemsOrder.AddItems(new MediumPepsi());
                                    break;

                                case 3:
                                    itemsOrder.AddItems(new LargePepsi());
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            Print.ToConsolLine("------------------------");
                            Print.ToConsolLine("|You ordered Coke       |");
                            Print.ToConsolLine("|Enter the Coke Size    |");
                            Print.ToConsolLine("|    1. Small Coke      |");
                            Print.ToConsolLine("|    2. Medium Coke     |");
                            Print.ToConsolLine("|    3. Large Coke      |");
                            Print.ToConsolLine("------------------------");

                            int cokesize = int.Parse(System.Console.ReadLine());
                            switch (cokesize)
                            {
                                case 1:
                                    itemsOrder.AddItems(new SmallCoke());
                                    break;
                                case 2:
                                    itemsOrder.AddItems(new MediumCoke());
                                    break;
                                case 3:
                                    itemsOrder.AddItems(new LargeCoke());
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }//End of the Cold-Drink switch 

                return itemsOrder;
            }
            catch (System.Exception)
            {
                throw new System.Exception("IO Exception");
            }
        } //End of the preparePizza() method   
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.Write(txt, para);
        public static void ToConsolLine(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}