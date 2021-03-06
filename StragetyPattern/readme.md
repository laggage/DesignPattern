﻿# 策略模式(Stragety Pattern)

## 动机(Motivation)

在软件构建过程中，某些对象使用的算法可能多种多样，经常改变，如果将这些算法都编码到对象中，将会使对象变得异常复杂；而且有时候支持不使用的算法也是一个性能负担。如何在运行时根据需要透明地更改对象的算法？将算法与对象本身解耦，从而避免上述问题？

## 意图

 定义一系列算法，把它们一个个封装起来，并且使它们可互相替换。该模式使得算法可独立于使用它的客户而变化。　　　　　　                                ——《设计模式》GoF

## 结构图

![image](https://user-images.githubusercontent.com/38829279/83552124-d9907d00-a53b-11ea-956d-534fa981cc36.png)


## 实例

### 购物车结算

尝试实现一个简单的购物车, 购物车可以有不同的结算方式, 如 PayPal结算或者信用卡结算;



### 电影票折扣

不同的人群提供不同的折扣策略;

- 学生: 凭学生证8折
- 年龄十周岁以下的儿童, 每张票减免十元(票的原价必须大于20)
- 影院VIP: 票价半价优惠, 可以进行积分, 积分达到一定可以获赠影院的奖品;

