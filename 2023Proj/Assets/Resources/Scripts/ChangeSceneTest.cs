using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetMouseButton(0))
        {
            GameManager.Instance.ChangeSecen();
        }*/
        if (Input.GetMouseButton(1))
        {
            if(GameManager.Instance.changeScene == 0) 
            {
                GameManager.Instance.ChangeScene("05_FlappyBird");
                GameManager.Instance.changeScene++;
            }
        }
    }

    private void OnGUI()
    {
        if (GameManager.Instance.changeScene == 0)
        {
            if (GUI.Button(new Rect(100, 200, 200, 30), "씬 변경"))
            {
                if (GameManager.Instance.changeScene == 0)
                {
                    GameManager.Instance.ChangeScene("05_FlappyBird");
                    GameManager.Instance.changeScene++;
                }
                else if (GameManager.Instance.changeScene == 2)
                {
                    GameManager.Instance.ChangeScene("03_Collision");
                    GameManager.Instance.changeScene++;
                }
            }
        }
        

        if (GameManager.Instance.changeScene == 2)
        {
            if (GUI.Button(new Rect(100, 200, 200, 30), "ReStart"))
            {
                if (GameManager.Instance.changeScene == 2)
                {
                    GameManager.Instance.ChangeScene("05_FlappyBird");
                    GameManager.Instance.changeScene = 1;
                }
            }
        }


    }

}

#region
/*
 * OnGUI 잘 사용하지 않음 느려서
 */
#endregion