using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public int demage;
    public float time;
    public float startTime;
    private Animator _animator;

    private PolygonCollider2D _polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            _animator.SetTrigger("Attack");
            // 携程
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        _polygonCollider2D.enabled = true;
        StartCoroutine(disableHitBox());

    }

    
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        _polygonCollider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        // 判断是否攻击到了enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(demage);
        }
    }
}
