/***
 * 
 *    Title: "SUIFW" UI框架项目
 *           主题： xxx    
 *    Description: 
 *           功能： yyy
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
	public class StartProject : MonoBehaviour,HotUpdateProcess.IStartGame {
        //热更新UI界面
        public GameObject goHotUpdateUI;
        //3D英雄角色
        public GameObject goHero;


        /// <summary>
        /// 服务器已经更新完毕，可以开始后续游戏逻辑
        /// </summary>
        public void ReceiveInfoStartRuning()
        {
            //加载登陆窗体
            UIManager.GetInstance().ShowUIForms(ProConst.LOGON_FROMS);
            //关闭热更新进度界面
            Invoke("CloseHotUpdateProcessUI",0.5F);
            //显示3D角色
            Invoke("ShowHero", 1F);
        }

        //关闭热更新进度界面
        private void CloseHotUpdateProcessUI()
        {
            goHotUpdateUI.SetActive(false);
        }

        //显示3D角色
        private void ShowHero()
        {
            goHero.SetActive(true);
        }

    }
}