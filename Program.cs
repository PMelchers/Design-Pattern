using StrategyPattern.Ducks;
using StrategyPattern.Interfaces.FlyBehavior;

namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duck mallardDuck = new MallardDuck();
            Duck redheadDuck = new RedheadDuck();
            Duck decoyDuck = new DecoyDuck();
            Duck rubberDuck = new RubberDuck();
            Duck robotDuck = new RobotDuck();

            Console.WriteLine("Mallard Duck:");
            mallardDuck.Display();
            mallardDuck.PerformQuack();
            mallardDuck.PerformFly();
            mallardDuck.PerformSwim();

            Console.WriteLine("Redhead Duck:");
            redheadDuck.Display();
            redheadDuck.PerformQuack();
            redheadDuck.PerformFly();
            redheadDuck.PerformSwim();

            Console.WriteLine("Decoy Duck.");
            decoyDuck.Display();
            decoyDuck.PerformQuack();
            decoyDuck.PerformFly();
            decoyDuck.PerformSwim();

            Console.WriteLine("Rubber Duck:");
            rubberDuck.Display();
            rubberDuck.PerformQuack();
            rubberDuck.PerformFly();
            rubberDuck.PerformSwim();

            Console.WriteLine("Robot Duck:");
            robotDuck.Display();
            robotDuck.PerformQuack();
            robotDuck.PerformFly();
            robotDuck.PerformSwim();
        }
    }
}