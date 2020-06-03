namespace StrategyPattern.Sample.MovieTicket
{
    public class VIPDiscount : IDiscount
    {
        public decimal CalculatePrice(decimal originPrice)
        {
            return originPrice / 2;
        }
    }
}
