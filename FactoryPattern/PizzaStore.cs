using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FactoryPattern
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(String type)
        {
            Pizza pizza;
            pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
        protected abstract Pizza CreatePizza(String type); 
    }

    public class NyPizzaStore : PizzaStore
    {
 
        protected override Pizza CreatePizza(string type)
        {
            
            Pizza pizza = null;
            if (type.Equals("Cheese"))
            {
                //pizza = new NYStylePizza();

                pizza = new NyPizza(new NyPizzaIngredients());
            }
            else if(type.Equals("Pepperoni"))
            {

            }
            return pizza;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {

        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("ThickCrust"))
            {
                //pizza = new ChicagoStylePizza();
            }
            return pizza;
        }
    }

    

    public abstract class Pizza
    {
        protected String name;
        protected String dough;
        protected String sauce;
        protected String shapes;
        protected ArrayList toppings = new ArrayList();

        public abstract void Prepare();
        //{
        //    Console.WriteLine("Prepare Pizza - "+name);
        //    Console.WriteLine("Tossing dough - " + dough);
        //    Console.WriteLine("Adding sauce - " + sauce);
        //    foreach (String x in toppings)
        //    {
        //        Console.WriteLine("Adding topping - " + x);
        //    }
        //}

        public void Bake()
        {
            Console.WriteLine("Bake Pizza - " + name);
        }

        public void Cut()
        {
            Console.WriteLine("Cut Pizza in to "+ shapes+" shapes");
            //Console.WriteLine("Cut Pizza in to diagonal shapes");
        }

        public void Box()
        {
            //Console.WriteLine("Box Pizza in official Pizzastore Box");
            Console.WriteLine("Box Pizza in official Pizzastore Box");
        }

        public String GetName()
        {
            return name;
        }
    }

   
    //public class NYStylePizza : Pizza
    //{
    //    public NYStylePizza()
    //    {
    //        name = "NY Style Sauce and cheese Pizza";
    //        sauce = "Marinara Sauce";
    //        dough = "Thin crust dough";
    //        toppings.Add("Grated reggiano cheese");

    //    }
    //}

    //public class ChicagoStylePizza : Pizza
    //{
    //    public ChicagoStylePizza()
    //    {
    //        name = "Chicage Style Sauce and cheese Pizza";
    //        sauce = "Marinara Sauce";
    //        dough = "Thick crust dough";
    //        toppings.Add("Grated reggiano cheese");

    //    }
    //}

    public interface PizzaIngredientsFactory
    {
        void CreateDough();
        ArrayList CreateToppings();
        String CreateShapes();
        String CreatePersonalizedBox();
        String GetName();
    }

    public class NyPizzaIngredients : PizzaIngredientsFactory
    {
        String name = "NYPizza";
        public void CreateDough()
        {
            Console.WriteLine("Create dough for NY pizza");
        }

        public ArrayList CreateToppings()
        {
            ArrayList nytoppings = new ArrayList();
            nytoppings.Add("Sauce1");
            nytoppings.Add("Jalopenoes");
            nytoppings.Add("Olives");
            return nytoppings;
        }

        public String  CreateShapes()
        {
            return "Square";
        }

        public String CreatePersonalizedBox()
        {
            return "New York Yummy Pizzas";
        }
        public String GetName()
        {
            return name;
        }
    }

    public class NyPizza : Pizza
    {
        PizzaIngredientsFactory NYInredientsInstace;
        public NyPizza(PizzaIngredientsFactory ingredientsInstance)
        {
            NYInredientsInstace = ingredientsInstance;
        }
        public override void Prepare()
        {
            
            name = NYInredientsInstace.GetName();
            toppings = NYInredientsInstace.CreateToppings();
            foreach (String x in toppings)
            {
                Console.WriteLine("Adding topping - " + x);
            }
            shapes = NYInredientsInstace.CreateShapes();
  
        }


    }

    #region not used

    //public class NYPizzaStore : PizzaStore
    //{
    //    IPizza pizza;
    //    protected override IPizza CreatePizza(string type)
    //    {
    //        if(type.Equals("Cheese"))
    //        {
    //            pizza = new NYStyleCheesePizza();
    //        }

    //        return pizza;
    //    }
    //}
    //public interface IPizza
    //{
    //    void Prepare();
    //    void Bake();
    //    void Cut();
    //    void Box();
    //}
    //public class NYStyleCheesePizza : IPizza
    //{

    //    public void Prepare()
    //    {
    //        Console.WriteLine("Prepare Pizza");
    //    }

    //    public void Bake()
    //    {
    //        Console.WriteLine("Bake Pizza");
    //    }

    //    public void Cut()
    //    {
    //        Console.WriteLine("Cut Pizza");
    //    }

    //    public void Box()
    //    {
    //        Console.WriteLine("Box Pizza");
    //    }
    //}
    #endregion

}


