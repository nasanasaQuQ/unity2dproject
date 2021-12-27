using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomRange : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    private PlayerHealth _playerHealth;
    private PolygonCollider2D _polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 判断是否攻击到了enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (_playerHealth)
            {
                _playerHealth.DamagePlayer(damage);
            }
        }
    }
}
