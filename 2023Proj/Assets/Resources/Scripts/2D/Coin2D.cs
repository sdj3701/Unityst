using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    public GameObject coinPrefab;
    Rigidbody2D rigidbody;
    float timeInterval = 3;

    IEnumerator Start()
    {
        while (true)
        {

            float yoffset = Random.Range(-200, 200);
            float xoffset = Random.Range(-300, 300);
            Vector3 position = new Vector3(transform.position.x + xoffset, transform.position.y + yoffset, transform.position.z);
            Instantiate(coinPrefab, position, transform.rotation);
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
