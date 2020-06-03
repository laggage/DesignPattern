# 状态模式

## 概述

## 定义

状态模式：**允许一个对象在其内部状态改变时改变它的行为。对象看起来似乎修改了它的类。**

State Pattern: **Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.**


## 结构

![image](https://user-images.githubusercontent.com/38829279/64392899-70014200-d081-11e9-866a-d3193c7b0f8f.png)

### Context（环境类）

环境类是真正拥有状态的对象, 只是将环境类中与状态有关的代码提取出来封装到专门的状态中;
State与Context之间可能存在依赖或双向关联关系;

```csharp
/// <summary>
/// 环境类, 真正拥有状态的对象, 将环境类中于状态有关的代码提取出来封装到
/// </summary>
class Context
{
    private State state;    // 维持对抽象状态对象的引用
    private int value;  // 其他属性值, 该属性值的变化可能会导致对象状态发生变化

    public void SetState(State s)
    {
        state = s;
    }

    public void Request()
    {
        // 其他代码
        state.Handle(); // 调用状态对象的业务方法
        // 其他代码
    }
}
```

### State（抽象状态类）

典型代码

```csharp
abstract class State
{
    public abstract void Handle();
}
```

### ConcreteState（具体状态类）

典型代码

```csharp
class ConcreteState : State
{
    public override void Handle()
    {
        // 
    }
}
```

### 状态转换

1. 由环境类负责状态转换, 此时环境类还充当状态管理器(State Manager)的角色, 再环境类的业务方法中通过对某些属性值的判读, 实现状态转换;

```csharp
……
public void ChangeState()
{
    //判断属性值，根据属性值进行状态转换
    if (value == 0)
    {
	    this.SetState(new ConcreteStateA());
    }
    else if (value == 1)
    {
	    this.SetState(new ConcreteStateB());
    }
     ......
}
……
```

2. 由具体状态类负责状态之间的转换, 可以再具体状态类的业务方法中判断环境类的某些属性值, 再根据情况为环境类设置新的状态对象, 实现状态转换;

```csharp
     ……
public void ChangeState(Context ctx) 
{
    //根据环境对象中的属性值进行状态转换
    if (ctx.Value == 1) 
    {
        ctx.SetState(new ConcreteStateB());
    }
    else if (ctx.Value == 2) 
    {
        ctx.SetState(new ConcreteStateC());
    }
......
}
……

```

## 应用实例

### 银行账户

> 某软件公司要为一银行开发一套信用卡业务系统，银行账户(Account)是该系统的核心类之一，通过分析，该软件公司开发人员发现在系统中账户存在3种状态，且在不同状态下账户存在不同的行为，具体说明如下：
(1) 如果账户中余额大于等于0，则账户的状态为正常状态(Normal State)，此时用户既可以向该账户存款也可以从该账户取款；
(2) 如果账户中余额小于0，并且大于-2000，则账户的状态为透支状态(Overdraft State)，此时用户既可以向该账户存款也可以从该账户取款，但需要按天计算利息；
(3) 如果账户中余额等于-2000，那么账户的状态为受限状态(Restricted State)，此时用户只能向该账户存款，不能再从中取款，同时也将按天计算利息；
(4) 根据余额的不同，以上3种状态可发生相互转换。
现使用状态模式设计并实现银行账户状态的转换。

`Account` 类, 环境类, 同时充当状态管理器

<details>
<summary>点击展开查看代码</summary>

```
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

        public Account(string name):this()
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
```
</details>

`AccountState`, `NormalState`, `OverdraftState`, `RestrictedState`状态类

<details>
<summary>点击展开查看代码</summary>

```csharp
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
```
</details>

客户端调用

```csharp
Account acc = new Account("李逍遥");
    acc.Deposit(1000);
    acc.WithDraw(2000);
    acc.WithDraw(1000);
    acc.WithDraw(500);
```
