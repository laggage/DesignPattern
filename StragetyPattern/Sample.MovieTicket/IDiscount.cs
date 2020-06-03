namespace StrategyPattern.Sample.MovieTicket
{
    public interface IDiscount
    {
        decimal CalculatePrice(decimal originPrice);
    }
}
