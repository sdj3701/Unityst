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
    
    IEnumerator 은 return 을해줘야 에러가 안남
    Invoke 실제로는 코루틴을 사용해라 오브젝트 비활성화 
 
 */

#endregion