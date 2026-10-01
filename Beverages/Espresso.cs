namespace DecoratorPattern.Beverages
{
    internal class Espresso : BeverageBase
    {
        public Espresso(Beverage? beverage = null, Size? size = null) : base("Espresso", 1.99, beverage, size)
        {
        }
    }
}
