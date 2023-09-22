using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2D : MonoBehaviour
{
    float moveSpeed = 300f;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
