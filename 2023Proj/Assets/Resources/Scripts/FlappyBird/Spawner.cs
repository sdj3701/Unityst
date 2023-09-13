using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject wallPrefab;
    public float interval = 2.0f;
    float min = -2.0f;
    float max = 2.0f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            float posoffset = Random.Range(min, max);
            float timeInterval = Random.Range(1, interval);
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + posoffset, transform.position.z);
            Instantiate(wallPrefab, newPos, transform.rotation);
            yield return new WaitForSeconds(timeInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


#region
/*
    
    IEnumerator �� return ������� ������ �ȳ�
    Invoke �����δ� �ڷ�ƾ�� ����ض� ������Ʈ ��Ȱ��ȭ 
 
 */

#endregion