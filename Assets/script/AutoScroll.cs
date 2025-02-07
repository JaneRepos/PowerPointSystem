using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoScroll : MonoBehaviour
{
   
   
    public ScrollRect scrollRect;
    public float scrollSpeed = 5f; // 自动滚动的速度
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.DownArrow))
        {
            scrollRect.verticalNormalizedPosition -= Time.deltaTime * scrollSpeed;
        }
        // 滚动向上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scrollRect.verticalNormalizedPosition += Time.deltaTime * scrollSpeed;
        }
        // 滚动向右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            scrollRect.horizontalNormalizedPosition += Time.deltaTime * scrollSpeed;
        }
        // 滚动向左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            scrollRect.horizontalNormalizedPosition -= Time.deltaTime * scrollSpeed;
        }
    }
}
