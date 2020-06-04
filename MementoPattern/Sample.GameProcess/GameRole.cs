using System;

namespace MementoPattern.Sample.GameProcess
{
    public class GameRole
    {
        /// <summary>
        /// 生命力
        /// </summary>
        public int Vatility { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int ATK { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defensive { get; set; }

        public GameRole(int vatility, int atk, int defensive)
        {
            Vatility = vatility;
            ATK = atk;
            Defensive = defensive;
        }

        public GameRole()
        {
        }

        public void DisplayState()
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"生命: {Vatility}; 攻击力: {ATK}; 防御: {Defensive}\r\n");
        }

        public void Fight()
        {
            Console.WriteLine("Fighting...");
            Vatility = Vatility > 10 ? Vatility - 10 : Vatility;
            ATK = ATK > 10 ? ATK - 10 : ATK;
            Defensive = Defensive > 10 ? Defensive - 10 : Defensive;
            DisplayState();
        }

        /// <summary>
        /// 保存状态
        /// </summary>
        /// <returns></returns>
        public RoleStateMemento CreateRoleStateMemento()
        {
            return new RoleStateMemento(Vatility, ATK, Defensive);
        }

        /// <summary>
        /// 恢复状态
        /// </summary>
        public void RestoreState(RoleStateMemento memento)
        {
            Vatility = memento.Vatility;
            ATK = memento.ATK;
            Defensive = memento.Defensive;
        }
    }
}
