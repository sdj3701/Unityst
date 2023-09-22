using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text coinText;

    void Update()
    {
        coinText.text = Mathf.Round(GameManager.Instance.count).ToString();
    }
}
