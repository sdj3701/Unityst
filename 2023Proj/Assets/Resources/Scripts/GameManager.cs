using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //���� ������Ű�� ���ؼ� ���
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
        �����͵��� �Ѵ�
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

        //���� �Ѿ�� ������ �Ǵµ� DontDestroyOnLoad�� �����߿����� �������� �ʰڴ�.
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeSecen()
    {
        int sceneIndex = changeScene++ % 2;
        //string sceneName = string.Format("Scene_ {0:2d}", scene); �ȵ�
        SceneManager.LoadScene(sceneIndex);

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string nextSceneName;

}
#region ��Ʈ
/*
 *  �̱��� ���Ҷ� get ����ȭ�� set
 */
#endregion