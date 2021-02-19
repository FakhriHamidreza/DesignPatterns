
## Name:
>    **Singleton**

## Complexity/ difficalty:
>   **Medium Low**

## Frequency of use:
>   **Medium High**

## Intent:
    - Ensure a class has only one instance, and provide a global point of access to it.
    - Encapsulated "just-in-time initialization" or "initialization on first use".

## Problem:
    Application needs one, and only one, instance of an object. Additionally, lazy initialization and global access are necessary.

## Participants:
    defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
    responsible for creating and maintaining its own unique instance.

    **Can be implemented:**
        - eager/ early Instantiation
        - Lazy/ late Instantiation
        - thread safe
        - static initialization
        - serialize/ deserialize

## Pros and Cons:
    + [x] You can be sure that a class has only a single instance.
    + [x] You gain a global access point to that instance.
    + [x] The singleton object is initialized only when it’s requested for the first time.

    - [] Violates the Single Responsibility Principle. The pattern solves two problems at the time.
    - [] The Singleton pattern can mask bad design, for instance, when the components of the program know too much about each other.
    - [] The pattern requires special treatment in a multithreaded environment so that multiple threads won’t create a singleton object several times.
    - [] It may be difficult to unit test the client code of the Singleton because many test frameworks rely on inheritance when producing mock objects. Since the constructor of the singleton class is private and overriding static methods is impossible in most languages, you will need to think of a creative way to mock the singleton. Or just don’t write the tests. Or don’t use the Singleton pattern.
    - [] This pattern reduces the potential for parallelism within a program because to access the singleton in a multi-threaded system, an object must be serialized (by locking).

## Relations with Other Patterns:
    - A Facade class can often be transformed into a Singleton since a single facade object is sufficient in most cases.(because only one Facade object is required)
    - Flyweight would resemble Singleton if you somehow managed to reduce all shared states of the objects to just one flyweight object. But there are two fundamental differences between these patterns:
                There should be only one Singleton instance, whereas a Flyweight class can have multiple instances with different intrinsic states.
                The Singleton object can be mutable. Flyweight objects are immutable.
    - Abstract Factories, Builders and Prototypes can all be implemented as Singletons (can use Singleton in their implementation).
    - State objects are often singleton

## Usage/Applicability:
    - Singleton pattern is mostly used in multi-threaded and database applications. It is used in logging, caching, thread pools, drivers object, configuration settings etc.
    - When you need stricter control over global variables.

## Missed Use/ Anti Pattern
    The advantage of Singleton over global variables is that you are absolutely sure of the number of instances when you use Singleton, and, you can change your mind and manage any number of instances.

    - The Singleton design pattern is one of the most inappropriately used patterns. Singletons are intended to be used when a class must have exactly one instance, no more, no less. Designers frequently use Singletons in a misguided attempt to replace global variables. A Singleton is, for intents and purposes, a global variable. The Singleton does not do away with the global; it merely renames it.
    - When is Singleton unnecessary? Short answer: most of the time. Long answer: when it's simpler to pass an object resource as a reference to the objects that need it, rather than letting objects access the resource globally. The real problem with Singletons is that they give you such a good excuse not to think carefully about the appropriate visibility of an object. Finding the right balance of exposure and protection for an object is critical for maintaining flexibility.
    - The answer to the global data question is not, "Make it a Singleton." The answer is, "Why in the hell are you using global data?" Changing the name doesn't change the problem. In fact, it may make it worse because it gives you the opportunity to say, "Well I'm not doing that, I'm doing this" – even though this and that are the same thing.

## How to Implement
    1. Define a private static attribute in the "single instance" class, to the class for storing the singleton instance.
    2. Define a public static accessor function in the class, for getting the singleton instance.
    3. Do "lazy initialization" (creation on first use) in the accessor function. It should create a new object on its first call and put it into the static field. The method should always return that instance on all subsequent calls.
    4. Define all constructors to be protected or private. The static method of the class will still be able to call the constructor, but not the other objects.
    5. Clients may only use the accessor function to manipulate the Singleton.

## Destroy:
    using reflection to destroy a singleton object
