## 原型模式(Prototype Pattern)

### 定义

用原型实例指定创建对象的种类, 并且通过拷贝这些原型创建新的对象.

### 结构

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821214443004-1827415954.png)

### .net中原型模式的实现

.net中System名称空间下有一个 `ICloneable` 接口, 继承并实现该接口, 也就实现原型模式了. 
`ICloneable` 接口相当于原型模式中的 `Prototype` 这个抽象类

#### .net中实现了ICloneable接口的类
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821214636857-656694395.png)

### 应用实例
#### 简历(简单的浅复制)

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822030002781-565088620.png)

实现代码:
```
namespace PrototypePattern.Resume
{
    using System;

    public class Resume:ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string  Sex { get; set; }


        public string Company { get; set; }
        public string TimeArea { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine("{0},{1}岁,{2};工作经历:{3},{4}", Name, Age, Sex,TimeArea,Company);
        }
    }
}

```

结果:
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822025852949-1610531331.png)

这个例子由于`Resume` 类的成员变量全部是 `string` 等值类型的变量, 所以不存在任何问题.

下面这个 `Resume` 有一个引用类型的成员的成员变量 `WorkExperience`
```
namespace PrototypePattern.Resume.DeepClone
{
    using System;

    public class WorkExperience
    {
        public string Company { get; set; }
        public string TimeArea { get; set; }
    }

    public class Resume : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public WorkExperience WorkExperience { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

```

此时, Clone 方法中 调用 `MemberwiseClone` 复制的 `WorkExperience` 只是复制的引用, 而不是复制的值, 因此复制后的对象中和原对象中使用的是同一个 `WorkExperience`. 

### 深克隆解决方案

1. 序列化
```
namespace PrototypePattern.Resume.DeepClone
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public class WorkExperience
    {
        public string Company { get; set; }
        public string TimeArea { get; set; }
    }

    [Serializable]
    public class Resume : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public WorkExperience WorkExperience { get; set; }

        public object Clone()
        {
            Resume clone = null;

            Stream ms = new MemoryStream(100);
            BinaryFormatter matter = new BinaryFormatter();

            try
            {
                matter.Serialize(ms, this);
                ms.Position = 0;
                clone = matter.Deserialize(ms) as Resume;
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }

            return clone;
        }

        public void Display()
        {
            Console.WriteLine(
                "{0},{1}岁,{2};工作经历:{3},{4}", 
                Name, Age, Sex, WorkExperience.TimeArea, WorkExperience.Company);
        }
    }
}
```

将要克隆的类标记为 `Serializable` , 然后在克隆方法中, 将自身序列化后再反序列化出来, 就得到了深复制的自身的对象.

**ps**: 此方法必须将相关的类标记为 `Serializable`

2. 硬核复制复杂对象
在clone方法中直接手动复制引用类型成员的各个属性..., 就不放代码了

3. 为引用类型变量实现ICloneable接口
很简单的
```
public object Clone()
{
    Resume clone = this.MemberwiseClone() as Resume;
    clone.WorkExperience = this.WorkExperience.Clone() as WorkExperience;
    return clone;
}
```

**总之, 具体问题再具体分析....**

