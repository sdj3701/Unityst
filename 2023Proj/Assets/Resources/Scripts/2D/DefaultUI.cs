using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUI : MonoBehaviour
{
    public GameObject popupObj = null;

    void Start()
    {
        if(popupObj)
            popupObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onPopup()
    {
        if (popupObj == null) return;
        if (popupObj.activeSelf)
        {
            popupObj.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            popupObj.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
