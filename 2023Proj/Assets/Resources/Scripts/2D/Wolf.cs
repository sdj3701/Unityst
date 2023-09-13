using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public GameObject wolfPrefab;
    Rigidbody2D rigidbody;
    float timeInterval = 3;

    IEnumerator Start()
    {
        while (true)
        {
            float offset = Random.Range(-200, 200);
            Vector3 position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            Instantiate(wolfPrefab, position, transform.rotation);
            yield return new WaitForSeconds(timeInterval);
        }
    }

    
}
