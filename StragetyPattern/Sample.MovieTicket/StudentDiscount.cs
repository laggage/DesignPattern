namespace StrategyPattern.Sample.MovieTicket
{
    public class StudentDiscount : IDiscount
    {
        public decimal CalculatePrice(decimal originPrice)
        {
            return originPrice * 0.8M;
        }
    }
}
