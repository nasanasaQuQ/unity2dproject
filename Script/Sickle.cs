using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;

    public int damage;

    public float rotateSpeed;
    public float tuning;
    
    private Rigidbody2D _rigidbody2D;

    private Transform playerTransform;

    private Transform sickleTransform;

    private Vector2 startSpeed;

    private CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * speed;
        startSpeed = _rigidbody2D.velocity;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sickleTransform = GetComponent<Transform>();
        cameraShake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector3(transform.position.x, y, 0.0f);
        _rigidbody2D.velocity = _rigidbody2D.velocity - startSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
