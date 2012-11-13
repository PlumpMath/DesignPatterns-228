using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCreate a NY style Pizza");
            PizzaStore nyPizzaStore = new NyPizzaStore();
            nyPizzaStore.OrderPizza("Cheese");

            //Console.WriteLine("\nCreate a chicago style Pizza");
            //PizzaStore chicagoPizzaStore = new ChicagoPizzaStore();
            //chicagoPizzaStore.OrderPizza("ThickCrust");

           
        }
    }
}
