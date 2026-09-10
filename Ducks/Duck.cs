using StrategyPattern.Interfaces.FlyBehavior;
using StrategyPattern.Interfaces.QuackBehavior;
using StrategyPattern.Interfaces.SwimBehaviour;

internal abstract class Duck
{
    protected QuackBehavior quackBehavior;
    protected FlyBehavior flyBehavior;
    protected SwimBehavior swimBehavior;

    public abstract void Display();

    public void SetQuackBehavior(QuackBehavior quackBehavior)
    {
        this.quackBehavior = quackBehavior;
    }

    public void SetFlyBehavior(FlyBehavior flyBehavior)
    {
        this.flyBehavior = flyBehavior;
    }

    public void SetSwimBehavior(SwimBehavior swimBehavior)
    {
        this.swimBehavior = swimBehavior;
    }

    public void PerformQuack()
    {
        quackBehavior.Quack();
    }
    public void PerformFly()
    {
        flyBehavior.Fly();
    }
    public void PerformSwim()
    {
        swimBehavior.Swim();
    }
}
