namespace FactoryPattern.Beverages
{
    public enum Size
    {
        TALL,
        GRANDE,
        VENDI
    }
    internal abstract class Beverage
    {
        // A beverage that wraps another beverage shares its size, so the size can be set on the outermost beverage
        public Size Size
        {
            get { return baseBeverage != null ? baseBeverage.Size : size; }
            set
            {
                if (baseBeverage != null)
                {
                    baseBeverage.Size = value;
                }
                else
                {
                    size = value;
                }
            }
        }
        private Size size = Size.TALL; // default size

        protected string description = "Unknown";
        protected Beverage? baseBeverage = null;

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract double cost();
    }
}
