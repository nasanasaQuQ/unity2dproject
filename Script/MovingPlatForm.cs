using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    public float moveSpeed;

    public float waitTime;

    public Transform[] movePos;
    private float _oldTime;
    private int i;

    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        _oldTime = waitTime;
        // 获取player当前层级
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime < 0.0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                waitTime = _oldTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 判断是否和player发生了碰撞
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        // 判断是否和player发生了碰撞
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = _playerTransform;
        }
    }
}
