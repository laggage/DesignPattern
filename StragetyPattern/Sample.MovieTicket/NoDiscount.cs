namespace StrategyPattern.Sample.MovieTicket
{
    public class NoDiscount:IDiscount
    {
        public decimal CalculatePrice(decimal originPrice) => originPrice;
    }
}
