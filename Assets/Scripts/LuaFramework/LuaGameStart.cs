/***
 * 
 *    Title:  "lua框架"项目启动脚本
 *                  
 *            主要功能： [主要功能]
 *          
 *    Description: 
 *            详细描述：
 *                      
 *            目录结构： [xxx]-->[xxx]-->[xxx]
 *            
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

namespace LuaFramework
{
    public class LuaGameStart : MonoBehaviour,HotUpdateProcess.IStartGame
    {

        public void ReceiveInfoStartRuning()
        {
            LuaHelper.GetInstance().DoString("require 'StartGame'");
        }


        //反注册热更新列表
        void OnDisable()
        {
            LuaHelper.GetInstance().CallLuaFunction("ProjectHotFix", "UnRegister_HotFix");
        }

    }//Class_end
}//namespace_end