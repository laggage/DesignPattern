using DesignParttern.Shared;
using System;

namespace StrategyPattern.Sample.ShopCartCheckout
{
    class ShopCartSampleClient: ISampleClient
    {
        public void Run()
        {
            var carts = new ShopCarts();
            carts.GoodsList.Add(new Goods("家用吸尘器", 500));
            carts.GoodsList.Add(new Goods("华硕笔记本电脑(16G+512G+独立显卡)", 8999));

            carts.CheckOut(new CreditCardStrategy());
            Console.WriteLine();

            carts.GoodsList.Add(new Goods("小米10", 2999));
            carts.GoodsList.Add(new Goods("AOC显示屏", 899));
            carts.CheckOut(new PayPalStrategy());
        }

        public override string ToString()
        {
            return "策略模式实例 - 使用不同的结算方式对购物车结算";
        }
    }
}
