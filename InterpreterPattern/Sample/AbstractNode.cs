namespace InterpreterPattern.Sample
{
    using System.Collections.Generic;

    abstract class AbstractNode
    {
        public abstract string Interpret();
    }

    class AndNode: AbstractNode
    {
        private AbstractNode Left { get; set; }
        private AbstractNode Right { get; set; }

        public AndNode()
        {
        }

        public AndNode(AbstractNode left, AbstractNode right)
        {
            Left = left;
            Right = right;
        }

        public override string Interpret()
        {
            return Left.Interpret() + " -> " + Right.Interpret();
        }
    }

    class SentenceNode : AbstractNode
    {
        private static Dictionary<string, string> ActionDict;
        

        private readonly AbstractNode action;
        private readonly AbstractNode direction;
        private readonly AbstractNode distance;

        public SentenceNode(AbstractNode action, AbstractNode direction, AbstractNode distance)
        {
            this.action = action;
            this.direction = direction;
            this.distance = distance;
        }

        public override string Interpret()
        {
            return this.direction.Interpret() + this.action.Interpret() + this.distance.Interpret();
        }
    }
}
