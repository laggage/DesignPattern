# 迭代器模式(**IteratorPattern**)

## 概述

又名游标(Cursor)模式;

通过引入迭代器，客户端无须了解聚合对象的内部结构即可实现对聚合对象中成员的遍历，还可以根据需要很方便地增加新的遍历方式;

C# java等语言已经实现好了迭代器模式, 直接使用就好了.

## 定义

迭代器模式：**提供一种方法顺序访问一个聚合对象中各个元素，且不用暴露该对象的内部表示。**

Iterator Pattern: **Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.**

## 结构

### Iterator（抽象迭代器） 
定义了访问和遍历抽象元素的接口, 声明了用于遍历数据元素的方法. 

### ConcreteIterator（具体迭代器）
### Aggregate（抽象聚合类）
用于存储和管理元素对象, 声明一个`CreateIterator`方法用于创建一个迭代器对象, 充当抽象迭代器的工厂角色.

### ConcreteAggregate（具体聚合类）


<details>
<summary>点击展开查看代码</summary>

```
namespace IteratorPattern.BaseImplement
{
    interface IIterator
    {
        void First(); //游标指向第一个元素
        void Next(); // 游标指向下一个元素
        bool HasNext();
        object CurrentItem();
    }

    class ConcreteIterator:IIterator
    {
        private ConcreteAggregate objects;  // 维持对具体聚合对象的引用, 以便于访问存储在聚合
                                            // 对象中的数据

        private int cursor;

        public void First()
        {
            // 实现代码
        }

        public void Next()
        {
            // 实现代码
        }

        public bool HasNext()
        {
            // 实现代码
        }

        public object CurrentItem()
        {
            // 实现代码
        }
    }

    abstract class Aggregate
    {

    }

    class ConcreteAggregate: Aggregate
    {

    }
}
```

</details>

## 应用实例

>某软件公司为某商场开发了一套销售管理系统，在对该系统进行分析

方法名 | 方法说明
-- | --
AbstractObjectList() | 构造方法，用于给objects对象赋值
AddObject() | 增加元素
RemoveObject() | 删除元素
GetObjects() | 获取所有元素
Next() | 移至下一个元素
IsLast() | 判断当前元素是否是最后一个元素
Previous() | 移至上一个元素
IsFirst() | 判断当前元素是否是第一个元素
GetNextItem() | 获取下一个元素
GetPreviousItem() | 获取上一个元素

> AbstractObjectList类的子类ProductList和CustomerList分别用于存储商品数据和客户数据。
通过分析，发现AbstractObjectList类的职责非常重，它既负责存储和管理数据，又负责遍历数据，违背了单一职责原则，实现代码将非常复杂。因此，开发人员决定使用迭代器模式对AbstractObjectList类进行重构，将负责遍历数据的方法提取出来，封装到专门的类中，实现数据存储和数据遍历分离，还可以给不同的具体数据集合类提供不同的遍历方式。
现给出使用迭代器模式重构后的解决方案。 

![image](https://user-images.githubusercontent.com/38829279/64261130-9b3f4080-cf5e-11e9-86f6-bf926ef8da8f.png)

### 自己实现iterator

抽象迭代器类 `IIterator` 
```
namespace IteratorPattern.Sample
{
    interface IIterator
    {
        void MoveToNext(); //移至下一个元素
        bool IsLast();
        void MoveToPrevious();
        bool IsFirst();
        object GetNextItem();
        object GetPreviousItem();
    }
}
```

抽象聚合类: `AbstractObjectList`
聚合类 `ProductList`
聚合类中有个内部类是具体迭代器类 `ProductIterator`

<details>
<summary>点击展开查看代码</summary>

```
namespace IteratorPattern.Sample
{
    using System.Collections.Generic;

    abstract class AbstractObjectList
    {
        private readonly List<object> objects;

        public AbstractObjectList(List<object> objects)
        {
            this.objects = objects;
        }

        public void AddObject(object obj)
        {
            this.objects.Add(obj);
        }

        public void RemoveObject(object obj)
        {
            this.objects.Remove(obj);
        }

        public object[] GetObjects() => this.objects.ToArray();

        public abstract IIterator CreateIterator();
    }

    class ProductList : AbstractObjectList
    {
        public ProductList():base(new List<object>())
        {
        }

        public ProductList(List<object> products) : base(products)
        {
        }

        /// <summary>
        /// 迭代器工厂方法
        /// </summary>
        /// <returns></returns>
        public override IIterator CreateIterator()
        {
            return new ProductIterator(this);
        }

        private class ProductIterator:IIterator
        {
            private int cursor;
            private readonly List<object> objects;

            public ProductIterator(ProductList productList)
            {
                this.cursor = 0;
                this.objects = new List<object>(productList.GetObjects());
            }

            public void MoveToNext()
            {
                if(!IsLast())
                    this.cursor++;
            }

            public bool IsLast()
            {
                return this.cursor == this.objects.Count - 1;
            }

            public void MoveToPrevious()
            {
                if (!IsFirst()) this.cursor--;
            }

            public bool IsFirst()
            {
                return this.objects.Count == 0;
            }

            /// <summary>
            /// 获取相对于当前位置的后一个的对象, 保持当前位置不变
            /// 如果当前位置已经是最后一个位置, 返回null
            /// </summary>
            /// <returns>相对于当前位置的后一个的对象</returns>
            public object GetNextItem()
            {
                return IsLast() ? null : this.objects[this.cursor+1];
            }

            /// <summary>
            /// 获取相对于当前位置的前一个对象, 保持当前位置不变
            /// 如果当前位置已经是第一个位置, 返回null
            /// </summary>
            /// <returns>相对于当前位置的前一个对象</returns>
            public object GetPreviousItem()
            {
                return IsFirst() ? null : this.objects[this.cursor - 1];
            }
        }
    }
}
```
</details>

客户端代码

```
ProductList productList = new ProductList();
productList.AddObject("建造者模式");
productList.AddObject("工厂方法模式");
productList.AddObject("职责链模式");
productList.AddObject("抽象工厂模式");
productList.AddObject("解释器模式");
IIterator iterator = productList.CreateIterator();
while (iterator.GetNextItem() is string item)
{
    iterator.MoveToNext();
    Console.WriteLine(item);
}
```

### 使用DotNet中已经实现好的Iterator

Dotnet中, `IEnumerable` 接口充当了抽象聚合类的角色, `IEnumerator` 接口是抽象迭代器类
```
IList<string> designPatterns =
    new List<string>
    {
        "建造者模式",
        "工厂方法模式",
        "职责链模式",
        "抽象工厂模式",
        "解释器模式",
    };

IEnumerator<string> enumerator = designPatterns.GetEnumerator();
while (enumerator.MoveNext())
{
Console.WriteLine(enumerator.Current);
}
```