using System;
using System.Collections.Generic;

namespace StrategyPattern.Sample.ShopCartCheckout
{
    public class ShopCarts
    {
        public List<Goods> GoodsList { get; private set; }

        public ShopCarts() : this(new List<Goods>())
        {
        }

        public ShopCarts(List<Goods> goodsList)
        {
            GoodsList = goodsList;
        }

        public void CheckOut(IPaymentStrategy paymentMethod)
        {
            Display();
            paymentMethod.Pay(_totalAmount);
            GoodsList.Clear();
        }

        protected void Display()
        {
            Console.WriteLine("Goods in shop carts to be payed: ");
            Console.WriteLine(new string('-', 20));
            GoodsList.ForEach(x =>
            {
                Console.WriteLine($"{x.Name}, ${x.Price}rmb");
            });
        }

        private decimal _totalAmount
        {
            get
            {
                decimal totoalAmount = 0;
                GoodsList.ForEach(x => totoalAmount += x.Price);
                return totoalAmount;
            }
        }
    }
}
