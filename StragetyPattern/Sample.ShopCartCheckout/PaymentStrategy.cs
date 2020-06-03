namespace StrategyPattern.Sample.ShopCartCheckout
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
}
