/*
 it’s not a design pattern, but a technique we use very often. It encapsulates the object instantiation process.
*/
using System;

namespace DesignPatterns.SimpleFactoryPattern
{
    abstract class Toy
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public void Prepare() =>
            Console.WriteLine($"{this.Name} is prepared");

        public void Package() =>
            Console.WriteLine($"{this.Name} is Packaged");

        public void Lable() =>
            Console.WriteLine($"{this.Name} is priced at {this.Price.ToString()}");
    }

    class Car : Toy
    {
        public Car()
        {
            this.Name = "Car";
            this.Price = 20;
        }
    }

    class Helicopter : Toy
    {
        public Helicopter()
        {
            this.Name = "Helicopter";
            this.Price = 100;
        }
    }

    class SimpleFactory
    {
        public Toy CreateToy(string toyName)
        {
            Toy toy = null;

            if ("car" == toyName)
            {
                toy = new Car();
            }
            else if ("helicopter" == toyName)
            {
                toy = new Helicopter();
            }

            return toy;
        }
    }

    abstract class ToysFactory
    {
        public SimpleFactory SimpleFactory;

        public ToysFactory(SimpleFactory simpleFactory) =>
            this.SimpleFactory = simpleFactory;

        public abstract void Prepare();

        public abstract void Package();

        public abstract void Lable();

        public Toy ProduceToy(string toyName)
        {
            var toy = this.SimpleFactory.CreateToy(toyName);

            toy.Prepare();
            toy.Package();
            toy.Lable();

            return toy;
        }
    }
}