using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class FactoryPattern
    {
        public B GetConcreteDoable()
        {
            return new B();
        }
    }

    public interface IDoTask
    {
        void DoTaskOne();
    }

    public class B : IDoTask
    {
        public void DoTaskOne()
        {
            Console.WriteLine("Zakończ zadanie");
        }
    }

    public class A
    {
        private IDoTask task;
        public A()
        {
            FactoryPattern fp = new FactoryPattern();
            task = fp.GetConcreteDoable();
            task.DoTaskOne();
            Console.ReadKey();
        }

        public void EndTheIssue()
        {
            task.DoTaskOne();
        }
    }


}
