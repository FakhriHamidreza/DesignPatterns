## Name:

    Abstract Factory/ super-factory/ factory of factory (Creates other factories)

## Complexity/ difficalty:

> **Medium Hight**

## Frequency of use:

> **High**

## Intent:

    Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    A hierarchy that encapsulates: many possible "platforms", and the construction of a suite of "products".
    The new operator considered harmful.

    If you are familiar with factory design pattern, you will notice that we have a single Factory class. This factory class returns different subclasses based on the input provided and factory class uses if-else or switch statement to achieve this.
    In the Abstract Factory pattern, we get rid of if-else block and have a factory class for each sub-class. Then an Abstract Factory class that will return the sub-class based on the input factory class

    An interface is responsible for creating a factory of related objects without explicitly specifying their classes. Each generated factory can give the objects as per the Factory pattern.

    Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

## Problem:

    If an application is to be portable, it needs to encapsulate platform dependencies. These "platforms" might include: windowing system, operating system, database, etc. Too often, this encapsulation is not engineered in advance, and lots of #ifdef case statements with options for all currently supported platforms begin to procreate like rabbits throughout the code.

## Participants:

    The classes and objects participating in this pattern are:
    - AbstractFactory
        declares an interface for operations that create abstract products
    - ConcreteFactory
        implements the operations to create concrete product objects
    - AbstractProduct
        declares an interface for a type of product object
    - Product
        defines a product object to be created by the corresponding concrete factory
        implements the AbstractProduct interface
    - Client
        uses interfaces declared by AbstractFactory and AbstractProduct classes

## Pros and Cons:

    - [x] You can be sure that the products you’re getting from a factory are compatible with each other.
    - [x] You avoid tight coupling between concrete products and client code.
    - [x] Single Responsibility Principle. You can extract the product creation code into one place, making the code easier to support.
    - [x] Open/Closed Principle. You can introduce new variants of products without breaking existing client code.
    - [x] Abstract Factory Pattern isolates the client code from concrete (implementation) classes.
    - [x] It eases the exchanging of object families.
    - [x] It promotes consistency among objects.

    - [] The code may become more complicated than it should be, since a lot of new interfaces and classes are introduced along with the pattern.

## Relations with Other Patterns:

    * Many designs start by using **Factory Method** (less complicated and more customizable via subclasses) and evolve toward **Abstract Factory**, **Prototype**, or **Builder** (more flexible, but more complicated). (Abstract Factory classes are often implemented with Factory Methods, but they can also be implemented using Prototype.)
    * **Builder** focuses on constructing complex objects step by step. **Abstract** Factory specializes in creating families of related objects. Abstract Factory returns the product immediately, whereas Builder lets you run some additional construction steps before fetching the product.
    * **Abstract Factory** classes are often based on a set of **Factory Methods**, but you can also use **Prototype** to compose the methods on these classes.
    * **Abstract Factory** can serve as an alternative to **Facade** when you only want to hide the way the subsystem objects are created from the client code.(to hide platform-specific classes.)
    * You can use **Abstract Factory** along with **Bridge**. This pairing is useful when some abstractions defined by Bridge can only work with specific implementations. In this case, Abstract Factory can encapsulate these relations and hide the complexity from the client code.
    * **Abstract Factories**, **Builders** and **Prototypes** can all be implemented as **Singletons**.

## Usage/ Applicability

    Use the Abstract Factory when your code needs to work with various families of related products, but you don’t want it to depend on the concrete classes of those products—they might be unknown beforehand or you simply want to allow for future extensibility.

    The Abstract Factory provides you with an interface for creating objects from each class of the product family. As long as your code creates objects via this interface, you don’t have to worry about creating the wrong variant of a product which doesn’t match the products already created by your app.

        - Consider implementing the Abstract Factory when you have a class with a set of Factory Methods that blur its primary responsibility.
        - In a well-designed program each class is responsible only for one thing. When a class deals with multiple product types, it may be worth extracting its factory methods into a stand-alone factory class or a full-blown Abstract Factory implementation.

    - When the system needs to be independent of how its object are created, composed, and represented.
    - When the family of related objects has to be used together, then this constraint needs to be enforced.
    - When you want to provide a library of objects that does not show implementations and only reveals interfaces.
    - When the system needs to be configured with one of a multiple family of objects.
    - When you want to create a set of related objects or dependent objects which must be used together.
    - When the Concrete classes should be decoupled from the clients.

## Identification:

    The pattern is easy to recognize by methods, which return a factory object. Then, the factory is used for creating specific sub-components.

## Differences between Abstract Factory and Factory Method Design Pattern:

    Abstract Factory Design Pattern adds a layer of abstraction to the Factory Method Design Pattern
    The Abstract Factory design pattern implementation can have multiple factory methods
    Similar products of a factory implementation are grouped in Abstract factory
    The Abstract Factory Pattern uses object composition to decouple applications from specific implementations
    The Factory Method Pattern uses inheritance to decouple applications from specific implementations
