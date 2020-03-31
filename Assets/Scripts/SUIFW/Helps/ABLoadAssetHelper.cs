﻿/***
 * 
 *    Title:  UI框架： AssetBunde 资源调用帮助脚本
 *                  
 *            主要功能：
 *                封装ABFW框架中关于资源调用API，帮助类。
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

using ABFW;   //导入AB框架命名空间

namespace SUIFW
{
    public class ABLoadAssetHelper : MonoBehaviour
    {
        //本类实例
        private static ABLoadAssetHelper _Instance;
        //AB包场景名称
        private string _ScenesName = string.Empty;
        //AB包的名称
        private string _AssetBundleName = string.Empty;
        //AB包中资源的名称
        private string _AssetName = string.Empty;
        //是否包资源加载完毕
        private bool _IsLoadFinish = false;
        //克隆出来的UI预设
        private UnityEngine.Object _CloneUIPrefab = null;
        /*  属性 */
        public bool IsLoadFinish
        {
            get { return _IsLoadFinish; }
        }




        //得到本类的实例
        public static ABLoadAssetHelper GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new GameObject("_ABLoadAssetHelper").AddComponent<ABLoadAssetHelper>();
            }
            return _Instance;
        }

        /// <summary>
        /// 调用AB框架ab包
        /// </summary>
        /// <param name="abPara"></param>
        public void LoadAssetBundlePack(ABPara abPara)
        {
            //仅仅是加载相同AB包中的不同资源
            if ((abPara.ScenesName==_ScenesName)  && (abPara.AssetBundleName==_AssetBundleName))
            {
                _AssetName = abPara.AssetName;
                LoadABAssetComplete(""); //这里的参数没有实际作用。
            }
            else {
                //参数赋值
                _ScenesName = abPara.ScenesName;
                _AssetBundleName = abPara.AssetBundleName;
                _AssetName = abPara.AssetName;
                //调用ABFW 主API
                StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePack(_ScenesName, _AssetBundleName, LoadABAssetComplete));
            }
        }

        /// <summary>
        /// （回调函数） 调用AB包中的资源
        /// </summary>
        /// <param name="abName">没有用到</param>
        private void LoadABAssetComplete(string abName)
        {
            UnityEngine.Object tmpObj = null;

            tmpObj=AssetBundleMgr.GetInstance().LoadAsset(_ScenesName, _AssetBundleName, _AssetName, false);
            if (tmpObj!=null)
            {
                _CloneUIPrefab = Instantiate(tmpObj);
            }
            _IsLoadFinish = true;
        }

        /// <summary>
        /// 得到（克隆）的UI预设
        /// </summary>
        /// <returns></returns>
        public UnityEngine.Object GetCloneUIPrefab()
        {
            if (_CloneUIPrefab!=null)
            {
                _IsLoadFinish = false;
                return _CloneUIPrefab;
            }

            return null;
        }

    }//Class_end
}//namespace_end