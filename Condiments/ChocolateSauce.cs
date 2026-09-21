using DecoratorPattern.Beverages;
namespace DecoratorPattern.Condiments
{
    internal class ChocolateSauce : CondimentDecorator
    {
        public ChocolateSauce(Beverage beverage)
        {
            this.baseBeverage = beverage;
        }

        public override double cost()
        {
            double extra = PriceBySize(0.30, 0.45, 0.60);
            return extra + baseBeverage.cost();
        }

        public override string GetDescription()
        {
            return baseBeverage.GetDescription() + ", Chocolate";
        }
    }
}
