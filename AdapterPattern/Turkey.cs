using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{

    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }


    public class WildTurkey : ITurkey
    {

        #region Turkey Members

        public void Gobble()
        {
            Console.WriteLine("This is Wild Turkey gobbling");
        }

        public void Fly()
        {
            Console.WriteLine("This is Wild Turkey flying");

        }

        #endregion
    }
}
