using FactoryPattern.Beverages;
using FactoryPattern.Factories;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BeverageFactory factory = new CoffeeFactory();

            foreach (CoffeeType type in Enum.GetValues<CoffeeType>())
            {
                Console.Write(type + ": ");
                PrintBeverage(factory.OrderBeverage(type));
            }

            Console.WriteLine();
            Console.WriteLine("Mocha in all sizes:");
            foreach (Size size in Enum.GetValues<Size>())
            {
                Console.Write(size + ": ");
                PrintBeverage(factory.OrderBeverage(CoffeeType.Mocha, size));
            }
        }

        static void PrintBeverage(Beverage beverage)
        {
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.cost().ToString("#.##"));
        }
    }
}
