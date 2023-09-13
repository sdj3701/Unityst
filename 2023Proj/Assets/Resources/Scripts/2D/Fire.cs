using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Update()
    {
        Invoke("Death", 3.0f);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }

    
}
