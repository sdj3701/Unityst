using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinText;
    // Update is called once per frame
    void Update()
    {
        Invoke("Death", 3.0f);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.count += 100;
            Destroy(this.gameObject);
        }
    }

}
