/***
 * 
 *    Title: "SUIFW" UI框架项目
 *           主题： 英雄信息显示窗体
 *    Description: 
 *           功能： 
 *                  
 *    Date: 2017
 *    Version: 0.1版本
 *    Modify Recoder: 
 *    
 *   
 */
using System.Collections;
using System.Collections.Generic;
using SUIFW;
using UnityEngine;

namespace DemoProject
{
	public class HeroInfoUIForm : BaseUIForm {


		void Awake () 
        {
		    //窗体性质
            CurrentUIType.UIForms_Type = UIFormType.Fixed;  //固定在主窗体上面显示


            RigisterButtonObjectEvent("BtnItem1",
                p =>
                {
                    //CloseUIForm();
                    OpenUIForm(ProConst.LOGON_FROMS,true);
                }
                );

            //隐藏UI窗体
            RigisterButtonObjectEvent("BtnItem1 (2)",
                p =>
                {
                    OpenUIForm(ProConst.HERO_INFO_UIFORM,true);
                }
                );
            //显示UI窗体
            RigisterButtonObjectEvent("BtnItem1 (1)",
                p =>
                {
                    OpenUIForm(ProConst.MAIN_CITY_UIFORM);
                    OpenUIForm(ProConst.HERO_INFO_UIFORM);
                }
                );


        }

    }
}