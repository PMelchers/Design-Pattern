using FactoryPattern.Beverages;
using FactoryPattern.Factories;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BeverageFactory factory = new CoffeeFactory();

            // Order one of every coffee variant, only through the factory
            foreach (CoffeeType type in Enum.GetValues<CoffeeType>())
            {
                Console.Write(type + ": ");
                PrintBeverage(factory.OrderBeverage(type));
            }

            // The price of the condiments depends on the size of the beverage
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
