using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
   
    
    public void OnExitGame()//定义一个退出游戏的方法
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();//否则在打包文件中
    }
}
