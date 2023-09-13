using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTime : MonoBehaviour
{
    public float limitTime = 5.0f;
    public Text textTime;

    void Update()
    {

        if (limitTime > 0)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1;
            Death();
        }

        if (Time.timeScale == 0)
        {
            limitTime -= Time.unscaledDeltaTime;
            textTime.text = Mathf.Round(limitTime).ToString();
        }
    }
    
    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}
