﻿/***
 *
 *   Title: "AssetBundle简单框架"项目
 *          工具类：     
 *
 *   Description:
 *          功能： 
 *             1： 本框架项目所有的常量
 *             2： 所有的委托定义。
 *             3： 枚举定义。
 *             4： 常量定义。
 *
 *   Author: Liuguozhu
 *
 *   Date: 2017.10
 *
 *   Modify：  
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABFW
{
    /* 委托定义区 */
    public delegate void DelLoadComplete(string abName);


    /* 枚举类型定义 */

	public class ABDefine
	{
        /* 框架常量 */
        public static string ASSETBUNDLE_MANIFEST = "AssetBundleManifest";
		
	}
}


