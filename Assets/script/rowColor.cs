using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rowColor : MonoBehaviour
{
    public Color[] rowColors; // 在Inspector中设置这个数组来指定每行的颜色
    private int rowIndex; // 用于指定当前行的索引
    void Start()
    {
        rowIndex = transform.GetSiblingIndex(); // 获取当前行的索引
        if (rowIndex < rowColors.Length)
        {
            GetComponent<Renderer>().material.color = rowColors[rowIndex]; // 设置当前行的颜色
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
