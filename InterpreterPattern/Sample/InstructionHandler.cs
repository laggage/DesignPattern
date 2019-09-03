namespace InterpreterPattern.Sample
{
    using System;
    using System.Collections.Generic;

    class InstructionHandler
    {
        public void Handle(string instruction)
        {
            string[] words = instruction.Split(" ");
            Stack<AbstractNode> nodeStack = new Stack<AbstractNode>();
            AbstractNode action = null, direction = null, distance = null;
            AbstractNode left = null, right = null, and = null;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Equals("and",StringComparison.OrdinalIgnoreCase))
                {
                    left = nodeStack.Pop();
                    direction = new DirectionNode(words[++i]);
                    action = new ActionNode(words[++i]);
                    distance = new DistanceNode(words[++i]);
                    right = new SentenceNode(action, direction, distance);
                    and = new AndNode(left, right);
                    nodeStack.Push(and);
                }
                else
                {
                    direction = new DirectionNode(words[i]);
                    action = new ActionNode(words[++i]);
                    distance = new DistanceNode(words[++i]);
                    right = new SentenceNode(action, direction, distance);
                    nodeStack.Push(right);
                }
            }

            string res = nodeStack.Pop().Interpret();
            Console.WriteLine(res);
        }
    }

    class SampleClient
    {
        public static void Run()
        {
            Console.WriteLine("Input instruction(direction(up|down|left|right) action(move|run) distance(0-*)): ");
            string instruction = Console.ReadLine();
            InstructionHandler handler = new InstructionHandler();
            try
            {
                handler.Handle(instruction);
            }
            catch(Exception)
            {
                Console.WriteLine("Bad instructions");
            }
        }
    }
}
