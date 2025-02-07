using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;
using System.Collections.Concurrent;

public class scrollscript : MonoBehaviour
{
    private (GameObject, int)[] cubesWithState;
    void Start()
    {
        
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("cubes");
        cubesWithState = new (GameObject, int)[cubes.Length];
        for (int i = 0; i < cubes.Length; i++)
        {
            cubesWithState[i] = (cubes[i], 0);
        }
        Debug.Log(cubesWithState.Length);
        Thread newThread = new Thread(changecolor);  
        newThread.Start();
    }


    public void ItemClick(int index) {
        Debug.Log("current click:"+index);//打印标记

            for (int i = 0; i < cubesWithState.Length; i++)
            {
                if (index == i)
                {
                    cubesWithState[i].Item2 = 2;
                }
                else
                {
                    if (cubesWithState[i].Item2 == 2)
                    {
                        cubesWithState[i].Item2 = 1;
                    }
                }
                Debug.Log("cube status:" + cubesWithState[i].Item2);
            }
    }


    private void changecolor() {

        while (true) {
                UnityMainThreadDispatcher.Enqueue(() =>
                    {
                        for (int i = 0; i < cubesWithState.Length; i++)
                        {
                            if (cubesWithState[i].Item2 == 2)
                            {
                                Color col = cubesWithState[i].Item1.GetComponentInChildren<Renderer>().material.color;
                                if (col == Color.gray)
                                {
                                    cubesWithState[i].Item1.GetComponentInChildren<Renderer>().material.color = Color.red;
                                }
                                else
                                {
                                    cubesWithState[i].Item1.GetComponentInChildren<Renderer>().material.color = Color.gray;
                                }

                            }
                            else if (cubesWithState[i].Item2 == 1)
                            {
                                cubesWithState[i].Item1.GetComponentInChildren<Renderer>().material.color = Color.yellow;
    ;
                            }
                            else {
                                cubesWithState[i].Item1.GetComponent<Renderer>().material.color = Color.gray;
                            }
                            }
                    });
              
                Thread.Sleep(100);
            }
      
    }
}
