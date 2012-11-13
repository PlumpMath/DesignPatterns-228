using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{

    public class DuckAdapter : ITurkey
    {
        private IDuck duck;
        public DuckAdapter(IDuck duck)
        {
            this.duck = duck;
        }


        #region ITurkey Members

        public void Gobble()
        {
            duck.Quack();
        }

        public void Fly()
        {
            duck.Fly();
        }

        #endregion
    }

    public class TurkeyAdapter : IDuck
    {
        private ITurkey turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }

        #region Duck Members

        public void Quack()
        {
            this.turkey.Gobble();
            
        }

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.turkey.Fly();
            }
        }

        #endregion

       
    }

    public class ClassAdapter : WildTurkey,IDuck

    {
        private ITurkey turkey;

        public ClassAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }

        #region IDuck Members

        public void Quack()
        {
            turkey.Gobble();
        }

        #endregion
    }



    class Program
    {
        static void Main(string[] args)
        {

            //Mallard duck is the target class which is derived from IDuck
            //WildTurkey is the adaptee derived from ITurkey
            //TurkeyAdapter is the adapter which adapts to IDuck which client knows so implements IDuck
            //But since the behaviour is of type WildTurkey an instance of  WildTurkey is passed in the constuctor.

            /*If we have a third party API and client does not know about these api's then we can come up with the class 
             which is derived from the class known to the client and provide a constructor which takes the third party API instance
             Each of the methods in the known class will be modified to call the third pary api.*/

            Console.WriteLine("\nThis is Mallard actions:");
            IDuck mallardDuck = new MallardDuck();
            mallardDuck.Quack();
            mallardDuck.Fly();

            Console.WriteLine("\nThis is Wild Turkey actions:");
            ITurkey wildTurkey = new WildTurkey();
            wildTurkey.Gobble();
            wildTurkey.Fly();

            \
            IDuck turkeyAdapter = new TurkeyAdapter(wildTurkey);
            Console.WriteLine("\nThis is Duck Adapter actions:");
            TestDuck(turkeyAdapter);
            
           
            DuckAdapter duckAdapter = new DuckAdapter(mallardDuck);
            Console.WriteLine("\nThis is Turkey Adapter actions:");
            TestDuck(duckAdapter);

            IDuck classAdapter = new ClassAdapter(wildTurkey);
            Console.WriteLine("\nThis is class Adapter actions:");
            TestDuck(classAdapter);

            Console.ReadLine();

        }

        static void TestDuck(IDuck duckInterface)
        {
            duckInterface.Quack();
            duckInterface.Fly();
        }

        static void TestDuck(ITurkey turkeyInterface)
        {
            turkeyInterface.Gobble();
            turkeyInterface.Fly();
        }

        
    }
}
