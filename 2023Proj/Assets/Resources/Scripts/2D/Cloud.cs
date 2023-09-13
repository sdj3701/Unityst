using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject coludPrefab;
    Rigidbody2D rigidbody;
    float timeInterval = 1;


    IEnumerator Start()
    {
        while (true)
        {
            float offset = Random.Range(-200, 200);
            Vector3 position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            Instantiate(coludPrefab, position, transform.rotation);
            yield return new WaitForSeconds(timeInterval);
        }
    }
    

}
    
