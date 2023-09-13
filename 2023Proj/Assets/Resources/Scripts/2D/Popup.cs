using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    public Text titletext = null;
    public InputField inputText = null;

    public Toggle toggleBGM = null;

    public GameObject radioGoupObj = null;
    Toggle[] toggleRadio;


    // Start is called before the first frame update
    void Start()
    {
        titletext = GetComponentInChildren<Text>();
        titletext.text = "뷁";

        //여러개의 컴포넌트를 찾기 때문에 ts가 붙음
        toggleRadio = radioGoupObj.GetComponentsInChildren<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClickOK()
    {
        Debug.Log("onClickOK");
        titletext.text = "OK clicked!!";

    }
    void onClickCancel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void onTextChanged()
    {
        titletext.text = inputText.text;
    }

    void onTextEndEdit()
    {
        titletext.text = inputText.text;
    }

    public void onToggleBGM()
    {
        if (toggleBGM.isOn)
        {
            Debug.Log("BGM on!");
        }
        else
        {
            Debug.Log("BGM off!");
        }
    }
    public void onToggleRadio()
    {
        if (toggleRadio == null) return;

        if (toggleRadio[0].isOn)
        {
            Player2D.MaxHP = 1000;
            Player2D.CurrentHP = 1000;
            Player2D.Damage = 1000;

            Debug.Log("1치트");
        }
        else if (toggleRadio[1].isOn)
        {
            Debug.Log("2Sound");
        }
    }


}
