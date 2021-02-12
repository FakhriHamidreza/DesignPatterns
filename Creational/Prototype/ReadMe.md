Prototype pattern refers to creating duplicate object while keeping performance in mind. 

## Name:
>    **Prototype**

## Also known as:
    Clone

## Complexity/ difficalty:


## Frequency of use:
>   **Medium**

## Intent:
Prototype is a creational design pattern that lets you copy existing objects without making your code dependent on their classes.
- Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
- Co-opt one instance of a class for use as a breeder of all future instances.
- The new operator considered harmful.

## Problem:
Application "hard wires" the class of object to create in each "new" expression.

Say you have an object, and you want to create an exact copy of it. How would you do it? First, you have to create a new object of the same class. Then you have to go through all the fields of the original object and copy their values over to the new object.

Nice! But there’s a catch. Not all objects can be copied that way because some of the object’s fields may be private and not visible from outside of the object itself.

There’s one more problem with the direct approach. Since you have to know the object’s class to create a duplicate, your code becomes dependent on that class. If the extra dependency doesn’t scare you, there’s another catch. Sometimes you only know the interface that the object follows, but not its concrete class, when, for example, a parameter in a method accepts any objects that follow some interface.

## Participants:
The classes and objects participating in this pattern are:
    Prototype  (ColorPrototype)
        declares an interface for cloning itself
    ConcretePrototype  (Color)
        implements an operation for cloning itself
    Client  (ColorManager)
        creates a new object by asking a prototype to clone itself

## Aspects/ Rules:
- Prototype doesn't require subclassing, but it does require an "initialize" operation. Factory Method requires subclassing, but doesn't require Initialize. (Factory Method: creation through inheritance. Prototype: creation through delegation.)
- Prototype is unique among the other creational patterns in that it doesn't require a class – only an object.
- Abstract Factory classes are often implemented with Factory Methods, but they can be implemented using Prototype.

## Pros and Cons:
- [x] You can clone objects without coupling to their concrete classes.
- [x] You can get rid of repeated initialization code in favor of cloning pre-built prototypes.
- [x] You can produce complex objects more conveniently.
- [x] You get an alternative to inheritance when dealing with configuration presets for complex objects.
- [x] It reduces the need of sub-classing.
- [x] It hides complexities of creating objects.
- [x] The clients can get new objects without knowing which type of object it will be.
- [x] It lets you add or remove objects at runtime.

 - [] Cloning complex objects that have circular references might be very tricky.

## Relations with Other Patterns:
- Many designs start by using **Factory Method** (less complicated and more customizable via subclasses) and evolve toward **Abstract Factory**, **Prototype**, or **Builder** (more flexible, but more complicated).
- **Abstract Factory** classes are often based on a set of **Factory Methods**, but you can also use **Prototype** to compose the methods on these classes.
- **Prototype** can help when you need to save copies of **Commands** into history.
- Designs that make heavy use of **Composite** and **Decorator** can often benefit from using **Prototype**. Applying the pattern lets you clone complex structures instead of re-constructing them from scratch.
- **Prototype** isn’t based on inheritance, so it doesn’t have its drawbacks. On the other hand, Prototype requires a complicated initialization of the cloned object. **Factory Method** is based on inheritance but doesn’t require an initialization step.
- Sometimes **Prototype** can be a simpler alternative to **Memento**. This works if the object, the state of which you want to store in the history, is fairly straightforward and doesn’t have links to external resources, or the links are easy to re-establish.
- **Astract Factories**, **Builders** and **Prototypes** can all be implemented as **Singletons**.

## Usage/Applicability:
- Use the Prototype pattern when your code shouldn’t depend on the concrete classes of objects that you need to copy.

This happens a lot when your code works with objects passed to you from 3rd-party code via some interface. The concrete classes of these objects are unknown, and you couldn’t depend on them even if you wanted to.

The Prototype pattern provides the client code with a general interface for working with all objects that support cloning. This interface makes the client code independent from the concrete classes of objects that it clones.

- Use the pattern when you want to reduce the number of subclasses that only differ in the way they initialize their respective objects. Somebody could have created these subclasses to be able to create objects with a specific configuration.

The Prototype pattern lets you use a set of pre-built objects, configured in various ways, as prototypes.

Instead of instantiating a subclass that matches some configuration, the client can simply look for an appropriate prototype and clone it.

- When the classes are instantiated at runtime.
- When the cost of creating an object is expensive or complicated.
- When you want to keep the number of classes in an application minimum.
- When the client application needs to be unaware of object creation and representation.
- when object initialization is expensive, and you anticipate few variations on the initialization parameters. In this context, Prototype can avoid expensive "creation from scratch", and support cheap cloning of a pre-initialized prototype.


## Destroy:

