
## Name:
>    **Builder**

## Complexity/ difficalty:
>   **Medium High**

## Frequency of use:
>   **Medium low**

## Description:
    Builder pattern was introduced to solve some of the problems with Factory and Abstract Factory design patterns, when the Object contains a lot of attributes.

    There are three major issues with Factory and Abstract Factory design patterns when the Object contains a lot of attributes.
    1. Too Many arguments to pass from client program to the Factory class that can be error prone because most of the time, the type of arguments are same and from client side its hard to maintain the order of the argument.
    2. Some of the parameters might be optional but in Factory pattern, we are forced to send all the parameters and optional parameters need to send as NULL.
    3. If the object is heavy and its creation is complex, then all that complexity will be part of Factory classes that is confusing.

    Builder focuses on constructing a complex object step by step. Abstract Factory emphasizes a family of product objects (either simple or complex). Builder returns the product as a final step, but as far as the Abstract Factory is concerned, the product gets returned immediately.

    We can solve the issues with large number of parameters by providing a constructor with required parameters and then different setter methods to set the optional parameters. The problem with this approach is that the Object state will be inconsistent until unless all the attributes are set explicitly.

## Intent:
    Builder is a creational design pattern that lets you construct complex objects step by step (using simple objects). The pattern allows you to produce different types and representations of an object using the same construction code.
    This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.
    Builder pattern solves the issue with large number of optional parameters and inconsistent state by providing a way to build the object step-by-step and provide a method that will actually return the final Object.

    - Separate the construction of a complex object from its representation so that the same construction process can create different representations.
    - Parse a complex representation, create one of several targets.

## Problem:
    Imagine a complex object that requires laborious, step-by-step initialization of many fields and nested objects. Such initialization code is usually buried inside a monstrous constructor with lots of parameters. Or even worse: scattered all over the client code.

## Participants:
    - Builder
            specifies an abstract interface for creating parts of a Product object
    - ConcreteBuilder
            constructs and assembles parts of the product by implementing the Builder interface
            defines and keeps track of the representation it creates
            provides an interface for retrieving the product
    - Director
            constructs an object using the Builder interface
    - Product
            represents the complex object under construction. ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled
            includes classes that define the constituent parts, including interfaces for assembling the parts into the final result

## Pros and Cons:
    - [x] You can construct objects step-by-step, defer construction steps or run steps recursively.
    - [x] You can reuse the same construction code when building various representations of products.
    - [x] Single Responsibility Principle. You can isolate complex construction code from the business logic of the product.
    - [x] It provides clear separation between the construction and representation of an object.
    - [x] It supports to change the internal representation of objects.
    - [x] It provides better control over construction process.

    - []  The overall complexity of the code increases since the pattern requires creating multiple new classes.

## Relations with Other Patterns:
    - Many designs start by using Factory Method (less complicated and more customizable via subclasses) and evolve toward Abstract Factory, Prototype, or Builder (more flexible, but more complicated).

    - Builder focuses on constructing complex objects step by step. Abstract Factory specializes in creating families of related objects. Abstract Factory returns the product immediately, whereas Builder lets you run some additional construction steps before fetching the product.
    - You can use Builder when creating complex Composite trees because you can program its construction steps to work recursively.
    - You can combine Builder with Bridge: the director class plays the role of the abstraction, while different builders act as implementations.
    - Abstract Factories, Builders and Prototypes can all be implemented as Singletons.

## Usage/Applicability:
    - Use the Builder pattern to get rid of a “telescopic constructor”.
        Say you have a constructor with ten optional parameters. Calling such a beast is very inconvenient; therefore, you overload the constructor and create several shorter versions with fewer parameters. These constructors still refer to the main one, passing some default values into any omitted parameters.

        class Pizza {
        Pizza(int size) { ... }
        Pizza(int size, boolean cheese) { ... }
        Pizza(int size, boolean cheese, boolean pepperoni) { ... }
        // ...

        Creating such a monster is only possible in languages that support method overloading, such as C# or Java.

        The Builder pattern lets you build objects step by step, using only those steps that you really need. After implementing the pattern, you don’t have to cram dozens of parameters into your constructors anymore.

        - Use the Builder pattern when you want your code to be able to create different representations of some product (for example, stone and wooden houses).

        The Builder pattern can be applied when construction of various representations of the product involves similar steps that differ only in the details.

        The base builder interface defines all possible construction steps, and concrete builders implement these steps to construct particular representations of the product. Meanwhile, the director class guides the order of construction.

        - Use the Builder to construct Composite trees or other complex objects.

        The Builder pattern lets you construct products step-by-step. You could defer execution of some steps without breaking the final product. You can even call steps recursively, which comes in handy when you need to build an object tree.

        A builder doesn’t expose the unfinished product while running construction steps. This prevents the client code from fetching an incomplete result.
