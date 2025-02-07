using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class border : MonoBehaviour
{
    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        if (textComponent != null)
        {
            // 创建一个新的边框
            //RectOffset border = new RectOffset();
            //border.bottom = 3; // 边框的厚度

            //// 应用边框到Text的样式
            //textComponent.rectTransform.offsetMin = new Vector2(textComponent.rectTransform.offsetMin.x, textComponent.rectTransform.offsetMin.y - 3);
            //textComponent.rectTransform.offsetMax = new Vector2(textComponent.rectTransform.offsetMax.x, textComponent.rectTransform.offsetMax.y + 3);
            //textComponent.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom,1, 3);
            ////textComponent.fontSize = 20; // 根据需要设置字体大小
            //textComponent.rectTransform.anchorMin = new Vector2(0, 0.5f);
            //textComponent.rectTransform.anchorMax = new Vector2(1, 0.5f);
            //textComponent.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            //textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            //textComponent.verticalOverflow = VerticalWrapMode.Overflow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
