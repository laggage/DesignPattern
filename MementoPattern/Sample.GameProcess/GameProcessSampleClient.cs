using DesignParttern.Shared;
using System;

namespace MementoPattern.Sample.GameProcess
{
    public class GameProcessSampleClient : ISampleClient
    {
        public void Run()
        {
            var gameRole = new GameRole(100, 100, 100);
            var careTaker = new RoleStateCaretaker();
            Console.WriteLine("---------- 初始状态 ---------");
            gameRole.DisplayState();
            gameRole.Fight();

            Console.WriteLine("---------- 保存进度 ----------");
            careTaker.RoleState = gameRole.CreateRoleStateMemento();
            Console.WriteLine();

            gameRole.Fight();

            Console.WriteLine("---------- 恢复进度 ----------");
            gameRole.RestoreState(careTaker.RoleState);
            gameRole.DisplayState();
        }

        public override string ToString()
        {
            return "备忘录模式实例 - 保存游戏进度"; ;
        }
    }
}
