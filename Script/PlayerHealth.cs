using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int blinks;
    public float time;
    private Renderer _renderer;
    private ScreenFlash _screenFlash;
    private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {   
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        _renderer = GetComponent<Renderer>();
        _animator = GetComponent<Animator>();
        _screenFlash = GetComponent<ScreenFlash>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {   
        _screenFlash.FlashScreen();
        health -= damage;
        HealthBar.HealthCurrent = health;
        if (health < 0)
        {
            health = 0;
            _rigidbody2D.velocity = new Vector2(0,0);
            //_rigidbody2D.gravityScale = 0.0f;
            _animator.SetTrigger("Die");
            Destroy(gameObject,1.5f);
            GameController.IsGamerAlive = false;
        }
        if (health <= 0)
        {
            _rigidbody2D.velocity = new Vector2(0,0);
            //_rigidbody2D.gravityScale = 0.0f;
            _animator.SetTrigger("Die");
            Destroy(gameObject,1.5f);
            GameController.IsGamerAlive = false;
        }
        BlinkPlayer(blinks,time);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks*2; i++)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return new WaitForSeconds(seconds);
        }

        _renderer.enabled = true;
    }

}
