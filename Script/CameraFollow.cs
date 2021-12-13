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
    // Start is called before the first frame update
    void Start()
    {
        GameController.MyCameraShake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (target)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
}
