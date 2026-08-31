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
    internal class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new MuteQuack();
            swimBehavior = new FloatBehavior();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a Decoy Duck");
        }
    }
}
