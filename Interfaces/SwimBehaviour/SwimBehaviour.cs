using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces.SwimBehaviour
{
    internal interface SwimBehavior
    {
        void Swim();
    }
    internal class SinkBehavior : SwimBehavior
    {
        public void Swim()
        {
            Console.WriteLine("I'm sinking!");
        }
    }

    internal class FloatBehavior : SwimBehavior
    {
        public void Swim()
        {
            Console.WriteLine("I'm floating!");
        }
    }
}
