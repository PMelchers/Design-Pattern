using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces.QuackBehavior
{
    internal interface QuackBehavior
    {
        void Quack();
    }

    internal class RegularQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack! Quack!");
        }
    }

    internal class MuteQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<< Silence >>");
        }
    }

    internal class Squeak : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak! Squeak!");
        }
    }
}
