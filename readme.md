## SimpleCalculator

这是一个学习Demo级别的项目;

一个基于.net中 `Expression` 的简单的四则预算api;

输入一个四则运算表达式的字符串式如: `-5+(-5)+35^3+14*(52+9)`, 调用 `IArithmetricCalculator.Calculator()` 返回具体的计算结果;

## 实现

1. 中缀表达式转成后缀表达式
2. 后缀表达式构建表达式树, 表达式树的结构是一棵二叉树, 这里直接使用了.net内置的`BinaryExpression`

## 使用的设计模式

- 建造者模式结合单例模式
- 工厂方法模式

## 调用示例

请看测试代码;

```csharp
IArithmetricCalculator calculator = ExpressionTreeArithmetricCalculator.Create(exprText);
double res = calculator.Calculate();
```

## 如何计算最终结果?

使用策略模式, 定义一个 `IExpressionTreeCalculatorEngine` 接口, 这个类作为 `Calculator` 类的一个私有字段, 有两个类实现了 `IExpressionTreeCalculatorEngine`, 也就是有两种策略来根据生成的 `Expression` 计算最终结果, 分别是 
- `RecursionExpressionTreeCalculatorEngine`, 这个类通过继承 `ExpressionVisitor`来递归遍历各个表达式节点, 类似二叉树的后序遍历;
- `DefaultCalculatorEngine`, 这个策略就很简单了, 直接将作为参数的传递过来的表达式通过 `Expression.Lambda()` 生成 lambda 表达式然后编译得到结果;
