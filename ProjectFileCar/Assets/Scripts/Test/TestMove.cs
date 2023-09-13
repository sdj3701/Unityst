using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        float move = 0;
        move += 0.5f;

        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move);
    }

}
