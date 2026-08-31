using StrategyPattern.Interfaces.FlyBehavior;
using StrategyPattern.Interfaces.QuackBehavior;
using StrategyPattern.Interfaces.SwimBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Ducks
{
    internal class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new RegularQuack();
            flyBehavior = new FlyWithWings();
            swimBehavior = new FloatBehavior();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a Mallard Duck");
        }
    }
}
