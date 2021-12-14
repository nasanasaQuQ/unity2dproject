using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 相机跟随player
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothing;
    
    // 最小移动以及最大移动坐标
    public Vector2 minPosition;

    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameController.MyCameraShake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    private void LateUpdate()
    {
        if (target)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
