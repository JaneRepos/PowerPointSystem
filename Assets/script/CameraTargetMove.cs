using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetMove : MonoBehaviour
{
    public Transform target;
    public Vector3 pivotOffset = Vector3.zero;
    public float distance = 10.0f;
    public float minDistance = 2f;
    public float maxDistance = 15f;
    public float zoomSpeed = 1f;
    public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;
    public bool allowYTilt = true;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float targetX = 0f;
    private float targetY = 0f;
    public float targetDistance = 0f;

    private void Start()
    {
        var angles = transform.eulerAngles;
        targetX = x = angles.x;
        targetY = y = ClampAngle(angles.y, yMinLimit, yMaxLimit);
        targetDistance = distance;
        Debug.Log("角度为："+angles.x);
    }

    private void LateUpdate()
    {
        if (!target) return;
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0.0f) targetDistance -= zoomSpeed;
        else if (scroll < 0.0f)
            targetDistance += zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
        {
            targetX += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            if (allowYTilt)
            {
                targetY -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
                targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
            }
        }

        x = targetX;
        y = targetY;
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        distance = targetDistance;
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + pivotOffset;
        transform.rotation = rotation;
        transform.position = position;
    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
