using System;
namespace StrategyPattern.Sample.MovieTicket
{
    /// <summary>
    /// 电影票
    /// </summary>
    public class MovieTicket
    {
        public decimal OriginPrice { get; }

        public string MovieName { get; set; }

        public DateTime WatchingTime { get; set; }

        public MovieTicket()
        {
        }

        public MovieTicket(string movieName, decimal originPrice)
        {
            MovieName = movieName;
            OriginPrice = originPrice;
        }

        public decimal GetDiscountedPrice(IDiscount discount)
        {
            return discount.CalculatePrice(OriginPrice);
        }

        public static IDiscount GetDiscount(Customer customer)
        {
            switch(customer.Role)
            {
                case CustomerRole.Adult: return new NoDiscount();
                case CustomerRole.Student: return new StudentDiscount();
                case CustomerRole.Children: return new ChildrenDiscount();
                default: return new NoDiscount();
            }
        }
    }
}
