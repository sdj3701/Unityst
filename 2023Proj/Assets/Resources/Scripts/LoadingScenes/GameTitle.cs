using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoNextScene()
    {
        GameManager.Instance.nextSceneName = "09_NavMeshAgent";
        SceneManager.LoadScene("14_Loading");
    }
}

/*
    던파 포탈에 충돌하면 해당된 씬을 출력해주면 될거갔다


 
 */
