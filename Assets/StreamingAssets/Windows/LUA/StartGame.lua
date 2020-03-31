---
---  Lua项目开始入门脚本
---
--- Created by Administrator.
--- DateTime: 2019/5/28
---
print("啊啊啊")

--引入项目常量与“枚举”
require("SysDefine")
--引入项目初始化核心脚本
require("ProjectInit")
--引入项目热补丁模块的注册
require("ProjectHotFix")

--项目开始
ProjectInit.Init()
--项目中所有的hotfix 进行注册
ProjectHotFix.HotfixUpdate()