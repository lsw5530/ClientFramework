/***
 * 
 *    Title:  热更新等待界面。
 *                  
 *            主要功能： 使得对象进行旋转
 *          
 *    Description: 
 *            详细描述：
 *                      
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

namespace DemoProject
{
    public class MakeRotation : MonoBehaviour
    {
        //旋转的对象
        public GameObject goObj;
        //旋转的速度
        public float rotationSpeed = 5F;


        void Update()
        {
            goObj.transform.Rotate(Vector3.back* rotationSpeed);
        }

    }//Class_end
}//namespace_end