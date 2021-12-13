using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 简单鲜血粒子特效
 */
public class BloodEffect : MonoBehaviour
{
    public float timeToDeath;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
