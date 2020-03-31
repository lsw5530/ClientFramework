---
---  “公告栏”  UI窗体视图层脚本
---
--- Created by Administrator.
--- DateTime: 2019/6/12
---

--定义字段
NotificationUIForm={}
local this=NotificationUIForm
--公告标题
local strNotiTitle="<color='#ff0000ff'>重要公告</color>"
--公告内容
local strNotiContent="<b>亲爱的小伙伴们：</b>\r\n\n　　由于服务器异常，邮件模块出现了一些小问题，目前技术小哥正在紧急修复中，并将邮件模块暂时关闭。\r\n\n　　各位小伙伴们不用担心，问题修复后，会第一时间通知大家，给大家带来的不便，还请原谅！\r\n\n　　感谢大家多年以来对本游戏的关心与爱护\r\n\n　　　　　　　　　　魔兽世界项目组 2028年9月9日"
local transform
local gameobject



--说明:
--输入参数： obj 表示UI窗体对象。
function NotificationUIForm.Awake(obj)
    gameobject=obj
    transform=obj.transform
end

function NotificationUIForm.Start(obj)
    --查找与设置通知的标题
    this.txtTitle=transform:Find("Txt_Title"):GetComponent("UnityEngine.UI.Text")
    this.txtTitle.text=strNotiTitle

    --查找与设置通知的内容
    this.txtContent=transform:Find("Scroll View/Viewport/Content/Text"):GetComponent("UnityEngine.UI.Text")
    this.txtContent.text=strNotiContent

end
