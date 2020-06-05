# 命令模式(Command Pattern)

## 概述

命令模式可以将请求发送者和接收者完全解耦, 发送者和接收者之间没有直接的引用关系, 发送请求的对象只需要知道如何发送请求, 而不必知道如何完成请求. 
命令模式是一种对象行为型模式, 别名为动作模式(**Action**)或事物(**Transaction**)模式.

命令模式的本质是对请求进行封装. 一个请求对应于一个命令，将发出命令的责任和执行命令的责任分开.

## 定义

命令模式：**将一个请求封装为一个对象，从而让你可以用不同的请求对客户进行参数化，对请求排队或者记录请求日志，以及支持可撤销的操作。**

Command Pattern: **Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.**

## 结构和实现

- Command（抽象命令类）
- ConcreteCommand（具体命令类）
- Invoker（调用者）
- Receiver（接收者）

![image](https://user-images.githubusercontent.com/38829279/64145242-85405b80-ce4a-11e9-98e3-cb87c18df8c0.png)

```csharp
namespace CommandPattern.BaseImplement
{
    abstract class Command
    {
        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        private Receiver _receiver;

        public override void Execute()
        {
            _receiver.Action();
        }
    }

    class Invoker
    {
        public Command Command { get; set; }

        public void Invoke()
        {
            Command?.Execute();
        }
    }

    class Receiver
    {
        public void Action()
        {
        }
    }
}
```

## 应用实例

> 为了用户使用方便，某系统提供了一系列功能键，用户可以自定义功能键的功能，例如功能键FunctionButton可以用于退出系统（由SystemExitClass类来实现），也可以用于显示帮助文档（由DisplayHelpClass类来实现）。
用户可以通过**修改配置文件**来改变功能键的用途，现使用命令模式来设计该系统，使得功能键类与功能类之间解耦，可为同一个功能键设置不同的功能。

![image](https://user-images.githubusercontent.com/38829279/64173537-1be03d00-ce8a-11e9-9178-48e9e991d35d.png)


<details>
<summary>点击展开查看代码</summary>

```csharp
namespace CommandPattern.Sample
{
    using System;
    using System.Reflection;

    class SystemExitHelper
    {
        public static void Exit()
        {
            Console.WriteLine("Exit. ");
        }
    }

    class HelpInfoDisplayer
    {
        public static void DisplayHelpInfo(string text = "")
        {
            Console.WriteLine("Help document display\r\n {0}", text);
        }
    }

    class FunctionButton
    {
        public Command Command { get; set; }

        public void Click()
        {
            Console.WriteLine("Console button clicked. Execute command: \r\n{0}", Command.GetType().FullName);
        }
    }

    abstract class Command
    {
        public abstract void Execute();
    }

    class DisplayHelpInfoCommand : Command
    {
        public override void Execute()
        {
            HelpInfoDisplayer.DisplayHelpInfo("--version, show app version. ");
        }
    }

    class ExitSystemCommand : Command
    {
        public override void Execute()
        {
            SystemExitHelper.Exit();
        }
    }

    class SampleClient
    {
        public static void Run()
        {
            // 读取配置文件确定要调用的命令
            string commandName = "CommandPattern.Sample." + Program.Configuration["CommandName"] + "Command";

            Assembly assembly = Assembly.GetExecutingAssembly();
            Command command = assembly.CreateInstance(commandName) as Command;
            FunctionButton btn = new FunctionButton() { Command = command };
            btn.Click();

            // 读取配置文件另一种方法
            //string commandName = "CommandPattern.Sample." + Program.Configuration["CommandName"] + "Command";
            //Type type = Type.GetType(commandName);
            //Command command = type.Assembly.CreateInstance(type.FullName) as Command;
            //FunctionButton btn = new FunctionButton() { Command = command };
            //btn.Click();
        }
    }
}

namespace CommandPattern
{
    using System.IO;
    using CommandPattern.Sample;
    using Microsoft.Extensions.Configuration;

    class Program
    {
        private static readonly IConfigurationBuilder _configurationBuilder;

        public static IConfigurationRoot Configuration { get; }

        static Program()
        {
            _configurationBuilder = new ConfigurationBuilder();
            Configuration = _configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json",true,true)
                .Build();
        }

        static void Main(string[] args)
        {
            SampleClient.Run();
        }
    }
}
```
</details>
