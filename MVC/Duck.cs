using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC
{

    public interface QuackObservable
    {
        void RegisterObservable(Observer observer);
        void NotifyObserver();
    }

    public interface Quackable : QuackObservable
    {
        void Quack();
    }

    public interface Observer
    {
        void Update(QuackObservable duck);
    }

    public class Observable : QuackObservable
    {
        ArrayList observers = new ArrayList();
        QuackObservable duck;

        public Observable(QuackObservable duck)
        {
            this.duck = duck;
            
        }

        public void RegisterObservable(Observer observer )
        {
            observers.Add(observer);
        }

        public void NotifyObserver()
        {
            IEnumerator iterator = observers.GetEnumerator();
            while (iterator.MoveNext())
            {
                Observer observer = (Observer)iterator.Current;
                observer.Update(this.duck);
            }
        }
    }

    #region Classes implementing Quack
    public class MallardDuck : Quackable
    {
        Observable observable;
        public MallardDuck()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Quack-M");
            NotifyObserver();
            
        }

        public void RegisterObservable(Observer observer)
        {
            observable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            observable.NotifyObserver();
        }
    }

    public class ReadHeadDuck : Quackable
    {
        Observable observable;
        public ReadHeadDuck()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Quack");
            NotifyObserver();
        }

        public void RegisterObservable(Observer observer)
        {
            observable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            observable.NotifyObserver();
        }
    }

    public class DuckCall : Quackable
    {
        Observable observable;

        public DuckCall()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Kwak");
            NotifyObserver();
        }

        public void RegisterObservable(Observer observer)
        {
            observable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            observable.NotifyObserver();
        }
    }

    public class RubberDuck : Quackable
    {
        Observable observable;

        public RubberDuck()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Squeak");
            NotifyObserver();
        }
        
        public void RegisterObservable(Observer observer)
        {
            observable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            observable.NotifyObserver();
        }
    }
    #endregion

#region aNew class
    public class Geese
    {
        public void Honk()
        {
            Console.WriteLine("Honks");
           
        }
    }
#endregion

#region adapter to adapt duck
    public class GeeseAdapter : Quackable
    {
        private Geese _goose;
        Observable observable;

        public GeeseAdapter(Geese goose)
        {
            this._goose = goose;
            observable = new Observable(this);
        }

        #region Quackable Members

        public void Quack()
        {
            _goose.Honk();
            NotifyObserver();
        }

        #endregion
        public void RegisterObservable(Observer observer)
        {
            observable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            observable.NotifyObserver();
        }
    }
#endregion

    #region Decorator to count the number of quacks
    public class QuackCounter : Quackable
    {
        Quackable duckObservable;
        //Observable observable;
        static int _quackCounter;
        public QuackCounter(Quackable duck)
        {
            this.duckObservable = duck;
            //observable = new Observable(this.duckObservable);
        }


        #region Quackable Members
        public void Quack()
        {
             duckObservable.Quack();
            
            _quackCounter++;
        }
        #endregion

        public void RegisterObservable(Observer observer)
        {
            this.duckObservable.RegisterObservable(observer);
        }

        public void NotifyObserver()
        {
            throw new Exception("Method not implemented intentionally");
        }

        static public int GetQuackCounter()
        {
            return _quackCounter;
        }
    }

    #endregion


    public abstract class AbstractDuckFactory
    {
        public abstract Quackable CreateMallardDuck();
        public abstract Quackable CreateRedHeadDuck();
        public abstract Quackable CreateDuckCall();
        public abstract Quackable CreateRubberDuck();
        public abstract Quackable CreateGeese();


    }

    public class DuckFactory : AbstractDuckFactory
    {

        public override Quackable CreateMallardDuck()
        {
            return new MallardDuck();
        }

        public override Quackable CreateRedHeadDuck()
        {
            return new ReadHeadDuck();
        }

        public override Quackable CreateDuckCall()
        {
            return new DuckCall();
        }

        public override Quackable CreateRubberDuck()
        {
            return new RubberDuck();
        }

        public override Quackable CreateGeese()
        {
            return new GeeseAdapter(new Geese());
        }
    }

    

    public class CountingDuckFactory : DuckFactory
    {

        public override Quackable CreateMallardDuck()
        {
            return new QuackCounter(new MallardDuck());
        }

        public override Quackable CreateRedHeadDuck()
        {
            return new QuackCounter(new ReadHeadDuck());
        }

        public override Quackable CreateDuckCall()
        {
            return new QuackCounter(new DuckCall());
        }

        public override Quackable CreateRubberDuck()
        {
            return new QuackCounter(new RubberDuck());
        }

        public override Quackable CreateGeese()
        {
            return new QuackCounter(new GeeseAdapter(new Geese()));
        }
    }

    public class Flock : Quackable
    {
        
       
        ArrayList quackers = new ArrayList();
        
        public Flock()
        {
           
        }
        public void Add(Quackable quacker)
        {

            quackers.Add(quacker);
             
           
        }

        public void Quack()
        {
            IEnumerator iterator =  quackers.GetEnumerator();
            
            while (iterator.MoveNext())
            {
                ((Quackable)(iterator.Current)).Quack();
            }
        }

        public void RegisterObservable(Observer observer)
        {

            IEnumerator iterator = quackers.GetEnumerator();

            while (iterator.MoveNext())
            {
                ((Quackable)(iterator.Current)).RegisterObservable(observer);
            }
        }

        public void NotifyObserver()
        {
            throw new Exception("Method not implemented intentionally");
        }

    }

    public class Quackalogist : Observer
    {

        public void Update(QuackObservable duck)
        {
            Console.WriteLine("Quackalogist:" + duck + " just quacked");
        }
    }

}
