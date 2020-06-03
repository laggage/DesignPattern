using System;

namespace StrategyPattern.Sample.MovieTicket
{
    public enum CustomerRole
    {
        Student,
        Children,
        Adult
    }

    public class Customer
    {
        public CustomerRole Role { get; private set; }

        public Customer(CustomerRole role)
        {
            Role = role;
        }

        public static Customer CreateCustomer(string role)
        {
            switch(role)
            {
                case "儿童": return new Customer(CustomerRole.Children);
                case "学生": return new Customer(CustomerRole.Student);
                case "成年人": return new Customer(CustomerRole.Adult);
                default: throw new ArgumentException($"不存在的顾客角色-{role}");
            }
        }
    }
}
