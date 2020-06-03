namespace StrategyPattern.Sample.MovieTicket
{
    public class ChildrenDiscount: IDiscount
    {
        public decimal CalculatePrice(decimal originPrice)
        {
            return originPrice > 20 ? originPrice - 10 : originPrice;
        }
    }
}
