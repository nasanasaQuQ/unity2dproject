using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{

    public float moveSpeed;
    public float radius;
    public float startWaitTime;

    private float waitTime;

    private Transform playerTransform;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, moveSpeed*Time.deltaTime);
        // 判断是否到达了生成的位置
        if (playerTransform)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            // 如果小于检测半径
            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position,
                    moveSpeed * Time.deltaTime);
            }
        }
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private Vector2 GetRandomPos()
    {
        // 在左下角至右上角随机生成一个坐标
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return randomPos;
    }



    
}
