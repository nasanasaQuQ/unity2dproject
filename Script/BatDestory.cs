using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDestory : MonoBehaviour
{
    public int flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EasterEgg.Password += flag.ToString();
    }
    
    
}
