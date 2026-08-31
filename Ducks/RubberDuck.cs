using System;
using StrategyPattern.Interfaces.FlyBehavior;
using StrategyPattern.Interfaces.QuackBehavior;
using StrategyPattern.Interfaces.SwimBehaviour;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Ducks
{
    internal class RubberDuck : Duck
    {
        public RubberDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Squeak();
            swimBehavior = new FloatBehavior();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a Rubber Duck");
        }
    }
}
