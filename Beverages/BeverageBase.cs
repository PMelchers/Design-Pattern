namespace FactoryPattern.Beverages
{
    // A beverage that can serve as the base of a drink (Espresso, Chocolate, ...)
    // It can also be combined with another beverage, e.g. a Doppio is an Espresso on top of an Espresso
    internal abstract class BeverageBase : Beverage
    {
        private readonly double price;

        protected BeverageBase(string description, double price, Beverage? beverage = null, Size? size = null)
        {
            this.description = description;
            this.price = price;
            this.baseBeverage = beverage;

            if (beverage == null && size.HasValue)
            {
                Size = size.Value;
            }
        }

        public override string GetDescription()
        {
            if (baseBeverage != null)
            {
                return baseBeverage.GetDescription() + ", " + description;
            }
            return description;
        }

        public override double cost()
        {
            if (baseBeverage != null)
            {
                return price + baseBeverage.cost();
            }
            return price;
        }
    }
}
