using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    class DuckSimulator
    {
        static void Main(string[] args)
        {
            DuckSimulator simulator = new DuckSimulator();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();
            simulator.Simulate(duckFactory);
        }

        void Simulate(AbstractDuckFactory duckFactory)
        {

            Quackable mallardDuck = duckFactory.CreateMallardDuck();
            Quackable redHeadDuck = duckFactory.CreateRedHeadDuck();
            Quackable duckCall = duckFactory.CreateDuckCall();
            Quackable rubberDuck = duckFactory.CreateRubberDuck();
            Quackable gooseAdapter = duckFactory.CreateGeese();// new GeeseAdapter(new Geese());

            Flock duckFlock = new Flock();
            duckFlock.Add(mallardDuck);
            duckFlock.Add(redHeadDuck);
            duckFlock.Add(duckCall);
            duckFlock.Add(rubberDuck);
            duckFlock.Add(gooseAdapter);


            Flock mallardFlock = new Flock();
            mallardFlock.Add(duckFactory.CreateMallardDuck());
            mallardFlock.Add(duckFactory.CreateMallardDuck());
            mallardFlock.Add(duckFactory.CreateMallardDuck());
            mallardFlock.Add(duckFactory.CreateMallardDuck());
           
            //again add the mallard to duck flock
            duckFlock.Add(mallardFlock);

            //Quackalogist qmallard = new Quackalogist();
            //MallardDuck malldck = new MallardDuck();
            //malldck.RegisterObservable(qmallard);
            //Simulate(malldck);


            //Quackalogist quackalogist = new Quackalogist();
            //Quackable mallardDuckDec = new QuackCounter(new MallardDuck());
            //mallardDuckDec.RegisterObservable(quackalogist);
            //Simulate(mallardDuckDec);

            Quackalogist quackalogistFlock = new Quackalogist();
            duckFlock.RegisterObservable(quackalogistFlock);


            Console.WriteLine("\nPrinting duckflock+ mallardflock");
            Simulate(duckFlock);


            Console.WriteLine("\nPrinting mallardflock");
            //mallardFlock.RegisterObservable(quackalogistFlock);
            Simulate(mallardFlock);

            Console.WriteLine(QuackCounter.GetQuackCounter());

        }

        void Simulate(Quackable duck)
        {
            duck.Quack();

            
        }

        
    }

   
}
