using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChange : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;
    public float time;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {   
            _animator.SetBool("ChangeToWhite",true);
            Invoke("ChangeImage",time);
        }
    }

    void ChangeImage()
    {
        img1.SetActive(false);
        img1.SetActive(true);
    }
}
