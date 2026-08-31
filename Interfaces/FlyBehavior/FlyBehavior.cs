using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces.FlyBehavior
{
    internal interface FlyBehavior
    {
        void Fly();
    }

    internal class FlyWithWings : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with wings!");
        }
    }

    internal class FlyNoWay : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly!");
        }
    }
}
