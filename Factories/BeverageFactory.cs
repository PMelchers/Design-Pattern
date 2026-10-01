using FactoryPattern.Beverages;

namespace FactoryPattern.Factories
{
    internal abstract class BeverageFactory
    {
        public Beverage OrderBeverage(CoffeeType type, Size size = Size.TALL)
        {
            Beverage beverage = CreateBeverage(type);
            beverage.Size = size;
            return beverage;
        }

        protected abstract Beverage CreateBeverage(CoffeeType type);
    }
}
