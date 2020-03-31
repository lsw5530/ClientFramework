﻿/***
 *
 *  Title: "lua框架"项目
 *  
 *          Lua 帮助类
 *  
 *  
 *  Description:
 *        功能：[本脚本的主要功能描述] 
 *
 *  Date: 2018
 * 
 *  Version: 1.0
 *
 *  Modify Recorder:
 *     
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
using ABFW;


namespace LuaFramework {
    public class LuaHelper {
        //本类静态实例
        private static LuaHelper _Instance;
        //Lua 环境
        private LuaEnv _luaEnv = new LuaEnv();
        //缓存lua文件名称与对应的lua信息。
        private Dictionary<string, byte[]> _DicLuaFileArray = new Dictionary<string, byte[]>();


        private LuaHelper() {
            //私有构造函数
            _luaEnv.AddLoader(customLoader);
        }

        /// <summary>
        /// 得到帮助类实例
        /// </summary>
        /// <returns></returns>
        public static LuaHelper GetInstance() {
            if (_Instance == null) {
                _Instance = new LuaHelper();
            }
            return _Instance;
        }

        /// <summary>
        /// 得到lua环境
        /// </summary>
        /// <returns></returns>
        public LuaEnv GetLuaEnv() {
            if (_luaEnv != null) {
                return _luaEnv;
            }
            else {
                Debug.LogError(GetType() + "/GetLuaEnv()/出现严重错误！   _luaEnv==null!!!   ");
                return null;
            }
        }

        /// <summary>
        /// 执行lua代码
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="chunkName"></param>
        /// <param name="env"></param>
        public void DoString(string chunk, string chunkName = "chunk", LuaTable env = null) {
            _luaEnv.DoString(chunk, chunkName, env);
        }

        /// <summary>
        /// 调用lua中的方法
        /// </summary>
        /// <param name="luaScriptName">lua 脚本名称</param>
        /// <param name="luaMethodName">lua 的方法</param>
        /// <param name="args">可变 object 类型数组</param>
        /// <returns>
        /// 对象数组
        /// </returns>
        public object[] CallLuaFunction(string luaScriptName, string luaMethodName, params object[] args) {
            LuaTable luaTab = _luaEnv.Global.Get<LuaTable>(luaScriptName);
            LuaFunction luaFun = luaTab.Get<LuaFunction>(luaMethodName);
            return luaFun.Call(args);
        }

        /// <summary>
        /// 自定义调取lua文件内容
        /// </summary>
        /// <param name="fileName">lua文件名称</param>
        /// <returns></returns>
        private byte[] customLoader(ref string fileName) {
            //获取lua所在目录
            //string luaPath = PathTools.GetABOutPath() + PathTools.LUA_DEPLOY_PATH;//Original
            string luaPath = PathTools.GetABOutPath() + HotUpdateProcess.HotUpdatePathTool.LUA_DEPLOY_PATH;
            if (!File.Exists(luaPath + "/" + fileName+".lua")) {

                Debug.LogError("luaPath:" + luaPath + "/" + fileName + ".lua");
            }
            //缓存判断处理： 根据lua文件路径，获取lua的内容
            if (_DicLuaFileArray.ContainsKey(fileName)) {
                //如果在缓存中可以查找成功，则直接返回结果。
                return _DicLuaFileArray[fileName];
            }
            else {
                return ProcessDIR(new DirectoryInfo(luaPath), fileName);
            }
        }

        /// <summary>
        /// 根据lua文件名称，递归取得lua内容信息,且放入缓存集合
        /// </summary>
        /// <param name="fileSysInfo">lua的文件信息</param>
        /// <param name="fileName">查询的lua文件名称</param>
        /// <returns></returns>
        private byte[] ProcessDIR(FileSystemInfo fileSysInfo, string fileName) {
            DirectoryInfo dirInfo = fileSysInfo as DirectoryInfo;
            FileSystemInfo[] files = dirInfo.GetFileSystemInfos();

            foreach (FileSystemInfo item in files) {
                FileInfo fileInfo = item as FileInfo;
                //表示一个文件夹
                if (fileInfo == null) {
                    //递归处理
                    ProcessDIR(item, fileName);
                }
                //表示文件本身
                else {
                    //得到文件本身，去掉后缀
                    string tmpName = item.Name.Split('.')[0];
                    if (item.Extension == ".meta" || tmpName != fileName) {
                        continue;
                    }
                    //读取lua文件内容字节信息
                    byte[] bytes = File.ReadAllBytes(fileInfo.FullName);
                    //添加到缓存集合中
                    _DicLuaFileArray.Add(fileName, bytes);
                    return bytes;
                }

            }
            Debug.LogError("not found:" + fileName);
            return null;
        }//ProcessDIR_end

        /// <summary>
        /// 给指定对象，动态添加“BaseLuaUIForm”脚本
        /// </summary>
        /// <param name="go"></param>
        public void AddBaseLuaUIForm(GameObject go) {
            go.AddComponent<BaseLuaUIForm>();
        }



    }//Class_end
}


