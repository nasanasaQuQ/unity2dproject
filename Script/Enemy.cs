using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;

    public int health;

    public float flashTime;

    private SpriteRenderer spriteRenderer;
    public GameObject bloodEffect;
    private Color originColor;
    // Start is called before the first frame update
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }

    // Update is called once per frame
    public void Update()
    {
        Death();
    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.MyCameraShake.Shake();
    }
    
    // 受伤闪烁功能
    void FlashColor(float time)
    {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor",time);
    }

    void ResetColor()
    {
        spriteRenderer.color = originColor;
    }
    
}
