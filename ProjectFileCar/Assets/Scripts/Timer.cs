using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public Text timerTxt;
    public float time = 1.0f;
    private float selectCountdown;

    // Start is called before the first frame update
    void Start()
    {
        selectCountdown = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.changeScene == 1)
        {
            if (Mathf.Floor(selectCountdown) <= 0)
            {

            }
            else
            {
                selectCountdown += Time.deltaTime;
                timerTxt.text = Mathf.Floor(selectCountdown).ToString();
            }
        }
        
        if(GameManager.Instance.changeScene == 2)
        {
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
}
