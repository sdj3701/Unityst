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
 *  �ٸ� ������Ʈ�� ���� ��ũ��Ʈ �Լ��� ������ �޾ƿ��� ���ؼ���
 *  �ϴ� �� ������Ʈ�� ã�� ������ GetComponent�� ���ָ� ������ ����� �� �ִ�.
 *  if (GameManager.Instance.changeScene == 2)
        {

        }
 *  
 */
#endregion