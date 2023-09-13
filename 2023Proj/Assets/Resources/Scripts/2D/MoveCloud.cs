using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    float moveSpeed = 300f;

    void Start()
    {
        Invoke("Death", 3.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}
