
## Name:
>    **Singleton**

## Complexity/ difficalty:


## Frequency of use:
>   **Medium High**

## Intent:
> Ensure a class has only one instance, and provide a global point of access to it.
    Encapsulated "just-in-time initialization" or "initialization on first use".
    When you need stricter control over global variables.

## Problem:
>    Application needs one, and only one, instance of an object. Additionally, lazy initialization and global access are necessary.

## Participants:
> defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
    responsible for creating and maintaining its own unique instance.

**Can be implemented:**

- eager/ early Instantiation
- Lazy/ late Instantiation
- thread safe
- static block
- serialize/ deserialize

## Pros and Cons:
> + [x] You can be sure that a class has only a single instance.
        The advantage of Singleton over global variables is that you are absolutely sure of the number of instances when you use Singleton, and, you can change your mind and manage any number of instances.
        The Singleton design pattern is one of the most inappropriately used patterns. Singletons are intended to be used when a class must have exactly one instance, no more, no less. Designers frequently use Singletons in a misguided attempt to replace global variables. A Singleton is, for intents and purposes, a global variable. The Singleton does not do away with the global; it merely renames it.
+ [x] You gain a global access point to that instance.
+ [x] The singleton object is initialized only when it’s requested for the first time.

> - [] Violates the Single Responsibility Principle. The pattern solves two problems at the time.
- [] The Singleton pattern can mask bad design, for instance, when the components of the program know too much about each other.
- [] The pattern requires special treatment in a multithreaded environment so that multiple threads won’t create a singleton object several times.
- [] It may be difficult to unit test the client code of the Singleton because many test frameworks rely on inheritance when producing mock objects. Since the constructor of the singleton class is private and overriding static methods is impossible in most languages, you will need to think of a creative way to mock the singleton. Or just don’t write the tests. Or don’t use the Singleton pattern.

## Relations with Other Patterns:
> - A Facade class can often be transformed into a Singleton since a single facade object is sufficient in most cases.
- Flyweight would resemble Singleton if you somehow managed to reduce all shared states of the objects to just one flyweight object. But there are two fundamental differences between these patterns:
            There should be only one Singleton instance, whereas a Flyweight class can have multiple instances with different intrinsic states.
            The Singleton object can be mutable. Flyweight objects are immutable.
- Abstract Factories, Builders and Prototypes can all be implemented as Singletons (can use Singleton in their implementation).
- State objects are often singleton

## Usage/Applicability:
> Singleton pattern is mostly used in multi-threaded and database applications. It is used in logging, caching, thread pools, drivers object, configuration settings etc.

## Destroy:
> using reflection to destroy a singleton object
