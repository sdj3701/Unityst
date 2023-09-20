using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swpan : MonoBehaviour
{
    public List<GameObject> childObjects; // Inspector���� ����
    Vector3 ranchilPos;

    public Vector3 Vector3ranchilDir()
    {
        return ranchilPos;
    }
    void Start()
    {
        ActivateRandomChildObject();
    }

    void ActivateRandomChildObject()
    {
        if (childObjects.Count > 0)
        {
            // ��� �ڽ� ������Ʈ ��Ȱ��ȭ
            DeactivateAllChildren();

            // �����ϰ� �ϳ��� �ڽ� ������Ʈ �����Ͽ� Ȱ��ȭ
            int randomIndex = Random.Range(0, childObjects.Count);
            GameObject randomChild = childObjects[randomIndex];
            randomChild.SetActive(true);
            ranchilPos = randomChild.transform.position;
        }
        else
        {
            Debug.LogWarning("No child objects assigned.");
        }
    }

    void DeactivateAllChildren()
    {
        foreach (GameObject child in childObjects)
        {
            child.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(var obj in childObjects)
        {
            if(obj)
            {
                obj.gameObject.SetActive(false);
                ActivateRandomChildObject();
            }
        }
    }
}
