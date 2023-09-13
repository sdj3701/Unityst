using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get 
        {
            if(_instance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                _instance = newGameObject.AddComponent<GameManager>();

            }
            return _instance; 
        } 
    }

    public int changeScene = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeSecen(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
