using DesignParttern.Shared;
using System;
using System.Reflection;

namespace CommandPattern.Sample
{
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

    class SampleClient:ISampleClient
    {
        public void Run()
        {
            // 读取配置文件确定要调用的命令
            string commandName = "CommandPattern.Sample." + Program.Configuration["CommandName"] + "Command";

            var assembly = Assembly.GetExecutingAssembly();
            var command = assembly.CreateInstance(commandName) as Command;
            var btn = new FunctionButton() { Command = command };
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
