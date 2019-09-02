# 代理模式

## 定义
**给某一个对象提供一个代理或占位符, 并由代理对象来控制对原对象的访问.**

例如电脑桌面的快捷方式就是一个代理对象，快捷方式是它所引用的程序的一个代理。

## 概述
软件开发中, 由于某些原因, 客户端不想或不能直接访问一个对象, 此时可以通过一个被称为"代理"的第三者来实现间接访问, 该方案对应的设计模式就是代理模式.
代理模式的应用广泛, 常见的代理形式:
1. 远程代理(Remote Proxy)
    使得客户端程序可以访问在远程主机上的对象, 远程主机可能具有更好的计算性能与处理速度.
    远程代理可以将网络的细节隐藏起来, 使得客户端不必考虑网络的存在.
    DotNet中的分布式技术如DCOM(Distribute Component Object Model, 分布式组件对象模型), Web Service中, 都应用了远程代理模式.
2. 虚拟代理(Virtual Proxy)
    对一些占用资源较多或者加载时间较长的对象, 可以用一个加载事件相对较短的代理模式对象来代表真实对象.
3. 缓冲代理(Cache Proxy)
    为某一个操作结果提供临时的缓存存储空间, 以便在后续的使用中共享这些结果. 从而避免某些方法的重复执行.
4. 保护代理
    控制一个对象的访问，可以给不同的用户提供不同级别的使用权限.
5. 智能应用代理
    当一个对象被引用时，提供一些额外的操作，比如将对此对象调用的次数记录下来等.

## 结构
1. 抽象主题角色(**Subject**)
2. 代理主题角色(**Proxy**)
    包含了对真是主题的引用, 可以在任何时候操作真实主题对象.
3. 真是主题角色(**RealSubject**)
    定义了代理角色所代表的真是对象, 真实主题角色实现了真实的业务操作

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823191751065-117793762.png)

```
namespace ProxyPattern.BaseImplement
{
    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject:Subject
    {
        public override void Request()
        {
            //业务方法具体实现代码
        }
    }


    class Proxy:Subject
    {
        private RealSubject _realSubject;

        public Proxy()
        {
            _realSubject = new RealSubject();
        }

        public void PreRequest()
        { }

        public override void Request()
        {
            PreRequest();
            _realSubject.Request();
            PostRequest();
        }

        public void PostRequest()
        { }
    }
}
```

## 应用实例
> 收费商务信息查询系统
> 进行商务信息查询之前用户需要通过身份验证, 只有合法的用户才能查询;
> 进行商务信息查询时系统需要记录查询日志, 以便根据查询次数收取查询费用;

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190824013200489-2039499006.png)

<details>
<summary>点击展开查看代码</summary>

```
namespace ProxyPattern.Searcher
{
    using System;

    interface ISearcher
    {
        string DoSearch(string userId, string keyword);
    }

    class Searcher:ISearcher
    {
        public string DoSearch(string userId, string keyword)
        {
            Console.WriteLine("用户'{0}'使用关键字'{1}'查询.", userId, keyword);
            return "具体内容";
        }
    }

    class AccessValidator
    {
        public bool Validate(string userId)
        {
            Console.WriteLine("在数据库中验证用户'{0}'是否合法", userId);
            if (userId.Equals("容儿"))
            {

                Console.WriteLine("用户{0}合法.", userId);
                return true;
            }
            else
            {
                Console.WriteLine("用户{0}非法.", userId);
                return false;
            }
        }
    }

    class Logger
    {
        public void Log(string userId)
        {
            Console.WriteLine("更新数据库, 用户{0}查询次数加一.", userId);
        }
    }

    class ProxySearcher:ISearcher
    {
        private AccessValidator _validator;
        private Logger _logger;
        private Searcher _searcher;

        public ProxySearcher()
        {
            _validator = new AccessValidator();
            _logger = new Logger();
            _searcher = new Searcher();
        }

        public string DoSearch(string userId, string keyword)
        {
            string result = string.Empty;
            if(_validator.Validate(userId))
            {
                result = _searcher.DoSearch(userId, keyword);
                _logger.Log(userId);
            }
            return result;
        }
    }
}
```
</details>

这个例子是保护代理和智能引用代理的应用, 代理类 **`ProxySearcher`** 中实现对真实主题类的 **权限控制** 和 **引用计数**.
