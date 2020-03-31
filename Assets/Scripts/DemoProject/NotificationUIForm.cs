/***
 * 
 *    Title:  公告系统
 *                  
 *          
 *    Description: 
 *            详细描述：
 * 
 *    Date: 2019
 *    
 *    Version: 0.1
 *    
 *    Modify Recoder: 
 *   
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

namespace DemoProject
{
    public class NotificationUIForm : BaseUIForm
    {
        void Awake()
        {
            //窗体的性质
            CurrentUIType.UIForms_Type = UIFormType.PopUp;  //弹出窗体。
            CurrentUIType.UIForm_LucencyType = UIFormLucenyType.Translucence;
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.ReverseChange;

            //注册按钮事件
            RigisterButtonObjectEvent("BtnConfirm", p => CloseUIForm());

        }
    }//Class_end
}//namespace_end