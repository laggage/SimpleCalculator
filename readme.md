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
