using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    AsyncOperation async;

    void Start()
    {
        StartCoroutine(LoadingNextScene(GameManager.Instance.nextSceneName));
    }

    void Update()
    {
        DelayTime();
    }

    IEnumerator LoadingNextScene(string SceneName)
    {
        //바로 동기화 해주는게 아니라 어느정도 텀을 두고 씽크를 함
        async = SceneManager.LoadSceneAsync(SceneName);
        //바로 전환해도 바로 전환 하면 안될수도 있기 때문에
        async.allowSceneActivation = false;

        //if문으로 해도 되는데 오류가 있을수도 있음
        while(async.progress < 0.9f)
        {
            //아직까지는 돌리지 않겠다
            yield return true;
        }

        while(async.progress>= 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            //일부로 딜레이를 줘서 일관성을 줌
            if (delayTime > 2.0f)
                break;
        }

        async.allowSceneActivation = true;
    }

    float delayTime = 0.0f;
    void DelayTime()
    {
        delayTime += Time.deltaTime;
    }



}
