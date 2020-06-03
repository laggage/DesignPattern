using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Sample.ShopCartCheckout
{
    public class PayPalStrategy : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"您正在使用Paypal结算, 支付金额: {amount}");
        }
    }
}
