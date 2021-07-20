using System;
using System.Text;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region
            //Pizza pizza1 = new ItalianPizza();
            //pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            //Console.WriteLine("Название: {0}", pizza1.Name);
            //Console.WriteLine("Цена: {0}", pizza1.GetCost());

            //Pizza pizza2 = new ItalianPizza();
            //pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            //Console.WriteLine("Название: {0}", pizza2.Name);
            //Console.WriteLine("Цена: {0}", pizza2.GetCost());

            //Pizza pizza3 = new BulgerianPizza();
            //pizza3 = new TomatoPizza(pizza3);
            //pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            //Console.WriteLine("Название: {0}", pizza3.Name);
            //Console.WriteLine("Цена: {0}", pizza3.GetCost());

            //Console.ReadLine();
            #endregion

            Beverage beverage = new Espresso();
            beverage = new Whip(beverage);
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());

            Beverage beverage2 = new HouseBlend();
            beverage2 = new Soy(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());

            Soy soy = new Soy(beverage2);
            Console.WriteLine($"Soy removed\n{soy.GetDescriptionWithoutSoy()} ${soy.CostWithoutSoy()}");

            beverage2 = new HouseBlend();
            beverage2 = new Soy(beverage2);
            beverage2 = new Mocha(beverage2);
            Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());

        }
    }

    abstract class Pizza
    {
        public string Name { get; protected set; }

        public Pizza(string name)
        {
            Name = name;
        }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }

    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}
