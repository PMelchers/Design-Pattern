namespace DecoratorPattern.Beverages
{
    internal class Chocolate : BeverageBase
    {
        public Chocolate(Beverage? beverage = null, Size? size = null) : base("Chocolate", 1.50, beverage, size)
        {
        }
    }
}
