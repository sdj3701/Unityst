using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 5.0f;

    IEnumerator Start()
    {
        while (true)
        {
            float ranSpawner = Random.Range(-12, 12);
            float timeInterval = Random.Range(1, interval);
            Vector3 newPos = new Vector3(transform.position.x + ranSpawner, transform.position.y, transform.position.z);
            GameObject newObject = Instantiate(enemyPrefab, newPos, transform.rotation);
            newObject.name = "Enemy";
            yield return new WaitForSeconds(timeInterval);
        }
    }

    void Update()
    {

    }
}
