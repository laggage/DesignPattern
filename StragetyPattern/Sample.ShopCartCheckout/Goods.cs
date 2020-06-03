using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Sample.ShopCartCheckout
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods
    {
        public decimal Price { get; set; }
        public string Name { get; set; }

        public Goods()
        {
        }

        public Goods(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
