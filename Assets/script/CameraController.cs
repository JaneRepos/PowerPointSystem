using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float forwardBackSpeed = 1f;
    public float rotateSpeed = 2f;

    private Vector3 lastMousePositionLeft;
    private Vector3 lastMousePosition = Vector3.zero;
    private Transform target;
    private List<Tuple<string, float, float, float>> initialPostition = new List<Tuple<string,float, float, float>>();
  
    // public Camera cameraToCheck;

     bool IsMouseInViewport()
    {
        Camera cam =  Camera.main;
        // 将相机的近裁剪面的四个角点转换到屏幕空间
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // 获取屏幕空间的四个角点
        Vector3 screenBottomLeft = cam.WorldToScreenPoint(bottomLeft);
        Vector3 screenTopRight = cam.WorldToScreenPoint(topRight);

        // 构建屏幕空间的矩形
        Rect viewportRect = new Rect(screenBottomLeft.x, screenBottomLeft.y, screenTopRight.x - screenBottomLeft.x, screenTopRight.y - screenBottomLeft.y);

        // 检查鼠标位置是否在矩形内
        return viewportRect.Contains(Input.mousePosition);
    }

    void Update()
    {
        if(IsMouseInViewport())
        {
            if (Input.GetMouseButtonDown(1)) 
            {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        
                    Debug.DrawLine(ray.origin, ray.GetPoint(100), Color.red, 20f); 

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        string currentName = hit.transform.gameObject.name;
                        Quaternion currentQuaternion = hit.transform.rotation;
                        Debug.Log(currentName);
                        if (target == null)
                        {
                            initialPostition.Add(new Tuple<string, float, float, float>(currentName, currentQuaternion.x, currentQuaternion.y, currentQuaternion.z));
                        }
                        else if (name != target.gameObject.name)
                        {
                            Tuple<string, float, float, float> lastPostition = initialPostition.Find(obj => obj.Item1 == target.gameObject.name);
                            target.transform.rotation = Quaternion.Euler(lastPostition.Item2, lastPostition.Item3, lastPostition.Item4);
                            initialPostition.Add(new Tuple<string, float, float, float>(currentName, currentQuaternion.x, currentQuaternion.y, currentQuaternion.z));
                        }
                        else
                        {

                        }
                        target = hit.transform;
                    }
                }

            if (Input.GetMouseButton(1) && target != null) 
            {
                if (lastMousePosition != Vector3.zero)
                {
                    Vector3 delta = Input.mousePosition - lastMousePosition;
                    float rotateX = delta.y * rotateSpeed;
                    float rotateY = delta.x * rotateSpeed;

                    target.RotateAround(target.position, transform.up, rotateY);
                    //target.RotateAround(target.position, transform.right, -rotateX);
                }
                lastMousePosition = Input.mousePosition;
            }


            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastMousePositionLeft;
                Vector3 moveDirection = -transform.right * delta.x + (-transform.up * delta.y);
                transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

                lastMousePositionLeft = Input.mousePosition;
            }

            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(Vector3.forward * scrollWheel * forwardBackSpeed);
        }
    }
}

