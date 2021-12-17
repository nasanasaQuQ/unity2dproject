using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image flashImage;

    public float flashTime;

    public Color flashColor;

    private Color _defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        _defaultColor = flashImage.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        flashImage.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        flashImage.color = _defaultColor;
    }
    
}
