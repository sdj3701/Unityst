using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //값을 유지시키기 위해서 사용
    private static GameManager sInstance;

    public int count = 0;

    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }

            return sInstance;
        }

    }

    public int changeScene = 0;

/*    struct PlayerInfo
    {
        같은것들을 한다
        string useID;
    };*/


    private void Awake()
    {
        if(sInstance != null && sInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sInstance = this;

        //씬이 넘어가면 삭제가 되는데 DontDestroyOnLoad는 실행중에서는 삭제하지 않겠다.
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeSecen()
    {
        int sceneIndex = changeScene++ % 2;
        //string sceneName = string.Format("Scene_ {0:2d}", scene); 안됨
        SceneManager.LoadScene(sceneIndex);

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string nextSceneName;

}
#region 노트
/*
 *  싱글톤 비교할때 get 값변화는 set
 */
#endregion