using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{


    public interface IDuck
    {
        void Quack();
        void Fly();
    }




    public class MallardDuck : IDuck
    {

        #region Duck Members

        public void Quack()
        {
            Console.WriteLine("This is Mallard Duck quacking");
        }

        public void Fly()
        {
            Console.WriteLine("This is Mallard Duck flying");
        }

        #endregion
    }
}
