using DesignParttern.Shared;
using System;
using System.Collections.Generic;

namespace StrategyPattern.Sample.MovieTicket
{
    class MovieTicketSampleClient : ISampleClient
    {
        private Customer _curCustomer = null;

        public void Run()
        {
            var movieTickets = new List<MovieTicket>()
            {
                new MovieTicket("复仇者联盟", 29.9m),
                new MovieTicket("钢铁侠3", 29.9m),
                new MovieTicket("港囧", 19.9m),
                new MovieTicket("囧妈", 39.9m),
                new MovieTicket("决战紫禁城", 9.9m),
            };

            while(_curCustomer == null) SetCustomer();

            Console.WriteLine($"Current user: {_curCustomer.Role}");
            Console.WriteLine(new string('-', 20));
            movieTickets.ForEach(t =>
            {
                Console.WriteLine(
                    $"ticket: {t.MovieName}, Origin Price: ${t.OriginPrice}, Discount Price: {t.GetDiscountedPrice(MovieTicket.GetDiscount(_curCustomer))}");
            });
        }

        private void SetCustomer()
        {
            string[] roles = new string[] { "儿童", "学生", "成年人" };
            Console.WriteLine("Please input role of customer: ");
            for (int i = 0; i < roles.Length; i++)
                Console.WriteLine($"{i}. {roles[i]}");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index))
                _curCustomer = Customer.CreateCustomer(roles[index]);
        }

        public override string ToString()
        {
            return "策略模式实例 - 对不同的人群采用不同的折扣出售电影票";
        }
    }
}
