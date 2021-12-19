using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int startCoinNum;

    public Text coinNumText;

    public static int NowCoinNum;
    // Start is called before the first frame update
    void Start()
    {
        NowCoinNum = startCoinNum;
    }

    // Update is called once per frame
    void Update()
    {
        coinNumText.text = NowCoinNum.ToString();
    }
}
