using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestPattern
{
    /// <summary>
    /// 
    /// </summary>
    public interface FirstInterface
    {
        void Method1();
        void Method2();
    }

    public interface SecondInterface : FirstInterface
    {
        void Method3();
    }


    public class SecondImpl : SecondInterface
    {

        #region SecondInterface Members

        public void Method3()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region FirstInterface Members

        public void Method1()
        {
            throw new NotImplementedException();
        }

        public void Method2()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Test Multiple inheritance
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            FirstInterface x = new SecondImpl();
        }
    }
}
