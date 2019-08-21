## 产品等级结构与产品族

工厂方法模式通过引入工厂等级结构, 解决了简单工厂模式中工厂类职责过重的问题, 但是由于每个具体的工厂只有一个或一组重载的工厂方法, 可能导致系统中存在大量的工厂类, 势必增加系统的开销. 
有时, 可能需要一个工厂能够提供多种产品对象, 而不是单一的产品对象, 例如一个电器工厂, 它可以生产电视机, 电冰箱, 空调等多种电器, 而不只是某一种电器. 
因此, 可以考虑将一些相关的产品组成一个"产品族", 由同一个工厂来生产, 这就是抽象工厂的基本思想.

## 抽象工厂模式
提供一个创建一系列相关或相互依赖对象的接口, 而无需指定他们具体的类.

## 抽象工厂模式的结构

### 4个角色(注意, 和工厂方法的角色一样)
1. 抽象工厂(AbstractFactory)
2. 具体工厂(ConcreteFactory)
3. 抽象产品(AbstractProduct)
4. 具体产品(ConcreteProduct)

### 结构图
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821152819819-757349038.png)


## 应用实例

### 界面皮肤库
- 春天风格的皮肤 
    提供浅绿色按钮 绿色边框的文本框 绿色边框的组合框
- 夏天风格的皮肤
    浅蓝色的按钮 蓝色边框的文本框 蓝色边框的组合框

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821154454361-804983260.png)

## 开闭原则的倾斜性
上面的界面皮肤库应用实例存在非常严重的问题.
如果在设计之初考虑不全面, 忘记为某种类型的界面组件(比如 单选按钮RadioButton)提供不同皮肤下的风格化显示, 那么在向系统中增加单选按钮将非常麻烦, 无法满足开闭原则的前提下增加单选按钮.
这时抽象工厂模式最大的缺点所在. 无法方便的增加新的产品等级结构.
抽象工厂模式存在开闭原则的倾斜性, 以一种倾斜的方式来满足开闭原则, 为增加新产品族提供方便, 但不能方便的增加新产品结构, 因此要求设计人员在设计之初就要全面考虑, 不要在设计完成之后再向系统中增加新的产品等级结构, 也不要删除已有的产品等级结构, 否则会导致系统出现较大的修改.

## 抽象工厂模式的适用环境
一个系统不依赖于产品类实例如何被创建, 组合和表达的细节;
系统中有多于一个的产品族, 但每次只使用其中某一产品族;
属于同一个产品族的产品将在一起使用;
产品等级结构稳定;
