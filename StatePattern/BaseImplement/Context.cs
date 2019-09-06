namespace StatePattern.BaseImplement
{
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
}
