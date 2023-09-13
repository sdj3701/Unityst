using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(GameManager.Instance.changeScene == 0)
        {
            if (GUI.Button(new Rect(250, 300, 400, 50), "게임 시작"))
            {
                if (GameManager.Instance.changeScene == 0)
                {
                    GameManager.Instance.changeScene++;
                    GameManager.Instance.ChangeSecen("SampleScene");
                    GameManager.Instance.changeScene++;
                }
            }
        }

        if(GameManager.Instance.changeScene == 2)
        {
            if (GUI.Button(new Rect(250, 300, 400, 50), "재시작"))
            {
                if (GameManager.Instance.changeScene == 2)
                {
                    GameManager.Instance.ChangeSecen("SampleScene");
                    GameManager.Instance.changeScene = 0;
                }
            }
        }
        
    }

}
