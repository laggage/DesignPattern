namespace StatePattern.Sample
{
    class Account
    {
        public Account()
        {
            Balance = 0;
            ChangeState();
        }

        public Account(decimal balance)
        {
            this.Balance = balance;

            ChangeState();
        }

        public Account(decimal balance, string name) : this(balance)
        {
            Name = name;
        }

        public Account(string name) : this()
        {
            Name = name;
        }

        private AccountState accountState;

        public decimal Balance { get; set; }
        public string Name { get; set; }

        private void ChangeState()
        {
            if (Balance >= 0) accountState = new NormalState(this);
            else if (Balance < 0 && Balance > -2000) accountState = new OverdraftState(this);
            else if (Balance <= -2000) accountState = new RestrictedState(this);
        }

        public void SetState(AccountState state)
        {
            accountState = state;
        }

        public void Deposit(decimal amount)
        {
            accountState.Deposit(amount);
            ChangeState();
        }

        public void WithDraw(decimal amount)
        {
            accountState.WithDraw(amount);
            ChangeState();
        }
    }
}
