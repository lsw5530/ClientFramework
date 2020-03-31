---
---  项目热补丁注册与反注册文件
---  功能: 本项目中所有的“热补丁”都在本文件注册，以及反注册
---
--- Created by Administrator.
--- DateTime: 2019/6/17
---

print("ProjectHotfix")
ProjectHotFix={}
local this=ProjectHotFix

--定义局部变量--
local heroComboCount=0  --英雄连招数量

--热补丁注册
function this:HotfixUpdate()
    print("热补丁注册列表！！！  HotfixUpdate（）")

    --注册补丁1：
    xlua.private_accessible(CS.HeroControl)  --可以访问CS中的私有字段
    xlua.hotfix(CS.HeroControl,'Start',
    function (self)
        self.animator=self:GetComponent('Animator')
    end
    )

    --注册补丁2：
    xlua.private_accessible(CS.HeroControl)  --可以访问CS中的私有字段
    xlua.hotfix(CS.HeroControl,'Update',
    function (self)
        --参数清空
        self.stateInfo=self.animator:GetCurrentAnimatorStateInfo(0)
        if(not self.stateInfo:IsName("Idle")) then
            self.animator:SetBool("IsAttack",false)
        end

        --动画过程控制
        if(self.stateInfo:IsName("Attack1") and (heroComboCount==2)) then
            self.animator:SetBool("IsAttack",true)
        elseif (self.stateInfo:IsName("Attack2") and (heroComboCount==3)) then
            self.animator:SetBool("IsAttack",true)
        end

        --响应输入信息
        if (CS.UnityEngine.Input.GetKeyDown(CS.UnityEngine.KeyCode.J)) then
            self:Attack()
        end

    end
    )


    --注册补丁3：
    xlua.private_accessible(CS.HeroControl)  --可以访问CS中的私有字段
    xlua.hotfix(CS.HeroControl,'Attack',
    function (self)
        if (self.stateInfo:IsName("Idle"))then
            self.animator:SetBool("IsAttack",true)
            heroComboCount=1
        elseif (self.stateInfo:IsName("Attack1"))then
            heroComboCount=2
        elseif (self.stateInfo:IsName("Attack2"))then
            heroComboCount=3
        end

    end)
end

--热补丁反注册（热补丁注销）
function this:UnRegister_HotFix()
    print("热补丁反注册 ###### UnRegister_HotFix（）")
    --反注册1：
    xlua.hotfix(CS.HeroControl,'Start',nil)
    --反注册2：
    xlua.hotfix(CS.HeroControl,'Update',nil)
    --反注册3：
    xlua.hotfix(CS.HeroControl,'Attack',nil)

end



