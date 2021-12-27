using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject boomRange;
    public Vector2 startSpeed;
    public float delayBoomTime;

    private Rigidbody2D _rigidbody2D;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rigidbody2D.velocity = transform.right * startSpeed.x + transform.up * startSpeed.y;
        Invoke("Expload",delayBoomTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenBoomRange()
    {   
        Instantiate(boomRange, transform.position, quaternion.identity);
    }

    void Expload()
    {
        _animator.SetTrigger("Boom");
        Invoke("GenBoomRange",0.5f);
        Invoke("DestroyObject", 1.1f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
