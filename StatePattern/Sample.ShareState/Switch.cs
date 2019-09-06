namespace StatePattern.Sample.ShareState
{
    class Switch
    {
        private static SwitchState currentState,onState,offState;

        static Switch()
        {
            onState = new OnState();
            offState = new OffState();
            currentState = offState;
        }

        public Switch()
        {
        }

        public SwitchState GetState(string state)
        {
            switch(state)
            {
                case "on": return onState; 
                case "off": return offState; 
                default:return currentState; 
            }
        }

        public void SetState(SwitchState state)
        {
            currentState = state;
        }

        public void On()
        {
            currentState.On(this);
        }

        public void Off()
        {
            currentState.Off(this);
        }
    }
}
