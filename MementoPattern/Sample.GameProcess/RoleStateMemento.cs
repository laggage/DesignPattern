namespace MementoPattern.Sample.GameProcess
{
    public class RoleStateMemento
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

        public RoleStateMemento(int vatility, int atk, int defensive)
        {
            Vatility = vatility;
            ATK = atk;
            Defensive = defensive;
        }
    }
}
