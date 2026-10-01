using FactoryPattern.Beverages;

namespace FactoryPattern.Condiments
{
    internal class VanillaSugar : CondimentDecorator
    {
        public VanillaSugar(Beverage beverage) : base(beverage, "Vanilla Sugar", 0.10, 0.15, 0.20)
        {
        }
    }
}
