using DecoratorPattern.Beverages;
namespace DecoratorPattern.Condiments
{
    internal class Liquor : CondimentDecorator
    {
        public Liquor(Beverage beverage)
        {
            this.baseBeverage = beverage;
        }

        public override double cost()
        {
            double extra = PriceBySize(0.70, 0.90, 1.10);
            return extra + baseBeverage.cost();
        }

        public override string GetDescription()
        {
            return baseBeverage.GetDescription() + ", Liquor";
        }
    }
}
