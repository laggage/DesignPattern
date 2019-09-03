namespace InterpreterPattern.Sample
{
    using System.Collections.Generic;

    class ActionNode : AbstractNode
    {
        private static Dictionary<string, string> ActionDict;

        private readonly string action;

        static ActionNode()
        {
            ActionDict = new Dictionary<string, string>
            {
                {"move","移动" },
                {"run","快速移动" }
            };
        }

        public ActionNode(string action)
        {
            this.action = action;
        }

        public override string Interpret()
        {
            return ActionDict[this.action];
        }
    }

    class DistanceNode: AbstractNode
    {
        private readonly string distance;

        public DistanceNode(string distance)
        {
            this.distance = distance;
        }

        public override string Interpret()
        {
            return this.distance + "米";
        }
    }

    class DirectionNode: AbstractNode
    {
        private static Dictionary<string, string> DirectionDict;

        private readonly string direction;

        static DirectionNode()
        {
            DirectionDict = new Dictionary<string, string>
            {
                {"up","向上" },
                {"left","向左" },
                {"down","向下" },
                {"right","向右" }
            };
        }

        public DirectionNode(string direction)
        {
            this.direction = direction;
        }

        public override string Interpret()
        {
            return DirectionDict[this.direction];
        }
    }
}
