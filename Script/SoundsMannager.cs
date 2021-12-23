using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMannager : MonoBehaviour
{
    public static AudioClip pickCoin;
    public static AudioClip throwCoin;

    public static AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPickCoinClip()
    {
        AudioSource.PlayOneShot(pickCoin);
    }
    
    public static void PlayThrowCoinClip()
    {
        AudioSource.PlayOneShot(throwCoin);
    }
}
