/***
 * 
 *    Title: 测试项目开发
 *           主要讲解 Animator 中GetCurrentAnimatorStateInfo() 方法的作用。
 *   
 */

using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using XLua;

[XLua.Hotfix]
public class HeroControl : MonoBehaviour {
    //private const string IDLE = "Idle";
    //private const string ATTACK_1 = "Attack1";
    //private const string ATTACK_2 = "Attack2";
    //private const string ATTACK_3 = "Attack3";
    private const string HeroActionState = "IsAttack";     //动画状态机的控制参数
    private Animator animator = null; 
    private int curComboCount = 0;                         //当前连击数   
    private AnimatorStateInfo stateInfo;                   //动画状态信息


    [LuaCallCSharp]
    public void Start() {
	    animator = this.GetComponent<Animator>();
	}

    //void Update()
    //{
    //    if(Time.frameCount%2==0)
    //    {        
    //        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    //        //参数清空
    //        if (!stateInfo.IsName(IDLE))//IsName() 得到当前动画状态机当前的“动画名称”
    //        {
    //            animator.SetBool(HeroActionState,false);
    //        }
    //        //normalizedTime 属性，得到当前动画状态机的动画执行的百分比
    //        if (stateInfo.IsName(ATTACK_1) && (stateInfo.normalizedTime > 0.6f) && (this.curComboCount == 2))
    //        {  
    //            animator.SetBool(HeroActionState, true);
    //        }else if (stateInfo.IsName(ATTACK_2) && (stateInfo.normalizedTime > 0.8f) && (this.curComboCount == 3))
    //        {
    //            animator.SetBool(HeroActionState, true);
    //        }

    //        if (Input.GetKeyDown(KeyCode.J))
    //        {
    //          Attack();
    //        }
    //    }
    //}

    ///// <summary>
    ///// 攻击
    ///// </summary>
    //void Attack()
    //{
    //    if (stateInfo.IsName(IDLE))
    //    {
    //        animator.SetBool(HeroActionState,true);
    //        this.curComboCount = 1;
    //    }
    //    else if (stateInfo.IsName(ATTACK_1))
    //    { 
    //        this.curComboCount = 2;
    //    }
    //    else if (stateInfo.IsName(ATTACK_2))
    //    {
    //        this.curComboCount = 3;
    //    }
    //}


    //简单没有连招的状态。
 
    void Update()
    {
        //stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        ////参数清空
        //if (!stateInfo.IsName("Idle"))//IsName() 得到当前动画状态机当前的“动画名称”
        //{
        //    animator.SetBool(HeroActionState, false);
        //}
        //if (stateInfo.IsName("Attack1"))
        //{
        //    animator.SetBool(HeroActionState, true);
        //}
        //else if (stateInfo.IsName("Attack2"))
        //{
        //    animator.SetBool(HeroActionState, true);
        //}

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    Attack();
        //}
    }

    /// <summary>
    /// 攻击
    /// </summary>
    void Attack()
    {
       animator.SetBool(HeroActionState, true);        
    }    

}//Class_end

