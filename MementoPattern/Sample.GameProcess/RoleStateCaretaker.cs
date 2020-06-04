namespace MementoPattern.Sample.GameProcess
{
    public class RoleStateCaretaker
    {
        public RoleStateMemento RoleState { get; set; }

        public RoleStateCaretaker(RoleStateMemento roleState)
        {
            RoleState = roleState;
        }

        public RoleStateCaretaker()
        {
        }
    }
}
