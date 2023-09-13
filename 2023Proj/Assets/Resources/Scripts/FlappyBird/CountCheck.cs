using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCheck : MonoBehaviour
{
    public Text textCountCheck;
    FlappyBird flappyBird;
    
    void Start()
    {
        GameObject countCheck = GameObject.Find("FlappyBird");
        if (GameManager.Instance.changeScene == 1)
            flappyBird = countCheck.GetComponent<FlappyBird>();
    }

    void Update()
    {
        if (GameManager.Instance.changeScene == 1)
        {
            textCountCheck.text = Mathf.Round(GameManager.Instance.count).ToString();
        }
        if(GameManager.Instance.changeScene == 2)
        {
            textCountCheck.text = Mathf.Round(GameManager.Instance.count).ToString();
        }



    }
}

#region Tip
/*
 * 
 *  다른 오브젝트에 속한 스크립트 함수나 변수를 받아오기 위해서는
 *  일단 그 오브젝트를 찾은 다음에 GetComponent를 해주면 변수를 사용할 수 있다.
 *  if (GameManager.Instance.changeScene == 2)
        {

        }
 *  
 */
#endregion