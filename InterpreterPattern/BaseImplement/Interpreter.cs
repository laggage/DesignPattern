namespace InterpreterPattern.BaseImplement
{
    using System.Collections;

    class Context
    {
        private readonly Hashtable hashTable;

        public Context()
        {
            this.hashTable = new Hashtable();
        }

        public void Assign(string key,string value)
        {
            this.hashTable.Add(key, value);
        }

        public string Lookup(string key) => this.hashTable[key] as string;
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context ctx);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context ctx)
        {
        }
    }

    class NonTerminalExpression : AbstractExpression
    {
        private AbstractExpression left;
        private AbstractExpression right;

        public NonTerminalExpression(AbstractExpression left, AbstractExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Interpret(Context ctx)
        {
        }
    }
}
