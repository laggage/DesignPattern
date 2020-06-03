using System;

namespace StrategyPattern.Sample.ShopCartCheckout
{
    public class CreditCardStrategy:IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"您正在使用信用卡结算, 支付金额: {amount}");
        }
    }
}
