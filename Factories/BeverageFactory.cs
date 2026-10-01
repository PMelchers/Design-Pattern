using FactoryPattern.Beverages;

namespace FactoryPattern.Factories
{
    internal abstract class BeverageFactory
    {
        // Every factory orders a beverage in the same way: create it and set its size
        public Beverage OrderBeverage(CoffeeType type, Size size = Size.TALL)
        {
            Beverage beverage = CreateBeverage(type);
            beverage.Size = size;
            return beverage;
        }

        // Factory method: subclasses decide which beverages they can make
        protected abstract Beverage CreateBeverage(CoffeeType type);
    }
}
