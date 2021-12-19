using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject diaImg;

    public Text diaText;

    public string showText;

    private bool _playerIsTouchSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowDialog();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player") 
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _playerIsTouchSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _playerIsTouchSign = false;
            diaImg.SetActive(false);
        }
    }

    private void ShowDialog()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerIsTouchSign)
        {
            diaImg.SetActive(true);
            diaText.text = showText;
        }
    }
    
}
