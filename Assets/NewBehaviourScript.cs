using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerMoveHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/// <summary>
/// 鼠标进入 rawimage
/// </summary>
/// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
    }

    /// <summary>
    /// 鼠标移动
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerMove(PointerEventData eventData)
    {
        //Debug.Log("Move");
    }

/// <summary>
/// 鼠标退出
/// </summary>
/// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
    }
}
