using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ObserverPattern
{

    public interface ISubject
    {
        void RegisterObserver(IObserver display);
        void RemoveObserver(IObserver display);
        void NotifyObserver();
    }

    public interface IObserver
    {
        void update(float t,float h,float p);
    }

   

    public class Subject : ISubject
    {
        private ArrayList observers;
        private float humidity;
        private float temperature;
        private float pressure;

        public Subject()
        {
            observers = new ArrayList();
        }



        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            int i = observers.IndexOf(observer);
            if (i > 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void NotifyObserver()
        {
            IEnumerator iterator = observers.GetEnumerator();
            while (iterator.MoveNext())
            {
                ((IObserver)(iterator.Current)).update(temperature,humidity,pressure);
            }

        }

        public void SetMeasurement(float temp,float humidity,float pressure)
        {
            this.temperature = temp;
            this.humidity    = humidity;
            this.pressure    = pressure;
            NotifyObserver();
        }
    }

    public class Display : IObserver
    {
        public void update(float temperature, float humidity, float pressure)
        {
            Console.WriteLine("T="+temperature +" H=" + humidity + " P="+pressure);
        }
    }

    public class DisplayNew : IObserver
    {
        public void update(float temperature, float humidity, float pressure)
        {
            Console.WriteLine("Temp:" + temperature + " Hue:" + humidity + " Press:" + pressure);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            Subject subject = new Subject();
            IObserver display = new Display();
            IObserver dips1 = new DisplayNew();
            subject.RegisterObserver(dips1);
            subject.RegisterObserver(display);

            subject.SetMeasurement((float)10.2, (float)11.2, (float)13.2);

            subject.RemoveObserver(display);

            subject.SetMeasurement((float)7.2, (float)8.2, (float)9.2);
        }
    }
}
