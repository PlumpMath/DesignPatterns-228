using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Collections;

namespace FactoryLike
{

    public interface IPizza
    {
        String GetStringName();
        

    }

    public class Pizza : IPizza
    {
        public String GetStringName()
        {
            return "New Pizza";
        }
    }



    public abstract class PizzaStore
    {
        public void OrderPizza()
        {
            IPizza pizza = CreatePizza();
            String name = pizza.GetStringName();


        }

        protected abstract IPizza CreatePizza();
    }


    public class NewPizzaStore : PizzaStore
    {

        protected override IPizza CreatePizza()
        {
            return new Pizza();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore pizzaStore = new NewPizzaStore();
            pizzaStore.OrderPizza();
        }
    }
}
