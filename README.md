# Nuget Packages
| Package Name | Nuget | Build |
|--|--|--|
|Sophon.Toolkit |[![nuget](https://img.shields.io/nuget/v/Sophon.Toolkit.svg?color=blue)](https://www.nuget.org/packages/Sophon.Toolkit/)|![Sophon.Toolkit Release](https://github.com/zhaobingwang/Sophon/workflows/Sophon.Toolkit%20Release/badge.svg)
|Sophon.Toolkit.Faker |[![nuget](https://img.shields.io/nuget/v/Sophon.Toolkit.Faker.svg?color=blue)](https://www.nuget.org/packages/Sophon.Toolkit.Faker/)|![Sophon.Toolkit.Faker Release](https://github.com/zhaobingwang/Sophon/workflows/Sophon.Toolkit.Faker%20Release/badge.svg)


# Git Commit Message

type类型如下：
- feat：新功能（feature） 
- fix：修补bug 
- docs：文档（documentation） 
- style：格式（不影响代码运行的变动,空格,格式化,等等） 
- build: 构建工具或外部依赖的改动（如nuget,npm等）
- refactor：重构（即不是新增功能，也不是修改bug的代码变动） 
- test：增加测试或者修改测试 
- chore：不修改src和test的操作（构建过程或辅助工具的变动）


# Comments in code
注释 | 解释 | 优先级
---|---|---
FIXME | 需要修正，甚至代码是错误的，不能工作，需要修复，如何修正会在说明中简略说明 | 高
TODO | 有功能代码待编写，待实现的功能在说明中会简略说明 | 普通
XXX |  陷阱(标识处代码虽然实现了功能，但是实现的方法有待商榷，希望将来能改进，要改进的地方会在说明中简略说明) | 普通