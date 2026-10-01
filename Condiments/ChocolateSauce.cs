using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class ChocolateSauce : CondimentDecorator
    {
        public ChocolateSauce(Beverage beverage) : base(beverage, "Chocolate", 0.30, 0.45, 0.60)
        {
        }
    }
}
