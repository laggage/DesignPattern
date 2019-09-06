namespace StatePattern.Sample
{
    using System;

    abstract class AccountState
    {
        protected readonly Account account;

        public AccountState(Account account)
        {
            this.account = account;
        }

        public abstract void Deposit(decimal amount);
        public abstract void WithDraw(decimal amount);
    }

    class NormalState : AccountState
    {
        public NormalState(Account account):base(account)
        {
        }

        public override void Deposit(decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine("正常状态 - 存款: {0}, 余额: {1}", amount, account.Balance);
        }

        public override void WithDraw(decimal amount)
        {
            account.Balance -= amount;
            Console.WriteLine("正常状态 - 取款: {0}, 余额: {1}", amount, account.Balance);
        }
    }

    class OverdraftState : AccountState
    {
        public OverdraftState(Account account) : base(account)
        {
        }

        public override void Deposit(decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine("透支状态 - 存款: {0}, 余额: {1}", amount, account.Balance);
        }

        public override void WithDraw(decimal amount)
        {
            account.Balance -= amount;
            Console.WriteLine("透支状态 - 取款: {0}, 余额: {1}", amount, account.Balance);
        }
    }

    class RestrictedState : AccountState
    {
        public RestrictedState(Account account) : base(account)
        {
        }

        public override void Deposit(decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine("受限状态 - 存款: {0}, 余额: {1}", amount, account.Balance);
        }

        public override void WithDraw(decimal amount)
        {
            Console.WriteLine("受限状态 - 无法取款, 余额: {0}", account.Balance);
        }
    }
}
