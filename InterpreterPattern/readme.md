# 解释器模式(Interpreter)

## 概述

**特点:** 学习难度大, 使用频率较低
**用途:** 描述了如何使用面向对象语言构成一个简单的语言解释器.

某些情况下, 为了更好的描述某一特定类型的问题, 可以创建一种新的语言, 这种语言有自己的表达式和结构, 即文法规则, 这些问题的实例对应语言中的句子

对解释器模式的学习能够加深对面向对象编程思想的理解, 并理解编程语言中文法规则的解释过程.

正则表达式是解释器模式的一种应用;

## 定义

解释器模式：**给定一个语言，定义它的文法的一种表示，并定义一个解释器，这个解释器使用该表示来解释语言中的句子。**

Interpreter Pattern: **Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.**

## 文法规则和抽象语法树

### 文法规则
>expression ::= value | operation
operation ::= expression '+' expression | expression '-' expression
value ::= an integer //一个整数值
>
>“::=”表示“定义为”
“|”表示“或”
“{”和“}”表示“组合”
“*”表示“出现0次或多次”

### 抽象语法树

> 描述了如何构成一个复杂的句子，通过对抽象语法树的分析，可以识别出语言中的终结符类和非终结符类


![image](https://user-images.githubusercontent.com/38829279/64191632-78a01f80-ceab-11e9-9021-301aad87b24f.png)


1 + 2 + 3 – 4 + 1


## 结构

![image](https://user-images.githubusercontent.com/38829279/64175190-60210c80-ce8d-11e9-8ac8-6ec7a208e214.png)

- AbstractExpression（抽象表达式）
- TerminalExpression（终结符表达式）
- NonterminalExpression（非终结符表达式）
- Context（环境类）: 环境类又称为上下文类, 用于存储解释器之外的全局变量, 通常临时存储了需要解释的语句;

<details>
<summary>点击展开查看代码</summary>

```
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
```
</details>

## 应用

> 某软件公司要开发一套机器人控制程序，在该机器人控制程序中包含一些简单的英文控制指令，每一个指令对应一个表达式(expression)，该表达式可以是简单表达式也可以是复合表达式。每一个简单表达式由移动方向(direction)，移动方式(action)和移动距离(distance)三部分组成，其中，移动方向包括向上(up)、向下(down)、向左(left)、向右(right)；移动方式包括移动(move)和快速移动(run)；移动距离为一个正整数。两个表达式之间可以通过与(and)连接，形成复合(composite)表达式。
用户通过对图形化的设置界面进行操作可以创建一个机器人控制指令，机器人在收到指令后将按照指令的设置进行移动，例如输入控制指令“up move 5”将“向上移动5个单位”；输入控制指令“down run 10 and left move 20”将“向下快速移动10个单位再向左移动20个单位”。
现使用解释器模式来设计该程序并模拟实现。

### 文法规则
```
expression ::= direction action distance | composite //表达式
composite ::= expression 'and' expression //复合表达式
direction ::= 'up' | 'down' | 'left' | 'right' //移动方向
action ::= 'move' | 'run' //移动方式
distance ::= an integer //移动距离

终结符表达式direction、action和distance对应DirectionNode类、ActionNode类和DistanceNode类
非终结符表达式expression和composite对应SentenceNode类和AndNode类
```

### 抽象语法树

![image](https://user-images.githubusercontent.com/38829279/64191369-e7c94400-ceaa-11e9-96f7-ee53d043217f.png)

### 代码

> (1) AbstractNode：抽象结点类，充当抽象表达式角色
(2) AndNode：And结点类，充当非终结符表达式角色
(3) SentenceNode：简单句子结点类，充当非终结符表达式角色
(4) DirectionNode：方向结点类，充当终结符表达式角色
(5) ActionNode：动作结点类，充当终结符表达式角色
(6) DistanceNode：距离结点类，充当终结符表达式角色
(7) InstructionHandler：指令处理类，工具类
(8) Program：客户端测试类


<details>
<summary>点击展开查看代码</summary>

```
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
```
</details>
