
## Name:
>    **Factory Method**

## Also known as:
    Virtual Constructor

## Frequency of use:
>   **High**

## Intent:
Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.
    Defining a "virtual" constructor.
    The new operator considered harmful.

## Problem:
    A framework needs to standardize the architectural model for a range of applications, but allow for individual applications to define their own domain objects and provide for their instantiation.

## Participants:
    Factory Methods are usually called within Template Methods.

    1. If you have an inheritance hierarchy that exercises polymorphism, consider adding a polymorphic creation capability by defining a static factory method in the base class.
    2. Design the arguments to the factory method. What qualities or characteristics are necessary and sufficient to identify the correct derived class to instantiate?
    3. Consider designing an internal "object pool" that will allow objects to be reused instead of created from scratch.
    4. Consider making all constructors private or protected.


    Product  (Page)
        defines the interface of objects the factory method creates
    ConcreteProduct  (SkillsPage, EducationPage, ExperiencePage)
        implements the Product interface
    Creator  (Document)
        declares the factory method, which returns an object of type Product. Creator may also define a default implementation of the factory method that returns a default ConcreteProduct object.
        may call the factory method to create a Product object.
    ConcreteCreator  (Report, Resume)
        overrides the factory method to return an instance of a ConcreteProduct.

## Pros and Cons:
    - You avoid tight coupling (It promotes the loose-coupling) between the creator and the concrete products.
    - Single Responsibility Principle. You can move the product creation code into one place in the program, making the code easier to support.
    - Open/Closed Principle. You can introduce new types of products into the program without breaking existing client code.
    - The advantage of a Factory Method is that it can return the same instance multiple times, or can return a subclass rather than an object of that exact type.
 
    * The code may become more complicated since you need to introduce a lot of new subclasses to implement the pattern. The best case scenario is when you’re introducing the pattern into an existing hierarchy of creator classes.

## Relations with Other Patterns:
    - Many designs start by using Factory Method (less complicated and more customizable via subclasses) and evolve toward Abstract Factory, Prototype, or Builder (more flexible, but more complicated).
    - Abstract Factory classes are often based on a set of Factory Methods, but you can also use Prototype to compose the methods on these classes.
    - You can use Factory Method along with Iterator to let collection subclasses return different types of iterators that are compatible with the collections.
    - Prototype isn’t based on inheritance, so it doesn’t have its drawbacks. On the other hand, Prototype requires a complicated initialization of the cloned object. Factory Method is based on inheritance but doesn’t require an initialization step.
        Factory Method: creation through inheritance. Prototype: creation through delegation.
        Prototype doesn't require subclassing, but it does require an Initialize operation. Factory Method requires subclassing, but doesn't require Initialize.
    - Factory Method is a specialization of Template Method. At the same time, a Factory Method may serve as a step in a large Template Method.

## Usage/Applicability:
    -Use the Factory Method when you don’t know beforehand the exact types and dependencies of the objects your code should work with.
        The Factory Method separates product construction code from the code that actually uses the product. Therefore it’s easier to extend the product construction code independently from the rest of the code.
        For example, to add a new product type to the app, you’ll only need to create a new creator subclass and override the factory method in it.
        The solution is to reduce the code that constructs components across the framework into a single factory method and let anyone override this method in addition to extending the component itself.
    -Use the Factory Method when you want to provide users of your library or framework with a way to extend its internal components.
        Inheritance is probably the easiest way to extend the default behavior of a library or framework. But how would the framework recognize that your subclass should be used instead of a standard component?
    - Use the Factory Method when you want to save system resources by reusing existing objects instead of rebuilding them each time.
        You often experience this need when dealing with large, resource-intensive objects such as database connections, file systems, and network resources.
        Let’s think about what has to be done to reuse an existing object:
            1.First, you need to create some storage to keep track of all of the created objects.
            2.When someone requests an object, the program should look for a free object inside that pool.
            3.… and then return it to the client code.
            4.If there are no free objects, the program should create a new one (and add it to the pool).

## Destroy:

