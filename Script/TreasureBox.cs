using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    private bool canOpen;

    private bool isOpened;
    public float delayTime;
    private Animator _animator;
    // 掉落Object
    public GameObject diaoluowu;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canOpen && !isOpened)
            {
                _animator.SetTrigger("Opening");
                isOpened = true;
                Invoke("GetCoin",delayTime);
            }
        }
    }

    private void GetCoin()
    {
        Instantiate(diaoluowu, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {   
            canOpen = false;
        }
    }
}
