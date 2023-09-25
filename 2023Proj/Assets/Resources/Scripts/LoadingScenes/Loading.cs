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
        //�ٷ� ����ȭ ���ִ°� �ƴ϶� ������� ���� �ΰ� ��ũ�� ��
        async = SceneManager.LoadSceneAsync(SceneName);
        //�ٷ� ��ȯ�ص� �ٷ� ��ȯ �ϸ� �ȵɼ��� �ֱ� ������
        async.allowSceneActivation = false;

        //if������ �ص� �Ǵµ� ������ �������� ����
        while(async.progress < 0.9f)
        {
            //���������� ������ �ʰڴ�
            yield return true;
        }

        while(async.progress>= 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            //�Ϻη� �����̸� �༭ �ϰ����� ��
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
